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
using Newtonsoft.Json;
using YouChatApp.JsonClasses;
using YouChatApp.AttachedFiles.CallHandler;

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

        private readonly ServerCommunicator serverCommunicator;

        private string chatId;
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
        private bool isAbleToSend = false;
        CallTimer timer;
        private bool wasOrderedToClose;
        private bool isFriendCameraOn = false;
        public VideoCall(string chatId, string name, Image profilePicture)
        {
            InitializeComponent();
            VideoOffImage = ProfileDetailsHandler.ProfilePicture;
            isMyMicrophoneMuted = false;
            CallEnderCustomButton.BorderRadius = 40;
            this.chatId = chatId;
            _friendName = name;
            FriendNameLabel.Text = name;
            FriendVideoOffImage = profilePicture;
            RemoteVideoPictureBox.Image = profilePicture;
            //MyVideoOffImage = UserProfile.ProfileDetailsHandler.ProfilePicture;
            MyVideoOffImage = VideoOffImage;
            wasOrderedToClose = false;
            UserVideoPictureBox.Image = VideoOffImage;

            serverCommunicator = ServerCommunicator.Instance;
            //string username = "yuval"; //the user that i try to call to...
            //ServerCommunication.SendMessage(ServerCommunication.UserConnectionCheckRequest,username);

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
            FriendNameLabel.Location = new Point((CallDetailsPanel.Width - FriendNameLabel.Width) / 2, FriendNameLabel.Location.Y);
            CallTimeLabel.Location = new Point((CallDetailsPanel.Width - CallTimeLabel.Width) / 2, CallTimeLabel.Location.Y);

            _videoToolTipContent = "Your Video";
            _friendVideoToolTipContent = _friendName + "'s Video";
            ToolTip.SetToolTip(UserVideoPictureBox, _videoToolTipContent);
            ToolTip.SetToolTip(RemoteVideoPictureBox, _friendVideoToolTipContent);
            CallEnderCustomButton.BorderRadius = 40;
            timer = new CallTimer(CallTimeTimer);
        }
        public void SetIsAbleToSendToTrue()
        {
            isAbleToSend = true;
        }

        private void VideoCall_Load(object sender, EventArgs e)
        {
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
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
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
            if (isAbleToSend)
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


        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (isAbleToSend)
            {
                using (var stream = new MemoryStream())
                {
                    eventArgs.Frame.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = stream.ToArray();

                    // Send the image over UDP
                    VideoServerCommunication.SendVideo(imageBytes);
                }
                Image currentVideoFrame = (System.Drawing.Image)eventArgs.Frame.Clone();
                if (_myVideoIsSmall)
                {
                    UserVideoPictureBox.Image = currentVideoFrame;
                }
                else
                {
                    RemoteVideoPictureBox.Image = currentVideoFrame;
                }
            }
        }

        private void CameraModeCustomButton_Click(object sender, EventArgs e)
        {
            EnumHandler.CommunicationMessageID_Enum CameraModeEnum;
            if (CameraIsOpen == false)
                CameraIsOpen = true;
            else
                CameraIsOpen = false;
            if (CameraIsOpen == true)
            {
                CameraModeCustomButton.BackgroundImage = CameraNotOpen;
                CameraModeEnum = EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOnRequest;
            }
            else
            {
                CameraModeCustomButton.BackgroundImage = CameraOpen;
                CameraModeEnum = EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOffRequest;
                if (_myVideoIsSmall)
                {
                    UserVideoPictureBox.Image = MyVideoOffImage;
                }
                else
                {
                    RemoteVideoPictureBox.Image = MyVideoOffImage;
                }

            }
            StartVideoSource();
            JsonObject videoCallCameraSetUpJsonObject = new JsonObject(CameraModeEnum, chatId);
            string videoCallCameraSetUpJson = JsonConvert.SerializeObject(videoCallCameraSetUpJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(videoCallCameraSetUpJson);
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
            EnumHandler.CommunicationMessageID_Enum MuteStateEnum;
            if (isMyMicrophoneMuted)
            {
                MuteStateEnum = EnumHandler.CommunicationMessageID_Enum.VideoCallMuteRequest;
            }
            else
            {
                MuteStateEnum = EnumHandler.CommunicationMessageID_Enum.VideoCallUnmuteRequest;

            }
            JsonObject muteStateJsonObject = new JsonObject(MuteStateEnum, chatId);
            string muteStateJson = JsonConvert.SerializeObject(muteStateJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(muteStateJson);
        }



        private void VideoCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleFormClosing();
        }
        private void HandleFormClosing()
        {
            if (!wasOrderedToClose)
            {
                VideoCallOverDetails videoCallOverDetails = new VideoCallOverDetails(chatId, AudioServerCommunication.GetLocalPort(), VideoServerCommunication.GetLocalPort());
                JsonObject endVideoCallRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.EndVideoCallRequest, videoCallOverDetails);
                string endVideoCallRequestJson = JsonConvert.SerializeObject(endVideoCallRequestJsonObject, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                serverCommunicator.SendMessage(endVideoCallRequestJson);
                CloseForm();
            }
        }
        private void CloseForm()
        {
            if (FormHandler._youChat != null)
            {
                this.Invoke(new Action(() => FormHandler._youChat.Show()));
            }
            AudioHandler.AudioHandler.HandleFormClosing(audioSourceStream, audioWaveOut, watcher);
            VideoServerCommunication.Close();

            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            timer.StopTimer();
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
            if (isFriendCameraOn)
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
            else
            {
                if (_myVideoIsSmall)
                {
                    RemoteVideoPictureBox.Image = FriendVideoOffImage;
                }
                else
                {
                    UserVideoPictureBox.Image = FriendVideoOffImage;
                }
            }

        }

        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleFormClosing();
            wasOrderedToClose = true;
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
                if (!CameraIsOpen)
                {
                    UserVideoPictureBox.Image = MyVideoOffImage;
                }
                if (!isFriendCameraOn)
                {
                    RemoteVideoPictureBox.Image = FriendVideoOffImage;
                }
                //UserVideoPictureBox.BackgroundImage = MyVideoOffImage;
                //RemoteVideoPictureBox.BackgroundImage = FriendVideoOffImage;

            }
            else
            {
                ToolTip.SetToolTip(UserVideoPictureBox, _friendVideoToolTipContent);
                ToolTip.SetToolTip(RemoteVideoPictureBox, _videoToolTipContent);
                if (!CameraIsOpen)
                {
                    RemoteVideoPictureBox.Image = MyVideoOffImage;
                }
                if (!isFriendCameraOn)
                {
                    UserVideoPictureBox.Image = FriendVideoOffImage;
                }
                //UserVideoPictureBox.BackgroundImage = FriendVideoOffImage;
                //RemoteVideoPictureBox.BackgroundImage = MyVideoOffImage;
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
      

        private void CameraDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void HandleMute()
        {
            isFriendMicrophoneMuted = false;
        }
        public void HandleUnmute()
        {
            isFriendMicrophoneMuted = true;
        }
        public void HandleCameraOn()
        {
            //if (_myVideoIsSmall)
            //{
            //    UserVideoPictureBox.Image = FriendVideoOffImage;
            //}
            //else
            //{
            //    RemoteVideoPictureBox.Image = FriendVideoOffImage;
            //}
            isFriendCameraOn = true;
        }
        public void HandleCameraOff()
        {
            if (_myVideoIsSmall)
            {
                RemoteVideoPictureBox.Image = FriendVideoOffImage;
            }
            else
            {
                UserVideoPictureBox.Image = FriendVideoOffImage;
            }
            isFriendCameraOn = false;

        }
        public void HandleCallOver()
        {
            wasOrderedToClose = true;

            CloseForm();
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseVideoCall(); });

        }
    }

}
