using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    internal class VideoAndAudioServerCommunication
    {
        public static bool _udpIsOn = false;
        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint;
        public static void ConnectUdp(string ip)
        {
            _udpIsOn = true;
            //UdpClient.Connect(ip, 1501);
            udpClient = new UdpClient();
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
        }


        /// <summary>
        /// The BeginRead method initiates an asynchronous read operation on the network stream associated with the client
        /// It reads data into the Data buffer and calls the ReceiveMessage method when the read operation is complete       
        /// </summary>


        public static void SendMessageThroughtUdp(string message)
        {
            if (_udpIsOn)
            {
                try
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                    udpClient.Send(sendBytes, sendBytes.Length);


                    // Send data to the client
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static void SendImage(Image image)
        {
            if (_udpIsOn)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] imageData = ms.ToArray();

                        // Specify the server's IP and port
                        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("server_ip"), 12345);

                        // Send the image data
                        udpClient.Send(imageData, imageData.Length, serverEndPoint);
                    }


                    // Send data to the client
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data: {ex.Message}");
                }
            }

        }


        // Send a UDP datagram to the remote endpoint
        public static void Send(string message)
        {
            if (_udpIsOn)
            {
                try
                {
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    udpClient.Send(data, data.Length, remoteEndPoint);


                    // Send data to the client
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data: {ex.Message}");
                }
            }

        }


        // Receive a UDP datagram from the remote endpoint
        public static string Receive()
        {
            try
            {
                byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                string receivedMessage = Encoding.ASCII.GetString(receivedData);
                Console.WriteLine($"Received: {receivedMessage}");
                return receivedMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving data: {ex.Message}");
                return null;
            }
        }

        // Close the UDP client when done
        public void Close()
        {
            _udpIsOn = false;
            udpClient.Close();
        }
    }
}
