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
using YouChatApp.JsonClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.Controls
{
    public partial class ProfileStatusControl : UserControl
    {
        private bool IsSelectedStatusShownProperty = true;
        public ProfileStatusControl()
        {
            InitializeComponent();
        }
        public bool IsSelectedStatusShown
        {
            get
            {
                return IsSelectedStatusShownProperty;
            }
            set
            {
                IsSelectedStatusShownProperty = value;
                HandleSelectedStatusVisibility();
            }
        }
        public string Status
        {
            get
            {
                return ProfileStatusCustomTextBox.TextContent;
            }
        }

        private void RefreshStatusCustomButton_Click(object sender, EventArgs e)
        {
            RefreshProfileStatusCustomTextBoxContent();
        }
        private void RefreshProfileStatusCustomTextBoxContent()
        {
            ProfileStatusCustomTextBox.TextContent = "";
            CharNumberLabel.Text = "0/" + ProfileStatusCustomTextBox.MaxLength;
        }

        private void ProfileStatusCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            CharNumberLabel.Text = ProfileStatusCustomTextBox.TextContent.Length.ToString() + "/" + ProfileStatusCustomTextBox.MaxLength;
            if (ProfileStatusCustomTextBox.IsContainingValue())
            {
                SaveStatusCustomButton.Enabled = true;
                RefreshStatusCustomButton.Enabled = true;

            }
            else
            {
                SaveStatusCustomButton.Enabled = false;
                RefreshStatusCustomButton.Enabled = false;

            }
        }
        private void HandleSelectedStatusVisibility()
        {
            if (IsSelectedStatusShown)
            {
                StatusTextPanel.Visible = true;
                StatusMainPanel.Location = new Point(StatusMainPanel.Location.X, StatusTextPanel.Location.Y + StatusTextPanel.Height + 10);
            }
            else
            {
                StatusTextPanel.Visible = false;
                StatusMainPanel.Location = new Point(StatusMainPanel.Location.X, StatusTextPanel.Location.Y);
            }
            this.Height = StatusMainPanel.Location.Y + StatusMainPanel.Height + 10;
        }

        private void SaveStatusCustomButton_Click(object sender, EventArgs e)
        {
            if (ProfileStatusCustomTextBox.IsContainingValue())
                setStatus(ProfileStatusCustomTextBox.TextContent);
            string ProfileStatus = Status;
            JsonObject profileStatusJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UploadStatusRequest, ProfileStatus);
            string profileStatusJson = JsonConvert.SerializeObject(profileStatusJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(profileStatusJson);
            RefreshProfileStatusCustomTextBoxContent();
        }
        public void setStatus(string status)
        {
            CurrentStatusLabel.Text = CurrentStatusLabel.Text.Substring(0, 16) + status;
        }

        private void StatusMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
