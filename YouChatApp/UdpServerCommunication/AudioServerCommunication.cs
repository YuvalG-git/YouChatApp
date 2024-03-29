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

namespace YouChatApp
{
    internal class AudioServerCommunication
    {
        public static bool _udpIsOn = false;
        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint;
        private static VideoCall _videoCall;
        private static AudioCall _audioCall;
        private static bool _isVideoCall;

        public static void ConnectUdp(string ip, VideoCall videoCall)
        {
            _videoCall = videoCall;
            _audioCall = null;
            _isVideoCall = true;
            HandleConnect(ip);
        }
        public static void ConnectUdp(string ip, AudioCall audioCall)
        {
            _videoCall = null;
            _audioCall = audioCall;
            _isVideoCall = false;
            HandleConnect(ip);
        }
        private static void HandleConnect(string ip)
        {
            _udpIsOn = true;
            udpClient = new UdpClient();
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 11000);
            udpClient.Connect(remoteEndPoint);
            udpClient.BeginReceive(new AsyncCallback(ReceiveAudio), null);//starts async listen too screen/camera sharing.
        }


        /// <summary>
        /// The BeginRead method initiates an asynchronous read operation on the network stream associated with the client
        /// It reads data into the Data buffer and calls the ReceiveMessage method when the read operation is complete       
        /// </summary>



        public static void SendAudio(byte[] data, int dataLength)
        {
            if (_udpIsOn)
            {
                try
                {
                    udpClient.Send(data, dataLength/*, remoteEndPoint*/);


                    // Send data to the client
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
                    // Receive the image from the server
                    try
                    {
                        byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                        if (_videoCall != null) //maybe i should use interface for this... in order to not check each time but just
                        {
                            //_videoCall.Invoke((Action)delegate { _videoCall.HandleReceivedImage(receivedImage); });
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

        // Close the UDP client when done
        public static void Close()
        {
            if (udpClient != null)
            {
                _udpIsOn = false;
                udpClient.Close();
                udpClient.Dispose();
            }
        }
    }
}
