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
using YouChatApp.Controls;
using YouChatApp.JsonClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.UserAuthentication.Forms
{
    /// <summary>
    /// The "ProfileStatusSelector" class represents a form for selecting and sending profile status updates.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for selecting and sending profile status updates.
    /// It includes methods for initializing the form, sending status updates to the server,
    /// and opening the main application form.
    /// </remarks>
    public partial class ProfileStatusSelector : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ProfileStatusSelector" constructor initializes a new instance of the <see cref="ProfileStatusSelector"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new ProfileStatusSelector instance and set up its components.
        /// It initializes the server communicator instance and adds a custom button click handler to the ProfileStatusControl for sending status updates.
        /// </remarks>
        public ProfileStatusSelector()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            ProfileStatusControl.AddSaveStatusCustomButtonClickHandler(SendStatus);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "SendStatus" method sends the user's profile status to the server.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the user's profile status from the ProfileStatusControl.
        /// It then creates a message containing the profile status and sends it to the server
        /// using the serverCommunicator.
        /// </remarks>
        private void SendStatus(object sender, EventArgs e)
        {
            string ProfileStatus = ProfileStatusControl.GetStatus();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UploadStatusRequest;
            object messageContent = ProfileStatus;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "OpenApp" method hides the current form and opens the YouChat application form.
        /// </summary>
        /// <remarks>
        /// This method hides the current form, creates a new instance of the YouChat form, and then shows the YouChat form.
        /// </remarks>
        public void OpenApp()
        {
            this.Hide();
            FormHandler._youChat = new YouChat();
            this.Invoke(new Action(() => FormHandler._youChat.Show()));
        }

        #endregion
    }
}
