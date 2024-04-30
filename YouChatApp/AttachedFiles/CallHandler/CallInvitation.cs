using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.ContactHandler;
using YouChatApp.JsonClasses;

namespace YouChatApp.AttachedFiles.CallHandler
{
    /// <summary>
    /// The "CallInvitation" class represents a form for managing call invitations in the application.
    /// It provides functionality for accepting or declining audio or video call invitations.
    /// </summary>
    /// <remarks>
    /// This class handles the display of call invitations, including the friend's name, profile picture, and call type (audio or video).
    /// It also provides functionality for accepting or declining the call invitation, as well as sending a message instead of joining the call.
    /// </remarks>
    public partial class CallInvitation : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        /// <summary>
        /// The readonly string "_chatId" stores the ID of the chat.
        /// </summary>
        private readonly string _chatId;

        /// <summary>
        /// The readonly bool "_isVideoCall" indicates whether the call is a video call.
        /// </summary>
        private readonly bool _isVideoCall;

        #endregion

        #region Constructors

        /// <summary>
        /// The "CallInvitation" constructor initializes a new instance of the <see cref="CallInvitation"/> class with the specified chat ID, friend's name, profile picture, and call type.
        /// </summary>
        /// <param name="chatId">The ID of the chat associated with the call invitation.</param>
        /// <param name="friendName">The name of the friend sending the call invitation.</param>
        /// <param name="profilePicture">The profile picture of the friend sending the call invitation.</param>
        /// <param name="isVideoCall">A boolean value indicating whether the call is a video call.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the CallInvitation class, representing a call invitation from a friend.
        /// It initializes various components and settings for displaying the call invitation, including the chat ID, friend's name, profile picture, and call type.
        /// </remarks>
        public CallInvitation(string chatId, string friendName, Image profilePicture, bool isVideoCall)
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            _chatId = chatId;
            _isVideoCall = isVideoCall;
            ContentLabel.Text = friendName + " is calling you";
            FriendCircularPictureBox.Image = profilePicture;
            ContentLabel.Location = new System.Drawing.Point((FriendInformationPanel.Width - ContentLabel.Width)/2, ContentLabel.Location.Y);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "CallInvitation_Load" method handles the loading of the CallInvitation form.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs associated with the event.</param>
        /// <remarks>
        /// This method sets the BorderRadius property of the JoinCallCustomButton, DeclineCallCustomButton, and MessageSenderCustomButton controls to 40.
        /// </remarks>
        private void CallInvitation_Load(object sender, EventArgs e)
        {
            JoinCallCustomButton.BorderRadius = 40;
            DeclineCallCustomButton.BorderRadius = 40;
            MessageSenderCustomButton.BorderRadius = 40;
        }

        /// <summary>
        /// The "JoinCallCustomButton_Click" method handles the click event of the JoinCallCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs associated with the event.</param>
        /// <remarks>
        /// This method sends a call acceptance request based on whether it's a video or audio call,
        /// then hides the form.
        /// </remarks>
        private void JoinCallCustomButton_Click(object sender, EventArgs e)
        {
            EnumHandler.CommunicationMessageID_Enum callAcceptanceRequest = _isVideoCall ? EnumHandler.CommunicationMessageID_Enum.VideoCallAcceptanceRequest : EnumHandler.CommunicationMessageID_Enum.AudioCallAcceptanceRequest ;
            HandleOptionButtonClick(callAcceptanceRequest);
            this.Hide();
        }

        /// <summary>
        /// The "DeclineCallCustomButton_Click" method handles the click event of the DeclineCallCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs associated with the event.</param>
        /// <remarks>
        /// This method enables the direct chat features panel, sends a call denial request based on whether it's a video or audio call, and then hides the form.
        /// </remarks>
        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.EnableDirectChatFeaturesPanel()));
            EnumHandler.CommunicationMessageID_Enum callDenialRequest = _isVideoCall ? EnumHandler.CommunicationMessageID_Enum.VideoCallDenialRequest : EnumHandler.CommunicationMessageID_Enum.AudioCallDenialRequest;
            HandleOptionButtonClick(callDenialRequest);
            this.Hide();
        }

        /// <summary>
        /// The "MessageSenderCustomButton_Click" method handles the click event of the MessageSenderCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The EventArgs associated with the event.</param>
        /// <remarks>
        /// This method handles the selection of a call message, enables the direct chat features panel, sends a call denial request based on whether it's a video or audio call, and then hides the form.
        /// </remarks>
        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.HandleCallMessageSelection(_chatId)));
            this.Invoke(new Action(() => FormHandler._youChat.EnableDirectChatFeaturesPanel()));
            EnumHandler.CommunicationMessageID_Enum callDenialRequest = _isVideoCall ? EnumHandler.CommunicationMessageID_Enum.VideoCallDenialRequest : EnumHandler.CommunicationMessageID_Enum.AudioCallDenialRequest;
            HandleOptionButtonClick(callDenialRequest);
            this.Hide();
        }

        /// <summary>
        /// The "HandleOptionButtonClick" method handles the click event of various option buttons in the call invitation form.
        /// </summary>
        /// <param name="callResponse">The type of communication message to send as a response to the call invitation.</param>
        /// <remarks>
        /// This method sends a message of the specified type as a response to the call invitation. 
        /// The message content is the ID of the chat associated with the call invitation.
        /// </remarks>
        private void HandleOptionButtonClick(EnumHandler.CommunicationMessageID_Enum callResponse)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = callResponse;
            object messageContent = _chatId;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion
    }
}
