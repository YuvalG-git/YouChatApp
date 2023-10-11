﻿using AForge.Video.DirectShow;
using AForge.Video;
//using AForge.Video.FFMPEG;

using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Tracing;

namespace YouChatApp.AttachedFiles
{
    public partial class Camera : Form
    {
        bool CameraIsOpen = false;
        Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;
        Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;
        Image VideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile; //need to change that to my profile picture...
        bool _isImageTaken = false;
        public Image ImageToSend { get; set; }
        // https://www.flaticon.com/search?author_id=1828&style_id=1236&type=standard&word=conversation

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private int waitingTime = 0;

        private ManagementEventWatcher watcher;
        int CurrentWidth;
        int CurrentHeight;
        int CameraWidth;
        int CameraHeight;
        private bool isResizing = false;
        public Camera()
        {
            InitializeComponent();
            TimerOptionComboBox.SelectedIndex = 0;
        }



        private void InitializeCameraList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }
            else
            {
                CameraDeviceComboBox.Items.Clear(); // Clear existing items.

                foreach (FilterInfo device in videoDevices)
                {
                    CameraDeviceComboBox.Items.Add(device.Name);
                }

                // Select the first device by default.
                CameraDeviceComboBox.SelectedIndex = 0;
            }

            // Start the video source with the selected camera.
            StartVideoSource();

        }
        private void StartVideoSource()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            videoSource = new VideoCaptureDevice(videoDevices[CameraDeviceComboBox.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);

            if (CameraIsOpen)
            {
                videoSource.Start();
            }
            else
            {
                UserVideoPictureBox.Image = VideoOffImage;
            }
        }

        private void InitializeCameraChangeDetection()
        {
            // Create a management event watcher to monitor hardware changes.
            watcher = new ManagementEventWatcher();
            watcher.EventArrived += new EventArrivedEventHandler(HandleVideoDeviceChange);

            // Set up a query to listen for device arrival and device removal events.
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            watcher.Query = query;

            // Start listening for hardware changes.
            watcher.Start();
        }
        private void HandleVideoDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshCameraList));
        }
        private void HandleAudioDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshCameraList));
        }
        private void RefreshCameraList()
        {
            InitializeCameraList(); // Refresh the camera list.
        }


        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Convert the video frame to an image (e.g., JPEG)
            using (var stream = new MemoryStream())
            {
                eventArgs.Frame.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = stream.ToArray();

                // Send the image over UDP
                //udpClient.Send(imageBytes, imageBytes.Length, endPoint);
            }
            UserVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();
        }

        private void CameraModeCustomButton_Click(object sender, EventArgs e)
        {
            if (CameraIsOpen == false)
                CameraIsOpen = true;
            else
                CameraIsOpen = false;
            if (CameraIsOpen == true)
            {
                CameraModeCustomButton.BackgroundImage = CameraNotOpen;
            }
            else
            {
                CameraModeCustomButton.BackgroundImage = CameraOpen;
            }
            StartVideoSource();
        }



        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }


            // Stop monitoring hardware changes.
            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            InitializeCameraList(); // Load the initial camera devices when the form loads.
            InitializeCameraChangeDetection(); // Start monitoring camera changes.
            CurrentWidth = this.Width;
            CurrentHeight = this.Height;
        }

        private void ImageTakerCustomButton_Click(object sender, EventArgs e)
        {
            if (CameraIsOpen)
            {
                if (waitingTime == 0)
                {
                    SetImage();
                }
                else
                {
                    _isImageTaken = false;
                    SaveImageCustomButton.Enabled = false;

                    CountDownTimeSpan = TimeSpan.FromSeconds(waitingTime);
                    TimerTickTimeSpan = TimeSpan.FromMilliseconds(Timer.Interval);
                    UserImageTakenPictureBox.Image = CountDownImageList._CountDownImageList.Images[(int)CountDownTimeSpan.TotalSeconds - 1];

                    Timer.Start();
                }
            }
        }
        private void SetImage()
        {
            if (UserVideoPictureBox.Image != null)
            {
                Bitmap capturedImage = (Bitmap)UserVideoPictureBox.Image.Clone();

                UserImageTakenPictureBox.Image = capturedImage;
                _isImageTaken = true;
                SaveImageCustomButton.Enabled = true;
                //// Create a unique filename for the saved image (e.g., using a timestamp)
                //string fileName = $"captured_image_{DateTime.Now:yyyyMMddHHmmss}.jpg";

                //// Save the captured image to disk
                //capturedImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                //MessageBox.Show($"Image saved as {fileName}");
            }
            else
            {
                MessageBox.Show("No image to capture.");
            }
        }

        private void TimerOptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TimerOptionComboBox.SelectedIndex == 0)
            {
                waitingTime = 0;
            }
            else if (TimerOptionComboBox.SelectedIndex <= 3)
            {
                string TimerComboBoxContent = TimerOptionComboBox.Text;
                TimerComboBoxContent = TimerComboBoxContent.Substring(0, TimerComboBoxContent.Length - 8);
                int Time = int.Parse(TimerComboBoxContent);
                waitingTime = Time;
            }
        }
        private int lastValidTime;

        private void TimerOptionComboBox_TextChanged(object sender, EventArgs e)
        {
            //if (TimerOptionComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            //{
            //    if (TimerOptionComboBox.Text.)
            //}
            //else
            //{
            //    if (TimerOptionComboBox.SelectedIndex == 4)
            //    {
            //        TimerOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            //    }
            //    else
            //    {
            //        TimerOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //        if (TimerOptionComboBox.SelectedIndex == 0)
            //        {
            //            waitingTime = 0;
            //        }
            //        else if (TimerOptionComboBox.SelectedIndex <= 3)
            //        {
            //            string TimerComboBoxContent = TimerOptionComboBox.Text;
            //            TimerComboBoxContent = TimerComboBoxContent.Substring(0, TimerComboBoxContent.Length - 8);
            //            int Time = int.Parse(TimerComboBoxContent);
            //            waitingTime = Time;
            //        }
            //    }
            //}

        }
        TimeSpan TimerTickTimeSpan;
        TimeSpan CountDownTimeSpan;

        private void Timer_Tick(object sender, EventArgs e)
        {
            CountDownTimeSpan -= TimerTickTimeSpan;
            if (CountDownTimeSpan.TotalMilliseconds <= 0)
            {
                Timer.Stop();
                SetImage();


            }
            else
            {
                UserImageTakenPictureBox.Image = CountDownImageList._CountDownImageList.Images[(int)CountDownTimeSpan.TotalSeconds-1];
                WaitingTimeLabel.Text = $"{CountDownTimeSpan:ss}";
            }
        }

        private void SaveImageCustomButton_Click(object sender, EventArgs e)
        {
            ImageToSend = UserImageTakenPictureBox.Image;
            //needs to close if it was for group image otherwise not..
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
