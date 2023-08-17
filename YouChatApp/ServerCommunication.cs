using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    internal class ServerCommunication
    {
        /// <summary>
        /// Request/Response kinds' which are used in sending and recieving messages
        /// </summary>
        public const int registerRequest = 1;
        public const int registerResponse = 2;
        public const int loginRequest = 3;
        public const int loginResponse = 4;
        public const int colorRequest = 5;
        public const int colorResponse = 6;
        public const int playersNumRequest = 7;
        public const int playersNumResponse = 8;
        public const int boardSizeSender = 9;
        public const int boardSizeRequest = 10;
        public const int boardSizeResponse = 11;
        public const int oppenentDetailsRequest = 12;
        public const int oppenentDetailsResponse = 13;
        public const int coordinatesSender = 14;
        public const int coordinatesReciever = 15;
        public const int skipTurnSender = 16;
        public const int skipTurnReciever = 17;
        public const int endGameRequest = 18;
        public const int endGameResponse = 19;
        public const int disconnectRequest = 20;
        public const int loadingModeRequest = 21;
        public const int lastGameRequest = 22;
        public const int lastGameResponse = 23;
        public const int anotherGameRequest = 24;
        public const int anotherGameResponse = 25;
        public const int leaveGameRequest = 26;
        public const int disconnectResponse = 27;
        public const int sendMessageRequest = 28;
        public const int sendMessageResponse = 29;
        public const int ResetPasswordRequest = 30;
        public const int resetPasswordResponse = 31;

        const string registerResponse1 = "Your registeration has completed successfully \nPlease press the back button to return to the home screen and login";
        const string registerResponse2 = "Your registeration has failed \nPlease try again ";
        const string loginResponse1 = "The login has been successfully completed";
        const string loginResponse2 = "The login has failed";
        const string colorResponse1 = "You have chosen the coolest color";
        const string colorResponse2 = "An error occurred to happen \nChoose a new Color";
        const string colorResponse3 = "Your oppoenent has already chosen this color \nPlease choose a diffrenet color";

        /// <summary>
        /// Object which represents the server's TCP client
        /// </summary>
        private static TcpClient Client { get; set; }

        /// <summary>
        /// Byte array which represents the data received from the server
        /// </summary>
        private static byte[] Data;

        /// <summary>
        /// Declares a variable of type LoginRegistPage which represents the loginRegistPage form's object and is used to perform actions on the form
        /// </summary>
        public static LoginAndRegistration loginAndRegistration;

        public static Profile profile;

        public static YouChat youChat;


        /// <summary>
        /// Represents the player's name
        /// </summary>
        public static string name;

        /// <summary>
        /// Represents the oppoenent's username
        /// </summary>
        public static string OppenentName;

        /// <summary>
        /// A boolean variable which represents the player's need in the game board's size
        /// </summary>
        public static Boolean noNeededSize;

        /// <summary>
        /// Represents the player's color
        /// </summary>
        public static Color myColor;

        /// <summary>
        /// Represents the oppoenents's color
        /// </summary>
        public static Color oppenentColor;

        /// <summary>
        /// Represents the game board's size
        /// </summary>
        public static int size;


        /// <summary>
        /// Represents the X coordinate of the board 
        /// </summary>
        public static int xCord = 100;

        /// <summary>
        /// Represents the Y coordinate of the board 
        /// </summary>
        public static int yCord = 300;

        /// <summary>
        /// Represents the player's number, meaning if he is the first player to play, or the second one
        /// </summary>
        public static int playerNum;

        /// <summary>
        /// Represents if the client is connected
        /// </summary>
        private static Boolean isConnected = true;

        /// <summary>
        /// The Connect method attempts to establish a TCP/IP connection with a server using the provided IP addressand port: 1500
        /// If the connection attempt fails, a MessageBox is displayed to the user
        /// This method also creates a byte array to hold incoming data and begins an asynchronous read operation on the client's NetworkStream using the BeginRead method
        /// The Connect method attempts to establish a TCP/IP connection with a server using the provided IP address
        /// </summary>
        /// <param name="ip">Represents the ip address of the server to connect to</param>
        /// <returns>It returns true if the connection is successful. Otherwise, it returns false</returns>
        public static bool Connect(string ip)
        {
            Client = new TcpClient();
            try
            {
                Client.Connect(ip, 1500);
            }
            catch
            {
                MessageBox.Show("There wasn't a server in this address...\nPlease Try Again", "Connection try");
            }
            if (!Client.Connected)
                return false;
            Data = new byte[Client.ReceiveBufferSize];
            // BeginRead will begin async read from the NetworkStream
            // This allows the server to remain responsive and continue accepting new connections from other clients
            // When reading complete control will be transfered to the ReviveMessage() function.
            Client.GetStream().BeginRead(Data,
                                          0,
                                          System.Convert.ToInt32(Client.ReceiveBufferSize),
                                          ReceiveMessage,
                                          null);
            return true;
        }

        /// <summary>
        /// The BeginRead method initiates an asynchronous read operation on the network stream associated with the client
        /// It reads data into the Data buffer and calls the ReceiveMessage method when the read operation is complete       
        /// </summary>
        public static void BeginRead()
        {
            Client.GetStream().BeginRead(Data,
                                                      0,
                                                      System.Convert.ToInt32(Client.ReceiveBufferSize),
                                                      ReceiveMessage,
                                                      null);
        }

        /// <summary>
        /// The ReceiveMessage method recieves and handles the incomming stream
        /// </summary>
        /// <param name="ar">IAsyncResult Interface</param>
        private static void ReceiveMessage(IAsyncResult ar)
        {
            if (Client != null)
            {
                int bytesRead;
                try
                {
                    lock (Client.GetStream())
                    {
                        // call EndRead to handle the end of an async read.
                        bytesRead = Client.GetStream().EndRead(ar);
                    }
                    // if bytesread<1 -> the client disconnected
                    if (bytesRead < 1)
                    {
                        MessageBox.Show("Server is down.", "Server Communication");
                        Disconnect();
                        return;
                    }
                    else // client still connected
                    {
                        string incomingData = System.Text.Encoding.ASCII.GetString(Data, 0, bytesRead);
                        string[] messageToArray = incomingData.Split('$');
                        int requestNumber = Convert.ToInt32(messageToArray[0]);
                        string messageDetails = messageToArray[1];
                        if (requestNumber == registerResponse)
                        {
                            if (messageDetails == registerResponse1)
                            {
                                MessageBox.Show(messageDetails);
                                loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
                            }
                            else if (messageDetails == registerResponse2)
                            {
                                MessageBox.Show(messageDetails);
                                loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.setRegistButtonEnabled(); });
                            }
                        }
                        else if (requestNumber == loginResponse)
                        {
                            if (messageDetails == loginResponse1)
                            {
                                MessageBox.Show(messageDetails);
                                loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
                            }
                            else if (messageDetails == loginResponse2)
                            {
                                MessageBox.Show(messageDetails + "\nYou probably wrote the wrong username or password \nIn case you don't have an account yet, please sign up");
                                loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.setLoginButtonEnabled(); });
                            }
                        }
                        else if (requestNumber == sendMessageResponse)
                        {
                            youChat.Invoke((Action)delegate { youChat.Message3(messageDetails); });
                        }
                        else if (requestNumber == resetPasswordResponse)
                        {

                        }

                    }
                    if (isConnected)
                    {
                        lock (Client.GetStream())
                        {
                            // continue reading from the client
                            Client.GetStream().BeginRead(Data, 0, System.Convert.ToInt32(Client.ReceiveBufferSize), ReceiveMessage, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
                }
            }
        }

        /// <summary>
        /// The SendMessage method sends a message to the server
        /// </summary>
        /// <param name="message">Represents the message the client sends to the server</param>
        public static void SendMessage(string message)
        {
            if (isConnected)
            {
                try
                {
                    NetworkStream ns = Client.GetStream();

                    // Send data to the client
                    byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                    ns.Write(bytesToSend, 0, bytesToSend.Length);
                    ns.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public static void SendImage(Image image)
        {
            if (isConnected)
            {
                try
                {
                    NetworkStream ns = Client.GetStream();

                    image.Save(ns, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ns.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// The Disconnect method disconnects the client from the server
        /// </summary>
        public static void Disconnect()
        {
            if (Client != null)
            {
                try
                {
                    Client.GetStream().Close();
                    Client.Close();
                    Client = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
