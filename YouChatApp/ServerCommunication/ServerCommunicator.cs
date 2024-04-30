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
        private const string FailedRegistrationResponse = "Your registeration has failed \nPlease try changing the information provided again";
        private const string FailedLoginResponse = "The login has failed \nYou probably wrote the wrong username or password \nIn case you don't have an account yet, please sign up";
        private const string PasswordRenewalMessage_UnmatchedDetails = "Your past details aren't matching";
        private const string FailedCallRequest = "The user is currently offline or in another call. Please try again later.";

        private bool isKeyExchangeInProgress = false;
        private Queue<MessageState> messageQueue = new Queue<MessageState>();

        private TcpClient Client;

        private byte[] Data;
        private byte[] dataHistory;

        private RSAServiceProvider Rsa;
        private string ServerPublicKey;
        private string PrivateKey;

        public string SymmetricKey;


        private bool isConnected;



        private static string serverIp = "10.100.102.3";

        private static ServerCommunicator _instance;

        public static ServerCommunicator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServerCommunicator();
                }
                return _instance;
            }
        }

        private ServerCommunicator()
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
            Client = new TcpClient();

            try
            {
                Client.Connect(ip, 1500);

            }
            catch
            {
                MessageBox.Show("There wasn't a server in this address...\nPlease Try Again", "Server Connection Attempt");
            }
            if (!Client.Connected)
                return false;
            isConnected = true;
            HandleKeys();

            Data = new byte[Client.ReceiveBufferSize];
            // BeginRead will begin async read from the NetworkStream
            // This allows the server to remain responsive and continue accepting new connections from other clients
            // When reading complete control will be transfered to the ReviveMessage() function.
            Client.GetStream().BeginRead(Data, 0, 4, ReceiveMessageLength, null);
            dataHistory = new byte[0];
            return true;
        }
        private void HandleKeys()
        {
            Rsa = new RSAServiceProvider();
            PrivateKey = Rsa.GetPrivateKey();
            string clientPublicKey = Rsa.GetPublicKey();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.EncryptionClientPublicKeySender;
            object messageContent = clientPublicKey;
            SendMessage(messageType, messageContent, false);
            isKeyExchangeInProgress = true;
        }



        private void ReceiveMessageLength(IAsyncResult ar)
        {
            if (Client != null && Client.Connected)
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
                        byte[] buffer = new byte[bytesRead];
                        Array.Copy(Data, buffer, bytesRead);

                        bytesRead = BitConverter.ToInt32(buffer, 0);

                        if (isConnected)
                        {
                            lock (Client.GetStream())
                            {
                                if (bytesRead > 100000)
                                {
                                    Console.WriteLine(bytesRead);
                                }

                                // continue reading from the client
                                Client.GetStream().BeginRead(Data, 0, bytesRead, ReceiveMessage, null);
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
            if (Client != null && Client.Connected)
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
                        byte[] buffer = new byte[4];
                        Array.Copy(Data, 0, buffer, 0, 4);

                        int value = BitConverter.ToInt32(buffer, 0);
                        int newLength = dataHistory.Length + bytesRead - 4;

                        // Create a new array to hold the combined data
                        byte[] newDataHistory = new byte[newLength];

                        // Copy the existing dataHistory to the new array
                        Array.Copy(dataHistory, 0, newDataHistory, 0, dataHistory.Length);

                        // Copy the MessageData to the end of the new array
                        Array.Copy(Data, 4, newDataHistory, dataHistory.Length, bytesRead - 4);

                        // Assign the new array to dataHistory
                        dataHistory = newDataHistory;

                        if (value == 1)
                        {
                            string incomingData = System.Text.Encoding.ASCII.GetString(dataHistory, 0, dataHistory.Length);
                            byte receivedByteSignal = (byte)incomingData[0];
                            string actualMessage = incomingData.Substring(1);
                            if (receivedByteSignal == 1)
                            {
                                actualMessage = Encryption.Encryption.DecryptData(SymmetricKey, actualMessage);
                            }
                            JsonObject jsonObject = JsonClasses.JsonHandler.JsonHandler.GetJsonDataFromJsonString(actualMessage);
                            EnumHandler.CommunicationMessageID_Enum messageType = JsonClasses.JsonHandler.JsonHandler.GetMessageTypeOfCommunicationMessageID_Enum(jsonObject);
                            switch (messageType)
                            {
                                case EnumHandler.CommunicationMessageID_Enum.EncryptionServerPublicKeyReciever:
                                    ServerPublicKey = jsonObject.MessageBody as string;
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EncryptionSymmetricKeyReciever:
                                    HandleEncryptionSymmetricKeyRecieverEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EncryptionRenewKeys:
                                    HandleKeys();
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_SuccessfulRegistration:
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.OpenProfilePictureSelector(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.RegistrationResponse_FailedRegistration:
                                    MessageBox.Show(FailedRegistrationResponse);
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleProblematicDetails(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureResponse:
                                    FormHandler._profilePictureSelector.Invoke((Action)delegate { FormHandler._profilePictureSelector.OpenStatusSelector(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UploadStatusResponse:
                                    FormHandler._profileStatusSelector.Invoke((Action)delegate { FormHandler._profileStatusSelector.OpenApp(); });
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
                                    HandleLoginResponse_SuccessfulSmtpLoginCodeEnum(jsonObject);
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
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.SuccessfulPersonalVerificationAnswersResponse_SetUserStatus:
                                case EnumHandler.CommunicationMessageID_Enum.InitialProfileSettingsCheckResponse_SetUserStatus:
                                    FormHandler._login.Invoke((Action)delegate { FormHandler._login.OpenStatusSelector(); });
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
                                    MessageBox.Show(PasswordRenewalMessage_UnmatchedDetails, "Unmatched Details.");
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
                                    HandleUserDetailsResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.LoginBanStart:
                                    HandleLoginBanStartEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.LoginBanFinish:
                                    HandleLoginBanFinishEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.PasswordUpdateBanStart:
                                    HandlePasswordUpdateBanStartEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.PasswordUpdateBanFinish:
                                    FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.HandleBanOver(); });
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
                                    HandlePastFriendRequestsResponseEnum(jsonObject);
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
                                    FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleBanOver(); });
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
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOnResponse:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCameraOn(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.VideoCallCameraOffResponse:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCameraOff(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndVideoCallResponse_Reciever:
                                    FormHandler._videoCall.Invoke((Action)delegate { FormHandler._videoCall.HandleCallOver(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndVideoCallResponse_Sender:
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
                                    HandleUdpAudioConnectionResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UdpVideoConnectionResponse:
                                    HandleUdpVideoConnectionResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndAudioCallResponse_Reciever:
                                    FormHandler._audioCall.Invoke((Action)delegate { FormHandler._audioCall.HandleCallOver(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.EndAudioCallResponse_Sender:
                                    FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.CloseAudioCall(); });
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.DeleteMessageResponse:
                                    HandleDeleteMessageResponseEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusResponse_Sender:
                                    HandleUpdateProfileStatusResponse_SenderEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusResponse_Reciever:
                                    HandleUpdateProfileStatusResponse_RecieverEnum(jsonObject);
                                    break;
                                case EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureResponse_Sender:
                                    HandleUpdateProfilePictureResponse_SenderEnum(jsonObject);
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
                        lock (Client.GetStream())
                        {
                            // continue reading from the client
                            Client.GetStream().BeginRead(Data, 0, 4, ReceiveMessageLength, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ask somebody for help\n\n" + ex, "Error");
                }
            }
        }
        
        private void HandleUpdateProfilePictureResponse_SenderEnum(JsonObject jsonObject)
        {
            string profilePictureId = jsonObject.MessageBody as string;
            ProfileDetailsHandler.ProfilePictureId = profilePictureId;
            ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(ProfileDetailsHandler.ProfilePictureId);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleProfilePictureChange(ProfileDetailsHandler.Name, profilePictureId); });
        }
        private void HandleUpdateProfileStatusResponse_SenderEnum(JsonObject jsonObject)
        {
            string status = jsonObject.MessageBody as string;
            ProfileDetailsHandler.Status = status;
        }
        private void HandleUdpVideoConnectionResponseEnum(JsonObject jsonObject)
        {
            UdpDetails udpDetails = jsonObject.MessageBody as UdpDetails;
            string encryptedUdpAudioSymmetricKey = udpDetails.FieldNumber1;
            string encryptedUdpVideoSymmetricKey = udpDetails.FieldNumber2;
            string audioSymmetricKey = Rsa.Decrypt(encryptedUdpAudioSymmetricKey, PrivateKey);
            string videoSymmetricKey = Rsa.Decrypt(encryptedUdpVideoSymmetricKey, PrivateKey);
            AudioServerCommunication.symmetricKey = audioSymmetricKey;
            VideoServerCommunication.symmetricKey = videoSymmetricKey;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenVideoCall(); });
        }
        private void HandleUdpAudioConnectionResponseEnum(JsonObject jsonObject)
        {
            string EncryptedUdpSymmetricKey = jsonObject.MessageBody as string;
            string symmetricKey = Rsa.Decrypt(EncryptedUdpSymmetricKey, PrivateKey);
            AudioServerCommunication.symmetricKey = symmetricKey;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenAudioCall(); });
        }
        private void HandlePastFriendRequestsResponseEnum(JsonObject jsonObject)
        {
            PastFriendRequests pastFriendRequests = jsonObject.MessageBody as PastFriendRequests;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetListOfFriendRequestControl(pastFriendRequests); });
        }
        private void HandleLoginBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleBan(banDuration); });
        }
        private void HandleUserDetailsResponseEnum(JsonObject jsonObject)
        {
            UserDetails userDetails = jsonObject.MessageBody as UserDetails;
            ProfileDetailsHandler.Name = userDetails.Username;
            ProfileDetailsHandler.ProfilePictureId = userDetails.ProfilePicture;
            ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(ProfileDetailsHandler.ProfilePictureId);//returns the wrong image for some reason                                                                                                                                           //a soultion might be a object and not a static class...
            ProfileDetailsHandler.Status = userDetails.ProfileStatus;
            ProfileDetailsHandler.TagLine = userDetails.TagLineId;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetProfilePicture(); });
        }
        private void HandleLoginResponse_SuccessfulSmtpLoginCodeEnum(JsonObject jsonObject)
        {
            ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
            byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
            Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCorrectCodeResponse(captchaCodeImage); });
        }
        private void HandleEncryptionSymmetricKeyRecieverEnum(JsonObject jsonObject)
        {
            string EncryptedSymmetricKeyReciever = jsonObject.MessageBody as string;
            SymmetricKey = Rsa.Decrypt(EncryptedSymmetricKeyReciever, PrivateKey);
            isKeyExchangeInProgress = false;
            SendQueuedMessages();
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
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ChatInformationRequest;
            object messageContent = null;
            SendMessage(messageType, messageContent);
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
        private void HandleRegistrationBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleBan(banDuration); });
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
        private void HandleSendMessage(string jsonMessage, bool needEncryption)
        {
            if (Client != null && Client.Connected & isConnected)
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
                    NetworkStream ns = Client.GetStream();

                    int bufferSize = Client.ReceiveBufferSize;
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

        public void SendMessage(EnumHandler.CommunicationMessageID_Enum messageType, object messageContent, bool needEncryption = true)
        {
            string jsonMessage = JsonClasses.JsonHandler.JsonHandler.GetJsonStringFromJsonData(messageType, messageContent);
            if (isKeyExchangeInProgress)
            {
                // Queue the message for sending after the key exchange process is over
                MessageState messageState = new MessageState(jsonMessage, needEncryption);
                messageQueue.Enqueue(messageState);
                return;
            }
            HandleSendMessage(jsonMessage, needEncryption);
        }

       
        private void SendQueuedMessages()
        {
            MessageState messageState;
            string jsonMessage;
            bool needEncryption;
            while (messageQueue.Count > 0)
            {
                messageState = messageQueue.Dequeue();
                jsonMessage = messageState.JsonMessage;
                needEncryption = messageState.NeedsEncryption;
                HandleSendMessage(jsonMessage, needEncryption);
            }
        }


        /// <summary>
        /// The Disconnect method disconnects the client from the server
        /// </summary>
        public void Disconnect()
        {
            if (Client != null)
            {
                try
                {
                    if (Client.GetStream().CanRead)
                        Client.GetStream().Close();
                    Client.Close();
                    Client.Dispose();
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
