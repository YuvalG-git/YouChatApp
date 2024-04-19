﻿using Newtonsoft.Json;
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
        public const string FriendRequestResponseSender1 = "Approval";
        public const string FriendRequestResponseSender2 = "Rejection";
        const string VideoCallResponse1 = "Your friend is offline. Please try to call again.";
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

        public int SelectedContacts = 0;


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
            dataHistory = new byte[0]; //נניח שאין מעבר לint הגדול ביותר...
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
                    //Console.WriteLine("trying to get lock in length:");
                    //lock (MessageClient.GetStream())
                    //{
                    //    // call EndRead to handle the end of an async read.
                    //    bytesRead = MessageClient.GetStream().EndRead(ar);
                    //}
                    //Console.WriteLine("unlocked in length:");

                    bytesRead = MessageClient.GetStream().EndRead(ar);

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
                                Array.Copy(buffer, 0, MessageData, 0, bytesRead);

                                MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);

                            }
                            else
                            {
                                Console.WriteLine("trying to get lock in length2:");

                                //lock (MessageClient.GetStream())
                                //{
                                //    // continue reading from the client
                                //    MessageClient.GetStream().BeginRead(MessageData, 0, bytesRead, ReceiveMessage, null);
                                //}
                                MessageClient.GetStream().BeginRead(MessageData, 0, bytesRead, ReceiveMessage, null);
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

                    //lock (MessageClient.GetStream())
                    //{
                    //    // call EndRead to handle the end of an async read.
                    //    bytesRead = MessageClient.GetStream().EndRead(ar);
                    //}

                    bytesRead = MessageClient.GetStream().EndRead(ar);

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
                                FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.OpenInitialProfileSelectionForm(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedRegistration:
                                MessageBox.Show(registerResponse2);
                                FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleProblematicDetails(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureResponse:
                                ProfilePictureId = jsonObject.MessageBody as string;
                                FormHandler._initialProfileSelection.Invoke((Action)delegate { FormHandler._initialProfileSelection.SetPhaseTwo(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.UploadStatusResponse:
                                ProfileStatus = jsonObject.MessageBody as string;
                                FormHandler._initialProfileSelection.Invoke((Action)delegate { FormHandler._initialProfileSelection.OpenApp(); });
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
                            case EnumHandler.CommunicationMessageID_Enum.UdpAudioConnectionResponse:
                                FormHandler._audioCall.Invoke((Action)delegate { FormHandler._audioCall.SetIsAbleToSendToTrue(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_UpdatePassword:
                                FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandlePasswordUpdateCase(); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserProfilePicture:
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserProfilePicture:
                                FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenInitialProfileSelection(true); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserStatus:
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserStatus:

                                FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenInitialProfileSelection(false); });
                                break;
                            case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_OpenChat:
                            case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_OpenChat:
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
                                UserProfile.ProfileDetailsHandler.LastSeenProperty = userDetails.LastSeenProperty;
                                UserProfile.ProfileDetailsHandler.OnlineProperty = userDetails.OnlineProperty;
                                UserProfile.ProfileDetailsHandler.ProfilePictureProperty = userDetails.ProfilePictureProperty;
                                UserProfile.ProfileDetailsHandler.StatusProperty = userDetails.StatusProperty;
                                UserProfile.ProfileDetailsHandler.TextSize = userDetails.TextSizeProperty;
                                UserProfile.ProfileDetailsHandler.MessageGap = userDetails.MessageGapProperty;
                                UserProfile.ProfileDetailsHandler.EnterKeyPressed = userDetails.EnterKeyPressedProperty;
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

                        //lock (MessageClient.GetStream())
                        //{
                        //    // continue reading from the client
                        //    MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);
                        //    //dataHistory = new byte[0];
                        //    //MessageClient.GetStream().BeginRead(MessageData, 0, System.Convert.ToInt32(MessageClient.ReceiveBufferSize), ReceiveMessage, null);
                        //}
                        MessageClient.GetStream().BeginRead(MessageData, 0, 4, ReceiveMessageLength, null);

                        Console.WriteLine("unlocked in message2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
                }
            }
        }
        private void HandleFriendRequestRecieverEnum(JsonObject jsonObject)
        {
            PastFriendRequest pastFriendRequest = jsonObject.MessageBody as PastFriendRequest;

            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.AddFriendRequest(pastFriendRequest); });

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
            string contactName = contact.Name;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleSuccessfulFriendRequest(contact,chatDetails); });

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
       
     

        /// <summary>
        /// The SendMessage method sends a message to the server
        /// </summary>
        /// <param name="message">Represents the message the client sends to the server</param>
        public  void SendMessage(int messageId, string messageContent) //maybe to add a function that recieves only messageId (i dont need to send content all the time...)
        {
            //if (isConnected)
            //{
            //    try
            //    {
            //        string message = messageId + "$";
            //        if (messageId == EncryptionClientPublicKeySender)
            //        {
            //            message += messageContent;
            //        }
            //        else
            //        {
            //            string EncryptedMessageContent = Encryption.Encryption.EncryptData(SymmetricKey, messageContent);
            //            message += EncryptedMessageContent;
            //        }
            //        NetworkStream ns = MessageClient.GetStream();

            //        // Send data to the client
            //        byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
            //        //byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(EncryptedMessage);

            //        ns.Write(bytesToSend, 0, bytesToSend.Length);
            //        ns.Flush();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //}
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
