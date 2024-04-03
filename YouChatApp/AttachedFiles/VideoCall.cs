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
        /// <summary>
        /// Gets or sets a value indicating whether the microphone is muted.
        /// </summary>
        private bool isMyMicrophoneMuted;

        /// <summary>
        /// The watcher for management events. Used for updating the input and output audio devices connected to the computer.
        /// </summary>
        private ManagementEventWatcher watcher;

        /// <summary>
        /// The DirectSoundOut instance for audio playback. Used for playing the received audio.
        /// </summary>
        public DirectSoundOut audioWaveOut;

        /// <summary>
        /// The BufferedWaveProvider for audio playback. Responsible for converting the byte array of audio to playable audio through the WaveOut.
        /// </summary>
        private BufferedWaveProvider audioBufferedWaveProvider;

        /// <summary>
        /// The WaveIn instance for audio capture. Responsible for recording audio.
        /// </summary>
        private WaveIn audioSourceStream;

        /// <summary>
        /// The list of output audio device GUIDs.
        /// </summary>
        private List<Guid> outputAudioDeviceGuids;


        bool CameraIsOpen = false;
        Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;
        Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;
        Image MicrophoneNotOpen = global::YouChatApp.Properties.Resources.MicrophoneClose;
        Image MicrophoneOpen = global::YouChatApp.Properties.Resources.MicrophoneOpen;
        Image VideoOffImage;
        Image FriendVideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile; //need to change that to my profile picture...
        Image MyVideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile; //need to change that to my profile picture...

        Image FriendMicrophoneOffImage = global::YouChatApp.Properties.Resources.FriendMicrophoneClosed;

        private DateTime callStartTime;
        private double zoomFactor; // Adjust this to your desired zoom factor

        private bool _myVideoIsSmall = true;
        // https://www.flaticon.com/search?author_id=1828&style_id=1236&type=standard&word=conversation

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
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
        private bool isFriendMicrophoneMuted;

        CallTimer timer;
        public VideoCall(string name, Image profilePicture)
        {
            InitializeComponent();
            VideoOffImage = ProfileDetailsHandler.ProfilePicture;
            isMyMicrophoneMuted = false;
            CallEnderCustomButton.BorderRadius = 40;
            _friendName = name;
            FriendNameLabel.Text = name;
            FriendVideoOffImage = profilePicture;
            RemoteVideoPictureBox.BackgroundImage = profilePicture;
            //MyVideoOffImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            MyVideoOffImage = profilePicture;

            UserVideoPictureBox.BackgroundImage = MyVideoOffImage;
            //string username = "yuval"; //the user that i try to call to...
            //ServerCommunication.SendMessage(ServerCommunication.UserConnectionCheckRequest,username);
        }

        private void VideoCall_Load(object sender, EventArgs e)
        {
            VideoServerCommunication.ConnectUdp("10.100.102.3", this);
            AudioServerCommunication.ConnectUdp("10.100.102.3", this);
            InitializeCameraList(); // Load the initial camera devices when the form loads.
            WaveFormat waveFormat = new WaveFormat(44100, 16, 2);
            audioBufferedWaveProvider = new BufferedWaveProvider(waveFormat);
            outputAudioDeviceGuids = new List<Guid>();

            audioBufferedWaveProvider.DiscardOnBufferOverflow = true;
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
            AudioHandler.AudioHandler.StartAudioRecording(AudioInputDeviceComboBox, ref audioSourceStream, sourceStream_DataAvailable);
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            InitializeVideoAndAudioChangeDetection(); // Start monitoring camera changes.            InitializeVideoAndAudioChangeDetection(); // Start monitoring camera changes.
            CurrentWidth = this.Width;
            CurrentHeight = this.Height;


            //_friendName = ChatHandler.ChatManager.CurrentChatName;
            FriendNameLabel.Text = _friendName;
            FriendNameLabel.Location = new Point((CallDetailsPanel.Width - FriendNameLabel.Width) /2, FriendNameLabel.Location.Y);
            CallTimeLabel.Location = new Point((CallDetailsPanel.Width - CallTimeLabel.Width) / 2, CallTimeLabel.Location.Y);

            _videoToolTipContent = "Your Video";
            _friendVideoToolTipContent = _friendName + "'s Video";
            ToolTip.SetToolTip(UserVideoPictureBox, _videoToolTipContent);
            ToolTip.SetToolTip(RemoteVideoPictureBox, _friendVideoToolTipContent);
            CallEnderCustomButton.BorderRadius = 40;
            timer = new CallTimer(CallTimeTimer);
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
            //where to put it:
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

        private void InitializeVideoAndAudioChangeDetection()
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
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
        }
        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            AudioHandler.AudioHandler.HandleSourceStreamDataAvailable(e, audioSourceStream, isMyMicrophoneMuted);
        }
        public void ReceiveAudioData(byte[] receivedData)
        {
            AudioHandler.AudioHandler.HandleReceivedAudioData(receivedData, audioWaveOut, audioBufferedWaveProvider);
        }
        private void HandleWaveOut()
        {
            AudioHandler.AudioHandler.HandleWaveOutPhaseOne(audioWaveOut);


            int selectedDeviceIndex = AudioOutputDeviceComboBox.SelectedIndex;
            audioWaveOut = new DirectSoundOut(outputAudioDeviceGuids[selectedDeviceIndex]); //to add here -1 if deleting computer main

            AudioHandler.AudioHandler.HandleWaveOutPhaseTwo(audioWaveOut, audioBufferedWaveProvider);

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
                VideoServerCommunication.SendVideo(imageBytes);
                //udpClient.Send(imageBytes, imageBytes.Length, endPoint);
            }
            Image currentVideoFrame = (System.Drawing.Image)eventArgs.Frame.Clone();
            using (Graphics graphics = Graphics.FromImage(currentVideoFrame)) //this will be used for the friends vide and mot here for my own...
            {
                // Draw the video frame on the context
                graphics.DrawImage(currentVideoFrame, 0, 0, currentVideoFrame.Width, currentVideoFrame.Height);

                // Draw the overlay image on the context
                graphics.DrawImage(FriendMicrophoneOffImage, 0, 0,50,50); // todo - to handle the case when my camera hides the microphone symbol - can do it by simply using if and setting the symbol on the button right corner...
            }
            int videoPictureBoxWidth;
            if (_myVideoIsSmall)
            {
                UserVideoPictureBox.Image = currentVideoFrame;
                videoPictureBoxWidth = UserVideoPictureBox.Width;
            }
            else
            {
                RemoteVideoPictureBox.Image = currentVideoFrame;
                videoPictureBoxWidth = RemoteVideoPictureBox.Width;

            }
            //zoomFactor = currentVideoFrame.Width / videoPictureBoxWidth;
            //DisplayCroppedBackground(currentVideoFrame);
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


        private void AudioInputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleAudioInputDeviceComboBoxSelectedIndexChanged(audioSourceStream, AudioInputDeviceComboBox);
        }

        private void AudioOutputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleWaveOut();
        }

        private void MicrophoneModeCustomButton_Click(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleMicrophoneModeCustomButtonClick(ref audioSourceStream, ref isMyMicrophoneMuted, MicrophoneModeCustomButton, AudioInputDeviceComboBox, sourceStream_DataAvailable);
        }



        private void VideoCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleFormClosing();
        }
        private void HandleFormClosing()
        {
            AudioHandler.AudioHandler.HandleFormClosing(audioSourceStream, audioWaveOut, watcher);
            VideoServerCommunication.Close();

            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            timer.StopTimer();
            //send message to other user that call is over..
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
            HandleDoubleClick();
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

        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleFormClosing();
            this.Close();
        }

        private void RemoteVideoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            HandleDoubleClick();
        }
        private void HandleDoubleClick()
        {
            _myVideoIsSmall = !_myVideoIsSmall;
            if (_myVideoIsSmall)
            {
                ToolTip.SetToolTip(UserVideoPictureBox, _videoToolTipContent);
                ToolTip.SetToolTip(RemoteVideoPictureBox, _friendVideoToolTipContent);
                //FriendClosedMicrophonePictureBox.Location = new Point(RemoteVideoPictureBox.Location.X + 1, RemoteVideoPictureBox.Location.Y + 1);
            }
            else
            {
                ToolTip.SetToolTip(UserVideoPictureBox, _friendVideoToolTipContent);
                ToolTip.SetToolTip(RemoteVideoPictureBox, _videoToolTipContent);
                //FriendClosedMicrophonePictureBox.Location = new Point(UserVideoPictureBox.Location.X + 1, UserVideoPictureBox.Location.Y + 1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CallTimeTimer_Tick(object sender, EventArgs e)
        {
            timer.HandleTimerTick(CallTimeLabel);
            //TimeSpan callDuration = DateTime.Now - callStartTime;

            //string formattedDuration = string.Empty;

            //if (callDuration.Hours > 0)
            //{
            //    formattedDuration = $"{callDuration.Hours:D2}:{callDuration.Minutes:D2}:{callDuration.Seconds:D2}";
            //}
            //else
            //{
            //    formattedDuration = $"{callDuration.Minutes:D2}:{callDuration.Seconds:D2}";
            //}

            //CallTimeLabel.Text = formattedDuration;
            CallTimeLabel.Location = new Point((CallDetailsPanel.Width - CallTimeLabel.Width) / 2, CallTimeLabel.Location.Y);
        }

        private void RefreshAudioOptionsCustomButtons_Click(object sender, EventArgs e)
        {
            RefreshAudioList();
        }
        private void DisplayCroppedBackground(Image capturedFrame)
        {
            ////should replace the code downward with this:


            ////// Ensure that the cropping region is within the bounds of the image
            ////cropX = Math.Max(0, cropX);
            ////cropY = Math.Max(0, cropY);
            ////cropWidth = Math.Min(capturedFrame.Width - cropX, cropWidth);
            ////cropHeight = Math.Min(capturedFrame.Height - cropY, cropHeight);

            ////// Create a cropped image
            ////Bitmap croppedImage = new Bitmap(cropWidth, cropHeight);
            ////using (Graphics g = Graphics.FromImage(croppedImage))
            ////{
            ////    g.DrawImage(capturedFrame, new Rectangle(0, 0, cropWidth, cropHeight), new Rectangle(cropX, cropY, cropWidth, cropHeight), GraphicsUnit.Pixel);
            ////}




            //// Load the captured frame
            ////Point location = this.PointToClient(FriendClosedMicrophonePictureBox.Location);
            ////Point pictureBoxLocation = FriendClosedMicrophonePictureBox.PointToScreen(Point.Empty);
            ////Point realPictureBoxLocation = this.PointToClient(pictureBoxLocation);
            //Point pictureBoxLocationOnForm = new Point(VideoPanel.Location.X + FriendClosedMicrophonePictureBox.Location.X, VideoPanel.Location.Y + FriendClosedMicrophonePictureBox.Location.Y);
            //int cropX = (int)(pictureBoxLocationOnForm.X);
            //int cropY = (int)(pictureBoxLocationOnForm.Y);
            //int cropWidth = (int)(FriendClosedMicrophonePictureBox.Width * zoomFactor);
            //int cropHeight = (int)(FriendClosedMicrophonePictureBox.Height * zoomFactor);
            //cropX = Math.Max(0, cropX);
            //cropY = Math.Max(0, cropY);
            //cropWidth = Math.Min(capturedFrame.Width - cropX, cropWidth);
            //cropHeight = Math.Min(capturedFrame.Height - cropY, cropHeight);

            //// Define the cropping region (adjust coordinates and size as needed)
            ////Rectangle cropRegion = new Rectangle(pictureBoxLocationOnForm.X, pictureBoxLocationOnForm.Y, FriendClosedMicrophonePictureBox.Width, FriendClosedMicrophonePictureBox.Height);

            //// Crop the specific region from the captured frame
            //Bitmap croppedImage = new Bitmap(cropWidth, cropHeight);
            //using (Graphics g = Graphics.FromImage(croppedImage))
            //{
            //    g.DrawImage(capturedFrame, new Rectangle(0, 0, cropWidth, cropHeight), new Rectangle(cropX, cropY, cropWidth, cropHeight), GraphicsUnit.Pixel);
            //}

            //// Set the cropped image as the background
            //FriendClosedMicrophonePictureBox.BackgroundImage = croppedImage;

            //// Dispose of the original captured frame
            //capturedFrame.Dispose();
        }

        private void CameraDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
