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
    /// The "CallInvitation" form displays a call invitation from a friend.
    /// </summary>
    public partial class CallInvitation : Form
    {
        /// <summary>
        /// The "serverCommunicator" field represents an instance of the ServerCommunicator class for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        /// <summary>
        /// The "_chatId" field stores the ID of the chat associated with the call invitation.
        /// </summary>
        private readonly string _chatId;

        /// <summary>
        /// The "_isVideoCall" field indicates whether the call invitation is for a video call or an audio call.
        /// </summary>
        private readonly bool _isVideoCall;

        /// <summary>
        /// The "CallInvitation" constructor initializes a new instance of the "CallInvitation" form with the specified parameters.
        /// </summary>
        /// <param name="chatId">The ID of the chat associated with the call invitation.</param>
        /// <param name="friendName">The name of the friend who is calling.</param>
        /// <param name="profilePicture">The profile picture of the friend who is calling.</param>
        /// <param name="isVideoCall">Specifies whether the call is a video call.</param>
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

        /// <summary>
        /// The "CallInvitation_Load" method handles the form load event and sets the border radius for custom buttons.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CallInvitation_Load(object sender, EventArgs e)
        {
            JoinCallCustomButton.BorderRadius = 40;
            DeclineCallCustomButton.BorderRadius = 40;
            MessageSenderCustomButton.BorderRadius = 40;
        }

        /// <summary>
        /// The "JoinCallCustomButton_Click" method handles the click event for joining a call.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void JoinCallCustomButton_Click(object sender, EventArgs e)
        {
            EnumHandler.CommunicationMessageID_Enum callAcceptanceRequest = _isVideoCall ? EnumHandler.CommunicationMessageID_Enum.VideoCallAcceptanceRequest : EnumHandler.CommunicationMessageID_Enum.AudioCallAcceptanceRequest ;
            HandleOptionButtonClick(callAcceptanceRequest);
            this.Hide();
        }

        /// <summary>
        /// The "DeclineCallCustomButton_Click" method handles the click event for declining a call.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DeclineCallCustomButton_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.EnableDirectChatFeaturesPanel()));
            EnumHandler.CommunicationMessageID_Enum callDenialRequest = _isVideoCall ? EnumHandler.CommunicationMessageID_Enum.VideoCallDenialRequest : EnumHandler.CommunicationMessageID_Enum.AudioCallDenialRequest;
            HandleOptionButtonClick(callDenialRequest);
            this.Hide();
        }

        /// <summary>
        /// The "MessageSenderCustomButton_Click" method handles the click event for sending a message instead of joining a call.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void MessageSenderCustomButton_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.HandleCallMessageSelection(_chatId)));
            this.Invoke(new Action(() => FormHandler._youChat.EnableDirectChatFeaturesPanel()));
            EnumHandler.CommunicationMessageID_Enum callDenialRequest = _isVideoCall ? EnumHandler.CommunicationMessageID_Enum.VideoCallDenialRequest : EnumHandler.CommunicationMessageID_Enum.AudioCallDenialRequest;
            HandleOptionButtonClick(callDenialRequest);
            this.Hide();
        }

        /// <summary>
        /// The "HandleOptionButtonClick" method sends the call response message to the server.
        /// </summary>
        /// <param name="callResponse">The type of call response message to send.</param>
        private void HandleOptionButtonClick(EnumHandler.CommunicationMessageID_Enum callResponse)
        {
            JsonObject videoCallResponseJsonObject = new JsonObject(callResponse, _chatId);
            string videoCallResponseJson = JsonConvert.SerializeObject(videoCallResponseJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(videoCallResponseJson);
        }
    }
}
