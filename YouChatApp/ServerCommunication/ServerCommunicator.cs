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
    /// <summary>
    /// The "ServerCommunicator" class is responsible for the server communication.
    /// </summary>
    public class ServerCommunicator
    {
        #region Private Message Const Fields

        /// <summary>
        /// The constant string "FailedRegistrationResponse" represents the response message for a failed registration attempt.
        /// </summary>
        private const string FailedRegistrationResponse = "Your registration has failed. Please try changing the information provided again.";

        /// <summary>
        /// The constant string "FailedLoginResponse" represents the response message for a failed login attempt.
        /// </summary>
        private const string FailedLoginResponse = "The login has failed. You probably wrote the wrong username or password. In case you don't have an account yet, please sign up.";

        /// <summary>
        /// The constant string "PasswordRenewalMessage_UnmatchedDetails" represents the message for unmatched details during a password renewal process.
        /// </summary>
        private const string PasswordRenewalMessage_UnmatchedDetails = "Your past details aren't matching.";

        /// <summary>
        /// The constant string "FailedCallRequest" represents the message for a failed call request.
        /// </summary>
        private const string FailedCallRequest = "The user is currently offline or in another call. Please try again later.";

        #endregion

        #region Private Communication Fields

        /// <summary>
        /// The TcpClient "Client" represents the TCP client.
        /// </summary>
        private TcpClient Client;

        /// <summary>
        /// The byte[] "Data" represents the data.
        /// </summary>
        private byte[] Data;

        /// <summary>
        /// The byte[] "dataHistory" represents the data history.
        /// </summary>
        private byte[] dataHistory;

        #endregion

        #region Private Encryption Fields

        /// <summary>
        /// The RSAServiceProvider "Rsa" represents the RSA service provider.
        /// </summary>
        private RSAServiceProvider Rsa;

        /// <summary>
        /// The string "ServerPublicKey" represents the server's public key.
        /// </summary>
        private string ServerPublicKey;

        /// <summary>
        /// The string "PrivateKey" represents the private key.
        /// </summary>
        private string PrivateKey;

        /// <summary>
        /// The string "SymmetricKey" represents the symmetric key.
        /// </summary>
        private string SymmetricKey;

        #endregion

        #region Private Fields

        /// <summary>
        /// The boolean "isKeyExchangeInProgress" indicates whether a key exchange is in progress.
        /// </summary>
        private bool isKeyExchangeInProgress = false;

        /// <summary>
        /// The Queue<MessageState> "messageQueue" represents the queue of message states.
        /// </summary>
        private Queue<MessageState> messageQueue = new Queue<MessageState>();

        /// <summary>
        /// The boolean "isConnected" indicates whether the client is connected.
        /// </summary>
        private bool isConnected;

        /// <summary>
        /// The static ServerCommunicator "_instance" represents the instance of the server communicator.
        /// </summary>
        private static ServerCommunicator _instance;

        #endregion

        #region Private Const Fields

        /// <summary>
        /// The static string "serverIp" represents the server's IP address.
        /// </summary>
        private const string serverIp = "10.100.102.3";

        /// <summary>
        /// The static int "serverPort" represents the server's port.
        /// </summary>
        private const int serverPort = 1500;

        #endregion

        #region Constructors

        /// <summary>
        /// The <see cref="ServerCommunicator"/> private constructor initializes a new instance of the ServerCommunicator class and connects to the server.
        /// </summary>
        /// <remarks>
        /// This constructor is used internally to create a new ServerCommunicator instance and establish a connection to the server.
        /// </remarks>
        private ServerCommunicator()
        {
            Connect();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Instance" property represents the singleton instance of the ServerCommunicator class.
        /// It gets the singleton instance, creating a new instance if it does not already exist.
        /// </summary>
        /// <value>
        /// The singleton instance of the ServerCommunicator class.
        /// </value>
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

        #endregion

        #region Private Communictation Methods

        /// <summary>
        /// The "Connect" method attempts to connect to a server at the specified IP address.
        /// </summary>
        /// <returns>True if the connection was successful, otherwise false.</returns>
        /// <remarks>
        /// This method creates a new TcpClient instance and attempts to connect to the server at the server IP and port.
        /// If the connection attempt fails, a message box is displayed to inform the user.
        /// If the connection is successful, the method sets the "isConnected" flag to true and calls the "HandleKeys" method.
        /// It then initializes the "Data" array with the size of the client's receive buffer and begins an asynchronous read operation on the network stream.
        /// The method returns true if the connection was successful, otherwise false.
        /// </remarks>
        private bool Connect()
        {
            Client = new TcpClient();
            try
            {
                Client.Connect(serverIp, serverPort);

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

        /// <summary>
        /// The "ReceiveMessageLength" method handles the reception of the message length from the server.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        /// <remarks>
        /// This method is called when the client receives the length of the message from the server. It reads the length of the message
        /// from the server's stream and prepares to receive the actual message by calling the "ReceiveMessage" method.
        /// </remarks>
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
        /// The "ReceiveMessage" method handles the reception of messages from the server.
        /// </summary>
        /// <param name="ar">The result of the asynchronous operation.</param>
        /// <remarks>
        /// This method is called when an asynchronous read operation completes.
        /// This method is called when the client receives a message from the server. It first checks if the client is still connected
        /// and reads the number of bytes received from the server.
        /// If the number of bytes read is less than 1, it indicates that the server has disconnected, and the client is notified.
        /// The method then calls the "Disconnect" method to close the connection. It reads the message from the server's stream,
        /// decrypts it if necessary, and processes it based on its type. It then reads the message length and creates a new byte
        /// array to hold the combined data. The method continues to read from the server's stream until it has received the entire message.
        /// It decrypts the message if it is an encrypted message and then deserializes it into a JsonObject. Based on the message type,
        /// the method calls the appropriate handler method to process the message. Finally, the method resets the dataHistory array and
        /// prepares to receive the next message length from the server.
        /// </remarks>
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

        /// <summary>
        /// The "HandleSendMessage" method sends a JSON message to the server, optionally encrypting it.
        /// </summary>
        /// <param name="jsonMessage">The JSON message to send.</param>
        /// <param name="needEncryption">A boolean value indicating whether the message needs to be encrypted.</param>
        /// <remarks>
        /// This method is responsible for sending messages to the server. It first checks if the client is connected and if encryption is needed.
        /// If encryption is required, it encrypts the message using the symmetric key. It then constructs the final message byte array
        /// with a signal byte indicating encryption, copies the message bytes to the array, and sends it to the server using the network stream.
        /// The method handles messages that exceed the buffer size by splitting them into smaller messages.
        /// </remarks>
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

        /// <summary>
        /// The "SendQueuedMessages" method sends all queued messages to the server.
        /// </summary>
        /// <remarks>
        /// This method dequeues messages from the message queue and sends them to the server using the "HandleSendMessage" method.
        /// It continues this process until the message queue is empty.
        /// </remarks>
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

        #endregion

        #region Private Methods

        /// <summary>
        /// The "HandleKeys" method handles the key exchange process between the client and the server.
        /// </summary>
        /// <remarks>
        /// This method generates a new RSA key pair for the client and sends the public key to the server.
        /// The method sets a flag to indicate that the key exchange process is in progress.
        /// </remarks>
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

        /// <summary>
        /// The "HandleUpdateProfilePictureResponse_SenderEnum" method handles the response from the server after requesting to update the profile picture.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the response from the server.</param>
        /// <remarks>
        /// This method extracts the profile picture ID from the message body of the JSON object.
        /// It updates the local profile picture ID and retrieves the new profile picture image.
        /// Finally, it invokes a method on the main application form to handle the profile picture change visually.
        /// </remarks>
        private void HandleUpdateProfilePictureResponse_SenderEnum(JsonObject jsonObject)
        {
            string profilePictureId = jsonObject.MessageBody as string;
            ProfileDetailsHandler.ProfilePictureId = profilePictureId;
            ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(ProfileDetailsHandler.ProfilePictureId);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleProfilePictureChange(ProfileDetailsHandler.Name, profilePictureId); });
        }

        /// <summary>
        /// The "HandleUpdateProfileStatusResponse_SenderEnum" method handles the response from the server after requesting to update the profile status.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the response from the server.</param>
        /// <remarks>
        /// This method extracts the new profile status from the message body of the JSON object and updates the local profile status.
        /// </remarks>
        private void HandleUpdateProfileStatusResponse_SenderEnum(JsonObject jsonObject)
        {
            string status = jsonObject.MessageBody as string;
            ProfileDetailsHandler.Status = status;
        }

        /// <summary>
        /// The "HandleUdpVideoConnectionResponseEnum" method handles the response from the server for establishing a UDP video connection.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the response from the server.</param>
        /// <remarks>
        /// This method extracts the UDP details from the message body of the JSON object, decrypts the UDP audio and video symmetric keys, 
        /// and sets the symmetric keys for audio and video communication. It then invokes the opening of a video call in the UI.
        /// </remarks>
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

        /// <summary>
        /// The "HandleUdpAudioConnectionResponseEnum" method handles the response from the server for establishing a UDP audio connection.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the response from the server.</param>
        /// <remarks>
        /// This method extracts the encrypted UDP symmetric key from the message body of the JSON object, decrypts it using the private key, 
        /// and sets the symmetric key for audio communication. It then invokes the opening of an audio call in the UI.
        /// </remarks>
        private void HandleUdpAudioConnectionResponseEnum(JsonObject jsonObject)
        {
            string EncryptedUdpSymmetricKey = jsonObject.MessageBody as string;
            string symmetricKey = Rsa.Decrypt(EncryptedUdpSymmetricKey, PrivateKey);
            AudioServerCommunication.symmetricKey = symmetricKey;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenAudioCall(); });
        }

        /// <summary>
        /// The "HandlePastFriendRequestsResponseEnum" method handles the response from the server containing past friend requests.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the response from the server.</param>
        /// <remarks>
        /// This method extracts the past friend requests from the message body of the JSON object and sets the list of friend request controls in the UI.
        /// </remarks>
        private void HandlePastFriendRequestsResponseEnum(JsonObject jsonObject)
        {
            PastFriendRequests pastFriendRequests = jsonObject.MessageBody as PastFriendRequests;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetListOfFriendRequestControl(pastFriendRequests); });
        }

        /// <summary>
        /// The "HandleLoginBanStartEnum" method handles the start of a login ban received from the server.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the ban duration.</param>
        /// <remarks>
        /// This method extracts the ban duration from the message body of the JSON object and invokes the UI method to handle the ban.
        /// </remarks>
        private void HandleLoginBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleBan(banDuration); });
        }

        /// <summary>
        /// The "HandleUserDetailsResponseEnum" method handles the user details response received from the server.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the user details.</param>
        /// <remarks>
        /// This method extracts the user details from the message body of the JSON object and updates the local profile details accordingly.
        /// It then invokes the UI method to set the profile picture.
        /// </remarks>
        private void HandleUserDetailsResponseEnum(JsonObject jsonObject)
        {
            UserDetails userDetails = jsonObject.MessageBody as UserDetails;
            ProfileDetailsHandler.Name = userDetails.Username;
            ProfileDetailsHandler.ProfilePictureId = userDetails.ProfilePicture;
            ProfileDetailsHandler.ProfilePicture = ProfilePictureImageList.GetImageByImageId(ProfileDetailsHandler.ProfilePictureId);
            ProfileDetailsHandler.Status = userDetails.ProfileStatus;
            ProfileDetailsHandler.TagLine = userDetails.TagLineId;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetProfilePicture(); });
        }

        /// <summary>
        /// The "HandleLoginResponse_SuccessfulSmtpLoginCodeEnum" method handles the successful SMTP login code response received from the server.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the captcha code image.</param>
        /// <remarks>
        /// This method extracts the captcha code image bytes from the message body of the JSON object and converts them into an image.
        /// It then invokes the UI method to handle the correct code response, passing the captcha code image.
        /// </remarks>
        private void HandleLoginResponse_SuccessfulSmtpLoginCodeEnum(JsonObject jsonObject)
        {
            ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
            byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
            Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCorrectCodeResponse(captchaCodeImage); });
        }

        /// <summary>
        /// The "HandleEncryptionSymmetricKeyRecieverEnum" method handles the reception of the encrypted symmetric key from the server.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the encrypted symmetric key.</param>
        /// <remarks>
        /// This method extracts the encrypted symmetric key from the message body of the JSON object and decrypts it using the private key.
        /// It then sets the symmetric key, indicating that the key exchange process is complete, and proceeds to send any queued messages.
        /// </remarks>
        private void HandleEncryptionSymmetricKeyRecieverEnum(JsonObject jsonObject)
        {
            string EncryptedSymmetricKeyReciever = jsonObject.MessageBody as string;
            SymmetricKey = Rsa.Decrypt(EncryptedSymmetricKeyReciever, PrivateKey);
            isKeyExchangeInProgress = false;
            SendQueuedMessages();
        }

        /// <summary>
        /// The "HandleUpdateProfilePictureResponse_ChatUserRecieverEnum" method handles the response for updating the profile picture for a chat user.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the profile picture update information.</param>
        /// <remarks>
        /// This method extracts the username and profile picture ID from the message body of the JSON object.
        /// It then invokes the "HandleProfilePictureChange" method of the chat form to update the profile picture for the specified user.
        /// </remarks>
        private void HandleUpdateProfilePictureResponse_ChatUserRecieverEnum(JsonObject jsonObject)
        {
            ProfilePictureUpdate profilePictureUpdate = jsonObject.MessageBody as ProfilePictureUpdate;
            string username = profilePictureUpdate.Username;
            string profilePictureId = profilePictureUpdate.ProfilePictureId;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleProfilePictureChange(username, profilePictureId); });
        }

        /// <summary>
        /// The "HandleUpdateProfilePictureResponse_ContactRecieverEnum" method handles the response for updating the profile picture for a contact.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the profile picture update information.</param>
        /// <remarks>
        /// This method extracts the username and profile picture ID from the message body of the JSON object.
        /// It then retrieves the contact from the contact manager using the username.
        /// If the contact is found, it updates the contact's profile picture and invokes the "ChangeUserProfilePicture" method of the chat form to reflect the change.
        /// </remarks>
        private void HandleUpdateProfilePictureResponse_ContactRecieverEnum(JsonObject jsonObject)
        {
            ProfilePictureUpdate profilePictureUpdate = jsonObject.MessageBody as ProfilePictureUpdate;
            string username = profilePictureUpdate.Username;
            string profilePictureId = profilePictureUpdate.ProfilePictureId;
            Contact contact = ContactManager.GetContact(username);
            if (contact != null)
            {
                contact.ProfilePicture = ProfilePictureImageList.GetImageByImageId(profilePictureId);
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.ChangeUserProfilePicture(username, profilePictureId, contact.ProfilePicture); });
            }
        }

        /// <summary>
        /// The "HandleOfflineUpdateEnum" method handles the update for setting a contact's online status to offline.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the offline update details.</param>
        /// <remarks>
        /// This method extracts the username and last seen time from the message body of the JSON object.
        /// It then retrieves the contact from the contact manager using the username.
        /// If the contact is found, it sets the contact's online status to false and updates the last seen time.
        /// Finally, it invokes the "SetChatOnline" method of the chat form to reflect the change in the UI.
        /// </remarks>
        private void HandleOfflineUpdateEnum(JsonObject jsonObject)
        {
            OfflineDetails offlineDetails = jsonObject.MessageBody as OfflineDetails;
            string username = offlineDetails.Username;
            DateTime lastSeenTime = offlineDetails.LastSeenTime;
            Contact contact = ContactManager.GetContact(username);
            if (contact != null)
            {
                contact.Online = false;
                contact.LastSeenTime = lastSeenTime;
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetChatOnline(username, false, lastSeenTime); });
            }
        }

        /// <summary>
        /// The "HandleUpdateProfileStatusResponse_RecieverEnum" method handles the update for changing a user's status.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the status update details.</param>
        /// <remarks>
        /// This method extracts the username and status from the message body of the JSON object.
        /// It then retrieves the contact from the contact manager using the username.
        /// If the contact is found, it updates the contact's status and invokes the "ChangeUserStatus" method of the chat form to reflect the change in the UI.
        /// </remarks>
        private void HandleUpdateProfileStatusResponse_RecieverEnum(JsonObject jsonObject)
        {
            StatusUpdate statusUpdate = jsonObject.MessageBody as StatusUpdate;
            string username = statusUpdate.username;
            string status = statusUpdate.Status;
            Contact contact = ContactManager.GetContact(username);
            if (contact != null)
            {
                contact.Status = status;
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.ChangeUserStatus(username, status); });
            }
        }

        /// <summary>
        /// The "HandleOnlineUpdateEnum" method handles the update for changing a user's online status to online.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the username of the user to become online.</param>
        /// <remarks>
        /// This method extracts the username from the message body of the JSON object.
        /// It then retrieves the contact from the contact manager using the username and sets the contact's online status to true.
        /// Finally, it invokes the "SetChatOnline" method of the chat form to reflect the change in the UI.
        /// </remarks>
        private void HandleOnlineUpdateEnum(JsonObject jsonObject)
        {
            string userToBecomeOnlineName = jsonObject.MessageBody as string;
            Contact contact = ContactManager.GetContact(userToBecomeOnlineName);
            contact.Online = true;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetChatOnline(userToBecomeOnlineName,true); });
        }

        /// <summary>
        /// The "HandleMessageHistoryResponseEnum" method handles the response from the server containing message history.
        /// </summary>
        /// <param name="jsonObject">The JsonObject containing the response from the server.</param>
        /// <remarks>
        /// This method extracts the message history from the JsonObject and invokes the appropriate method in the YouChat form to handle the message history.
        /// If the content is a MessageHistory object, it extracts the messages and invokes the HandleMessageHistory method.
        /// If the content is a string representing a chatId, it invokes the HandleMessageHistory method with the chatId parameter.
        /// </remarks>
        private void HandleMessageHistoryResponseEnum(JsonObject jsonObject)
        {
            object content = jsonObject.MessageBody;
            if (content is MessageHistory messageHistory)
            {
                List<JsonClasses.Message> messages = messageHistory.Messages;
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleMessageHistory(messages); });
            }
            else if (content is string chatId)
            {
                FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleMessageHistory(chatId); });
            }
        }

        /// <summary>
        /// The "HandleSuccessfulAudioCallResponse_RecieverEnum" method handles the successful response to an audio call request.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the call.</param>
        /// <remarks>
        /// This method extracts the details of the friend from the JSON object.
        /// It then invokes the "OpenCallInvitation" method of the chat form to display the call invitation.
        /// </remarks>
        private void HandleSuccessfulAudioCallResponse_RecieverEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenCallInvitation(details[0], details[1],false); });
        }

        /// <summary>
        /// The "HandleSuccessfulVideoCallResponse_RecieverEnum" method handles the successful response to a video call request.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the call.</param>
        /// <remarks>
        /// This method extracts the details of the friend from the JSON object.
        /// It then invokes the "OpenCallInvitation" method of the chat form to display the call invitation for a video call.
        /// </remarks>
        private void HandleSuccessfulVideoCallResponse_RecieverEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.OpenCallInvitation(details[0], details[1],true); });
        }

        /// <summary>
        /// The "HandleVideoCallAcceptanceResponseEnum" method handles the response to a video call acceptance.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the call.</param>
        /// <remarks>
        /// This method extracts the details of the friend from the JSON object.
        /// It then invokes the "StartVideoUdpConnection" method of the chat form to start the UDP video connection.
        /// </remarks>
        private void HandleVideoCallAcceptanceResponseEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.StartVideoUdpConnection(details[0], details[1]); });
        }

        /// <summary>
        /// The "HandleAudioCallAcceptanceResponseEnum" method handles the response to an audio call acceptance.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the call.</param>
        /// <remarks>
        /// This method extracts the details of the friend from the JSON object.
        /// It then invokes the "StartAudioUdpConnection" method of the chat form to start the UDP audio connection.
        /// </remarks>
        private void HandleAudioCallAcceptanceResponseEnum(JsonObject jsonObject)
        {
            string[] details = GetFriendName(jsonObject);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.StartAudioUdpConnection(details[0], details[1]); });
        }

        /// <summary>
        /// The "GetFriendName" method retrieves the name of the friend associated with a chat from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the chat ID.</param>
        /// <returns>An array containing the chat ID and the name of the friend.</returns>
        /// <remarks>
        /// This method extracts the chat ID from the JSON object and retrieves the corresponding chat details.
        /// It then gets the name of the friend from the chat details and returns an array containing the chat ID and the friend's name.
        /// </remarks>
        private string[] GetFriendName(JsonObject jsonObject)
        {
            string chatId = jsonObject.MessageBody as string;
            ChatDetails chatDetails = ChatManager.GetChat(chatId);
            DirectChat directChat = (DirectChat)chatDetails;
            string friendName = directChat.GetContactName();
            return new string[] { chatId, friendName};
        }

        /// <summary>
        /// The "HandleDeleteMessageResponseEnum" method handles the response for deleting a message from a chat.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the message details.</param>
        /// <remarks>
        /// This method extracts the message details from the JSON object, including the message sender's name, chat ID,
        /// message date and time, and message content. It then invokes the UI method to handle the deleted message,
        /// passing along these details.
        /// </remarks>
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

        /// <summary>
        /// The "HandleSendMessageResponseEnum" method handles the response for sending a message to a chat.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the message details.</param>
        /// <remarks>
        /// This method extracts the message details from the JSON object, including the message sender's name, chat ID,
        /// message date and time, and message content. It then checks the type of message content (text or image) and
        /// invokes the UI method accordingly to handle the message.
        /// </remarks>
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

        /// <summary>
        /// The "HandleGroupCreatorResponseEnum" method handles the response for creating a new group chat.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the group chat details.</param>
        /// <remarks>
        /// This method extracts the group chat details from the JSON object and adds the new group chat to the chat manager.
        /// It then retrieves the chat details for the new group chat and invokes the UI method to handle the new group chat creation.
        /// </remarks>
        private void HandleGroupCreatorResponseEnum(JsonObject jsonObject)
        {
            GroupChatDetails groupChatDetails = jsonObject.MessageBody as GroupChatDetails;
            ChatManager.AddChat(groupChatDetails);
            string chatId = groupChatDetails.ChatTagLineId;
            ChatDetails chat = ChatManager.GetChat(chatId);
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleNewGroupChatCreation(chat); });
        }

        /// <summary>
        /// The "HandleFriendRequestRecieverEnum" method handles the reception of a friend request.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the friend request.</param>
        /// <remarks>
        /// This method extracts the details of the friend request from the JSON object and invokes the UI method to handle the new friend request.
        /// </remarks>
        private void HandleFriendRequestRecieverEnum(JsonObject jsonObject)
        {
            PastFriendRequest pastFriendRequest = jsonObject.MessageBody as PastFriendRequest;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.HandleNewFriendRequest(pastFriendRequest); });
        }

        /// <summary>
        /// The "HandleChatInformationResponseEnum" method handles the reception of chat information.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the chats.</param>
        /// <remarks>
        /// This method extracts the list of chat details from the JSON object and adds each chat to the chat manager.
        /// It then invokes the UI method to update the list of contacts in the chat control.
        /// </remarks>
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

        /// <summary>
        /// The "HandleContactInformationResponseEnum" method handles the reception of contact information.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the contacts.</param>
        /// <remarks>
        /// This method extracts the list of contact details from the JSON object and updates the contact control list in the UI.
        /// It then sends a chat information request message to retrieve chat information.
        /// </remarks>
        private void HandleContactInformationResponseEnum(JsonObject jsonObject)
        {
            Contacts contacts = jsonObject.MessageBody as Contacts;
            List<ContactDetails> contactDetailsList = contacts.ContactList;
            FormHandler._youChat.Invoke((Action)delegate { FormHandler._youChat.SetContactControlList(contactDetailsList); });
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.ChatInformationRequest;
            object messageContent = null;
            SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "HandleFriendRequestResponseRecieverEnum" method handles the reception of a friend request response.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the details of the contact and chat.</param>
        /// <remarks>
        /// This method extracts the contact details and chat details from the JSON object and adds them to the contact and chat managers, respectively.
        /// It then invokes the UI method to handle the successful friend request, passing the contact and chat details.
        /// </remarks>
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

        /// <summary>
        /// The "HandleResetPasswordBanStartEnum" method handles the start of a ban for resetting the password.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the ban duration.</param>
        /// <remarks>
        /// This method extracts the ban duration from the JSON object and invokes the UI method to handle the ban, passing the ban duration.
        /// </remarks>
        private void HandleResetPasswordBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleBan(banDuration); });
        }

        /// <summary>
        /// The "HandleResetPasswordBanFinishEnum" method handles the completion of a ban for resetting the password.
        /// </summary>
        /// <param name="jsonObject">The JSON object indicating the end of the ban.</param>
        /// <remarks>
        /// This method invokes the UI method to indicate that the ban for resetting the password is over.
        /// </remarks>
        private void HandleResetPasswordBanFinishEnum(JsonObject jsonObject)
        {
            FormHandler._passwordRestart.Invoke((Action)delegate { FormHandler._passwordRestart.HandleBanOver(); });
        }

        /// <summary>
        /// The "HandlePasswordUpdateBanStartEnum" method handles the start of a ban for updating the password.
        /// </summary>
        /// <param name="jsonObject">The JSON object indicating the start of the ban.</param>
        /// <remarks>
        /// This method invokes the UI method to handle the ban for updating the password.
        /// </remarks>
        private void HandlePasswordUpdateBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._passwordUpdate.Invoke((Action)delegate { FormHandler._passwordUpdate.HandleBan(banDuration); });
        }

        /// <summary>
        /// The "HandleRegistrationBanStartEnum" method handles the start of a ban for registration.
        /// </summary>
        /// <param name="jsonObject">The JSON object indicating the start of the ban.</param>
        /// <remarks>
        /// This method invokes the UI method to handle the ban for registration.
        /// </remarks>
        private void HandleRegistrationBanStartEnum(JsonObject jsonObject)
        {
            double banDuration = (double)jsonObject.MessageBody;
            FormHandler._registration.Invoke((Action)delegate { FormHandler._registration.HandleBan(banDuration); });
        }

        /// <summary>
        /// The "HandleCaptchaImageAngleResponseEnum" method handles the arrival of a captcha image with rotation angles.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing captcha rotation image details.</param>
        /// <remarks>
        /// This method invokes the UI method to handle the captcha image with rotation angles.
        /// </remarks>
        private void HandleCaptchaImageAngleResponseEnum(JsonObject jsonObject)
        {
            CaptchaRotationImageDetails captchaRotationImageDetails = jsonObject.MessageBody as CaptchaRotationImageDetails;
            object[] values = HandleCaptchaRotationImageDetailsArrival(captchaRotationImageDetails);
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCorrectCaptchaCode((Image)values[2], (Image)values[3], (int)values[0], (int)values[1]); });
        }

        /// <summary>
        /// The "HandleCaptchaRotationImageDetailsArrival" method handles the arrival of captcha rotation image details.
        /// It extracts the rotated image, background image, score, and attempts from the provided captcha rotation image details.
        /// </summary>
        /// <param name="captchaRotationImageDetails">The captcha rotation image details object containing the rotated image, background image, and success rate.</param>
        /// <returns>
        /// An array containing the captcha rotation score, attempts, rotated image, and background image.
        /// </returns>
        /// <remarks>
        /// This method is used to process and extract relevant information from the received captcha rotation image details.
        /// </remarks>
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

        /// <summary>
        /// The "HandleLoginBanFinishEnum" method handles the completion of a login ban.
        /// It checks if additional action is required after the ban, such as displaying a new captcha image.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing information about the ban completion.</param>
        /// <remarks>
        /// This method is called when the login ban is over. If a new captcha image is provided, it handles displaying it to the user.
        /// </remarks>
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

        /// <summary>
        /// The "HandleCaptchaImageResponseEnum" method handles the arrival of a new captcha image.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the new captcha image.</param>
        /// <remarks>
        /// This method is called when a new captcha image is needed, such as during a login attempt.
        /// It converts the image bytes to an image object and then invokes the login form's method to handle the new captcha image.
        /// </remarks>
        private void HandleCaptchaImageResponseEnum(JsonObject jsonObject)
        {
            ImageContent captchaCodeImageContent = jsonObject.MessageBody as ImageContent;
            byte[] captchaCodeImageBytes = captchaCodeImageContent.ImageBytes;
            Image captchaCodeImage = ConvertHandler.ConvertBytesToImage(captchaCodeImageBytes);
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleCaptchaImageRenewal(captchaCodeImage); });
        }

        /// <summary>
        /// The "HandleSuccessfulCaptchaImageAngleResponseEnum" method handles the successful response to a captcha image angle request.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the personal verification questions and captcha rotation success rate.</param>
        /// <remarks>
        /// This method is called when the server successfully processes a captcha image angle request.
        /// It extracts the personal verification questions and captcha rotation success rate from the JSON object,
        /// then invokes the login form's method to handle the successful response, passing the personal verification questions, score, and attempts.
        /// </remarks>
        private void HandleSuccessfulCaptchaImageAngleResponseEnum(JsonObject jsonObject)
        {
            PersonalVerificationQuestionDetails verificationQuestionDetails = jsonObject.MessageBody as PersonalVerificationQuestionDetails;
            PersonalVerificationQuestions personalVerificationQuestions = verificationQuestionDetails.PersonalVerificationQuestions;
            CaptchaRotationSuccessRate captchaRotationSuccessRate = verificationQuestionDetails.CaptchaRotationSuccessRate;
            int score = captchaRotationSuccessRate.Score;
            int attempts = captchaRotationSuccessRate.Attempts;
            FormHandler._login.Invoke((Action)delegate { FormHandler._login.HandleSuccessfulCaptchaImageAngleResponse(personalVerificationQuestions, score,attempts); });
        }

        #endregion

        #region Public Methods    


        /// <summary>
        /// The "SendMessage" method sends a message to the server.
        /// </summary>
        /// <param name="messageType">The type of the message to send.</param>
        /// <param name="messageContent">The content of the message to send.</param>
        /// <param name="needEncryption">A flag indicating whether the message needs to be encrypted. Default is true.</param>
        /// <remarks>
        /// The method uses the JsonHandler class to convert the message type and content into a JSON string.
        /// If a key exchange process is in progress, the message is queued for sending after the key exchange is completed.
        /// If no key exchange is in progress, the message is sent immediately using the HandleSendMessage method.
        /// </remarks>
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


        /// <summary>
        /// The "Disconnect" method disconnects the client from the server.
        /// </summary>
        /// <remarks>
        /// If the client is not null, it closes and disposes the stream and sets the client to null.
        /// </remarks>
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

        #endregion
    }
}
