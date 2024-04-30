using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.AttachedFiles;
using System.Drawing;
using System.Threading;
using Newtonsoft.Json;
using YouChatApp.JsonClasses;

namespace YouChatApp
{
    internal class AudioServerCommunication
    {
        #region Private Const Fields

        private const int startingPort = 12345;
        private const int lastPort = 65535;

        #endregion

        #region Private Static Fields

        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint;
        private static VideoCall _videoCall;
        private static AudioCall _audioCall;

        private static int localPort;
        #endregion

        #region Public Static Fields
        public static bool _udpIsOn = false;

        public static string symmetricKey;

        #endregion

        #region Public Static Get Methods

        public static int GetLocalPort()
        {
            return localPort;
        }

        #endregion

        #region Public Static Connect Methods
        public static int ConnectUdp(string ip, VideoCall videoCall)
        {
            _videoCall = videoCall;
            _audioCall = null;
            return HandleConnect(ip);
        }
        public static int ConnectUdp(string ip, AudioCall audioCall)
        {
            _videoCall = null;
            _audioCall = audioCall;
            return HandleConnect(ip);
        }
        private static int HandleConnect(string ip)
        {
            for (int i = startingPort; i < lastPort; i++) 
            {
                udpClient = new UdpClient();
                try
                {
                    _udpIsOn = true;
                    udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, i));
                    remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 11000);
                    udpClient.Connect(remoteEndPoint);
                    localPort = i;
                    udpClient.BeginReceive(new AsyncCallback(ReceiveAudio), null);
                    Console.WriteLine($"UDP client started on port {localPort}");
                    break; // Exit the loop if binding is successful
                }
                catch (SocketException)
                {
                    Console.WriteLine($"Failed to bind UDP client to port {i}. Trying next port...");
                    // Continue to the next port
                }
            }
            return localPort;   
        }

        #endregion

        #region Public Static Communication Methods

        public static void SendAudio(byte[] data, int dataLength)
        {
            if (_udpIsOn)
            {
                try
                {
                    byte[] buffer = Encryption.Encryption.EncryptDataToBytes(symmetricKey, data);
                    udpClient.Send(buffer, buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data: {ex.Message}");
                }
            }

        }
        public static void ReceiveAudio(IAsyncResult ar)
        {
            while (true)
            {
                if (_udpIsOn)
                {
                    try
                    {
                        byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                        // Decrypt the received data using the client's key
                        receivedData = Encryption.Encryption.DecryptDataToBytes(symmetricKey, receivedData);
                        if (_videoCall != null) 
                        {
                            _videoCall.Invoke((Action)delegate { _videoCall.ReceiveAudioData(receivedData); });
                        }
                        else if (_audioCall != null)
                        {
                            _audioCall.Invoke((Action)delegate { _audioCall.ReceiveAudioData(receivedData); });
                        }
                    }
                    catch (SocketException ex)
                    {
                        if (ex.ErrorCode == 10004) // WSACancelBlockingCall
                        {
                            // Handle the WSACancelBlockingCall exception
                            // For example, log the error or take appropriate action
                            Console.WriteLine("WSACancelBlockingCall exception occurred: " + ex.Message);
                        }
                        else
                        {
                            // Handle other SocketException errors
                            Console.WriteLine("SocketException occurred: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle other exceptions
                        Console.WriteLine("Exception occurred: " + ex.Message);
                    }
                }
            }
        }

        public static void Close()
        {
            if (udpClient != null)
            {
                _udpIsOn = false;
                udpClient.Close();
                udpClient.Dispose();
            }
        }

        #endregion
    }
}
