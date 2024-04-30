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
    /// <summary>
    /// The "AudioHandler" class provides static methods for managing audio devices and audio data in the YouChatApp application.
    /// </summary>
    /// <remarks>
    /// This class includes methods for initializing audio input and output devices, starting and stopping audio recording, handling audio data events, and managing microphone mode.
    /// It also handles cleanup operations when the form is closing, such as closing the audio server communication, stopping and disposing the audio output device, stopping audio recording, and disposing the management event watcher.
    /// </remarks>
    internal class AudioHandler
    {
        #region Private Static Fields

        /// <summary>
        /// The static List "inputDevices" stores the available input devices for recording audio.
        /// </summary>
        private static List<WaveInCapabilities> inputDevices;

        #endregion

        #region Private Static Readonly Fields

        /// <summary>
        /// The static readonly Image "MicrophoneNotOpen" represents the image for a closed microphone.
        /// </summary>
        private static readonly Image MicrophoneNotOpen = global::YouChatApp.Properties.Resources.MicrophoneClose;

        /// <summary>
        /// The static readonly Image "MicrophoneOpen" represents the image for an open microphone.
        /// </summary>
        private static readonly Image MicrophoneOpen = global::YouChatApp.Properties.Resources.MicrophoneOpen;

        #endregion

        #region Public Static Audio Devices Methods

        /// <summary>
        /// The "InitializeAudioInputDeviceList" method initializes the list of available audio input devices and populates a ComboBox with their names.
        /// </summary>
        /// <param name="AudioInputDeviceComboBox">The ComboBox control to populate with device names.</param>
        /// <param name="sourceStream">The WaveIn instance used for audio capture.</param>
        /// <remarks>
        /// This method initializes a list of WaveInCapabilities representing available audio input devices.
        /// It clears the items in the specified ComboBox and adds the names of the available input devices to it.
        /// The method then sets the selected index of the ComboBox to 0 and assigns the selected device number to the WaveIn instance.
        /// </remarks>
        public static void InitializeAudioInputDeviceList(ComboBox AudioInputDeviceComboBox, WaveIn sourceStream)
        {
            // Initialize the list of input devices and clear the ComboBox
            inputDevices = new List<WaveInCapabilities>();
            AudioInputDeviceComboBox.Items.Clear();

            // Populate the inputDevices list with the capabilities of each input device
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                inputDevices.Add(WaveIn.GetCapabilities(i));
            }

            // Add the names of the input devices to the ComboBox
            foreach (WaveInCapabilities device in inputDevices)
            {
                AudioInputDeviceComboBox.Items.Add(device.ProductName);
            }

            // Set the selected index of the ComboBox to 0
            AudioInputDeviceComboBox.SelectedIndex = 0;

            // Assign the selected device number to the WaveIn instance
            sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
        }

        /// <summary>
        /// The "InitializeAudioOutputDeviceList" method initializes the list of available audio output devices and populates a ComboBox with their names.
        /// </summary>
        /// <param name="AudioOutputDeviceComboBox">The ComboBox control to populate with device names.</param>
        /// <param name="_outputDeviceGuids">The list to store the GUIDs of the available output devices.</param>
        /// <remarks>
        /// This method clears the items in the specified ComboBox and adds the names of the available output devices to it.
        /// It also populates the _outputDeviceGuids list with the GUIDs of the available output devices.
        /// The method then sets the selected index of the ComboBox to 0.
        /// </remarks>
        public static void InitializeAudioOutputDeviceList(ComboBox AudioOutputDeviceComboBox, List<Guid> _outputDeviceGuids)
        {
            // Clear the items in the ComboBox
            AudioOutputDeviceComboBox.Items.Clear();

            // Populate the ComboBox with the names of the available output devices
            foreach (var deviceInfo in DirectSoundOut.Devices)
            {
                _outputDeviceGuids.Add(deviceInfo.Guid);
                AudioOutputDeviceComboBox.Items.Add(deviceInfo.Description);
            }

            // Set the selected index of the ComboBox to 0
            AudioOutputDeviceComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// The "HandleAudioInputDeviceComboBoxSelectedIndexChanged" method handles the event when the selected index of the audio input device ComboBox changes, updating the device number of the source stream if it is not null.
        /// </summary>
        /// <param name="sourceStream">The WaveIn instance used for audio capture.</param>
        /// <param name="AudioInputDeviceComboBox">The ComboBox control containing the selected input device.</param>
        /// <remarks>
        /// This method updates the device number of the sourceStream to match the selected index of the AudioInputDeviceComboBox if the sourceStream is not null.
        /// </remarks>
        public static void HandleAudioInputDeviceComboBoxSelectedIndexChanged(WaveIn sourceStream, ComboBox AudioInputDeviceComboBox)
        {
            if (sourceStream != null)
                sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
        }

        #endregion

        #region Public Static Audio Recording Methods

        /// <summary>
        /// The "StartAudioRecording" method starts audio recording using the specified input device.
        /// </summary>
        /// <param name="AudioInputDeviceComboBox">The ComboBox control containing the selected input device.</param>
        /// <param name="sourceStream">The WaveIn instance used for audio capture.</param>
        /// <param name="sourceStream_DataAvailable">The event handler for handling data available events.</param>
        /// <remarks>
        /// This method creates a new WaveIn instance for audio capture and configures it with the selected input device.
        /// It sets up the WaveFormat for the audio stream based on the input device's capabilities.
        /// The method then subscribes to the DataAvailable event with the specified event handler and starts recording audio.
        /// </remarks>
        public static void StartAudioRecording(ComboBox AudioInputDeviceComboBox, ref WaveIn sourceStream, EventHandler<NAudio.Wave.WaveInEventArgs> sourceStream_DataAvailable)
        {
            // Create a new WaveIn instance for audio capture
            sourceStream = new NAudio.Wave.WaveIn();

            // Set the device number and WaveFormat for the audio stream
            sourceStream.DeviceNumber = AudioInputDeviceComboBox.SelectedIndex;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100,
                NAudio.Wave.WaveIn.GetCapabilities(AudioInputDeviceComboBox.SelectedIndex).Channels);

            // Subscribe to the DataAvailable event with the specified event handler
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);

            // Start recording audio
            sourceStream.StartRecording();
        }

        /// <summary>
        /// The "HandleSourceStreamDataAvailable" method handles the event when audio data is available from the source stream, sending the audio data to the audio server communication if not muted.
        /// </summary>
        /// <param name="e">The WaveInEventArgs containing the audio data.</param>
        /// <param name="sourceStream">The WaveIn instance used for audio capture.</param>
        /// <param name="isMuted">A flag indicating whether audio is muted.</param>
        /// <remarks>
        /// This method checks if the sourceStream is null and returns early if it is.
        /// If audio is not muted, it sends the audio data from the WaveInEventArgs (e) to the audio server communication using the SendAudio method.
        /// If an exception occurs during the operation, it displays a message box with the exception details.
        /// </remarks>
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

        /// <summary>
        /// The "HandleWaveOutPhaseOne" method handles phase one of stopping and disposing the audio output device.
        /// </summary>
        /// <param name="_waveOut">The DirectSoundOut instance used for audio output.</param>
        /// <remarks>
        /// This method stops and disposes the audio output device (_waveOut) if it is not null.
        /// </remarks>
        public static void HandleWaveOutPhaseOne(DirectSoundOut _waveOut)
        {
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }
        }

        /// <summary>
        /// The "HandleWaveOutPhaseTwo" method handles phase two of initializing and starting playback on the audio output device.
        /// </summary>
        /// <param name="_waveOut">The DirectSoundOut instance used for audio output.</param>
        /// <param name="provider">The BufferedWaveProvider used to buffer audio data for playback.</param>
        /// <remarks>
        /// This method initializes the audio output device (_waveOut) with the specified BufferedWaveProvider (provider) and starts playback.
        /// </remarks>
        public static void HandleWaveOutPhaseTwo(DirectSoundOut _waveOut, BufferedWaveProvider provider)
        {
            _waveOut.Init(provider);
            _waveOut.Play();
        }

        /// <summary>
        /// The "HandleReceivedAudioData" method handles received audio data by adding the data to the audio provider and playing it through the specified audio output device.
        /// </summary>
        /// <param name="receivedData">The byte array containing the received audio data.</param>
        /// <param name="_waveOut">The DirectSoundOut instance used for audio output.</param>
        /// <param name="provider">The BufferedWaveProvider used to buffer audio data for playback.</param>
        /// <remarks>
        /// This method adds the received audio data to the BufferedWaveProvider (provider) to be played through the audio output device (_waveOut).
        /// It then starts playing the audio if the audio output device (_waveOut) is not null.
        /// </remarks>
        public static void HandleReceivedAudioData(byte[] receivedData, DirectSoundOut _waveOut, BufferedWaveProvider provider)
        {
            if (_waveOut != null)
            {
                provider.AddSamples(receivedData, 0, receivedData.Length);
                _waveOut.Play();
            }
        }

        #endregion

        #region Public Static Form Methods

        /// <summary>
        /// The "HandleFormClosing" method handles cleanup operations when the form is closing, including closing the audio server communication, stopping and disposing the audio output device, stopping audio recording, and disposing the management event watcher.
        /// </summary>
        /// <param name="sourceStream">The WaveIn instance used for audio capture.</param>
        /// <param name="_waveOut">The DirectSoundOut instance used for audio output.</param>
        /// <param name="watcher">The ManagementEventWatcher instance used for monitoring system events.</param>
        /// <remarks>
        /// This method closes the audio server communication channel.
        /// It stops and disposes the audio output device ("_waveOut") if it is not null.
        /// It stops audio recording using the sourceStream if it is not null.
        /// It stops and disposes the management event watcher ("watcher") if it is not null.
        /// </remarks>
        public static void HandleFormClosing(WaveIn sourceStream, DirectSoundOut _waveOut, ManagementEventWatcher watcher)
        {
            // Close the audio server communication
            AudioServerCommunication.Close();

            // Stop and dispose the audio output device
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
            }

            // Stop audio recording
            if (sourceStream != null)
                sourceStream.StopRecording();

            // Stop and dispose the management event watcher
            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }

        /// <summary>
        /// The "HandleMicrophoneModeCustomButtonClick" method handles the button click event for toggling the microphone mode between open and muted.
        /// </summary>
        /// <param name="sourceStream">The WaveIn instance used for audio capture.</param>
        /// <param name="isMuted">A flag indicating whether audio is currently muted.</param>
        /// <param name="MicrophoneModeCustomButton">The CustomButton control used for toggling the microphone mode.</param>
        /// <param name="AudioInputDeviceComboBox">The ComboBox control containing the selected input device.</param>
        /// <param name="sourceStream_DataAvailable">The event handler for handling data available events from the source stream.</param>
        /// <remarks>
        /// This method toggles the microphone mode between open and muted.
        /// If the microphone is currently open, it stops audio recording, updates the button image, and sets the isMuted flag to true.
        /// If the microphone is currently muted, it starts audio recording, updates the button image, and sets the isMuted flag to false.
        /// </remarks>
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

        #endregion
    }
}
