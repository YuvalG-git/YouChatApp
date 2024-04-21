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

namespace YouChatApp.AttachedFiles
{
    public partial class AudioCall : Form
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

        private bool isAbleToSend = false;

        CallTimer timer;
        private string _chatId;
        private bool wasOrderedToClose;
        
        private readonly ServerCommunicator serverCommunicator;
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
            InitializeAudioDevicesChangeDetection(); // Start monitoring camera changes.
        }

        public void SetIsAbleToSendToTrue()
        {
            isAbleToSend = true;
        }
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
        private void HandleAudioDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshAudioList));
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

            AudioHandler.AudioHandler.HandleWaveOutPhaseTwo(audioWaveOut,audioBufferedWaveProvider);

        }

        private void AudioCall_Load(object sender, EventArgs e)
        {

        }

        private void AudioCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.StopTimer();
            AudioHandler.AudioHandler.HandleFormClosing(audioSourceStream, audioWaveOut, watcher);
        }

        private void AudioInputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleAudioInputDeviceComboBoxSelectedIndexChanged(audioSourceStream, AudioInputDeviceComboBox);
        }

        private void AudioOutputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleWaveOut();
            //AudioHandler.AudioHandler.HandleWaveOut(_waveOut, AudioOutputDeviceComboBox, _outputDeviceGuids, provider);
        }

        private void MicrophoneModeCustomButton_Click(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleMicrophoneModeCustomButtonClick(ref audioSourceStream, ref isMyMicrophoneMuted, MicrophoneModeCustomButton, AudioInputDeviceComboBox, sourceStream_DataAvailable);
        }
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

        private void CallEnderCustomButton_Click(object sender, EventArgs e)
        {
            HandleFormClosing();

            wasOrderedToClose = true;
            this.Close();
        }
        private void HandleFormClosing()
        {
            if (!wasOrderedToClose)
            {
                AudioCallOverDetails callOverDetails = new AudioCallOverDetails(_chatId, AudioServerCommunication.GetLocalPort());
                JsonObject endAudioCallRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.EndAudioCallRequest, callOverDetails);
                string endAudioCallRequestJson = JsonConvert.SerializeObject(endAudioCallRequestJsonObject, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                serverCommunicator.SendMessage(endAudioCallRequestJson);
                CloseForm();
            }
        }

        private void CallTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void CallTimeTimer_Tick(object sender, EventArgs e)
        {
            timer.HandleTimerTick(CallTimeLabel);
        }

        public void HandleCallOver()
        {
            wasOrderedToClose = true;

            CloseForm();
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseAudioCall(); });

        }
    }
}
