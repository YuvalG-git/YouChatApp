using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using YouChatApp.AttachedFiles;

namespace YouChatApp
{
    internal class VideoServerCommunication
    {
        public static bool _udpIsOn = false;
        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint;
        private static VideoCall _videoCall;
        public static void ConnectUdp(string ip,VideoCall videoCall)
        {
            _videoCall = videoCall;
            _udpIsOn = true;
            udpClient = new UdpClient();
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12000);
            udpClient.Connect(remoteEndPoint);
            udpClient.BeginReceive(new AsyncCallback(ReceiveVideoUdpMessage), null);//starts async listen too screen/camera sharing.
        }


        /// <summary>
        /// The BeginRead method initiates an asynchronous read operation on the network stream associated with the client
        /// It reads data into the Data buffer and calls the ReceiveMessage method when the read operation is complete       
        /// </summary>



        public static void SendVideo(byte[] data)
        {
            if (_udpIsOn)
            {
                try
                {
                    udpClient.Send(data, data.Length/*, remoteEndPoint*/);


                    // Send data to the client
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data: {ex.Message}");
                }
            }

        }
        public static void ReceiveVideoUdpMessage(IAsyncResult ar)
        {
            while (true)
            {
                if (_udpIsOn)
                {
                    // Receive the image from the server
                    try
                    {
                        if (_videoCall != null)
                        {
                            byte[] receivedData = udpClient.Receive(ref remoteEndPoint);

                            using (MemoryStream ms = new MemoryStream(receivedData))
                            {
                                Image receivedImage = Image.FromStream(ms);
                                _videoCall.Invoke((Action)delegate { _videoCall.HandleReceivedImage(receivedImage); }); //todo System.ObjectDisposedException excteption comes... needs to handle better
                            }
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
