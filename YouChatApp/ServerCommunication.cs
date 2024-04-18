using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using YouChatApp.AttachedFiles;
using YouChatApp.ChatHandler;
using YouChatApp.ContactHandler;
using YouChatApp.Encryption;
using YouChatApp.JsonClasses;
using YouChatApp.UserAuthentication.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        public const int FriendRequestSender = 48;
        public const int FriendRequestReceiver = 49;
        public const int FriendRequestResponseSender = 50;
        public const int FriendRequestResponseReceiver = 51;
        public const int FriendsProfileDetailsRequest = 52;
        public const int FriendsProfileDetailsResponse = 53;
        public const int PasswordUpdateRequest = 54;
        public const int PasswordUpdateResponse = 55;
        public const int UserConnectionCheckRequest = 56;
        public const int UserConnectionCheckResponse = 57;
        public const int PastFriendRequestsRequest = 58;
        public const int PastFriendRequestsResponse = 59;
        public const int BlockBeginning = 60;
        public const int BlockEnding = 61;
        public const int VideoCallRequest = 62;
        public const int VideoCallResponse = 63;
        public const int VideoCallResponseSender = 64;
        public const int VideoCallResponseReciever = 65;
        public const int GroupCreatorRequest = 66;
        public const int GroupCreatorResponse = 67;
        public const int UserDetailsRequest = 46;
        public const int UserDetailsResponse = 47;
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
        const string registerResponse2 = "Your registeration has failed \nPlease try changing the information provided again";
        const string loginResponse1 = "The login has been successfully completed";
        const string FailedLoginResponse = "The login has failed \nYou probably wrote the wrong username or password \nIn case you don't have an account yet, please sign up";
        const string loginResponse3 = "You need to change your password";
        const string loginResponse4 = "The login has been successfully completed but You haven't selected profile picture and status yet";
        const string loginResponse5 = "The login has been successfully completed but You haven't selected status yet";
        const string colorResponse1 = "You have chosen the coolest color";
        const string colorResponse2 = "An error occurred to happen \nChoose a new Color";
        const string colorResponse3 = "Your oppoenent has already chosen this color \nPlease choose a diffrenet color";
        const string ResetPasswordResponse1 = "The username and email address were matching";
        const string ResetPasswordResponse2 = "The username and email address weren't matching";
        const string InitialProfileSettingsCheckResponse1 = "The login has been successfully completed but you need to change your password";
        const string InitialProfileSettingsCheckResponse2 = "The login has been successfully completed but You haven't selected profile picture and status yet";
        const string InitialProfileSettingsCheckResponse3 = "The login has been successfully completed but You haven't selected status yet";
        const string InitialProfileSettingsCheckResponse4 = "The login has been successfully completed";
        const string PasswordMessageResponse1 = "This password has already been chosen by you before";
        const string PasswordMessageResponse2 = "Your new password has been saved";
        const string PasswordMessageResponse3 = "An error occured";
        const string PasswordMessageResponse4 = "Your past details aren't matching";
        public const string FriendRequestResponseSender1 = "Approval";
        public const string FriendRequestResponseSender2 = "Rejection";
        const string VideoCallResponse1 = "Your friend is offline. Please try to call again.";
        const string VideoCallResponse2 = "You have been asked to join a call";
        public const string VideoCallResponseResult1 = "Joining the video call";
        public const string VideoCallResponseResult2 = "Declining the video call";
        const string GroupCreatorResponse1 = "Group was successfully created";

        private static bool isKeyExchangeInProgress = false;
        private static Queue<string> messageQueue = new Queue<string>();

        public const string RightSmtpCode = "right";
        public const string WrongSmtpCode = "wrong";
        //TCP Sockets:

        /// <summary>
        /// Object which represents the server's TCP client for sending text messages
        /// </summary>
        private static TcpClient MessageClient { get; set; }

        /// <summary>
        /// Object which represents the server's TCP client for sending files
        /// </summary>
        private static TcpClient FileClient { get; set; }

        /// <summary>
        /// Byte arrays which represent the data received from the server 
        /// MessageData is used for messages received from the MessageClient socket, and FileData for messages received from the FileClient socket
        /// </summary>
        private static byte[] MessageData;
        private static byte[] FileData;
        private static byte[] dataHistory;

        public static int SelectedContacts = 0;


        //Form Instances

        /// <summary>
        /// Declares a variable of type LoginRegistPage which represents the loginRegistPage form's object and is used to perform actions on the form
        /// </summary>
        public static LoginAndRegistration loginAndRegistration;

        /// <summary>
        /// Declares a variable of type Login which represents the _login form's object and is used to perform actions on this form
        /// </summary>
        public static Login _login;

        /// <summary>
        /// Declares a variable of type Registration which represents the _registration form's object and is used to perform actions on this form
        /// </summary>
        public static Registration _registration;

        /// <summary>
        /// Declares a variable of type PasswordUpdate which represents the _passwordUpdate form's object and is used to perform actions on this form
        /// </summary>
        public static PasswordUpdate _passwordUpdate;

        /// <summary>
        /// Declares a variable of type PasswordRestart which represents the _passwordRestart form's object and is used to perform actions on this form
        /// </summary>
        public static PasswordRestart _passwordRestart;

        /// <summary>
        /// Declares a variable of type Profile which represents the _profile form's object and is used to perform actions on this form
        /// </summary>
        public static Profile _profile;

        /// <summary>
        /// Declares a variable of type YouChat which represents the _youChat form's object and is used to perform actions on this form
        /// </summary>
        public static YouChat _youChat;

        /// <summary>
        /// Declares a variable of type InitialProfileSelection which represents the _initialProfileSelection form's object and is used to perform actions on this form
        /// </summary>
        public static InitialProfileSelection _initialProfileSelection;

        /// <summary>
        /// Declares a variable of type EmojiKeyboard which represents the _emojiKeyboard form's object and is used to perform actions on this form
        /// </summary>
        public static EmojiKeyboard _emojiKeyboard = null;

        /// <summary>
        /// Declares a variable of type ContactSharing which represents the _contactSharing form's object and is used to perform actions on this form
        /// </summary>
        public static ContactSharing _contactSharing = null;

        /// <summary>
        /// Declares a variable of type Camera which represents the _camera form's object and is used to perform actions on this form
        /// </summary>
        public static Camera _camera = null;

        /// <summary>
        /// Declares a variable of type VideoCall which represents the _videoCall form's object and is used to perform actions on this form
        /// </summary>
        public static VideoCall _videoCall;


        /// <summary>
        /// Declares a variable of type AudioCall which represents the _audioCall form's object and is used to perform actions on this form
        /// </summary>
        public static AudioCall _audioCall;

        /// <summary>
        /// Declares a variable of type WaitingForm which represents the _waitingForm form's object and is used to perform actions on this form
        /// </summary>
        public static WaitingForm _waitingForm;

        /// <summary>
        /// Declares a variable of type CallInvitation which represents the _callInvitation form's object and is used to perform actions on this form
        /// </summary>
        public static CallInvitation _callInvitation;

        /// <summary>
        /// Declares a variable of type Paint which represents the _paint form's object and is used to perform actions on this form
        /// </summary>
        public static Paint _paint = null;

        public static ImageSender _imageSender;

        public static BanForm _banForm;

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


        public static bool EnterKeyPress = false; //false for now, in the future the value will be chosen when the user connects (the server will send this information


        public static ContactDetails _myData;
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
        private static Boolean isConnected;
        private static Boolean UdpIsOn = false;


        public static string ProfilePictureId;
        public static string ProfileStatus;


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
            MessageClient = new TcpClient();
            FileClient = new TcpClient();

            try
            {
                MessageClient.Connect(ip, 1500); //todo - to change the server ip to my computer ip
                FileClient.Connect(ip, 1500); //todo - to change the server ip to my computer ip

            }
            catch
            {
                MessageBox.Show("There wasn't a server in this address...\nPlease Try Again", "Server Connection Attempt");
            }
            //SendMessage(EncryptionClientPublicKeySender + "$" + Rsa.GetPublicKey());
            //SendMessage(EncryptionClientPublicKeySender, Rsa.GetPublicKey());

            if (!MessageClient.Connected)
                return false;
            isConnected = true;
            HandleKeys();

            MessageData = new byte[MessageClient.ReceiveBufferSize];
            // BeginRead will begin async read from the NetworkStream
            // This allows the server to remain responsive and continue accepting new connections from other clients
            // When reading complete control will be transfered to the ReviveMessage() function.
            MessageBeginRead();
            dataHistory = new byte[0]; //נניח שאין מעבר לint הגדול ביותר...
            return true;
        }
        private static void HandleKeys()
        {
            Rsa = new RSAServiceProvider();
            PrivateKey = Rsa.GetPrivateKey();
            string clientPublicKey = Rsa.GetPublicKey();
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.EncryptionClientPublicKeySender, clientPublicKey);
            string clientPublicKeyJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            SendMessage(clientPublicKeyJson, false);
            isKeyExchangeInProgress = true;
        }


        /// <summary>
        /// The BeginRead method initiates an asynchronous read operation on the network stream associated with the client
        /// It reads data into the Data buffer and calls the ReceiveMessage method when the read operation is complete       
        /// </summary>
        public static void MessageBeginRead()
        {
            //MessageClient.GetStream().BeginRead(MessageData,
            //                                          0,
            //                                          System.Convert.ToInt32(MessageClient.ReceiveBufferSize),
            //                                          ReceiveMessage,
            //                                          null);
            //MessageClient.GetStream().BeginRead(MessageData,
            //                              0,
            //                              4,
            //                              ReceiveMessageLength,
            //                              null);
            try
            {
                MessageClient.GetStream().BeginRead(MessageData,
                                                    0,
                                                    4,
                                                    ReceiveMessageLength,
                                                    null);
            }
            catch (SocketException ex) when (ex.ErrorCode == 10061)
            {
                Console.WriteLine("Connection refused by the server.");
                // Handle the refusal, e.g., retry or inform the user
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle other exceptions
            }

        }

        public static void FileBeginRead()
        {
            FileClient.GetStream().BeginRead(FileData,
                                                      0,
                                                      System.Convert.ToInt32(FileClient.ReceiveBufferSize),
                                                      ReceiveFile,
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
        private static void ReceiveMessageLength(IAsyncResult ar)
        {
            if (MessageClient != null)
            {
                int bytesRead;
                try
                {
                    //Console.WriteLine("trying to get lock in length:");
                    lock (MessageClient.GetStream())
                    {
                        // call EndRead to handle the end of an async read.
                        bytesRead = MessageClient.GetStream().EndRead(ar);
                    }
                    //Console.WriteLine("unlocked in length:");

                    //bytesRead = MessageClient.GetStream().EndRead(ar);

                    // if bytesread<1 -> the client disconnected
                    if (bytesRead < 1)
                    {
                        MessageBox.Show("Server is down.", "Server Communication");
                        Disconnect();
                        return;
                    }
                    else // client still connected
                    {
                        byte[] buffer = new byte[bytesRead];
                        Array.Copy(MessageData, buffer, bytesRead);

                        bytesRead = BitConverter.ToInt32(buffer, 0);
                        if (isConnected)
                        {
                            Console.WriteLine("trying to get lock in length2:");

                            lock (MessageClient.GetStream())
                            {
                                // continue reading from the client
                                MessageClient.GetStream().BeginRead(MessageData, 0, bytesRead, ReceiveMessage, null);
                            }
                            //MessageClient.GetStream().BeginRead(MessageData, 0, bytesRead, ReceiveMessage, null);
                            Console.WriteLine("unlocked in length2");

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
        /// The ReceiveMessage method recieves and handles the incomming stream
        /// </summary>
        /// <param name="ar">IAsyncResult Interface</param>
        private static void ReceiveMessage(IAsyncResult ar)
        {
            if (MessageClient != null)
            {
                int bytesRead;
                try
                {
                    Console.WriteLine("trying to get lock in message");

                    lock (MessageClient.GetStream())
                    {
                        // call EndRead to handle the end of an async read.
                        bytesRead = MessageClient.GetStream().EndRead(ar);
                    }
                    Console.WriteLine("unlocked message");

                    // if bytesread<1 -> the client disconnected
                    if (bytesRead < 1)
                    {
                        MessageBox.Show("Server is down.", "Server Communication");
                        Disconnect();
                        return;
                    }
                    else // client still connected
                    {
                        //byte[] buffer = new byte[4];
                        //Array.Copy(MessageData, buffer, bytesRead);

                        //int value = BitConverter.ToInt32(buffer, 0);
                        //int newLength = dataHistory.Length + bytesRead;

                        //// Create a new array to hold the combined data
                        //byte[] newDataHistory = new byte[newLength];

                        //// Copy the existing dataHistory to the new array
                        //Array.Copy(dataHistory, 0, newDataHistory, 0, dataHistory.Length);

                        //// Copy the MessageData to the end of the new array
                        //Array.Copy(MessageData, 0, newDataHistory, dataHistory.Length, bytesRead);

                        //// Assign the new array to dataHistory
                        //dataHistory = newDataHistory;
                    
                        //if (value == 1)
                        //{
                        //    //to use the data...
                        //}
                        string incomingData = System.Text.Encoding.ASCII.GetString(MessageData, 0, bytesRead);
                        byte receivedByteSignal = (byte)incomingData[0];
                        string actualMessage = incomingData.Substring(1);

                        // if the client is sending send me datatable
                        if (receivedByteSignal == 1)
                        {
                            actualMessage = Encryption.Encryption.DecryptData(SymmetricKey, actualMessage);
                        }
                        JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(actualMessage, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            Binder = new NamespaceAdjustmentBinder(),
                            Converters = { new EnumConverter<EnumHandler.CommunicationMessageID_Enum>() }
                        });
                        EnumHandler.CommunicationMessageID_Enum messageType = (EnumHandler.CommunicationMessageID_Enum)jsonObject.MessageType;
                        switch (messageType)
                        {
                            case EnumHandler.CommunicationMessageID_Enum.EncryptionServerPublicKeyReciever:
                                ServerPublicKey = jsonObject.MessageBody as string;
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.EncryptionSymmetricKeyReciever:
                                string EncryptedSymmetricKeyReciever = jsonObject.MessageBody as string;
                                SymmetricKey = Rsa.Decrypt(EncryptedSymmetricKeyReciever, PrivateKey);
                                isKeyExchangeInProgress = false;
                                SendQueuedMessages();
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.EncryptionRenewKeys:
                                HandleKeys();
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SuccessfulRegistration:
                                MessageBox.Show(registerResponse1);
                                _registration.Invoke((Action)delegate { _registration.OpenInitialProfileSelectionForm(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedRegistration:
                                MessageBox.Show(registerResponse2);
                                _registration.Invoke((Action)delegate { _registration.HandleProblematicDetails(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureResponse:
                                ProfilePictureId = jsonObject.MessageBody as string;
                                _initialProfileSelection.Invoke((Action)delegate { _initialProfileSelection.SetPhaseTwo(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.UploadStatusResponse:
                                ProfileStatus = jsonObject.MessageBody as string;
                                _initialProfileSelection.Invoke((Action)delegate { _initialProfileSelection.OpenApp(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SmtpRegistrationMessage:
                                _registration.Invoke((Action)delegate { _registration.HandleRecievedEmail(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SuccessfulSmtpRegistrationCode:
                                _registration.Invoke((Action)delegate { _registration.HandleCodeResponse(true); }); 
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedSmtpRegistrationCode:
                                _registration.Invoke((Action)delegate { _registration.HandleCodeResponse(false); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.ResetPasswordResponse_SmtpMessage:
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.HandleRecievedEmail(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulResetPasswordResponse_SmtpCode:
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.HandleCorrectCodeResponse(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedResetPasswordResponse_SmtpCode:
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.HandleWrongCodeResponse(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.loginResponse_SmtpLoginMessage:
                                _login.Invoke((Action)delegate { _login.HandleRecievedEmail(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.loginResponse_FailedLogin:
                                MessageBox.Show(FailedLoginResponse);
                                _login.Invoke((Action)delegate { _login.setLoginButtonEnabled(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.LoginResponse_SuccessfulSmtpLoginCode:
                                ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
                                byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
                                Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
                                _login.Invoke((Action)delegate { _login.HandleCorrectCodeResponse(captchaCodeImage); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.CaptchaImageResponse:
                                HandleCaptchaImageResponseEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.LoginResponse_FailedSmtpLoginCode:
                                _login.Invoke((Action)delegate { _login.HandleWrongCodeResponse(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulCaptchaCodeResponse:
                            case EnumHandler.CommunicationMessageID_Enum.CaptchaImageAngleResponse:
                                HandleCaptchaImageAngleResponseEnum(jsonObject);    
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedCaptchaCodeResponse:
                                _login.Invoke((Action)delegate { _login.HandleWrongCaptchaCode(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulCaptchaImageAngleResponse:
                                HandleSuccessfulCaptchaImageAngleResponseEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.UdpAudioConnectionResponse:
                                _audioCall.Invoke((Action)delegate { _audioCall.SetIsAbleToSendToTrue(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_UpdatePassword:
                                _login.Invoke((Action)delegate { _login.HandlePasswordUpdateCase(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserProfilePicture:
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserProfilePicture:
                                _login.Invoke((Action)delegate { _login.OpenInitialProfileSelection(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserStatus:
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserStatus:

                                _login.Invoke((Action)delegate { _login.OpenInitialProfileSelection(false); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_OpenChat:
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_OpenChat:
                                _login.Invoke((Action)delegate { _login.OpenApp(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedPersonalVerificationAnswersResponse:
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_HandleError:
                                _login.Invoke((Action)delegate { _login.HandleWrongPersonalVerificationAnswers(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPasswordUpdateResponse:
                                _passwordUpdate.Invoke((Action)delegate { _passwordUpdate.HandleSuccessfulPasswordUpdate(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedPasswordUpdateResponse_PasswordExist:
                                MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
                                _passwordUpdate.Invoke((Action)delegate { _passwordUpdate.SetEnable(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedPasswordUpdateResponse_UnmatchedDetails:
                                MessageBox.Show(PasswordMessageResponse4, "Unmatched Details.");
                                _passwordUpdate.Invoke((Action)delegate { _passwordUpdate.SetEnable(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.ErrorHandlePasswordUpdateResponse:
                                MessageBox.Show("try again", "Error occured.");
                                _passwordUpdate.Invoke((Action)delegate { _passwordUpdate.SetEnable(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_HandleError:
                                MessageBox.Show("try again", "Error occured.");
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.UserDetailsResponse:
                                //ProfilePictureImageList.InitializeImageLists();
                                UserDetails userDetails = jsonObject.MessageBody as UserDetails;
                                UserProfile.ProfileDetailsHandler.Name = userDetails.Username;
                                UserProfile.ProfileDetailsHandler.ProfilePictureId = userDetails.ProfilePicture; //need to convert it to the image
                                UserProfile.ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(UserProfile.ProfileDetailsHandler.ProfilePictureId);//returns the wrong image for some reason                                                                                                                                           //a soultion might be a object and not a static class...
                                UserProfile.ProfileDetailsHandler.Status = userDetails.ProfileStatus;
                                UserProfile.ProfileDetailsHandler.LastSeenProperty = userDetails.LastSeenProperty;
                                UserProfile.ProfileDetailsHandler.OnlineProperty = userDetails.OnlineProperty;
                                UserProfile.ProfileDetailsHandler.ProfilePictureProperty = userDetails.ProfilePictureProperty;
                                UserProfile.ProfileDetailsHandler.StatusProperty = userDetails.StatusProperty;
                                UserProfile.ProfileDetailsHandler.TextSize = userDetails.TextSizeProperty;
                                UserProfile.ProfileDetailsHandler.MessageGap = userDetails.MessageGapProperty;
                                UserProfile.ProfileDetailsHandler.EnterKeyPressed = userDetails.EnterKeyPressedProperty;
                                UserProfile.ProfileDetailsHandler.TagLine = userDetails.TagLineId;

                                _youChat.Invoke((Action)delegate { _youChat.SetProfilePicture(); });

                                //needs to restart everything according to it...
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.LoginBanStart:
                                double banDuration = (double)jsonObject.MessageBody;
                                _login.Invoke((Action)delegate { _login.HandleBan(banDuration); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.LoginBanFinish:
                                HandleLoginBanFinishEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulResetPasswordResponse:
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.HandleMatchingUsernameAndEmailAddress(); });

                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedResetPasswordResponse:
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.RestartDetails(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.PastFriendRequestsResponse:
                                PastFriendRequests pastFriendRequests = jsonObject.MessageBody as PastFriendRequests;
                                _youChat.Invoke((Action)delegate { _youChat.SetListOfFriendRequestControl(pastFriendRequests); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulRenewalMessageResponse:
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.HandleSuccessfulPasswordRenewal(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FailedRenewalMessageResponse:
                                MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.SetPasswordGeneratorControlEnable(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.ErrorHandleRenewalMessageResponse:
                                MessageBox.Show("try again", "Error occured.");
                                _passwordRestart.Invoke((Action)delegate { _passwordRestart.SetPasswordGeneratorControlEnable(true); });
                                break;
                            //case EnumHandler.CommunicationMessageID_Enum.EncryptionServerPublicKeyAndSymmetricKeyReciever:
                            //    EncryptionKeys encryptionKeys = jsonObject.MessageBody as EncryptionKeys;
                            //    ServerPublicKey = encryptionKeys.AsymmetricKey;
                            //    string EncryptedSymmetricKey = encryptionKeys.SymmetricKey;
                            //    SymmetricKey = Rsa.Decrypt(EncryptedSymmetricKey, PrivateKey);
                            //    break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationBanStart:
                                HandleRegistrationBanStartEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationBanFinish:
                                HandleRegistrationBanFinishEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FriendRequestReciever:
                                HandleFriendRequestRecieverEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.FriendRequestResponseReciever:
                                HandleFriendRequestResponseRecieverEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.ContactInformationResponse:
                                HandleContactInformationResponseEnum(jsonObject);
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.ChatInformationResponse:
                                HandleChatInformationResponseEnum(jsonObject);
                                break;
                        }
                    }
                    if (isConnected)
                    {
                        Console.WriteLine("trying to get lock in message2");

                        lock (MessageClient.GetStream())
                        {
                            // continue reading from the client
                            MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);
                            //dataHistory = new byte[0];
                            //MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);
                        }
                        Console.WriteLine("unlocked in message2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
                }
            }
        }
        private static void HandleFriendRequestRecieverEnum(JsonObject jsonObject)
        {
            PastFriendRequest pastFriendRequest = jsonObject.MessageBody as PastFriendRequest;

            _youChat.Invoke((Action)delegate { _youChat.AddFriendRequest(pastFriendRequest); });

        }
        private static void HandleChatInformationResponseEnum(JsonObject jsonObject)
        {
            Chats chats = jsonObject.MessageBody as Chats;
            List<ChatDetails> chatDetailsList = chats.ChatList;
            ChatDetails chat;
            foreach (ChatDetails chatDetails in chatDetailsList)
            {
                ChatManager.AddChat(chatDetails);
            }
            _youChat.Invoke((Action)delegate { _youChat.SetChatControlListOfContacts(); });

        }
        private static void HandleContactInformationResponseEnum(JsonObject jsonObject)
        {
            Contacts contacts = jsonObject.MessageBody as Contacts;
            List<ContactDetails> contactDetailsList = contacts.ContactList;
            _youChat.Invoke((Action)delegate { _youChat.SetContactControlList(contactDetailsList); });
            JsonObject chatInformationRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ChatInformationRequest, null);
            string chatInformationRequestJson = JsonConvert.SerializeObject(chatInformationRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            SendMessage(chatInformationRequestJson);

        }
        private static void HandleFriendRequestResponseRecieverEnum(JsonObject jsonObject)
        {
            ContactAndChat contactAndChat = jsonObject.MessageBody as ContactAndChat;
            ContactDetails contactDetails = contactAndChat.ContactDetails;
            Contact contact = new Contact(contactDetails);
            ContactManager.AddContact(contact);
            ChatDetails chatDetails = contactAndChat.Chat;
            ChatManager.AddChat(chatDetails);
            string contactName = contact.Name;
            _youChat.Invoke((Action)delegate { _youChat.HandleSuccessfulFriendRequest(contact,chatDetails); });

        }
        private static void HandleRegistrationBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            _registration.Invoke((Action)delegate { _registration.HandleBan(banDuration); });
        }
        private static void HandleRegistrationBanFinishEnum(JsonObject jsonObject)
        {
            _registration.Invoke((Action)delegate { _registration.HandleBanOver(); });
        }
        private static void HandleCaptchaImageAngleResponseEnum(JsonObject jsonObject)
        {
            CaptchaRotationImageDetails captchaRotationImageDetails = jsonObject.MessageBody as CaptchaRotationImageDetails;
            object[] values = HandleCaptchaRotationImageDetailsArrival(captchaRotationImageDetails);
            _login.Invoke((Action)delegate { _login.HandleCorrectCaptchaCode((Image)values[2], (Image)values[3], (int)values[0], (int)values[1]); });
        }
        private static object[] HandleCaptchaRotationImageDetailsArrival(CaptchaRotationImageDetails captchaRotationImageDetails)
        {
            CaptchaRotationImages captchaRotationImages = captchaRotationImageDetails.CaptchaRotationImages;
            CaptchaRotationSuccessRate captchaRotationSuccessRate = captchaRotationImageDetails.CaptchaRotationSuccessRate;
            int score = captchaRotationSuccessRate.Score;
            int attempts = captchaRotationSuccessRate.Attempts;
            ImageContent captchaCircularImageContent = captchaRotationImages.RotatedImage;
            ImageContent captchaImageContent = captchaRotationImages.BackgroundImage;
            byte[] captchaCircularImageBytes = captchaCircularImageContent.ImageBytes;
            byte[] captchaImageBytes = captchaImageContent.ImageBytes;
            Image captchaCircularImage = ConvertHandler.ConvertBytesToImage(captchaCircularImageBytes);
            Image captchaImage = ConvertHandler.ConvertBytesToImage(captchaImageBytes);
            object[] values = { score, attempts, captchaCircularImage, captchaImage };
            return values;
        }
        private static void HandleLoginBanFinishEnum(JsonObject jsonObject)
        {
            if (jsonObject.MessageBody == null)
            {
                _login.Invoke((Action)delegate { _login.HandleBanOver(); });
            }
            else if (jsonObject.MessageBody is CaptchaRotationImageDetails captchaRotationImageDetails)
            {
                object[] values = HandleCaptchaRotationImageDetailsArrival(captchaRotationImageDetails);
                _login.Invoke((Action)delegate { _login.HandleBanOver((Image)values[2], (Image)values[3], (int)values[0], (int)values[1]); });
            }
        }

        private static void HandleCaptchaImageResponseEnum(JsonObject jsonObject)
        {
            ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
            byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
            Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
            _login.Invoke((Action)delegate { _login.HandleCaptchaImageRenewal(captchaCodeImage); });
        }
        private static void HandleSuccessfulCaptchaImageAngleResponseEnum(JsonObject jsonObject)
        {
            PersonalVerificationQuestionDetails verificationQuestionDetails = jsonObject.MessageBody as PersonalVerificationQuestionDetails;
            PersonalVerificationQuestions personalVerificationQuestions = verificationQuestionDetails.PersonalVerificationQuestions;
            CaptchaRotationSuccessRate captchaRotationSuccessRate = verificationQuestionDetails.CaptchaRotationSuccessRate;
            int score = captchaRotationSuccessRate.Score;
            int attempts = captchaRotationSuccessRate.Attempts;

            _login.Invoke((Action)delegate { _login.HandleSuccessfulCaptchaImageAngleResponse(personalVerificationQuestions, score,attempts); });
        }
        ///// <summary>
        ///// The ReceiveMessage method recieves and handles the incomming stream
        ///// </summary>
        ///// <param name="ar">IAsyncResult Interface</param>
        //private static void ReceiveMessage(IAsyncResult ar)
        //{
        //    if (MessageClient != null)
        //    {
        //        int bytesRead;
        //        try
        //        {
        //            lock (MessageClient.GetStream())
        //            {
        //                // call EndRead to handle the end of an async read.
        //                bytesRead = MessageClient.GetStream().EndRead(ar);
        //            }
        //            // if bytesread<1 -> the client disconnected
        //            if (bytesRead < 1)
        //            {
        //                MessageBox.Show("Server is down.", "Server Communication");
        //                Disconnect();
        //                return;
        //            }
        //            else // client still connected
        //            {
        //                string incomingData = System.Text.Encoding.ASCII.GetString(MessageData, 0, bytesRead);
        //                string[] messageToArray = incomingData.Split('$');
        //                int requestNumber = Convert.ToInt32(messageToArray[0]);
        //                string messageDetails = messageToArray[1];
        //                string DecryptedMessageDetails;
        //                if (requestNumber == EncryptionServerPublicKeyReciever)
        //                {
        //                    ServerPublicKey = messageDetails; //maybe i should make the publickey as bytes and not string and then do the switch to string just after that...
        //                }
        //                else if (requestNumber == EncryptionSymmetricKeyReciever)//gets Symmetrical Key
        //                {
        //                    DecryptedMessageDetails = Rsa.Decrypt(messageDetails, PrivateKey);
        //                    SymmetricKey = DecryptedMessageDetails; 
        //                }
        //                else
        //                {
        //                    DecryptedMessageDetails = Encryption.Encryption.DecryptData(SymmetricKey, messageDetails);
        //                    if (requestNumber == registerResponse)
        //                    {
        //                        if (DecryptedMessageDetails == registerResponse1)
        //                        {
        //                            MessageBox.Show(DecryptedMessageDetails);
        //                            //loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.SetProfileDetails(true); });
        //                        }
        //                        else if (DecryptedMessageDetails == registerResponse2)
        //                        {
        //                            MessageBox.Show(DecryptedMessageDetails);
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.setRegistButtonEnabled(); });
        //                        }
        //                    }
        //                    else if (requestNumber == loginResponse)
        //                    {
        //                        if (DecryptedMessageDetails == loginResponse1)
        //                        {
        //                            MessageBox.Show(DecryptedMessageDetails);
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });

        //                            //bool IsPhaseOne = false;
        //                            //MessageBox.Show(messageDetails);
        //                            //if (true) //option that profilepicture and status were filled before
        //                            //    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
        //                            //else
        //                            //{
        //                            //    if (true)//option that profilepicture  was filled before
        //                            //    {
        //                            //        IsPhaseOne = true;
        //                            //    }
        //                            //    loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(IsPhaseOne); });

        //                            //}


        //                        }
        //                        else if (DecryptedMessageDetails == loginResponse2)
        //                        {
        //                            MessageBox.Show(DecryptedMessageDetails + "\nYou probably wrote the wrong username or password \nIn case you don't have an account yet, please sign up");
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.setLoginButtonEnabled(); });
        //                        }
        //                        else if (DecryptedMessageDetails == loginResponse3)
        //                        {

        //                        }
        //                        else if (DecryptedMessageDetails == loginResponse4)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(true); });

        //                        }
        //                        else if (DecryptedMessageDetails == loginResponse5)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(false); });

        //                        }
        //                        else
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandleMatchingUsernameAndPassword(DecryptedMessageDetails); });

        //                        }
        //                    }
        //                    else if (requestNumber == sendMessageResponse)
        //                    {
        //                        _youChat.Invoke((Action)delegate { _youChat.HandleMessagesByOthers(DecryptedMessageDetails); });
        //                    }
        //                    else if (requestNumber == ResetPasswordResponse)
        //                    {
        //                        if (DecryptedMessageDetails == ResetPasswordResponse1)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandleMatchingUsernameAndEmailAddress(); });
        //                        }
        //                        else if (DecryptedMessageDetails == ResetPasswordResponse2)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.RestartResetPasswordDetails(); });
        //                        }
        //                    }
        //                    else if(requestNumber == PasswordRenewalMessageResponse)
        //                    {
        //                        if ((DecryptedMessageDetails == PasswordMessageResponse1) || (DecryptedMessageDetails == PasswordMessageResponse3))
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.SelectNewPasswordForPasswordRenewal(); });
        //                        }
        //                        else if (DecryptedMessageDetails == PasswordMessageResponse2)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.ReturToLoginPanelAfterSuccessfulPasswordRenewal(); });
        //                        }
        //                    }
        //                    else if (requestNumber == ContactInformationResponse)
        //                    {
        //                        _youChat.Invoke((Action)delegate { _youChat.SetChatControlListOfContacts(DecryptedMessageDetails); });
        //                    }
        //                    else if (requestNumber == UploadProfilePictureResponse)
        //                    {
        //                        ProfilePictureId = DecryptedMessageDetails;
        //                        _initialProfileSelection.Invoke((Action)delegate { _initialProfileSelection.SetPhaseTwo(); });
        //                    }
        //                    else if (requestNumber == UploadStatusResponse)
        //                    {
        //                        ProfileStatus = DecryptedMessageDetails;
        //                        _initialProfileSelection.Invoke((Action)delegate { _initialProfileSelection.OpenApp(); });
        //                    }
        //                    else if(requestNumber == InitialProfileSettingsCheckResponse)
        //                    {
        //                        if (DecryptedMessageDetails == InitialProfileSettingsCheckResponse1)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandlePasswordUpdateCase(); });

        //                        }
        //                        else if (DecryptedMessageDetails == InitialProfileSettingsCheckResponse2)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(true); });

        //                        }
        //                        else if (DecryptedMessageDetails == InitialProfileSettingsCheckResponse3)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenInitialProfileSelection(false); });

        //                        }
        //                        else if (DecryptedMessageDetails == InitialProfileSettingsCheckResponse4)
        //                        {
        //                            MessageBox.Show(DecryptedMessageDetails);
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.OpenApp(); });
        //                        }
        //                    }
        //                    else if(requestNumber == UserDetailsResponse)
        //                    {
        //                        //ProfilePictureImageList.InitializeImageLists();
        //                        string[] MyContactContent = DecryptedMessageDetails.Split('#');
        //                        UserProfile.ProfileDetailsHandler.Name = MyContactContent[0];
        //                        UserProfile.ProfileDetailsHandler.ProfilePictureId = MyContactContent[1]; //need to convert it to the image
        //                        UserProfile.ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(UserProfile.ProfileDetailsHandler.ProfilePictureId);//returns the wrong image for some reason
        //                                                                                                                                                 //it returns the wrong image beacuse of a wrong number of images in the list
        //                                                                                                                                                 //a soultion might be a object and not a static class...
        //                        UserProfile.ProfileDetailsHandler.Status = MyContactContent[2];
        //                        UserProfile.ProfileDetailsHandler.LastSeenProperty = bool.Parse(MyContactContent[3]); //a solution...
        //                        UserProfile.ProfileDetailsHandler.OnlineProperty = bool.Parse(MyContactContent[4]);
        //                        UserProfile.ProfileDetailsHandler.ProfilePictureProperty = bool.Parse(MyContactContent[5]);
        //                        UserProfile.ProfileDetailsHandler.StatusProperty = bool.Parse(MyContactContent[6]);
        //                        UserProfile.ProfileDetailsHandler.TextSize = int.Parse(MyContactContent[7]);
        //                        UserProfile.ProfileDetailsHandler.MessageGap = int.Parse(MyContactContent[8]);
        //                        UserProfile.ProfileDetailsHandler.EnterKeyPressed = bool.Parse(MyContactContent[9]);
        //                        UserProfile.ProfileDetailsHandler.TagLine = MyContactContent[10];

        //                        _youChat.Invoke((Action)delegate { _youChat.SetProfilePicture(); });

        //                        //needs to restart everything according to it...

        //                    }
        //                    else if (requestNumber == PasswordUpdateResponse)
        //                    {
        //                        if ((DecryptedMessageDetails == PasswordMessageResponse1) || (DecryptedMessageDetails == PasswordMessageResponse3))
        //                        {
        //                            MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.RestartUpdatePasswordDetails(); });
        //                        }
        //                        else if (DecryptedMessageDetails == PasswordMessageResponse2)
        //                        {
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandleSuccessfulPasswordUpdate(); });
        //                        }
        //                        else if (DecryptedMessageDetails == PasswordMessageResponse4)
        //                        {
        //                            MessageBox.Show(PasswordMessageResponse4, "Unmatched Details");
        //                            loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.RestartUpdatePasswordDetails(); });
        //                        }
        //                    }
        //                    else if (requestNumber == PastFriendRequestsResponse)
        //                    {
        //                        _youChat.Invoke((Action)delegate { _youChat.SetListOfFriendRequestControl(DecryptedMessageDetails); });

        //                    }
        //                    else if (requestNumber == BlockBeginning)
        //                    {
        //                        string[] BlockContent = DecryptedMessageDetails.Split('#');
        //                        string timeAsString = BlockContent[1];
        //                        string message = BlockContent[0] + " for ";
        //                        double time = double.Parse(timeAsString);
        //                        if (time < 1)
        //                        {
        //                            message += (time * 60) + " Seconds";
        //                        }
        //                        else
        //                        {
        //                            message += (time) + " minute";
        //                            if (time != 1)
        //                            {
        //                                message += "s";
        //                            }
        //                        }
        //                        MessageBox.Show(message, "Ban.");

        //                        loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.HandleBan(time); });
        //                    }
        //                    else if (requestNumber == BlockEnding)
        //                    {
        //                        loginAndRegistration.Invoke((Action)delegate { loginAndRegistration.CancelBan(); });

        //                    }
        //                    else if (requestNumber == VideoCallResponse)
        //                    {
        //                        if (DecryptedMessageDetails == VideoCallResponse1)
        //                        {
        //                            _waitingForm.Invoke((Action)delegate { _waitingForm.Hide(); });
        //                        }
        //                        else
        //                        {
        //                            string[] messageInfo = DecryptedMessageDetails.Split('#');
        //                            string friendName = messageInfo[1];
        //                            _callInvitation = new CallInvitation(friendName);
        //                            _callInvitation.Invoke((Action)delegate { _callInvitation.Show(); }); //will it work?
        //                        }
        //                    }
        //                    else if (requestNumber == VideoCallResponseReciever)
        //                    {
        //                        if (DecryptedMessageDetails == VideoCallResponseResult1)
        //                        {
        //                            //open the video call form
        //                        }
        //                        else
        //                        {
        //                            //close the waiting form and return to youchat form

        //                        }
        //                    }
        //                    else if (requestNumber == GroupCreatorResponse)
        //                    {
        //                        if (DecryptedMessageDetails == GroupCreatorResponse1)
        //                        {
        //                            MessageBox.Show(DecryptedMessageDetails, "Successful Group Creation");
        //                        }
        //                        else
        //                        {
        //                            ChatCreator newChat = JsonConvert.DeserializeObject<ChatCreator>(DecryptedMessageDetails);

        //                            _youChat.Invoke((Action)delegate { _youChat.AddGroup(newChat); });

        //                        }
        //                    }
        //                }                          
        //            }
        //            if (isConnected)
        //            {
        //                lock (MessageClient.GetStream())
        //                {
        //                    // continue reading from the client
        //                    MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
        //        }
        //    }
        //}
        /// <summary>
        /// The ReceiveMessage method recieves and handles the incomming stream
        /// </summary>
        /// <param name="ar">IAsyncResult Interface</param>
        private static void ReceiveFile(IAsyncResult ar)
        {
            if (MessageClient != null)
            {
                int bytesRead;
                try
                {
                    lock (MessageClient.GetStream())
                    {
                        // call EndRead to handle the end of an async read.
                        bytesRead = MessageClient.GetStream().EndRead(ar);
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
                        string incomingData = System.Text.Encoding.ASCII.GetString(MessageData, 0, bytesRead);
                        string[] messageToArray = incomingData.Split('$');
                        int requestNumber = Convert.ToInt32(messageToArray[0]);
                        string messageDetails = messageToArray[1];
                        string DecryptedMessageDetails;
                        if (requestNumber == EncryptionServerPublicKeyReciever)
                        {
                            ServerPublicKey = messageDetails; //maybe i should make the publickey as bytes and not string and then do the switch to string just after that...
                        }
                        else if (requestNumber == EncryptionSymmetricKeyReciever)//gets Symmetrical Key
                        {
                            DecryptedMessageDetails = Rsa.Decrypt(messageDetails, PrivateKey);
                            SymmetricKey = DecryptedMessageDetails;
                        }
                        else
                        {
                            DecryptedMessageDetails = Encryption.Encryption.DecryptData(SymmetricKey, messageDetails);
                            if (requestNumber == registerResponse)
                            {
                                if (isConnected)
                                {
                                    lock (MessageClient.GetStream())
                                    {
                                        // continue reading from the client
                                        MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);
                                    }
                                }
                            }
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
        public static void SendMessage(int messageId, string messageContent) //maybe to add a function that recieves only messageId (i dont need to send content all the time...)
        {
            if (isConnected)
            {
                try
                {
                    string message = messageId + "$";
                    if (messageId == EncryptionClientPublicKeySender)
                    {
                        message += messageContent;
                    }
                    else
                    {
                        string EncryptedMessageContent = Encryption.Encryption.EncryptData(SymmetricKey, messageContent);
                        message += EncryptedMessageContent;
                    }
                    NetworkStream ns = MessageClient.GetStream();

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

        public static void SendMessage(string jsonMessage,bool needEncryption = true) //maybe to add a function that recieves only messageId (i dont need to send content all the time...)
        {
            if (isKeyExchangeInProgress)
            {
                // Queue the message for sending after the key exchange process is over
                messageQueue.Enqueue(jsonMessage);
                return;
            }
            if (isConnected)
            {
                try
                {
                    byte signal = needEncryption ? (byte)1 : (byte)0;

                    if (needEncryption)
                    {
                        jsonMessage = Encryption.Encryption.EncryptData(SymmetricKey, jsonMessage);
                    }
                    string messageToSend = Encoding.UTF8.GetString(new byte[] { signal }) + jsonMessage;

                    NetworkStream ns = MessageClient.GetStream();

                    // Send data to the client
                    byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(messageToSend);

                    // Prefixes 4 Bytes Indicating Message Length
                    byte[] length = BitConverter.GetBytes(bytesToSend.Length); // the length of the message in byte array
                    byte[] prefixedBuffer = new byte[bytesToSend.Length + sizeof(int)]; // the maximum size of int number in bytes array

                    Array.Copy(length, 0, prefixedBuffer, 0, sizeof(int)); // to get a fixed size of the prefix to the message
                    Array.Copy(bytesToSend, 0, prefixedBuffer, sizeof(int), bytesToSend.Length); // add the prefix to the message

                    // Actually send it

                    ns.Write(prefixedBuffer, 0, prefixedBuffer.Length);
                    ns.Flush();


                    //ns.Write(bytesToSend, 0, bytesToSend.Length);
                    //ns.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private static void SendQueuedMessages()
        {
            while (messageQueue.Count > 0)
            {
                SendMessage(messageQueue.Dequeue());
            }
        }
        public static void SendMessageAndImage(int messageId, string messageContent, Image image)
        {
            if (isConnected)
            {
                try
                {
                    string message = messageId + "$";
    

                    string EncryptedMessageContent = Encryption.Encryption.EncryptData(SymmetricKey, messageContent);
                    byte[] EncryptedImage = Encryption.Encryption.EncryptData(SymmetricKey, image);
                    message += EncryptedMessageContent;
                    NetworkStream ns = MessageClient.GetStream();
                    // Send data to the client
                    byte[] StringBytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                    ns.Write(StringBytesToSend, 0, StringBytesToSend.Length);
                    ns.Write(EncryptedImage, 0, EncryptedImage.Length);
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
                    NetworkStream ns = MessageClient.GetStream();

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
            if (MessageClient != null)
            {
                try
                {
                    MessageClient.GetStream().Close();
                    MessageClient.Close();
                    MessageClient.Dispose();
                    MessageClient = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }

}
