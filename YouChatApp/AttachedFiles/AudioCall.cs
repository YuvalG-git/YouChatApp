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

namespace YouChatApp.AttachedFiles
{
    public partial class AudioCall : Form
    {
        private WaveInEvent waveIn;
        private UdpClient udpClient;
        private IPEndPoint receiverEndPoint;
        private bool isMuted;
        private WaveOut waveOut;


        public AudioCall()
        {
            InitializeComponent();

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveOut = new WaveOut();

            udpClient = new UdpClient();
            receiverEndPoint = new IPEndPoint(IPAddress.Parse("Receiver's_IP"), 12345);

            isMuted = false;
        }

        public void Start()
        {
            waveIn.StartRecording();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            udpClient.Send(e.Buffer, e.BytesRecorded, receiverEndPoint);
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
        }
    }
}
