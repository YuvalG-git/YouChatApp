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
        private static int startingPort = 12345; // Set the starting port you want to use
        private static int localPort;
        public static string symmetricKey;
        public static int GetLocalPort()
        {
            return localPort;
        }
        public static int ConnectUdp(string ip,VideoCall videoCall)
        {
            _videoCall = videoCall;
            _udpIsOn = true;
            for (int i = startingPort; i < startingPort + 1000; i++) // Try ports in the range startingPort to startingPort + 1000
            {
                udpClient = new UdpClient();
                try
                {
                    _udpIsOn = true;
                    udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, i));
                    remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12000);
                    udpClient.Connect(remoteEndPoint);
                    localPort = i;
                    udpClient.BeginReceive(new AsyncCallback(ReceiveVideoUdpMessage), null);//starts async listen too screen/camera sharing.
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



        public static void SendVideo(byte[] data)
        {
            if (_udpIsOn)
            {
                try
                {
                    byte[] buffer = Encryption.Encryption.EncryptDataToBytes(symmetricKey, data);
                    udpClient.Send(buffer, buffer.Length/*, remoteEndPoint*/);


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
                            receivedData = Encryption.Encryption.DecryptDataToBytes(symmetricKey, receivedData);

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
