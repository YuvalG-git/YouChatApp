using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;
using AForge.Video;
using NAudio.CoreAudioApi;
using YouChatApp.Controls;
using System.Threading;
using Newtonsoft.Json;
using YouChatApp.JsonClasses;
using YouChatApp.AttachedFiles.CallHandler;

namespace YouChatApp.AttachedFiles
{
    /// <summary>
    /// The "AudioCall" class represents a form for managing audio calls.
    /// It provides functionality for audio input and output, microphone management, and call timing.
    /// </summary>
    /// <remarks>
    /// This class handles audio input and output devices, microphone mode toggling, and call timing.
    /// It also manages audio data events and cleanup operations on form closing.
    /// </remarks>
    public partial class AudioCall : Form
    {
        #region Private Audio Management Fields

        /// <summary>
        /// The ManagementEventWatcher "watcher" watches for management events.
        /// It Used for updating the input and output audio devices connected to the computer.
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
        private string _chatId;

        /// <summary>
        /// The bool "wasOrderedToClose" indicates whether the client was ordered to close.
        /// </summary>
        private bool wasOrderedToClose;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Constructors

        /// <summary>
        /// The "AudioCall" constructor initializes a new instance of the <see cref="AudioCall"/> class with the specified chat ID, name, and profile picture.
        /// </summary>
        /// <param name="chatId">The ID of the chat associated with the audio call.</param>
        /// <param name="name">The name of the participant in the audio call.</param>
        /// <param name="profilePicture">The profile picture of the participant in the audio call.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the AudioCall class, representing an audio call session.
        /// It initializes various components and settings for the audio call, including the chat ID, participant's name, and profile picture.
        /// </remarks>
        public AudioCall(string chatId, string name, Image profilePicture)
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            isMyMicrophoneMuted = false;
            CallEnderCustomButton.BorderRadius = 40;
            FriendNameLabel.Text = name;
            ContactProfilePicture.BackgroundImage = profilePicture;
            _chatId = chatId;
            wasOrderedToClose = false;
            WaveFormat waveFormat = new WaveFormat(44100, 16, 2);
            audioBufferedWaveProvider = new BufferedWaveProvider(waveFormat);
            outputAudioDeviceGuids = new List<Guid>();
            timer = new CallTimer(CallTimeTimer);
            audioBufferedWaveProvider.DiscardOnBufferOverflow = true;
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
            AudioHandler.AudioHandler.StartAudioRecording(AudioInputDeviceComboBox, ref audioSourceStream, sourceStream_DataAvailable);
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            InitializeAudioDevicesChangeDetection(); 
        }

        #endregion

        #region Private Audio Management Methods

        /// <summary>
        /// The "InitializeAudioDevicesChangeDetection" method initializes the audio devices change detection by creating a management event watcher to monitor hardware changes.
        /// </summary>
        /// <remarks>
        /// This method creates a ManagementEventWatcher to monitor hardware changes related to audio devices.
        /// It sets up a query to listen for device arrival and device removal events and starts listening for hardware changes.
        /// When a device arrival or removal event is detected, the HandleAudioDeviceChange method is called to handle the event.
        /// </remarks>
        private void InitializeAudioDevicesChangeDetection()
        {
            // Create a management event watcher to monitor hardware changes.
            watcher = new ManagementEventWatcher();
            watcher.EventArrived += new EventArrivedEventHandler(HandleAudioDeviceChange);

            // Set up a query to listen for device arrival and device removal events.
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            watcher.Query = query;

            // Start listening for hardware changes.
            watcher.Start();
        }

        /// <summary>
        /// The "HandleAudioDeviceChange" method handles audio device change events by refreshing the audio device list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void HandleAudioDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshAudioList));
        }

        /// <summary>
        /// The "RefreshAudioList" method refreshes the audio device list by initializing the audio input and output device lists.
        /// </summary>
        /// <remarks>
        /// This method is called when a hardware change related to audio devices is detected.
        /// It updates the list of available audio input and output devices in the corresponding ComboBox controls.
        /// </remarks>
        private void RefreshAudioList()
        {
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
        }

        /// <summary>
        /// The "sourceStream_DataAvailable" method handles the data available event from the audio source stream.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the audio data.</param>
        /// <remarks>
        /// This method checks if the application is able to send audio data and then forwards the audio data to the HandleSourceStreamDataAvailable method in the AudioHandler class for further processing.
        /// </remarks>
        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (isAbleToSend)
                AudioHandler.AudioHandler.HandleSourceStreamDataAvailable(e, audioSourceStream, isMyMicrophoneMuted);
        }

        /// <summary>
        /// The "HandleWaveOut" method handles the initialization and configuration of the audio output device.
        /// </summary>
        /// <remarks>
        /// This method performs two phases of initialization for the audio output device.
        /// In the first phase, it stops and disposes the current audio output device if it exists.
        /// In the second phase, it initializes a new DirectSoundOut instance based on the selected audio output device from the ComboBox and sets up the playback configuration.
        /// </remarks>
        private void HandleWaveOut()
        {
            AudioHandler.AudioHandler.HandleWaveOutPhaseOne(audioWaveOut);
            int selectedDeviceIndex = AudioOutputDeviceComboBox.SelectedIndex;
            audioWaveOut = new DirectSoundOut(outputAudioDeviceGuids[selectedDeviceIndex]);
            AudioHandler.AudioHandler.HandleWaveOutPhaseTwo(audioWaveOut, audioBufferedWaveProvider);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "AudioInputDeviceComboBox_SelectedIndexChanged" method handles the selected index changed event for the audio input device ComboBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the event information.</param>
        /// <remarks>
        /// This method is called when the selected index of the audio input device ComboBox changes.
        /// It updates the device number of the audio source stream to match the selected index, effectively changing the input device for audio capture.
        /// </remarks>
        private void AudioInputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleAudioInputDeviceComboBoxSelectedIndexChanged(audioSourceStream, AudioInputDeviceComboBox);
        }

        /// <summary>
        /// The "AudioOutputDeviceComboBox_SelectedIndexChanged" method handles the selected index changed event for the audio output device ComboBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the event information.</param>
        /// <remarks>
        /// This method is called when the selected index of the audio output device ComboBox changes.
        /// It triggers the HandleWaveOut method to reinitialize and configure the audio output device based on the newly selected device.
        /// </remarks>
        private void AudioOutputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleWaveOut();
        }

        /// <summary>
        /// The "MicrophoneModeCustomButton_Click" method handles the click event for the microphone mode custom button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the event information.</param>
        /// <remarks>
        /// This method is called when the microphone mode custom button is clicked.
        /// It toggles the microphone mode between open and muted, updating the button image and starting or stopping audio recording accordingly.
        /// </remarks>
        private void MicrophoneModeCustomButton_Click(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleMicrophoneModeCustomButtonClick(ref audioSourceStream, ref isMyMicrophoneMuted, MicrophoneModeCustomButton, AudioInputDeviceComboBox, sourceStream_DataAvailable);
        }

        /// <summary>
        /// The "CallTimeTimer_Tick" method handles the tick event of the call time timer.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the event information.</param>
        /// <remarks>
        /// This method is called when the call time timer ticks.
        /// It handles the timer tick by updating the call time label using the HandleTimerTick method of the timer object.
        /// </remarks>
        private void CallTimeTimer_Tick(object sender, EventArgs e)
        {
            timer.HandleTimerTick(CallTimeLabel);
        }

        #endregion

        #region Private Form Closing Methods

        /// <summary>
        /// The "AudioCall_FormClosing" method handles the form closing event for the AudioCall form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the form closing information.</param>
        /// <remarks>
        /// This method is called when the AudioCall form is closing.
        /// It stops the call timer and handles the closing of audio resources such as the audio source stream, audio output device, and hardware change watcher.
        /// </remarks>
        private void AudioCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.StopTimer();
            AudioHandler.AudioHandler.HandleFormClosing(audioSourceStream, audioWaveOut, watcher);
        }

        /// <summary>
        /// The "CloseForm" method closes the current form, handles audio resources, and stops the timer.
        /// </summary>
        /// <remarks>
        /// If the "_youChat" form is not null, it is shown using the UI thread.
        /// The method then handles closing audio resources by stopping audio recording, stopping audio playback, and disposing of the management event watcher.
        /// Finally, it stops the timer and resets the symmetric key used for communication.
        /// </remarks>
        private void CloseForm()
        {
            if (FormHandler._youChat != null)
            {
                this.Invoke(new Action(() => FormHandler._youChat.Show()));
            }
            AudioHandler.AudioHandler.HandleFormClosing(audioSourceStream, audioWaveOut, watcher);
            timer.StopTimer();
            AudioServerCommunication.symmetricKey = null;
        }

        /// <summary>
        /// The "CallEnderCustomButton_Click" method handles the click event for the call ender custom button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments containing the event information.</param>
        /// <remarks>
        /// This method is called when the call ender custom button is clicked.
        /// It handles the form closing actions by calling the CloseForm method, sets the wasOrderedToClose flag to true, and closes the form.
        /// </remarks>
        private void CallEnderCustomButton_Click(object sender, EventArgs e)
        {
            HandleFormClosing();
            wasOrderedToClose = true;
            this.Close();
        }

        /// <summary>
        /// The "HandleFormClosing" method handles the form closing event.
        /// </summary>
        /// <remarks>
        /// If the form was not previously ordered to close, it creates an "AudioCallOverDetails" object with the chat ID and local port.
        /// It then sends an "EndAudioCallRequest" message to the server with the call over details.
        /// Finally, it closes the form.
        /// </remarks>
        private void HandleFormClosing()
        {
            if (!wasOrderedToClose)
            {
                AudioCallOverDetails callOverDetails = new AudioCallOverDetails(_chatId, AudioServerCommunication.GetLocalPort());
                EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.EndAudioCallRequest;
                object messageContent = callOverDetails;
                serverCommunicator.SendMessage(messageType, messageContent);
                CloseForm();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "SetIsAbleToSendToTrue" method sets the flag indicating whether the call is able to send data to true.
        /// </summary>
        /// <remarks>
        /// This method is used to enable the call to send data. When called, it sets the isAbleToSend flag to true, indicating that the call is now able to send data.
        /// </remarks>
        public void SetIsAbleToSendToTrue()
        {
            isAbleToSend = true;
        }     

        /// <summary>
        /// The "ReceiveAudioData" method receives audio data and handles it for playback.
        /// </summary>
        /// <param name="receivedData">The received audio data.</param>
        /// <remarks>
        /// This method forwards the received audio data to the HandleReceivedAudioData method in the AudioHandler class for playback through the audio output device.
        /// </remarks>
        public void ReceiveAudioData(byte[] receivedData)
        {
            AudioHandler.AudioHandler.HandleReceivedAudioData(receivedData, audioWaveOut, audioBufferedWaveProvider);
        }
        
        /// <summary>
        /// The "HandleCallOver" method handles the end of the audio call.
        /// </summary>
        /// <remarks>
        /// This method sets the wasOrderedToClose flag to true, indicating that the form should close.
        /// It then closes the current form and invokes the CloseAudioCall method of the _youChat form to close the audio call.
        /// </remarks>
        public void HandleCallOver()
        {
            wasOrderedToClose = true;
            CloseForm();
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseAudioCall(); });
        }

        #endregion
    }
}
