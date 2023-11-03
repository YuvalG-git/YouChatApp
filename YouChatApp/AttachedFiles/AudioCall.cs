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

namespace YouChatApp.AttachedFiles
{
    public partial class AudioCall : Form
    {
        private WaveInEvent waveIn;
        private bool isMuted;
        private WaveOut waveOut;
        private List<WaveInCapabilities> inputDevices;
        private List<WaveOutCapabilities> outputDevices;
        private ManagementEventWatcher watcher;
        public DirectSoundOut _waveOut;//object incharge of playing audio wave
        private BufferedWaveProvider provider;//incharge of converting the byte array of audio to
        private WaveIn sourceStream;//incarge of recoring audio //todo - to use this in order to fix sound...

        Image MicrophoneNotOpen = global::YouChatApp.Properties.Resources.MicrophoneClose;
        Image MicrophoneOpen = global::YouChatApp.Properties.Resources.MicrophoneOpen;
      
        public AudioCall()
        {
            InitializeComponent();


            isMuted = false;
            CallEnderCustomButton.BorderRadius = 40;
            //StartAudioRecording();

        }
        //public void StartAudioRecording()
        //{
        //    sourceStream = new WaveIn();
        //    sourceStream.DeviceNumber = micIndex;
        //    sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(micIndex).Channels);
        //    sourceStream.DataAvailable += new
        //   EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
        //    sourceStream.StartRecording();
        //}
        ///// <summary>
        ///// update mic while recording
        ///// </summary>
        //public void UpdateRecordingDevice()
        //{
        //    if (sourceStream != null)
        //        sourceStream.DeviceNumber = micIndex;
        //}
        ///// <summary>
        ///// takes voice data from source stream and sends to server
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        //{
        //    if (sourceStream == null) return;
        //    try
        //    {
        //        byte[] EncryptedData = main.aes.EncryptBytes(e.Buffer);
        //        audioUdpClient.Send(EncryptedData, EncryptedData.Length);//sending data UPD
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
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
            AudioInputDeviceComboBox.SelectedIndex = 0;
            waveIn.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
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
            AudioOutputDeviceComboBox.SelectedIndex = 0;
            waveOut.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;

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
            InitializeAudioList(); // Refresh the camera list.
        }

        public void Start()
        {
            waveIn.StartRecording();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            AudioServerCommunication.SendAudio(e.Buffer, e.BytesRecorded);
        }

        public void Stop()
        {
            waveIn.StopRecording();
        }
        public void ToggleMute()
        {
            if (isMuted)
            {
                // Unmute
                waveIn.StartRecording();
            }
            else
            {
                // Mute
                waveIn.StopRecording();
            }
            isMuted = !isMuted;
        }
        public void ReceiveAudioData(byte[] receivedData)
        {
            // Process and play the received audio data using NAudio

            // Add your NAudio playback logic here
            // For example:


            waveOut.Init(new RawSourceWaveStream(new MemoryStream(receivedData), new WaveFormat(44100, 16, 1)));
            waveOut.Play();

            //provider.AddSamples(receivedData, 0, receivedData.Length);
            //_waveOut.Play();
        }

        private void AudioCall_Load(object sender, EventArgs e)
        {
            AudioServerCommunication.ConnectUdp("10.100.102.3", this);

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += WaveIn_DataAvailable;
            Start();
            waveOut = new WaveOut();
            this.provider = new BufferedWaveProvider(new WaveFormat(44100, 16, 2));
            this.provider.DiscardOnBufferOverflow = true;
            this._waveOut = new DirectSoundOut();
            this._waveOut.Init(provider);
            this._waveOut.Play();

            InitializeAudioList();
            InitializeAudioDevicesChangeDetection(); // Start monitoring camera changes.
        }

        private void AudioCall_FormClosing(object sender, FormClosingEventArgs e)
        {
            waveIn.StopRecording();



            // Stop monitoring hardware changes.
            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }

        private void AudioInputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            waveIn.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
        }

        private void AudioOutputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            waveOut.DeviceNumber = AudioOutputDeviceComboBox.SelectedIndex;
        }

        private void MicrophoneModeCustomButton_Click(object sender, EventArgs e)
        {
            if (isMuted == false)
                isMuted = true;
            else
                isMuted = false;
            if (isMuted == true)
            {
                MicrophoneModeCustomButton.BackgroundImage = MicrophoneNotOpen;
            }
            else
            {
                MicrophoneModeCustomButton.BackgroundImage = MicrophoneOpen;
            }
            //StartAudioSource();
        }
    }
}
