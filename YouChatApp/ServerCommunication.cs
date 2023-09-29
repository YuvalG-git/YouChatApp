using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Encryption;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Image = System.Drawing.Image;

namespace YouChatApp
{
    internal class ServerCommunication
    {
        /// <summary>
        /// Request/Response kinds' which are used in sending and recieving messages
        /// </summary>
        public const int EncryptionClientPublicKeySender = 39;
        public const int EncryptionServerPublicKeyReciever = 40;
        public const int EncryptionSymmetricKeyReciever = 41;
        public const int PasswordRenewalMessageRequest = 42;
        public const int PasswordRenewalMessageResponse = 43;
        public const int InitialProfileSettingsCheckRequest = 44;
        public const int InitialProfileSettingsCheckResponse = 45;
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
        public const int ResetPasswordResponse = 31;
        public const int MessageTextSizeIndexSender = 32;
        public const int ContactInformationRequest = 33;
        public const int ContactInformationResponse = 34;
        public const int UploadProfilePictureRequest = 35;
        public const int UploadProfilePictureResponse = 36;
        public const int UploadStatusRequest = 37;
        public const int UploadStatusResponse = 38;


        const string registerResponse1 = "Your registeration has completed successfully \nPlease press the back button to return to the home screen and login";
        const string registerResponse2 = "Your registeration has failed \nPlease try again ";
        const string loginResponse1 = "The login has been successfully completed";
        const string loginResponse2 = "The login has failed";
        const string loginResponse3 = "You need to change your password";
        const string loginResponse4 = "The login has been successfully completed but You haven't selected profile picture and status yet";
        const string loginResponse5 = "The login has been successfully completed but You haven't selected status yet";
        const string colorResponse1 = "You have chosen the coolest color";
        const string colorResponse2 = "An error occurred to happen \nChoose a new Color";
        const string colorResponse3 = "Your oppoenent has already chosen this color \nPlease choose a diffrenet color";
        const string ResetPasswordResponse1 = "The username and email address were matching";
        const string ResetPasswordResponse2 = "The username and email address weren't matching";
        const string InitialProfileSettingsCheckResponse1 = "The login has been successfully completed but You haven't selected profile picture and status yet";
        const string InitialProfileSettingsCheckResponse2 = "The login has been successfully completed but You haven't selected status yet";
        const string InitialProfileSettingsCheckResponse3 = "The login has been successfully completed";
        const string PasswordRenewalMessageResponse1 = "This password has already been chosen by you before";
        const string PasswordRenewalMessageResponse2 = "Your new password has been saved";
        const string PasswordRenewalMessageResponse3 = "An error occured";
        /// <summary>
        /// Object which represents the server's TCP client
        /// </summary>
        private static TcpClient Client { get; set; }

        /// <summary>
        /// Byte array which represents the data received from the server
        /// </summary>
        private static byte[] Data;

        public static int SelectedContacts = 0;

        /// <summary>
        /// Declares a variable of type LoginRegistPage which represents the loginRegistPage form's object and is used to perform actions on the form
        /// </summary>
        public static LoginAndRegistration loginAndRegistration;

        public static Profile profile;

        public static YouChat youChat;

        public static InitialProfileSelection InitialProfileSelection;

        private static UdpClient UdpClient;


        private static byte[] UdpData;


        private static RSAServiceProvider Rsa;
        private static string ServerPublicKey;
        private static string PrivateKey;

        public static string SymmetricKey;
        /// <summary>
        /// 0 - verysmall, 1- small, 2- normal, 3- large, 4 -huge...
        /// </summary>
        public static int SelectedMessageTextSize = 2; //todoישר כשמתחברים צריך לקבל מהשרת ביחד עם דברים נוספים 
        // value = 2 for now - until i will get the server to work


        public static int CurrentChatNumberID = 0;
        /// <summary>
        /// Represents the player's name
        /// </summary>
        public static string name;

        /// <summary>
        /// Represents the oppoenent's username
        /// </summary>
        public static string OppenentName;

        public static bool EnterKeyPress = false; //false for now, in the future the value will be chosen when the user connects (the server will send this information


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
        private static Boolean UdpIsOn = false;


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
                Client.Connect(ip, 1500); //todo - to change the server ip to my computer ip
            }
            catch
            {
                MessageBox.Show("There wasn't a server in this address...\nPlease Try Again", "Server Connection Attempt");
            }

            //Rsa = new RSAServiceProvider();
            //PrivateKey = Rsa.GetPrivateKey();
            //SendMessage(EncryptionClientPublicKeySender + "$" + Rsa.GetPublicKey());
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

        public static void ConnectUdp(string ip)
        {
            UdpIsOn = true;
            UdpClient.Connect(ip, 1501);
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

        public static void SendMessageThroughtUdp(string message)
        {
            if (UdpIsOn)
            {
                try
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                    UdpClient.Send(sendBytes, sendBytes.Length);


                    // Send data to the client
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
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
                        string DecryptedMessageDetails;
                        if (requestNumber == EncryptionServerPublicKeyReciever)
                        {
                            //ServerPublicKey = messageDetails; //maybe i should make the publickey as bytes and not string and then do the switch to string just after that...
                        }
                        else if (requestNumber == EncryptionSymmetricKeyReciever)//gets Symmetrical Key
                        {
                            //DecryptedMessageDetails = Rsa.Decrypt(messageDetails, PrivateKey);
                            //SymmetricKey = messageDetails; 
                        }
                        else
                        {
                            //byte[] Key = Encoding.UTF8.GetBytes(SymmetricKey);
                            //byte[] IV = new byte[16];

                            //DecryptedMessageDetails = AESServiceProvider.DecryptFromByte(Data, Key, IV);
                            if (requestNumber == registerResponse)
                            {
                                if (messageDetails == registerResponse1)
                                {
                                    MessageBox.Show(messageDetails);
                                    //loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.SetProfileDetails(true); });
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

                                    //bool IsPhaseOne = false;
                                    //MessageBox.Show(messageDetails);
                                    //if (true) //option that profilepicture and status were filled before
                                    //    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
                                    //else
                                    //{
                                    //    if (true)//option that profilepicture  was filled before
                                    //    {
                                    //        IsPhaseOne = true;
                                    //    }
                                    //    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(IsPhaseOne); });

                                    //}


                                }
                                else if (messageDetails == loginResponse2)
                                {
                                    MessageBox.Show(messageDetails + "\nYou probably wrote the wrong username or password \nIn case you don't have an account yet, please sign up");
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.setLoginButtonEnabled(); });
                                }
                                else if (messageDetails == loginResponse3)
                                {

                                }
                                else if (messageDetails == loginResponse4)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(true); });

                                }
                                else if (messageDetails == loginResponse5)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(false); });

                                }
                                else
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandleMatchingUsernameAndPassword(messageDetails); });

                                }
                            }
                            else if (requestNumber == sendMessageResponse)
                            {
                                youChat.Invoke((Action)delegate { youChat.Message(messageDetails); });
                            }
                            else if (requestNumber == ResetPasswordResponse)
                            {
                                if (messageDetails == ResetPasswordResponse1)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandleMatchingUsernameAndEmailAddress(); });
                                }
                                else if (messageDetails == ResetPasswordResponse2)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.RestartResetPasswordDetails(); });
                                }
                            }
                            else if(requestNumber == PasswordRenewalMessageResponse)
                            {
                                if ((messageDetails == PasswordRenewalMessageResponse1) || (messageDetails == PasswordRenewalMessageResponse3))
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.SelectNewPasswordForPasswordRenewal(); });
                                }
                                else if (messageDetails == PasswordRenewalMessageResponse2)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.ReturToLoginPanelAfterSuccessfulPasswordRenewal(); });
                                }
                            }
                            else if (requestNumber == ContactInformationResponse)
                            {
                                youChat.Invoke((Action)delegate { youChat.SetChatControlListOfContacts(messageDetails); });
                            }
                            else if (requestNumber == UploadProfilePictureResponse)
                            {
                                youChat.Invoke((Action)delegate { InitialProfileSelection.SetPhaseTwo(); });
                            }
                            else if (requestNumber == UploadStatusResponse)
                            {
                                youChat.Invoke((Action)delegate { InitialProfileSelection.OpenApp(); });
                            }
                            else if(requestNumber == InitialProfileSettingsCheckResponse)
                            {
                                if (messageDetails == InitialProfileSettingsCheckResponse1)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(true); });

                                }
                                else if (messageDetails == InitialProfileSettingsCheckResponse2)
                                {
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(false); });

                                }
                                else if (messageDetails == InitialProfileSettingsCheckResponse3)
                                {
                                    MessageBox.Show(messageDetails);
                                    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
                                }
                            }
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
                    //string EncryptedMessage =  Encryption.Encryption.EncryptData(SymmetricKey, message);
                    NetworkStream ns = Client.GetStream();

                    // Send data to the client
                    byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                    //byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(EncryptedMessage);

                    ns.Write(bytesToSend, 0, bytesToSend.Length);
                    ns.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public static void SendMessageAndImage(string message, Image image)
        {
            if (isConnected)
            {
                try
                {
                    NetworkStream ns = Client.GetStream();

                    // Send data to the client
                    byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                    ns.Write(bytesToSend, 0, bytesToSend.Length);
                    image.Save(ns, System.Drawing.Imaging.ImageFormat.Jpeg);

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
