using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Controls;
using YouChatApp.JsonClasses;
using YouChatApp.UserAuthentication.Forms;
using YouChatApp.UserProfile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace YouChatApp
{
    /// <summary>
    /// The "Profile" class represents the user's profile form.
    /// </summary>
    /// <remarks>
    /// This class manages various aspects of the user's profile, including profile picture selection, status updates,
    /// and communication with the server to update profile information.
    /// </remarks>
    public partial class Profile : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" represents the server communicator instance.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Constructors

        /// <summary>
        /// The "Profile" constructor initializes a new instance of the <see cref="Profile"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the Profile class, initializing various components
        /// and settings for the user's profile, including the server communicator, current profile picture, and profile status.
        /// It also adds event handlers for the profile picture control and status control.
        /// </remarks>
        public Profile()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            CurrentProfilePicturePictureBox.Image = ProfileDetailsHandler.ProfilePicture;
            ProfileStatusControl.setStatus(ProfileDetailsHandler.Status);
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
            ProfileStatusControl.AddSaveStatusCustomButtonClickHandler(SendStatus);
        }

        #endregion

        #region Private Profile Picture Methods

        /// <summary>
        /// The "ProfilePictureSelectionCustomButton_Click" method handles the click event of the profile picture selection custom button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// This method sets the visibility of the profile picture selection custom button and status selection custom button.
        /// It also updates the SettingsModeLabel text to "Profile Picture" and toggles the visibility of the profile picture panel and profile status control.
        /// </remarks>
        private void ProfilePictureSelectionCustomButton_Click(object sender, EventArgs e)
        {
            SetVisuality(ProfilePictureSelectionCustomButton, StatusSelectionCustomButton);

            SettingsModeLabel.Text = "Profile Picture";
            ProfilePicturePanel.Visible = true;
            ProfileStatusControl.Visible = false;
        }

        /// <summary>
        /// The "SaveProfilePictureCustomButton_Click" method saves the selected profile picture and sends a message to update the profile picture on the server.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the current profile picture to the selected image, disables the save button to prevent multiple clicks, gets the ID of the selected profile picture,
        /// and sends a message to the server to update the profile picture.
        /// </remarks>
        private void SaveProfilePictureCustomButton_Click(object sender, EventArgs e)
        {
            CurrentProfilePicturePictureBox.Image = ProfilePictureControl.ImageChosenAtTheMoment;
            SaveProfilePictureCustomButton.Enabled = false;
            string ProfilePictureId = ProfilePictureControl.GetImageNameID();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UpdateProfilePictureRequest;
            object messageContent = ProfilePictureId;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "SetConfirmButtonEnabled" method enables or disables the confirm button based on whether a profile picture is selected.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if a profile picture is currently selected in the profile picture control. 
        /// If a picture is selected, it enables the save profile picture button; otherwise, it disables the button.
        /// </remarks>
        private void SetConfirmButtonEnabled(object sender, EventArgs e)
        {
            if (ProfilePictureControl.ImageChosenAtTheMoment != null)
            {
                SaveProfilePictureCustomButton.Enabled = true;
            }
            else
            {
                SaveProfilePictureCustomButton.Enabled = false;
            }
        }

        #endregion

        #region Private Status Methods

        /// <summary>
        /// The "StatusSelectionCustomButton_Click" method handles the click event of the status selection custom button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs containing event data.</param>
        /// <remarks>
        /// This method sets the visibility of the status selection custom button and profile picture selection custom button.
        /// It also updates the SettingsModeLabel text to "Status" and toggles the visibility of the profile picture panel and profile status control.
        /// </remarks>
        private void StatusSelectionCustomButton_Click(object sender, EventArgs e)
        {
            SetVisuality(StatusSelectionCustomButton, ProfilePictureSelectionCustomButton);

            SettingsModeLabel.Text = "Status";
            ProfilePicturePanel.Visible = false;
            ProfileStatusControl.Visible = true;
        }

        /// <summary>
        /// The "SendStatus" method sends the updated profile status to the server.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the profile status from the profile status control. 
        /// It then sends an update profile status request message to the server with the new status information.
        /// </remarks>
        private void SendStatus(object sender, EventArgs e)
        {
            string ProfileStatus = ProfileStatusControl.GetStatus();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.UpdateProfileStatusRequest;
            object messageContent = ProfileStatus;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "SetVisuality" method adjusts the visual appearance of two custom buttons to indicate selection.
        /// </summary>
        /// <param name="selectedCustomButton">The custom button that is selected.</param>
        /// <param name="otherCustomButton">The other custom button that is not selected.</param>
        /// <remarks>
        /// This method disables the selected custom button, enables the other custom button, sets the border size of the selected custom button to 2 (indicating selection),
        /// sets the border size of the other custom button to 0 (indicating deselection), and makes the SettingsModeLabel visible.
        /// </remarks>
        private void SetVisuality(CustomButton selectedCustomButton, CustomButton otherCustomButton)  
        {
            selectedCustomButton.Enabled = false;
            otherCustomButton.Enabled = true;
            selectedCustomButton.BorderSize = 2;
            otherCustomButton.BorderSize = 0;
            SettingsModeLabel.Visible = true;
        }

        /// <summary>
        /// The "Profile_FormClosed" method handles the FormClosed event of the profile form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The FormClosedEventArgs containing event data.</param>
        /// <remarks>
        /// This method invokes a method on the main chat form to set the profile button enabled when the profile form is closed.
        /// </remarks>
        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Invoke(new Action(() => FormHandler._youChat.SetProfileButtonEnabled()));
        }

        #endregion
    }
}
