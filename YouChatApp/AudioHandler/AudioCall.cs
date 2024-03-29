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

namespace YouChatApp.AttachedFiles
{
    public partial class AudioCall : Form
    {
        private bool isMuted;
        private List<WaveInCapabilities> inputDevices;
        private ManagementEventWatcher watcher;
        public DirectSoundOut _waveOut;//object incharge of playing audio wave
        private BufferedWaveProvider provider;//incharge of converting the byte array of audio to
        private WaveIn sourceStream;//incarge of recoring audio //todo - to use this in order to fix sound...
        List<Guid> _outputDeviceGuids;
        Image MicrophoneNotOpen = global::YouChatApp.Properties.Resources.MicrophoneClose;
        Image MicrophoneOpen = global::YouChatApp.Properties.Resources.MicrophoneOpen;
      
        public AudioCall()
        {
            InitializeComponent();

            isMuted = false;
            CallEnderCustomButton.BorderRadius = 40;
        }

        private void InitializeAudioOutputDeviceList()
        {
            _outputDeviceGuids = new List<Guid>();
            foreach (var deviceInfo in DirectSoundOut.Devices)
            {
                _outputDeviceGuids.Add(deviceInfo.Guid);
                AudioOutputDeviceComboBox.Items.Add(deviceInfo.Description); //can tell it to delete the first (the computers main)
            }
            AudioOutputDeviceComboBox.SelectedIndex = 0;
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
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, sourceStream);
            AudioHandler.AudioHandler.InitializeAudioOutputDeviceList(AudioOutputDeviceComboBox, _outputDeviceGuids);
            InitializeAudioOutputDeviceList();
        }



        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (sourceStream == null) return;
            try
            {
                if (!isMuted)
                    AudioServerCommunication.SendAudio(e.Buffer, e.BytesRecorded);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ReceiveAudioData(byte[] receivedData)
        {
            if (_waveOut != null)
            {
                provider.AddSamples(receivedData, 0, receivedData.Length);
                _waveOut.Play();
            }
        }

        private void AudioCall_Load(object sender, EventArgs e)
        {
            AudioServerCommunication.ConnectUdp("10.100.102.3", this);
            this.provider = new BufferedWaveProvider(new WaveFormat(44100, 16, 2));
            this.provider.DiscardOnBufferOverflow = true;
            InitializeAudioOutputDeviceList();
            StartAudioRecording();
            AudioHandler.AudioHandler.InitializeAudioInputDeviceList(AudioInputDeviceComboBox, sourceStream);
            InitializeAudioDevicesChangeDetection(); // Start monitoring camera changes.
        }
        public void StartAudioRecording()
        {
            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100,
            NAudio.Wave.WaveIn.GetCapabilities(AudioInputDeviceComboBox.SelectedIndex).Channels);
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            sourceStream.StartRecording();
        }

        private void AudioCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sourceStream != null)
                sourceStream.StopRecording();
            
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }
            // Stop monitoring hardware changes.
            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }

        private void AudioInputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourceStream != null)
                sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
        }

        private void AudioOutputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleWaveOut();
        }
        private void HandleWaveOut()
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }

            int selectedDeviceIndex = AudioOutputDeviceComboBox.SelectedIndex;
            _waveOut = new DirectSoundOut(_outputDeviceGuids[selectedDeviceIndex]); //to add here -1 if deleting computer main

            this._waveOut.Init(provider);
            this._waveOut.Play();
        }

        private void MicrophoneModeCustomButton_Click(object sender, EventArgs e)
        {

            if (!isMuted)
            {
                MicrophoneModeCustomButton.BackgroundImage = MicrophoneOpen;
                sourceStream.StopRecording();
            }
            else
            {
                MicrophoneModeCustomButton.BackgroundImage = MicrophoneNotOpen;
                sourceStream.StartRecording();
            }
            isMuted = !isMuted;
        }
    }
}
