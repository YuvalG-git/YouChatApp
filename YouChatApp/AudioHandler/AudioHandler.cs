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
            foreach (var deviceInfo in DirectSoundOut.Devices)
            {
                _outputDeviceGuids.Add(deviceInfo.Guid);
                AudioOutputDeviceComboBox.Items.Add(deviceInfo.Description); //can tell it to delete the first (the computers main)
            }
            AudioOutputDeviceComboBox.SelectedIndex = 0;
        }
     

        public static void StartAudioRecording(ComboBox AudioInputDeviceComboBox, ref WaveIn sourceStream, EventHandler<NAudio.Wave.WaveInEventArgs> sourceStream_DataAvailable)
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
            AudioServerCommunication.Close();

            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }
            if (sourceStream != null)
                sourceStream.StopRecording();
            // Stop monitoring hardware changes.
            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }
        public static void HandleSourceStreamDataAvailable(NAudio.Wave.WaveInEventArgs e, WaveIn sourceStream, bool isMuted)
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
        public static void HandleWaveOutPhaseOne(DirectSoundOut _waveOut)
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }
        }
        public static void HandleWaveOutPhaseTwo(DirectSoundOut _waveOut, BufferedWaveProvider provider)
        {
            _waveOut.Init(provider);
            _waveOut.Play();
        }
        public static void HandleMicrophoneModeCustomButtonClick(ref WaveIn sourceStream, ref bool isMuted, CustomButton MicrophoneModeCustomButton, ComboBox AudioInputDeviceComboBox, EventHandler<NAudio.Wave.WaveInEventArgs> sourceStream_DataAvailable)
        {
            try
            {
                if (!isMuted)
                {
                    MicrophoneModeCustomButton.BackgroundImage = MicrophoneOpen;
                    sourceStream.StopRecording();
                }
                else
                {
                    MicrophoneModeCustomButton.BackgroundImage = MicrophoneNotOpen;
                    //sourceStream.StartRecording();
                    StartAudioRecording(AudioInputDeviceComboBox, ref sourceStream, sourceStream_DataAvailable); //was a problen with "sourceStream.StartRecording();" because sometimes the process didn't work and it hasn't started recording so i decided to "recreate" the object
                }
                isMuted = !isMuted; // Toggle the mute state
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                Console.WriteLine("Error starting or stopping recording: " + ex.Message);
            }
        }
    }
}
