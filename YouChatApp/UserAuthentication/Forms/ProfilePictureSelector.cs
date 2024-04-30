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

namespace YouChatApp.UserAuthentication.Forms
{
    /// <summary>
    /// The "ProfilePictureSelector" class represents a form for selecting and uploading profile pictures.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for selecting and uploading profile pictures.
    /// It includes methods for initializing the form, enabling the confirm button when an image is chosen,
    /// handling the click event of the confirm button to upload the selected image, and opening the profile status selector form.
    /// </remarks>
    public partial class ProfilePictureSelector : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" is used for communicating with the server.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ProfilePictureSelector" constructor initializes a new instance of the <see cref="ProfilePictureSelector"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new ProfilePictureSelector instance and set up its components.
        /// It initializes the server communicator instance and adds a button click handler to the ProfilePictureControl to enable the confirm button.
        /// </remarks>
        public ProfilePictureSelector()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "SetConfirmButtonEnabled" method enables or disables the ConfirmCustomButton based on whether an image is chosen in the ProfilePictureControl.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if an image is currently chosen in the ProfilePictureControl.
        /// If an image is chosen, it enables the ConfirmCustomButton; otherwise, it disables the ConfirmCustomButton.
        /// </remarks>
        private void SetConfirmButtonEnabled(object sender, EventArgs e)
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                ConfirmCustomButton.Enabled = true;
            }
            else
            {
                ConfirmCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "ConfirmCustomButton_Click" method handles the Click event of the ConfirmCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the profile picture ID from the ProfilePictureControl and sends it to the server as a message.
        /// The message type is set to UploadProfilePictureRequest.
        /// </remarks>
        private void ConfirmCustomButton_Click(object sender, EventArgs e)
        {
            string ProfilePictureId = ProfilePictureControl.GetImageNameID();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureRequest;
            object messageContent = ProfilePictureId;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "OpenStatusSelector" method hides the current form and opens the ProfileStatusSelector form.
        /// </summary>
        /// <remarks>
        /// This method hides the current form, creates a new instance of the ProfileStatusSelector form,
        /// and then shows the ProfileStatusSelector form.
        /// </remarks>
        public void OpenStatusSelector()
        {
            this.Hide();
            FormHandler._profileStatusSelector = new ProfileStatusSelector();
            this.Invoke(new Action(() => FormHandler._profileStatusSelector.Show()));
        }

        #endregion
    }
}

