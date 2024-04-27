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
using YouChatApp.JsonClasses.MessageClasses;
using YouChatApp.UserAuthentication.Forms;
using YouChatApp.UserProfile;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ChatManager = YouChatApp.ChatHandler.ChatManager;
using Image = System.Drawing.Image;

namespace YouChatApp
{
    public class ServerCommunicator
    {
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
        const string FailedCallRequest = "Your friend is offline. Please try to call again later.";
        const string VideoCallResponse2 = "You have been asked to join a call";
        public const string VideoCallResponseResult1 = "Joining the video call";
        public const string VideoCallResponseResult2 = "Declining the video call";
        const string GroupCreatorResponse1 = "Group was successfully created";

        private bool isKeyExchangeInProgress = false;
        private Queue<string> messageQueue = new Queue<string>();

        public const string RightSmtpCode = "right";
        public const string WrongSmtpCode = "wrong";
        //TCP Sockets:

        /// <summary>
        /// Object which represents the server's TCP client for sending text messages
        /// </summary>
        private TcpClient MessageClient { get; set; }


        /// <summary>
        /// Byte arrays which represent the data received from the server 
        /// MessageData is used for messages received from the MessageClient socket, and FileData for messages received from the FileClient socket
        /// </summary>
        private byte[] MessageData;
        private byte[] dataHistory;



        //Form Instances

      





        private RSAServiceProvider Rsa;
        private string ServerPublicKey;
        private string PrivateKey;

        public string SymmetricKey;
        /// <summary>
        /// 0 - verysmall, 1- small, 2- normal, 3- large, 4 -huge...
        /// </summary>
        public int SelectedMessageTextSize = 2; //todoישר כשמתחברים צריך לקבל מהשרת ביחד עם דברים נוספים 
        // value = 2 for now - until i will get the server to work


        public int CurrentChatNumberID = 0;


        public bool EnterKeyPress = false; //false for now, in the future the value will be chosen when the user connects (the server will send this information


        public ContactDetails _myData;


        /// <summary>
        /// Represents if the client is connected
        /// </summary>
        private bool isConnected;


        public string ProfilePictureId;
        public string ProfileStatus;

        private static string serverIp = "10.100.102.3";

        private static ServerCommunicator _instance;

        public static ServerCommunicator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServerCommunicator(serverIp);

                }
                return _instance;
            }
        }

        private ServerCommunicator(string ip)
        {
            Connect(serverIp);

        }

        /// <summary>
        /// The Connect method attempts to establish a TCP/IP connection with a server using the provided IP addressand port: 1500
        /// If the connection attempt fails, a MessageBox is displayed to the user
        /// This method also creates a byte array to hold incoming data and begins an asynchronous read operation on the client's NetworkStream using the BeginRead method
        /// The Connect method attempts to establish a TCP/IP connection with a server using the provided IP address
        /// </summary>
        /// <param name="ip">Represents the ip address of the server to connect to</param>
        /// <returns>It returns true if the connection is successful. Otherwise, it returns false</returns>
        private bool Connect(string ip)
        {
            MessageClient = new TcpClient();

            try
            {
                MessageClient.Connect(ip, 1500); //todo - to change the server ip to my computer ip

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
            MessageClient.GetStream().BeginRead(MessageData,
                                                               0,
                                                               4,
                                                               ReceiveMessageLength,
                                                               null);
            dataHistory = new byte[0];
            return true;
        }
        public void BeginRead()
        {
            MessageClient.GetStream().BeginRead(MessageData,
                                                   0,
                                                   4,
                                                   ReceiveMessageLength,
                                                   null);
        }
        private void HandleKeys()
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



        private void ReceiveMessageLength(IAsyncResult ar)
        {
            if (MessageClient != null)
            {
                int bytesRead;
                try
                {
                    Console.WriteLine("trying to get lock in length:");
                    lock (MessageClient.GetStream())
                    {
                        // call EndRead to handle the end of an async read.
                        bytesRead = MessageClient.GetStream().EndRead(ar);
                    }
                    Console.WriteLine("unlocked in length:");

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
                            if (bytesRead > MessageData.Length)
                            {
                                byte[] newMessageData = new byte[MessageData.Length];
                                Array.Copy(buffer, 0, newMessageData, 0, bytesRead);
                                Array.Copy(MessageData, 0, newMessageData, 4, MessageData.Length - 4);
                                MessageData = newMessageData;
                                MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);

                            }
                            else
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
        private void ReceiveMessage(IAsyncResult ar)
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

                    //bytesRead = MessageClient.GetStream().EndRead(ar);

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
                        byte[] buffer = new byte[4];
                        Array.Copy(MessageData, 0, buffer, 0, 4);

                        int value = BitConverter.ToInt32(buffer, 0);
                        int newLength = dataHistory.Length + bytesRead - 4;

                        // Create a new array to hold the combined data
                        byte[] newDataHistory = new byte[newLength];

                        // Copy the existing dataHistory to the new array
                        Array.Copy(dataHistory, 0, newDataHistory, 0, dataHistory.Length);

                        // Copy the MessageData to the end of the new array
                        Array.Copy(MessageData, 4, newDataHistory, dataHistory.Length, bytesRead - 4);

                        // Assign the new array to dataHistory
                        dataHistory = newDataHistory;

                        if (value == 1)
                        {
                            string incomingData = System.Text.Encoding.ASCII.GetString(dataHistory, 0, dataHistory.Length);
                            byte receivedByteSignal = (byte)incomingData[0];
                            string actualMessage = incomingData.Substring(1);
                            Console.WriteLine(actualMessage);
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
                                    //MessageBox.Show(registerResponse1);
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.OpenProfilePictureSelector(); });
                                    //FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.OpenInitialProfileSelectionForm(true); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedRegistration:
                                    MessageBox.Show(registerResponse2);
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleProblematicDetails(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureResponse:
                                    ProfilePictureId = jsonObject.MessageBody as string;
                                    FormHandler._profilePictureSelector.Invoke((Action)delegate { FormHandler._profilePictureSelector.OpenStatusSelector(); });

                                    //FormHandler._initialProfileSelection.Invoke((Action)delegate { FormHandler._initialProfileSelection.SetPhaseTwo(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UploadStatusResponse:
                                    ProfileStatus = jsonObject.MessageBody as string;
                                    FormHandler._profileStatusSelector.Invoke((Action)delegate { FormHandler._profileStatusSelector.OpenApp(); });
                                    //FormHandler._initialProfileSelection.Invoke((Action)delegate { FormHandler._initialProfileSelection.OpenApp(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SmtpRegistrationMessage:
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleRecievedEmail(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SuccessfulSmtpRegistrationCode:
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleCodeResponse(true); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedSmtpRegistrationCode:
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleCodeResponse(false); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.ResetPasswordResponse_SmtpMessage:
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleRecievedEmail(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulResetPasswordResponse_SmtpCode:
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleCorrectCodeResponse(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedResetPasswordResponse_SmtpCode:
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleWrongCodeResponse(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.loginResponse_SmtpLoginMessage:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleRecievedEmail(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.loginResponse_FailedLogin:
                                    MessageBox.Show(FailedLoginResponse);
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.setLoginButtonEnabled(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.LoginResponse_SuccessfulSmtpLoginCode:
                                    ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
                                    byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
                                    Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCorrectCodeResponse(captchaCodeImage); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.CaptchaImageResponse:
                                    HandleCaptchaImageResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.LoginResponse_FailedSmtpLoginCode:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleWrongCodeResponse(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulCaptchaCodeResponse:
                                case EnumHandler.CommunicationMessageID_Enum.CaptchaImageAngleResponse:
                                    HandleCaptchaImageAngleResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedCaptchaCodeResponse:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleWrongCaptchaCode(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulCaptchaImageAngleResponse:
                                    HandleSuccessfulCaptchaImageAngleResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_UpdatePassword:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandlePasswordUpdateCase(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserProfilePicture:
                                case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserProfilePicture:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenProfilePictureSelector(); });

                                    //FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenInitialProfileSelection(true); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserStatus:
                                case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserStatus:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenStatusSelector(); });

                                    //FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenInitialProfileSelection(false); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_OpenChat:
                                case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_OpenChat:
                                    //MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenApp(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedPersonalVerificationAnswersResponse:
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_HandleError:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleWrongPersonalVerificationAnswers(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPasswordUpdateResponse:
                                    FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.HandleSuccessfulPasswordUpdate(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedPasswordUpdateResponse_PasswordExist:
                                    MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
                                    FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.SetEnable(true); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedPasswordUpdateResponse_UnmatchedDetails:
                                    MessageBox.Show(PasswordMessageResponse4, "Unmatched Details.");
                                    FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.SetEnable(true); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.ErrorHandlePasswordUpdateResponse:
                                    MessageBox.Show("try again", "Error occured.");
                                    FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.SetEnable(true); });
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
                                    UserProfile.ProfileDetailsHandler.TagLine = userDetails.TagLineId;

                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetProfilePicture(); });

                                    //needs to restart everything according to it...
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.LoginBanStart:
                                    double banDuration = (double)jsonObject.MessageBody;
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleBan(banDuration); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.LoginBanFinish:
                                    HandleLoginBanFinishEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.PasswordUpdateBanStart:
                                    HandlePasswordUpdateBanStartEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.PasswordUpdateBanFinish:
                                    HandlePasswordUpdateBanFinishEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.ResetPasswordBanStart:
                                    HandleResetPasswordBanStartEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.ResetPasswordBanFinish:
                                    HandleResetPasswordBanFinishEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulResetPasswordResponse:
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleMatchingUsernameAndEmailAddress(); });

                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedResetPasswordResponse:
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.RestartDetails(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.PastFriendRequestsResponse:
                                    PastFriendRequests pastFriendRequests = jsonObject.MessageBody as PastFriendRequests;
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetListOfFriendRequestControl(pastFriendRequests); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulRenewalMessageResponse:
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleSuccessfulPasswordRenewal(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedRenewalMessageResponse:
                                    MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.SetPasswordGeneratorControlEnable(true); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.ErrorHandleRenewalMessageResponse:
                                    MessageBox.Show("try again", "Error occured.");
                                    FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.SetPasswordGeneratorControlEnable(true); });
                                    break;
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
                                case EnumHandler.CommunicationMessageID_Enum.GroupCreatorResponse:
                                    HandleGroupCreatorResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SendMessageResponse:
                                    HandleSendMessageResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulVideoCallResponse_Sender:
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulAudioCallResponse_Sender:
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenWaitingForm(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulVideoCallResponse_Reciever:
                                    HandleSuccessfulVideoCallResponse_RecieverEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.FailedVideoCallResponse:
                                case EnumHandler.CommunicationMessageID_Enum.FailedAudioCallResponse:
                                    MessageBox.Show(FailedCallRequest);
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.EnableDirectChatFeaturesPanel(); });

                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallAcceptanceResponse:
                                    HandleVideoCallAcceptanceResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallDenialResponse:
                                case EnumHandler.CommunicationMessageID_Enum.AudioCallDenialResponse:
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseWaitingForm(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallMuteResponse:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleMute(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallUnmuteResponse:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleUnmute(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOnResponse:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCameraOn(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOffResponse:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCameraOff(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndVideoCallResponse_Reciever:
                                    Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCallOver(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndVideoCallResponse_Sender:
                                    Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseVideoCall(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.MessageHistoryResponse:
                                    HandleMessageHistoryResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.OnlineUpdate:
                                    HandleOnlineUpdateEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.OfflineUpdate:
                                    HandleOfflineUpdateEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulAudioCallResponse_Reciever:
                                    HandleSuccessfulAudioCallResponse_RecieverEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.AudioCallAcceptanceResponse:
                                    HandleAudioCallAcceptanceResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UdpAudioConnectionResponse:
                                    string EncryptedUdpSymmetricKey = jsonObject.MessageBody as string;
                                    string symmetricKey = Rsa.Decrypt(EncryptedUdpSymmetricKey, PrivateKey);
                                    AudioServerCommunication.symmetricKey = symmetricKey;
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenAudioCall(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UdpVideoConnectionResponse:
                                    UdpDetails udpDetails = jsonObject.MessageBody as UdpDetails;
                                    string encryptedUdpAudioSymmetricKey = udpDetails.FieldNumber1;
                                    string encryptedUdpVideoSymmetricKey = udpDetails.FieldNumber2;

                                    string audioSymmetricKey = Rsa.Decrypt(encryptedUdpAudioSymmetricKey, PrivateKey);
                                    string videoSymmetricKey = Rsa.Decrypt(encryptedUdpVideoSymmetricKey, PrivateKey);

                                    AudioServerCommunication.symmetricKey = audioSymmetricKey;
                                    VideoServerCommunication.symmetricKey = videoSymmetricKey;

                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenVideoCall(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndAudioCallResponse_Reciever:
                                    Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
                                    FormHandler._audioCall.Invoke((Action)delegate { FormHandler._audioCall.HandleCallOver(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndAudioCallResponse_Sender:
                                    Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseAudioCall(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.DeleteMessageResponse:
                                    HandleDeleteMessageResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusResponse_Sender:
                                    string status = jsonObject.MessageBody as string;
                                    UserProfile.ProfileDetailsHandler.Status = status;
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusResponse_Reciever:
                                    HandleUpdateProfileStatusResponse_RecieverEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_Sender:
                                    string profilePictureId = jsonObject.MessageBody as string;
                                    UserProfile.ProfileDetailsHandler.ProfilePictureId = profilePictureId; //need to convert it to the image
                                    UserProfile.ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(UserProfile.ProfileDetailsHandler.ProfilePictureId);
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleProfilePictureChange(ProfileDetailsHandler.Name, profilePictureId); });

                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_ContactReciever:
                                    HandleUpdateProfilePictureResponse_ContactRecieverEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_ChatUserReciever:
                                    HandleUpdateProfilePictureResponse_ChatUserRecieverEnum(jsonObject);
                                    break;
                            }
                            dataHistory = new byte[0];

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
                        //MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);

                        Console.WriteLine("unlocked in message2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
                }
            }
        }


        ///// <summary>
        ///// The ReceiveMessage method recieves and handles the incomming stream
        ///// </summary>
        ///// <param name="ar">IAsyncResult Interface</param>
        //private void ReceiveMessage(IAsyncResult ar)
        //{
        //    if (MessageClient != null)
        //    {
        //        int bytesRead;
        //        try
        //        {
        //            Console.WriteLine("trying to get lock in message");

        //            lock (MessageClient.GetStream())
        //            {
        //                // call EndRead to handle the end of an async read.
        //                bytesRead = MessageClient.GetStream().EndRead(ar);
        //            }

        //            //bytesRead = MessageClient.GetStream().EndRead(ar);

        //            Console.WriteLine("unlocked message");

        //            // if bytesread<1 -> the client disconnected
        //            if (bytesRead < 1)
        //            {
        //                MessageBox.Show("Server is down.", "Server Communication");
        //                Disconnect();
        //                return;
        //            }
        //            else // client still connected
        //            {
        //                //byte[] buffer = new byte[4];
        //                //Array.Copy(MessageData,0, buffer,0, 4);

        //                //int value = BitConverter.ToInt32(buffer, 0);
        //                //int newLength = dataHistory.Length + bytesRead - 4;

        //                //// Create a new array to hold the combined data
        //                //byte[] newDataHistory = new byte[newLength];

        //                //// Copy the existing dataHistory to the new array
        //                //Array.Copy(dataHistory, 0, newDataHistory, 0, dataHistory.Length);

        //                //// Copy the MessageData to the end of the new array
        //                //Array.Copy(MessageData, 0, newDataHistory, dataHistory.Length, bytesRead - 4);

        //                //// Assign the new array to dataHistory
        //                //dataHistory = newDataHistory;

        //                //if (value == 1)
        //                //{
        //                //    //to use the data...
        //                //}
        //                string incomingData = System.Text.Encoding.ASCII.GetString(MessageData, 0, bytesRead);
        //                byte receivedByteSignal = (byte)incomingData[0];
        //                string actualMessage = incomingData.Substring(1);

        //                // if the client is sending send me datatable
        //                if (receivedByteSignal == 1)
        //                {
        //                    actualMessage = Encryption.Encryption.DecryptData(SymmetricKey, actualMessage);
        //                }
        //                JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(actualMessage, new JsonSerializerSettings
        //                {
        //                    TypeNameHandling = TypeNameHandling.Auto,
        //                    Binder = new NamespaceAdjustmentBinder(),
        //                    Converters = { new EnumConverter<EnumHandler.CommunicationMessageID_Enum>() }
        //                });
        //                EnumHandler.CommunicationMessageID_Enum messageType = (EnumHandler.CommunicationMessageID_Enum)jsonObject.MessageType;
        //                switch (messageType)
        //                {
        //                    case EnumHandler.CommunicationMessageID_Enum.EncryptionServerPublicKeyReciever:
        //                        ServerPublicKey = jsonObject.MessageBody as string;
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.EncryptionSymmetricKeyReciever:
        //                        string EncryptedSymmetricKeyReciever = jsonObject.MessageBody as string;
        //                        SymmetricKey = Rsa.Decrypt(EncryptedSymmetricKeyReciever, PrivateKey);
        //                        isKeyExchangeInProgress = false;
        //                        SendQueuedMessages();
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.EncryptionRenewKeys:
        //                        HandleKeys();
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SuccessfulRegistration:
        //                        //MessageBox.Show(registerResponse1);
        //                        FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.OpenProfilePictureSelector(); });
        //                        //FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.OpenInitialProfileSelectionForm(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedRegistration:
        //                        MessageBox.Show(registerResponse2);
        //                        FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleProblematicDetails(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureResponse:
        //                        ProfilePictureId = jsonObject.MessageBody as string;
        //                        FormHandler._profilePictureSelector.Invoke((Action)delegate { FormHandler._profilePictureSelector.OpenStatusSelector(); });

        //                        //FormHandler._initialProfileSelection.Invoke((Action)delegate { FormHandler._initialProfileSelection.SetPhaseTwo(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UploadStatusResponse:
        //                        ProfileStatus = jsonObject.MessageBody as string;
        //                        FormHandler._profileStatusSelector.Invoke((Action)delegate { FormHandler._profileStatusSelector.OpenApp(); });
        //                        //FormHandler._initialProfileSelection.Invoke((Action)delegate { FormHandler._initialProfileSelection.OpenApp(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SmtpRegistrationMessage:
        //                        FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleRecievedEmail(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SuccessfulSmtpRegistrationCode:
        //                        FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleCodeResponse(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedSmtpRegistrationCode:
        //                        FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleCodeResponse(false); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ResetPasswordResponse_SmtpMessage:
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleRecievedEmail(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulResetPasswordResponse_SmtpCode:
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleCorrectCodeResponse(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedResetPasswordResponse_SmtpCode:
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleWrongCodeResponse(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.loginResponse_SmtpLoginMessage:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleRecievedEmail(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.loginResponse_FailedLogin:
        //                        MessageBox.Show(FailedLoginResponse);
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.setLoginButtonEnabled(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.LoginResponse_SuccessfulSmtpLoginCode:
        //                        ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
        //                        byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
        //                        Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCorrectCodeResponse(captchaCodeImage); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.CaptchaImageResponse:
        //                        HandleCaptchaImageResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.LoginResponse_FailedSmtpLoginCode:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleWrongCodeResponse(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulCaptchaCodeResponse:
        //                    case EnumHandler.CommunicationMessageID_Enum.CaptchaImageAngleResponse:
        //                        HandleCaptchaImageAngleResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedCaptchaCodeResponse:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleWrongCaptchaCode(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulCaptchaImageAngleResponse:
        //                        HandleSuccessfulCaptchaImageAngleResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_UpdatePassword:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandlePasswordUpdateCase(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserProfilePicture:
        //                    case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserProfilePicture:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenProfilePictureSelector(); });

        //                        //FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenInitialProfileSelection(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserStatus:
        //                    case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserStatus:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenStatusSelector(); });

        //                        //FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenInitialProfileSelection(false); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_OpenChat:
        //                    case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_OpenChat:
        //                        //MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenApp(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedPersonalVerificationAnswersResponse:
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_HandleError:
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleWrongPersonalVerificationAnswers(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulPasswordUpdateResponse:
        //                        FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.HandleSuccessfulPasswordUpdate(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedPasswordUpdateResponse_PasswordExist:
        //                        MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
        //                        FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.SetEnable(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedPasswordUpdateResponse_UnmatchedDetails:
        //                        MessageBox.Show(PasswordMessageResponse4, "Unmatched Details.");
        //                        FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.SetEnable(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ErrorHandlePasswordUpdateResponse:
        //                        MessageBox.Show("try again", "Error occured.");
        //                        FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.SetEnable(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_HandleError:
        //                        MessageBox.Show("try again", "Error occured.");
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UserDetailsResponse:
        //                        //ProfilePictureImageList.InitializeImageLists();
        //                        UserDetails userDetails = jsonObject.MessageBody as UserDetails;
        //                        UserProfile.ProfileDetailsHandler.Name = userDetails.Username;
        //                        UserProfile.ProfileDetailsHandler.ProfilePictureId = userDetails.ProfilePicture; //need to convert it to the image
        //                        UserProfile.ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(UserProfile.ProfileDetailsHandler.ProfilePictureId);//returns the wrong image for some reason                                                                                                                                           //a soultion might be a object and not a static class...
        //                        UserProfile.ProfileDetailsHandler.Status = userDetails.ProfileStatus;
        //                        UserProfile.ProfileDetailsHandler.TagLine = userDetails.TagLineId;

        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetProfilePicture(); });

        //                        //needs to restart everything according to it...
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.LoginBanStart:
        //                        double banDuration = (double)jsonObject.MessageBody;
        //                        FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleBan(banDuration); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.LoginBanFinish:
        //                        HandleLoginBanFinishEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.PasswordUpdateBanStart:
        //                        HandlePasswordUpdateBanStartEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.PasswordUpdateBanFinish:
        //                        HandlePasswordUpdateBanFinishEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ResetPasswordBanStart:
        //                        HandleResetPasswordBanStartEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ResetPasswordBanFinish:
        //                        HandleResetPasswordBanFinishEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulResetPasswordResponse:
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleMatchingUsernameAndEmailAddress(); });

        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedResetPasswordResponse:
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.RestartDetails(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.PastFriendRequestsResponse:
        //                        PastFriendRequests pastFriendRequests = jsonObject.MessageBody as PastFriendRequests;
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetListOfFriendRequestControl(pastFriendRequests); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulRenewalMessageResponse:
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleSuccessfulPasswordRenewal(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedRenewalMessageResponse:
        //                        MessageBox.Show("Choose a new pasword", "Password Already Chosen.");
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.SetPasswordGeneratorControlEnable(true); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ErrorHandleRenewalMessageResponse:
        //                        MessageBox.Show("try again", "Error occured.");
        //                        FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.SetPasswordGeneratorControlEnable(true); });
        //                        break;
        //                    //case EnumHandler.CommunicationMessageID_Enum.EncryptionServerPublicKeyAndSymmetricKeyReciever:
        //                    //    EncryptionKeys encryptionKeys = jsonObject.MessageBody as EncryptionKeys;
        //                    //    ServerPublicKey = encryptionKeys.AsymmetricKey;
        //                    //    string EncryptedSymmetricKey = encryptionKeys.SymmetricKey;
        //                    //    SymmetricKey = Rsa.Decrypt(EncryptedSymmetricKey, PrivateKey);
        //                    //    break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationBanStart:
        //                        HandleRegistrationBanStartEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.RegistrationBanFinish:
        //                        HandleRegistrationBanFinishEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FriendRequestReciever:
        //                        HandleFriendRequestRecieverEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FriendRequestResponseReciever:
        //                        HandleFriendRequestResponseRecieverEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ContactInformationResponse:
        //                        HandleContactInformationResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.ChatInformationResponse:
        //                        HandleChatInformationResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.GroupCreatorResponse:
        //                        HandleGroupCreatorResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SendMessageResponse:
        //                        HandleSendMessageResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulVideoCallResponse_Sender:
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulAudioCallResponse_Sender:
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenWaitingForm(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulVideoCallResponse_Reciever:
        //                        HandleSuccessfulVideoCallResponse_RecieverEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedVideoCallResponse:
        //                    case EnumHandler.CommunicationMessageID_Enum.FailedAudioCallResponse:
        //                        MessageBox.Show(FailedCallRequest);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.VideoCallAcceptanceResponse:
        //                        HandleVideoCallAcceptanceResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.VideoCallDenialResponse:
        //                    case EnumHandler.CommunicationMessageID_Enum.AudioCallDenialResponse:
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseWaitingForm(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.VideoCallMuteResponse:
        //                        FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleMute(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.VideoCallUnmuteResponse:
        //                        FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleUnmute(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOnResponse:
        //                        FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCameraOn(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOffResponse:
        //                        FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCameraOff(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.EndVideoCallResponse_Reciever:
        //                        Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
        //                        FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCallOver(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.EndVideoCallResponse_Sender:
        //                        Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseVideoCall(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.MessageHistoryResponse:
        //                        HandleMessageHistoryResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.OnlineUpdate:
        //                        HandleOnlineUpdateEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.OfflineUpdate:
        //                        HandleOfflineUpdateEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.SuccessfulAudioCallResponse_Reciever:
        //                        HandleSuccessfulAudioCallResponse_RecieverEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.AudioCallAcceptanceResponse:
        //                        HandleAudioCallAcceptanceResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UdpAudioConnectionResponse:
        //                        string EncryptedUdpSymmetricKeyReciever = jsonObject.MessageBody as string;
        //                        string symmetricKey = Rsa.Decrypt(EncryptedUdpSymmetricKeyReciever, PrivateKey);
        //                        AudioServerCommunication.symmetricKey = symmetricKey;
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenAudioCall(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.EndAudioCallResponse_Reciever:
        //                        Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
        //                        FormHandler._audioCall.Invoke((Action)delegate { FormHandler._audioCall.HandleCallOver(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.EndAudioCallResponse_Sender:
        //                        Console.WriteLine(UserProfile.ProfileDetailsHandler.Name);
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseAudioCall(); });
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.DeleteMessageResponse:
        //                        HandleDeleteMessageResponseEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusResponse_Sender:
        //                        string status = jsonObject.MessageBody as string;
        //                        UserProfile.ProfileDetailsHandler.Status = status;
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusResponse_Reciever:
        //                        HandleUpdateProfileStatusResponse_RecieverEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_Sender:
        //                        string profilePictureId = jsonObject.MessageBody as string;
        //                        UserProfile.ProfileDetailsHandler.ProfilePictureId = profilePictureId; //need to convert it to the image
        //                        UserProfile.ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(UserProfile.ProfileDetailsHandler.ProfilePictureId);
        //                        FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleProfilePictureChange(ProfileDetailsHandler.Name, profilePictureId); });

        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_ContactReciever:
        //                        HandleUpdateProfilePictureResponse_ContactRecieverEnum(jsonObject);
        //                        break;
        //                    case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_ChatUserReciever:
        //                        HandleUpdateProfilePictureResponse_ChatUserRecieverEnum(jsonObject);
        //                        break;
        //                }
        //            }
        //            if (isConnected)
        //            {
        //                Console.WriteLine("trying to get lock in message2");

        //                lock (MessageClient.GetStream())
        //                {
        //                    // continue reading from the client
        //                    MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);
        //                    //dataHistory = new byte[0];
        //                    //MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);
        //                }
        //                //MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);

        //                Console.WriteLine("unlocked in message2");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
        //        }
        //    }
        //}
        private static void OpenYouChat()
        {
            FormHandler._youChat = new YouChat();

            FormHandler._youChat.ShowDialog();
            //FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenApp(); });
        }
        private void HandleUpdateProfilePictureResponse_ChatUserRecieverEnum(JsonObject jsonObject)
        {
            ProfilePictureUpdate profilePictureUpdate = jsonObject.MessageBody as ProfilePictureUpdate;
            string username = profilePictureUpdate.Username;
            string profilePictureId = profilePictureUpdate.ProfilePictureId;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleProfilePictureChange(username, profilePictureId); });

        }
        private void HandleUpdateProfilePictureResponse_ContactRecieverEnum(JsonObject jsonObject)
        {
            ProfilePictureUpdate profilePictureUpdate = jsonObject.MessageBody as ProfilePictureUpdate;
            string username = profilePictureUpdate.Username;
            string profilePictureId = profilePictureUpdate.ProfilePictureId;
            Contact contact = ContactManager.GetContact(username);
            contact.ProfilePicture = ProfilePictureImageList.GetImageByImageId(profilePictureId);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.ChangeUserProfilePicture(username, profilePictureId, contact.ProfilePicture); });

        }
        private void HandleOfflineUpdateEnum(JsonObject jsonObject)
        {
            OfflineDetails offlineDetails = jsonObject.MessageBody as OfflineDetails;
            string username = offlineDetails.Username;
            DateTime lastSeenTime = offlineDetails.LastSeenTime;
            Contact contact = ContactManager.GetContact(username);
            contact.Online = false;
            contact.LastSeenTime = lastSeenTime;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetChatOnline(username, false, lastSeenTime); });

        }
        private void HandleUpdateProfileStatusResponse_RecieverEnum(JsonObject jsonObject)
        {
            StatusUpdate statusUpdate = jsonObject.MessageBody as StatusUpdate;
            string username = statusUpdate.username;
            string status = statusUpdate.Status;
            Contact contact = ContactManager.GetContact(username);
            contact.Status = status;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.ChangeUserStatus(username, status); });
        }
        private void HandleOnlineUpdateEnum(JsonObject jsonObject)
        {
            string userToBecomeOnlineName = jsonObject.MessageBody as string;
            Contact contact = ContactManager.GetContact(userToBecomeOnlineName);
            contact.Online = true;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetChatOnline(userToBecomeOnlineName,true); });

        }
        private void HandleMessageHistoryResponseEnum(JsonObject jsonObject)
        {
            MessageHistory messageHistory = jsonObject.MessageBody as MessageHistory;
            List<JsonClasses.Message> messages = messageHistory.Messages;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleMessageHistory(messages); });

        }
        private void HandleSuccessfulAudioCallResponse_RecieverEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenCallInvitation(details[0], details[1],false); });

        }
        private void HandleSuccessfulVideoCallResponse_RecieverEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenCallInvitation(details[0], details[1],true); });

        }
        private void HandleVideoCallAcceptanceResponseEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            //FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenVideoCall(details[0], details[1]); });
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.StartVideoUdpConnection(details[0], details[1]); });

        }
        private void HandleAudioCallAcceptanceResponseEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.StartAudioUdpConnection(details[0], details[1]); });
        }

        private string[] GetFriendName(JsonObject jsonObject)
        {
            string chatId = jsonObject.MessageBody as string;
            ChatDetails chatDetails = ChatManager.GetChat(chatId);
            DirectChat directChat = (DirectChat)chatDetails;
            string friendName = directChat.GetContactName();
            return new string[] { chatId, friendName};
        }
        private void HandleDeleteMessageResponseEnum(JsonObject jsonObject)
        {
            JsonClasses.Message message = jsonObject.MessageBody as JsonClasses.Message;
            string messageSenderName = message.MessageSenderName;
            string chatId = message.ChatId;
            DateTime messageDateTime = message.MessageDateAndTime;
            object messageContent = message.MessageContent;
            string content = "";
            if (messageContent is string textMessageContent)
            {
                content = textMessageContent;
            }
            else if (messageContent is ImageContent imageMessageContent)
            {
                content = "Image";
            }
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleDeletedMessage(messageSenderName, chatId, messageDateTime, content); });

        }
        private void HandleSendMessageResponseEnum(JsonObject jsonObject)
        {
            JsonClasses.Message message = jsonObject.MessageBody as JsonClasses.Message;
            string messageSenderName = message.MessageSenderName;
            string chatId = message.ChatId;
            DateTime messageDateTime = message.MessageDateAndTime;
            object messageContent = message.MessageContent;
            if (messageContent is string textMessageContent)
            {
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleMessagesByOthers(messageSenderName, chatId, messageDateTime, textMessageContent); });

            }
            else if (messageContent is ImageContent imageMessageContent)
            {
                byte[] imageMessageContentByteArray = imageMessageContent.ImageBytes;
                Image imageMessage = ConvertHandler.ConvertBytesToImage(imageMessageContentByteArray);
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleImageMessagesByOthers(messageSenderName, chatId, messageDateTime, imageMessage); });
            }
            else if (messageContent is null)
            {
                //deleted message
            }
        }
        private void HandleGroupCreatorResponseEnum(JsonObject jsonObject)
        {
            GroupChatDetails groupChatDetails = jsonObject.MessageBody as GroupChatDetails;
            ChatManager.AddChat(groupChatDetails);
            string chatId = groupChatDetails.ChatTagLineId;
            ChatDetails chat = ChatManager.GetChat(chatId);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleNewGroupChatCreation(chat); });

        }
        private void HandleFriendRequestRecieverEnum(JsonObject jsonObject)
        {
            PastFriendRequest pastFriendRequest = jsonObject.MessageBody as PastFriendRequest;

            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleNewFriendRequest(pastFriendRequest); });

        }
        private void HandleChatInformationResponseEnum(JsonObject jsonObject)
        {
            Chats chats = jsonObject.MessageBody as Chats;
            List<ChatDetails> chatDetailsList = chats.ChatList;
            ChatDetails chat;
            foreach (ChatDetails chatDetails in chatDetailsList)
            {
                ChatManager.AddChat(chatDetails);
            }
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetChatControlListOfContacts(); });

        }
        private void HandleContactInformationResponseEnum(JsonObject jsonObject)
        {
            Contacts contacts = jsonObject.MessageBody as Contacts;
            List<ContactDetails> contactDetailsList = contacts.ContactList;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetContactControlList(contactDetailsList); });
            JsonObject chatInformationRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.ChatInformationRequest, null);
            string chatInformationRequestJson = JsonConvert.SerializeObject(chatInformationRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            SendMessage(chatInformationRequestJson);

        }
        private void HandleFriendRequestResponseRecieverEnum(JsonObject jsonObject)
        {
            ContactAndChat contactAndChat = jsonObject.MessageBody as ContactAndChat;
            ContactDetails contactDetails = contactAndChat.ContactDetails;
            Contact contact = new Contact(contactDetails);
            ContactManager.AddContact(contact);
            ChatDetails chatDetails = contactAndChat.Chat;
            ChatManager.AddChat(chatDetails);
            string chatId = chatDetails.ChatTagLineId;

            ChatDetails chat = ChatManager.GetChat(chatId);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleSuccessfulFriendRequest(contact, chat); });

        }
        private void HandleResetPasswordBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleBan(banDuration); });
        }
        private void HandleResetPasswordBanFinishEnum(JsonObject jsonObject)
        {
            FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleBanOver(); });
        }
        private void HandlePasswordUpdateBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.HandleBan(banDuration); });
        }
        private void HandlePasswordUpdateBanFinishEnum(JsonObject jsonObject)
        {
            FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.HandleBanOver(); });
        }
        private void HandleRegistrationBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleBan(banDuration); });
        }
        private void HandleRegistrationBanFinishEnum(JsonObject jsonObject)
        {
            FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleBanOver(); });
        }
        private void HandleCaptchaImageAngleResponseEnum(JsonObject jsonObject)
        {
            CaptchaRotationImageDetails captchaRotationImageDetails = jsonObject.MessageBody as CaptchaRotationImageDetails;
            object[] values = HandleCaptchaRotationImageDetailsArrival(captchaRotationImageDetails);
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCorrectCaptchaCode((Image)values[2], (Image)values[3], (int)values[0], (int)values[1]); });
        }
        private object[] HandleCaptchaRotationImageDetailsArrival(CaptchaRotationImageDetails captchaRotationImageDetails)
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
        private void HandleLoginBanFinishEnum(JsonObject jsonObject)
        {
            if (jsonObject.MessageBody == null)
            {
                FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleBanOver(); });
            }
            else if (jsonObject.MessageBody is CaptchaRotationImageDetails captchaRotationImageDetails)
            {
                object[] values = HandleCaptchaRotationImageDetailsArrival(captchaRotationImageDetails);
                FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleBanOver((Image)values[2], (Image)values[3], (int)values[0], (int)values[1]); });
            }
        }

        private void HandleCaptchaImageResponseEnum(JsonObject jsonObject)
        {
            ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
            byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
            Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCaptchaImageRenewal(captchaCodeImage); });
        }
        private void HandleSuccessfulCaptchaImageAngleResponseEnum(JsonObject jsonObject)
        {
            PersonalVerificationQuestionDetails verificationQuestionDetails = jsonObject.MessageBody as PersonalVerificationQuestionDetails;
            PersonalVerificationQuestions personalVerificationQuestions = verificationQuestionDetails.PersonalVerificationQuestions;
            CaptchaRotationSuccessRate captchaRotationSuccessRate = verificationQuestionDetails.CaptchaRotationSuccessRate;
            int score = captchaRotationSuccessRate.Score;
            int attempts = captchaRotationSuccessRate.Attempts;

            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleSuccessfulCaptchaImageAngleResponse(personalVerificationQuestions, score,attempts); });
        }



        public void SendMessage(string jsonMessage,bool needEncryption = true) //maybe to add a function that recieves only messageId (i dont need to send content all the time...)
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
                    byte[] jsonMessageBytes = System.Text.Encoding.UTF8.GetBytes(jsonMessage);

                    // Create a new byte array to hold the final message
                    byte[] totalBytesToSend = new byte[jsonMessageBytes.Length + 1];

                    // Copy the signal byte to the first position in the new array
                    totalBytesToSend[0] = signal;

                    // Copy the message bytes to the remaining positions in the new array
                    Array.Copy(jsonMessageBytes, 0, totalBytesToSend, 1, jsonMessageBytes.Length);
                    NetworkStream ns = MessageClient.GetStream();

                    int bufferSize = MessageClient.ReceiveBufferSize;
                    byte[] bytesToSend;
                    byte[] buffer;
                    byte[] length;
                    byte[] prefixedBuffer;
                    while (totalBytesToSend.Length > 0)
                    {
                        if (totalBytesToSend.Length > bufferSize - 8)
                        {
                            bytesToSend = new byte[bufferSize - 8];
                            Array.Copy(totalBytesToSend, 0, bytesToSend, 0, bufferSize - 8);
                            buffer = BitConverter.GetBytes(0); //indicates it's not the last message.
                        }
                        else
                        {
                            bytesToSend = totalBytesToSend;
                            buffer = BitConverter.GetBytes(1); //indicates it's the last message...
                        }

                        length = BitConverter.GetBytes(bytesToSend.Length + sizeof(int));  // the length of the message in byte array
                        prefixedBuffer = new byte[bytesToSend.Length + (2 * sizeof(int))];

                        Array.Copy(length, 0, prefixedBuffer, 0, sizeof(int));
                        Array.Copy(buffer, 0, prefixedBuffer, sizeof(int), sizeof(int));
                        Array.Copy(bytesToSend, 0, prefixedBuffer, (2 * sizeof(int)), bytesToSend.Length);

                        ns.Write(prefixedBuffer, 0, prefixedBuffer.Length);
                        ns.Flush();

                        if (totalBytesToSend.Length > bufferSize - 8)
                        {
                            byte[] newTotalBytesToSend = new byte[totalBytesToSend.Length - (System.Convert.ToInt32(bufferSize) - 8)];

                            Array.Copy(totalBytesToSend, System.Convert.ToInt32(bufferSize) - 8, newTotalBytesToSend, 0, newTotalBytesToSend.Length); // to get a fixed size of the prefix to the message
                            totalBytesToSend = newTotalBytesToSend;
                        }
                        else
                        {
                            totalBytesToSend = new byte[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void SendQueuedMessages()
        {
            while (messageQueue.Count > 0)
            {
                SendMessage(messageQueue.Dequeue());
            }
        }
        public void SendMessageAndImage(int messageId, string messageContent, Image image)
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

        /// <summary>
        /// The Disconnect method disconnects the client from the server
        /// </summary>
        public void Disconnect()
        {
            if (MessageClient != null)
            {
                try
                {
                    if (MessageClient.GetStream().CanRead)
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
        public void CheckSocketStatus()
        {
            if (MessageClient != null && MessageClient.Available > 0)
            {
                Console.WriteLine("Connection good");
            }
        }
    }

}
