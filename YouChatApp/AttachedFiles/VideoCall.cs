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
using System.Diagnostics.Tracing;
using YouChatApp.UserProfile;

namespace YouChatApp.AttachedFiles
{
    public partial class VideoCall : Form
    {
        bool CameraIsOpen = false;
        Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;
        Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;
        Image VideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile; //need to change that to my profile picture...
        private bool _myVideoIsSmall = true;
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

        private bool _isDragging = false;
        private Point _lastMousePosition;

        private string _friendName;
        private string _videoToolTipContent;
        private string _friendVideoToolTipContent;
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
            VideoAndAudioServerCommunication.ConnectUdp("10.100.102.3",this);
            _friendName = ChatHandler.ChatManager.CurrentChatName;
            _videoToolTipContent = "Your Video";
            _friendVideoToolTipContent = _friendName + "'s Video";
            ToolTip.SetToolTip(UserVideoPictureBox, _videoToolTipContent);
            ToolTip.SetToolTip(RemoteVideoPictureBox, _friendVideoToolTipContent);

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
                if (_myVideoIsSmall)
                {
                    UserVideoPictureBox.Image = VideoOffImage;
                }
                else
                {
                    RemoteVideoPictureBox.Image = VideoOffImage;

                }
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
            BeginInvoke(new Action(RefreshAudioList));
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
                VideoAndAudioServerCommunication.SendBytes(imageBytes);
                //udpClient.Send(imageBytes, imageBytes.Length, endPoint);
            }
            if (_myVideoIsSmall)
            {
                UserVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();
            }
            else
            {
                RemoteVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();
            }

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

        private void UserVideoPictureBox_Click(object sender, EventArgs e)
        {
        }

        private void UserVideoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePosition = e.Location;
            }
        }

        private void UserVideoPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //if (_isDragging)
            //{

            //    UserVideoPictureBox.Left = e.X + UserVideoPictureBox.Left - _lastMousePosition.X;
            //    UserVideoPictureBox.Top = e.Y + UserVideoPictureBox.Top - _lastMousePosition.Y;
            //    if (RemoteVideoPictureBox != null && UserVideoPictureBox.Bounds.IntersectsWith(RemoteVideoPictureBox.Bounds))
            //    {
            //        // Determine which side the UserVideoPictureBox should snap to
            //        int centerX = RemoteVideoPictureBox.Left + RemoteVideoPictureBox.Width / 2;
            //        int centerY = RemoteVideoPictureBox.Top + RemoteVideoPictureBox.Height / 2;

            //        if (e.X < centerX)
            //        {
            //            // Snap to the left side
            //            UserVideoPictureBox.Left = RemoteVideoPictureBox.Left - UserVideoPictureBox.Width;
            //        }
            //        else
            //        {
            //            // Snap to the right side
            //            UserVideoPictureBox.Left = RemoteVideoPictureBox.Right;
            //        }
            //    }
            //}
            //if (_isDragging)
            //{
            //    UserVideoPictureBox.Left = e.X + UserVideoPictureBox.Left - _lastMousePosition.X;
            //    UserVideoPictureBox.Top = e.Y + UserVideoPictureBox.Top - _lastMousePosition.Y;

            //    // Check for containment within the boundaries of the target PictureBox (e.g., TargetPictureBox)
            //    PictureBox targetPictureBox = RemoteVideoPictureBox; // Replace with the actual name of your target PictureBox
            //    if (targetPictureBox != null)
            //    {
            //        if (UserVideoPictureBox.Left < targetPictureBox.Left)
            //        {
            //            UserVideoPictureBox.Left = targetPictureBox.Left;
            //        }
            //        if (UserVideoPictureBox.Top < targetPictureBox.Top)
            //        {
            //            UserVideoPictureBox.Top = targetPictureBox.Top;
            //        }
            //        if (UserVideoPictureBox.Right > targetPictureBox.Right)
            //        {
            //            UserVideoPictureBox.Left = targetPictureBox.Right - UserVideoPictureBox.Width;
            //        }
            //        if (UserVideoPictureBox.Bottom > targetPictureBox.Bottom)
            //        {
            //            UserVideoPictureBox.Top = targetPictureBox.Bottom - UserVideoPictureBox.Height;
            //        }
            //    }
            //}
            if (_isDragging)
            {
                // Calculate the new position without moving it immediately
                int newLeft = e.X + UserVideoPictureBox.Left - _lastMousePosition.X;
                int newTop = e.Y + UserVideoPictureBox.Top - _lastMousePosition.Y;

                // Check for containment within the boundaries of the target PictureBox (e.g., TargetPictureBox)
                PictureBox targetPictureBox = RemoteVideoPictureBox; // Replace with the actual name of your target PictureBox
                if (targetPictureBox != null)
                {
                    if (newLeft < targetPictureBox.Left)
                    {
                        newLeft = targetPictureBox.Left;
                    }
                    if (newTop < targetPictureBox.Top)
                    {
                        newTop = targetPictureBox.Top;
                    }
                    if (newLeft + UserVideoPictureBox.Width > targetPictureBox.Right)
                    {
                        newLeft = targetPictureBox.Right - UserVideoPictureBox.Width;
                    }
                    if (newTop + UserVideoPictureBox.Height > targetPictureBox.Bottom)
                    {
                        newTop = targetPictureBox.Bottom - UserVideoPictureBox.Height;
                    }
                }

                // Update the PictureBox location only if it's within bounds
                UserVideoPictureBox.Left = newLeft;
                UserVideoPictureBox.Top = newTop;
            }
        }

        private void UserVideoPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }

        private void UserVideoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            _myVideoIsSmall = !_myVideoIsSmall;
            if (_myVideoIsSmall)
            {
                ToolTip.SetToolTip(UserVideoPictureBox, _videoToolTipContent);
                ToolTip.SetToolTip(RemoteVideoPictureBox, _friendVideoToolTipContent);
            }
            else
            {
                ToolTip.SetToolTip(UserVideoPictureBox, _friendVideoToolTipContent);
                ToolTip.SetToolTip(RemoteVideoPictureBox, _videoToolTipContent);
            }

        }

        private void RefreshCameraOptionsCustomButton_Click(object sender, EventArgs e)
        {
            RefreshCameraList();
        }



        public void HandleReceivedImage(Image receivedImage)
        {

            if (_myVideoIsSmall)
            {
                RemoteVideoPictureBox.Image = receivedImage;
            }
            else
            {
                UserVideoPictureBox.Image = receivedImage;
            }
        }
    }

}
