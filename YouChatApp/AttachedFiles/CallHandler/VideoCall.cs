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
    /// <summary>
    /// The "VideoCall" class represents a form for managing video calls.
    /// It provides functionality for audio & video input and output, microphone & camera management, and call timing.
    /// </summary>
    /// <remarks>
    /// This class handles audio & video input and output devices, microphone & camera mode toggling, and call timing.
    /// It also manages audio and video data events and cleanup operations on form closing.
    /// </remarks>
    public partial class VideoCall : Form
    {
        #region Private Audio Management Fields

        /// <summary>
        /// The ManagementEventWatcher "watcher" watches for management events.
        /// It Used for updating the input and output audio devices and video devices connected to the computer.
        /// </summary>
        private ManagementEventWatcher watcher;

        /// <summary>
        /// The DirectSoundOut "audioWaveOut" plays audio using DirectSound.
        /// </summary>
        private DirectSoundOut audioWaveOut;

        /// <summary>
        /// The BufferedWaveProvider "audioBufferedWaveProvider" buffers audio data for audio playback.
        /// It is responsible for converting the byte array of audio to playable audio through the WaveOut.
        /// </summary>
        private BufferedWaveProvider audioBufferedWaveProvider;

        /// <summary>
        /// The WaveIn "audioSourceStream" represents the source stream for audio input.
        /// It is responsible for recording audio.
        /// </summary>
        private WaveIn audioSourceStream;

        /// <summary>
        /// The List "outputAudioDeviceGuids" stores the GUIDs of output audio devices.
        /// </summary>
        private List<Guid> outputAudioDeviceGuids;

        #endregion

        #region Private Video Management Fields

        /// <summary>
        /// The FilterInfoCollection "videoDevices" represents the collection of video devices.
        /// </summary>
        private FilterInfoCollection videoDevices;

        /// <summary>
        /// The VideoCaptureDevice "videoSource" represents the video capture device.
        /// </summary>
        private VideoCaptureDevice videoSource;

        #endregion

        #region Private Fields

        /// <summary>
        /// The bool "isMyMicrophoneMuted" indicates whether the user's microphone is muted.
        /// </summary>
        private bool isMyMicrophoneMuted;

        /// <summary>
        /// The bool "isAbleToSend" indicates whether the client is able to send data.
        /// </summary>
        private bool isAbleToSend = false;

        /// <summary>
        /// The CallTimer "timer" represents a timer for call-related operations.
        /// </summary>
        private CallTimer timer;

        /// <summary>
        /// The string "_chatId" stores the ID of the chat.
        /// </summary>
        private string chatId;

        /// <summary>
        /// The bool "wasOrderedToClose" indicates whether the client was ordered to close.
        /// </summary>
        private bool wasOrderedToClose;

        /// <summary>
        /// The boolean variable "CameraIsOpen" represents whether the camera is open or closed.
        /// </summary>
        private bool CameraIsOpen = false;

        /// <summary>
        /// The Image "VideoOffImage" represents the image for turning off video.
        /// </summary>
        private Image VideoOffImage;

        /// <summary>
        /// The boolean variable "_myVideoIsSmall" represents whether the user's video is displayed in a small size.
        /// </summary>
        private bool _myVideoIsSmall = true;

        /// <summary>
        /// The boolean variable "_isDragging" represents whether an element is being dragged.
        /// </summary>
        private bool _isDragging = false;

        /// <summary>
        /// The Point "_lastMousePosition" represents the last known mouse position.
        /// </summary>
        private Point _lastMousePosition;

        /// <summary>
        /// The string "_friendName" represents the friend's name.
        /// </summary>
        private string _friendName;

        /// <summary>
        /// The string "_videoToolTipContent" represents the tooltip content for the video.
        /// </summary>
        private string _videoToolTipContent;

        /// <summary>
        /// The string "_friendVideoToolTipContent" represents the tooltip content for the friend's video.
        /// </summary>
        private string _friendVideoToolTipContent;

        /// <summary>
        /// The boolean variable "isFriendCameraOn" represents whether the friend's camera is on.
        /// </summary>
        private bool isFriendCameraOn = false;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;
       
        /// <summary>
        /// The readonly Image "CameraNotOpen" represents the image for a closed camera.
        /// </summary>
        private readonly Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;

        /// <summary>
        /// The readonly Image "CameraOpen" represents the image for an open camera.
        /// </summary>
        private readonly Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;

        /// <summary>
        /// The readonly Image "FriendVideoOffImage" represents the image for a friend's video off state.
        /// </summary>
        private readonly Image FriendVideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile;

        /// <summary>
        /// The readonly Image "MyVideoOffImage" represents the image for the user's video off state.
        /// </summary>
        private readonly Image MyVideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile;

        #endregion

        #region Constructors

        /// <summary>
        /// The "VideoCall" constructor initializes a new instance of the <see cref="VideoCall"/> class with the specified chat ID, name, and profile picture.
        /// </summary>
        /// <param name="chatId">The ID of the chat associated with the video call.</param>
        /// <param name="name">The name of the participant in the video call.</param>
        /// <param name="profilePicture">The profile picture of the participant in the video call.</param>
        /// <remarks>
        /// This constructor is used to create a new video call instance, setting up various components and settings for the video call,
        /// including the chat ID, participant's name, and profile picture. It also initializes audio and video recording devices,
        /// sets up tool tips for video controls, and starts a timer to track the call duration.
        /// </remarks>
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
            MyVideoOffImage = VideoOffImage;
            wasOrderedToClose = false;
            UserVideoPictureBox.Image = VideoOffImage;

            serverCommunicator = ServerCommunicator.Instance;

            InitializeCameraList(); 
            WaveFormat waveFormat = new WaveFormat(44100, 16, 2);
            audioBufferedWaveProvider = new BufferedWaveProvider(waveFormat);
            outputAudioDeviceGuids = new List<Guid>();

            audioBufferedWaveProvider.DiscardOnBufferOverflow = true;
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
            AudioHandler.AudioHandler.StartAudioRecording(AudioInputDeviceComboBox, ref audioSourceStream, sourceStream_DataAvailable);
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            InitializeVideoAndAudioChangeDetection();

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

        #endregion

        #region Private Audio Management Methods

        /// <summary>
        /// The "HandleWaveOut" method handles the initialization and setup of the audio output device for playback.
        /// </summary>
        /// <remarks>
        /// This method first performs phase one of the audio output handling by stopping and disposing of the current audio output device.
        /// Then, it initializes a new instance of the DirectSoundOut class with the selected audio output device.
        /// Finally, it completes the setup by performing phase two of the audio output handling, which initializes the audio output device with the buffered wave provider.
        /// </remarks>
        private void HandleWaveOut()
        {
            AudioHandler.AudioHandler.HandleWaveOutPhaseOne(audioWaveOut);
            int selectedDeviceIndex = AudioOutputDeviceComboBox.SelectedIndex;
            audioWaveOut = new DirectSoundOut(outputAudioDeviceGuids[selectedDeviceIndex]);
            AudioHandler.AudioHandler.HandleWaveOutPhaseTwo(audioWaveOut, audioBufferedWaveProvider);
        }

        /// <summary>
        /// The "sourceStream_DataAvailable" method handles the data available event from the audio source stream.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the audio data.</param>
        /// <remarks>
        /// This method checks if the application is able to send audio data, and if so, it calls the "HandleSourceStreamDataAvailable" method from the AudioHandler class to handle the audio data.
        /// </remarks>
        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (isAbleToSend)
                AudioHandler.AudioHandler.HandleSourceStreamDataAvailable(e, audioSourceStream, isMyMicrophoneMuted);
        }

        /// <summary>
        /// The "RefreshAudioList" method refreshes the list of available audio devices.
        /// </summary>
        /// <remarks>
        /// This method calls the "InitializeAudioInputDeviceList" and "InitializeAudioOutputDeviceList" methods from the AudioHandler class to refresh the audio input and output device lists respectively.
        /// </remarks>
        private void RefreshAudioList()
        {
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
        }

        /// <summary>
        /// The "HandleAudioDeviceChange" method handles the event of an audio device change.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when a hardware change related to audio devices is detected.
        /// It refreshes the audio device list to reflect any changes in available audio devices.
        /// </remarks>
        private void HandleAudioDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the audio device list when a hardware change is detected.
            BeginInvoke(new Action(RefreshAudioList));
        }

        #endregion

        #region Private Video Management Methods

        /// <summary>
        /// The "InitializeCameraList" method initializes the camera list by enumerating available video input devices.
        /// </summary>
        /// <remarks>
        /// This method retrieves a collection of video input devices using the FilterCategory.VideoInputDevice filter category.
        /// If no video devices are found, it displays a message box indicating the absence of devices.
        /// For each discovered video input device, the method adds its name to the CameraDeviceComboBox control.
        /// Finally, it selects the first device in the combo box by default and starts the video source with the selected camera.
        /// </remarks>
        private void InitializeCameraList()
        {
            // Get the collection of video input devices.
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Check if no video devices are found.
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }
            else
            {
                CameraDeviceComboBox.Items.Clear(); // Clear existing items.

                // Add each video input device to the camera device combo box.
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

        /// <summary>
        /// The "StartVideoSource" method starts the video source for capturing video from the selected camera device.
        /// </summary>
        /// <remarks>
        /// This method first checks if there is an existing video source that is running. 
        /// If so, it signals the video source to stop and waits for it to stop completely.
        /// Next, it retrieves the collection of video input devices to ensure there are available devices.
        /// If video devices are found, it creates a new instance of VideoCaptureDevice with the selected camera's MonikerString.
        /// It then subscribes to the NewFrame event to handle new video frames.
        /// If the camera is open, it starts the video source. 
        /// If the camera is not open, it sets the appropriate image for the UserVideoPictureBox or RemoteVideoPictureBox based on the state of the video.
        /// </remarks>
        private void StartVideoSource()
        {
            // Stop the current video source if it is running.
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            // Get the collection of video input devices.
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Check if video devices are available.
            if (videoDevices.Count != 0)
            {
                // Create a new instance of VideoCaptureDevice with the selected camera's MonikerString.
                videoSource = new VideoCaptureDevice(videoDevices[CameraDeviceComboBox.SelectedIndex].MonikerString);

                // Subscribe to the NewFrame event to handle new video frames.
                videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);

                // Start the video source if the camera is open.
                if (CameraIsOpen)
                {
                    videoSource.Start();
                }
                else
                {
                    // Set the appropriate image for the UserVideoPictureBox or RemoteVideoPictureBox based on the video state.
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

        /// <summary>
        /// The "VideoSource_NewFrame" event handler processes new frames from the video source.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="eventArgs">The event arguments containing the new video frame.</param>
        /// <remarks>
        /// This method checks if the video transmission is enabled ("isAbleToSend" flag) and, if so,
        /// converts the new video frame to a JPEG image and sends it over UDP using the VideoServerCommunication class.
        /// It also updates the local display of the video frame in either the UserVideoPictureBox (for local video) or RemoteVideoPictureBox (for remote video).
        /// </remarks>
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (isAbleToSend)
            {
                using (var stream = new MemoryStream())
                {
                    eventArgs.Frame.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = stream.ToArray();
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

        /// <summary>
        /// The "HandleVideoDeviceChange" method handles the event of a video device change.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when a hardware change related to video devices is detected.
        /// It refreshes the camera list to reflect any changes in available video devices.
        /// </remarks>
        private void HandleVideoDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshCameraList));
        }

        /// <summary>
        /// The "RefreshCameraList" method refreshes the list of available camera devices.
        /// </summary>
        /// <remarks>
        /// This method calls the "InitializeCameraList" method to refresh the camera list.
        /// </remarks>
        private void RefreshCameraList()
        {
            InitializeCameraList(); // Refresh the camera list.
        }

        #endregion

        #region Private General Management Methods

        /// <summary>
        /// The "InitializeVideoAndAudioChangeDetection" method initializes the monitoring of hardware changes for video and audio devices.
        /// </summary>
        /// <remarks>
        /// This method creates a ManagementEventWatcher to monitor hardware changes related to video and audio devices.
        /// It sets up a query to listen for device arrival and device removal events and starts listening for hardware changes.
        /// When a device arrival or removal event is detected, both the HandleVideoDeviceChange and HandleAudioDeviceChange methods are called to handle the event.
        /// </remarks>
        private void InitializeVideoAndAudioChangeDetection()
        {
            // Create a management event watcher to monitor hardware changes.
            watcher = new ManagementEventWatcher();

            // Subscribe to the EventArrived event for both video and audio device changes.
            watcher.EventArrived += new EventArrivedEventHandler(HandleVideoDeviceChange);
            watcher.EventArrived += new EventArrivedEventHandler(HandleAudioDeviceChange);

            // Set up a query to listen for device arrival and device removal events.
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            watcher.Query = query;

            // Start listening for hardware changes.
            watcher.Start();
        }

        #endregion

        #region Private Video Methods

        /// <summary>
        /// The "CameraModeCustomButton_Click" method handles the click event of the camera mode button,
        /// toggling the camera between open and closed states and sending a message to the server accordingly.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method toggles the camera mode between open and closed.
        /// If the camera is opened, it updates the button image, sends a request to turn the camera on to the server,
        /// and starts the video source.
        /// If the camera is closed, it updates the button image, sends a request to turn the camera off to the server,
        /// and stops displaying the video feed.
        /// </remarks>
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
            EnumHandler.CommunicationMessageID_Enum messageType = CameraModeEnum;
            object messageContent = chatId;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "RefreshCameraOptionsCustomButton_Click" method handles the Click event for the refresh camera options custom button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method refreshes the camera list when the refresh camera options custom button is clicked.
        /// </remarks>
        private void RefreshCameraOptionsCustomButton_Click(object sender, EventArgs e)
        {
            RefreshCameraList();
        }

        #endregion

        #region Private Audio Methods

        /// <summary>
        /// The "RefreshAudioOptionsCustomButtons_Click" method handles the click event of the refresh audio options custom buttons.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method refreshes the audio list when the refresh audio options custom buttons are clicked.
        /// </remarks>
        private void RefreshAudioOptionsCustomButtons_Click(object sender, EventArgs e)
        {
            RefreshAudioList();
        }

        /// <summary>
        /// The "AudioInputDeviceComboBox_SelectedIndexChanged" method handles the SelectedIndexChanged event of the audio input device combo box,
        /// updating the audio input device selection and its associated audio stream.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the audio input device selection in the combo box and sets the corresponding audio stream.
        /// </remarks>
        private void AudioInputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleAudioInputDeviceComboBoxSelectedIndexChanged(audioSourceStream, AudioInputDeviceComboBox);
        }

        /// <summary>
        /// The "AudioOutputDeviceComboBox_SelectedIndexChanged" method handles the SelectedIndexChanged event of the audio output device combo box,
        /// updating the audio output device selection and restarting the audio output stream.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the audio output device selection in the combo box and restarts the audio output stream.
        /// </remarks>
        private void AudioOutputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleWaveOut();
        }

        /// <summary>
        /// The "MicrophoneModeCustomButton_Click" method handles the Click event of the microphone mode custom button,
        /// toggling the microphone mute state and sending a message to the server to update the mute state.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method toggles the microphone mute state, updates the button image, and sends a message to the server to update the mute state.
        /// </remarks>
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
            EnumHandler.CommunicationMessageID_Enum messageType = MuteStateEnum;
            object messageContent = chatId;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Private Form Closing Methods

        /// <summary>
        /// The "VideoCall_FormClosing" method handles the FormClosing event of the video call form, 
        /// ensuring proper cleanup and handling before the form is closed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleFormClosing method to handle any necessary actions before the form is closed.
        /// </remarks>
        private void VideoCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleFormClosing();
        }

        /// <summary>
        /// The "HandleFormClosing" method handles actions that need to be taken before the video call form is closed.
        /// </summary>
        /// <remarks>
        /// If the form is not ordered to close, it creates a video call over details object containing the chat ID and local ports for audio and video communication.
        /// It then sends an end video call request message with the details to the server communicator and closes the form.
        /// </remarks>
        private void HandleFormClosing()
        {
            if (!wasOrderedToClose)
            {
                VideoCallOverDetails videoCallOverDetails = new VideoCallOverDetails(chatId, AudioServerCommunication.GetLocalPort(), VideoServerCommunication.GetLocalPort());
                EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.EndVideoCallRequest;
                object messageContent = videoCallOverDetails;
                serverCommunicator.SendMessage(messageType, messageContent);
                CloseForm();
            }
        }

        /// <summary>
        /// The "CloseForm" method performs cleanup tasks and closes the video call form.
        /// </summary>
        /// <remarks>
        /// If the "YouChat" form is not null, it is shown.
        /// It then handles form closing for audio and video components, closes the video server connection,
        /// stops the video source if it is running, and stops the call timer.
        /// </remarks>
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

        /// <summary>
        /// The "DeclineCallCustomButton_Click" method handles the click event of the "Decline" button in the call invitation form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method handles the form closing process when the "Decline" button is clicked.
        /// It first handles the form closing, sets the flag to indicate that the form was ordered to close, and then closes the form.
        /// </remarks>
        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            HandleFormClosing();
            wasOrderedToClose = true;
            this.Close();
        }
        #endregion

        #region Private Video Methods

        /// <summary>
        /// The "UserVideoPictureBox_MouseDown" method handles the MouseDown event for the user video picture box.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        /// <remarks>
        /// If the left mouse button is pressed, it sets the "_isDragging" flag to true
        /// and records the current mouse position in "_lastMousePosition".
        /// </remarks>
        private void UserVideoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePosition = e.Location;
            }
        }

        /// <summary>
        /// The "UserVideoPictureBox_MouseMove" method handles the MouseMove event for the user video picture box.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        /// <remarks>
        /// If the left mouse button is pressed (_isDragging is true), it calculates the new position based on the mouse movement.
        /// The method ensures that the picture box does not move outside the boundaries of the target picture box (e.g., RemoteVideoPictureBox).
        /// </remarks>
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

        /// <summary>
        /// The "UserVideoPictureBox_MouseUp" method handles the MouseUp event for the user video picture box.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        /// <remarks>
        /// If the left mouse button is released, it sets the _isDragging flag to false, indicating that dragging has stopped.
        /// </remarks>
        private void UserVideoPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }

        /// <summary>
        /// The "UserVideoPictureBox_DoubleClick" method handles the DoubleClick event for the user video picture box.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method calls the HandleDoubleClick method when the user double-clicks the user video picture box.
        /// </remarks>
        private void UserVideoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            HandleDoubleClick();
        }
  
        /// <summary>
        /// The "RemoteVideoPictureBox_DoubleClick" method handles the double-click event of the remote video picture box.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method handles the double-click event of the remote video picture box by invoking the HandleDoubleClick method.
        /// </remarks>
        private void RemoteVideoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            HandleDoubleClick();
        }

        /// <summary>
        /// The "HandleDoubleClick" method toggles the display size of the video.
        /// </summary>
        /// <remarks>
        /// This method toggles the display size of the video between small and large.
        /// If the video is currently small, it sets the ToolTip for the user video picture box to the video tooltip content and the ToolTip for the remote video picture box to the friend video tooltip content.
        /// If the video is currently large, it sets the ToolTip for the user video picture box to the friend video tooltip content and the ToolTip for the remote video picture box to the video tooltip content.
        /// It also updates the images of the user and remote video picture boxes based on the camera and friend camera status.
        /// </remarks>
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
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "CallTimeTimer_Tick" method handles the tick event of the call time timer.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the call time label to reflect the current call duration and centers the label horizontally within the call details panel.
        /// </remarks>
        private void CallTimeTimer_Tick(object sender, EventArgs e)
        {
            timer.HandleTimerTick(CallTimeLabel);
            CallTimeLabel.Location = new Point((CallDetailsPanel.Width - CallTimeLabel.Width) / 2, CallTimeLabel.Location.Y);
        }

        #endregion

        #region Public Video Methods

        /// <summary>
        /// The "HandleCameraOn" method sets the flag indicating that the friend's camera is on to true.
        /// </summary>
        public void HandleCameraOn()
        {
            isFriendCameraOn = true;
        }

        /// <summary>
        /// The "HandleCameraOff" method handles turning off the friend's camera by setting the appropriate image and updating the camera status flag.
        /// </summary>
        /// <remarks>
        /// This method updates the image displayed in the PictureBox based on the current video size setting.
        /// If the friend's camera is turned off, it displays the "FriendVideoOffImage" in the appropriate PictureBox.
        /// It also updates the "isFriendCameraOn" flag to indicate that the friend's camera is now off.
        /// </remarks>
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

        /// <summary>
        /// The "HandleReceivedImage" method handles the reception of an image for video display.
        /// </summary>
        /// <param name="receivedImage">The image received for display.</param>
        /// <remarks>
        /// This method updates the appropriate PictureBox (UserVideoPictureBox or RemoteVideoPictureBox) with the received image based on the current camera status.
        /// If the friend's camera is on, the method updates the PictureBox corresponding to the local camera.
        /// If the friend's camera is off, the method updates the PictureBox corresponding to the friend's camera to display a "camera off" image.
        /// </remarks>
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

        #endregion

        #region Public Audio Methods

        /// <summary>
        /// The "ReceiveAudioData" method processes received audio data.
        /// </summary>
        /// <param name="receivedData">The audio data received from the network.</param>
        /// <remarks>
        /// This method passes the received audio data to the "HandleReceivedAudioData" method in the AudioHandler class for processing and playback.
        /// </remarks>
        public void ReceiveAudioData(byte[] receivedData)
        {
            AudioHandler.AudioHandler.HandleReceivedAudioData(receivedData, audioWaveOut, audioBufferedWaveProvider);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "HandleCallOver" method handles the end of the video call by setting the flag to indicate the call is over, closing the form, and invoking the close method of the parent chat form to end the call.
        /// </summary>
        /// <remarks>
        /// This method sets the "wasOrderedToClose" flag to true to indicate that the call is over and prevents further actions from being taken in the call form.
        /// It then closes the call form and invokes the "CloseVideoCall" method of the parent chat form to properly end the video call.
        /// </remarks>
        public void HandleCallOver()
        {
            wasOrderedToClose = true;
            CloseForm();
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseVideoCall(); });
        }

        /// <summary>
        /// The "SetIsAbleToSendToTrue" method sets the flag "isAbleToSend" to true, allowing audio data to be sent.
        /// </summary>
        public void SetIsAbleToSendToTrue()
        {
            isAbleToSend = true;
        }

        #endregion
    }
}
