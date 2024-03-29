using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Controls;

namespace YouChatApp.AudioHandler
{
    internal class AudioHandler
    {
        private static List<WaveInCapabilities> inputDevices;
        private static Image MicrophoneNotOpen = global::YouChatApp.Properties.Resources.MicrophoneClose;
        private static Image MicrophoneOpen = global::YouChatApp.Properties.Resources.MicrophoneOpen;
        public static void InitializeAudioInputDeviceList(ComboBox AudioInputDeviceComboBox, WaveIn sourceStream)
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
            sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
        }
        public static void InitializeAudioOutputDeviceList(ComboBox AudioOutputDeviceComboBox, List<Guid> _outputDeviceGuids)
        {
            _outputDeviceGuids = new List<Guid>();
            foreach (var deviceInfo in DirectSoundOut.Devices)
            {
                _outputDeviceGuids.Add(deviceInfo.Guid);
                AudioOutputDeviceComboBox.Items.Add(deviceInfo.Description); //can tell it to delete the first (the computers main)
            }
            AudioOutputDeviceComboBox.SelectedIndex = 0;
        }
     

        public static void StartAudioRecording(ComboBox AudioInputDeviceComboBox, WaveIn sourceStream, EventHandler<NAudio.Wave.WaveInEventArgs> sourceStream_DataAvailable)
        {
            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100,
            NAudio.Wave.WaveIn.GetCapabilities(AudioInputDeviceComboBox.SelectedIndex).Channels);
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            sourceStream.StartRecording();
        }
        public static void HandleFormClosing(WaveIn sourceStream, DirectSoundOut _waveOut, ManagementEventWatcher watcher)
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
        public static void HandleAudioInputDeviceComboBoxSelectedIndexChanged(WaveIn sourceStream, ComboBox AudioInputDeviceComboBox)
        {
            if (sourceStream != null)
                sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
        }
        public static void HandleReceivedAudioData(byte[] receivedData, DirectSoundOut _waveOut, BufferedWaveProvider provider)
        {
            if (_waveOut != null)
            {
                provider.AddSamples(receivedData, 0, receivedData.Length);
                _waveOut.Play();
            }
        }
        public static void HandleWaveOut(DirectSoundOut _waveOut, ComboBox AudioOutputDeviceComboBox, List<Guid> _outputDeviceGuids, BufferedWaveProvider provider)
        {

            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }

            int selectedDeviceIndex = AudioOutputDeviceComboBox.SelectedIndex;
            _waveOut = new DirectSoundOut(_outputDeviceGuids[selectedDeviceIndex]); //to add here -1 if deleting computer main

            _waveOut.Init(provider);
            _waveOut.Play();
        }
        public static void HandleMicrophoneModeCustomButtonClick(WaveIn sourceStream, bool isMuted, CustomButton MicrophoneModeCustomButton)
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
