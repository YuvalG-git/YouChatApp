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

        public AudioCall()
        {
            InitializeComponent();
            isMyMicrophoneMuted = false;
            CallEnderCustomButton.BorderRadius = 40;
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
            AudioServerCommunication.ConnectUdp("10.100.102.3", this);
            WaveFormat waveFormat = new WaveFormat(44100, 16, 2);
            audioBufferedWaveProvider = new BufferedWaveProvider(waveFormat);
            outputAudioDeviceGuids = new List<Guid>();

            audioBufferedWaveProvider.DiscardOnBufferOverflow = true;
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, outputAudioDeviceGuids);
            AudioHandler.AudioHandler.StartAudioRecording(AudioInputDeviceComboBox, ref audioSourceStream, sourceStream_DataAvailable);
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, audioSourceStream);
            InitializeAudioDevicesChangeDetection(); // Start monitoring camera changes.
        }

        private void AudioCall_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void CallEnderCustomButton_Click(object sender, EventArgs e)
        {
            AudioHandler.AudioHandler.HandleFormClosing(audioSourceStream, audioWaveOut, watcher);
        }
    }
}
