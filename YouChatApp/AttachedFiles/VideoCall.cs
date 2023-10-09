using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Management;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;

namespace YouChatApp.AttachedFiles
{
    public partial class VideoCall : Form
    {
        bool CameraIsOpen = false;
        Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;
        Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;
        Image VideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile; //need to change that to my profile picture...

        // https://www.flaticon.com/search?author_id=1828&style_id=1236&type=standard&word=conversation

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private List<WaveInCapabilities> inputDevices;
        private List<WaveOutCapabilities> outputDevices;
        private WaveInEvent waveIn;

        private ManagementEventWatcher watcher;
        int CurrentWidth;
        int CurrentHeight;
        int CameraWidth;
        int CameraHeight;
        private bool isResizing = false;

        public VideoCall()
        {
            InitializeComponent();
            //string username = "yuval"; //the user that i try to call to...
            //ServerCommunication.SendMessage(ServerCommunication.UserConnectionCheckRequest,username);
        }

        private void VideoCall_Load(object sender, EventArgs e)
        {
            InitializeCameraList(); // Load the initial camera devices when the form loads.
            InitializeCameraChangeDetection(); // Start monitoring camera changes.
            InitializeAudioList();
            CurrentWidth = this.Width;
            CurrentHeight = this.Height;
            //videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //if (videoDevices.Count == 0)
            //{
            //    MessageBox.Show("No video devices found.");
            //    return;
            //}
            //else
            //{
            //    foreach (FilterInfo device in videoDevices)
            //    {
            //        CameraDeviceComboBox.Items.Add(device.Name);
            //    }
            //}

            //videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            //videoSource.Start();
        }
        private void InitializeAudioList()
        {
            inputDevices = new List<WaveInCapabilities>();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                inputDevices.Add(WaveIn.GetCapabilities(i));
            }
            foreach (WaveInCapabilities device in inputDevices)
            {
                AudioInputDeviceComboBox.Items.Add(device.ProductName);
            }
            // Enumerate available output devices (speakers)
            outputDevices = new List<WaveOutCapabilities>();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                outputDevices.Add(WaveOut.GetCapabilities(i));
            }
            foreach (WaveOutCapabilities device in outputDevices)
            {
                AudioOutputDeviceComboBox.Items.Add(device.ProductName);
            }
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
        private void RemoteVideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            RemoteVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();
        }
        private void StartVideoSource()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                //isResizing = true;
                //var resolution = videoSource.VideoResolution;
                //CameraWidth = resolution.FrameSize.Width;
                //CameraHeight = resolution.FrameSize.Height;
                //CurrentWidth = CameraWidth;
                //CurrentHeight = CameraHeight;
                //UserVideoPictureBox.Size = new Size(CurrentWidth, CurrentHeight);
                //isResizing = false;
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
            watcher.EventArrived += new EventArrivedEventHandler(HandleAudioDeviceChange);

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
        private void RefreshAudioList()
        {
            InitializeAudioList(); // Refresh the camera list.
        }


        private void StartStreaming()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
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
            RemoteVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();

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

        private void AudioDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VideoCall_FormClosing(object sender, FormClosingEventArgs e)
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

        private void VideoPictureBox_SizeChanged(object sender, EventArgs e)
        {
            //if (isResizing)
            //{
            //    return;
            //}
            //int newWidth;
            //int newHeight;
            //isResizing = true;
            //if (this.Width != CurrentWidth)
            //{
            //    newWidth = VideoPictureBox.Width;
            //    newHeight = (int)(newWidth * (CameraHeight / (double)CameraWidth));
            //    VideoPictureBox.Height = newHeight;
            //}
            //else
            //{
            //    newHeight = VideoPictureBox.Height;
            //    newWidth = (int)(newHeight * (CameraWidth / (double)CameraHeight));
            //    VideoPictureBox.Height = newHeight;
            //}
            //CurrentWidth = newWidth;
            //CurrentHeight = newHeight;
            //isResizing = false;

        }

    }

}
