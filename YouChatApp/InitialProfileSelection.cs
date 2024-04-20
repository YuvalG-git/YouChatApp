using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using YouChatApp.JsonClasses;

namespace YouChatApp
{
    public partial class InitialProfileSelection : Form
    {
        private readonly ServerCommunicator serverCommunicator;

        public InitialProfileSelection(bool IsPhaseOne)
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
           // serverCommunicator.BeginRead();
            //ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
            if (IsPhaseOne)
            {
                SetPhaseOne();
            }
            else
            {
                SetPhaseTwo();
            }
        }
        public InitialProfileSelection()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            // serverCommunicator.BeginRead();
            //ProfilePictureImageList.InitializeImageLists(); //todo - does it nessery if i did it before in another form - need to check...
            ProfilePictureControl.AddButtonClickHandler(SetConfirmButtonEnabled);
            if (true)
            {
                SetPhaseOne();
            }
            else
            {
                SetPhaseTwo();
            }
        }
        public void OpenApp()
        {
            this.Hide();
            FormHandler._youChat = new YouChat();
            this.Invoke(new Action(() => FormHandler._youChat.Show()));
        }

        private void SetPhaseOne()
        {
            ProfilePictureControl.Visible = true;
            ProfileStatusControl.Visible = false;
        }
        public void SetPhaseTwo()
        {
            ProfilePictureControl.Visible = false;
            ProfileStatusControl.Visible = true;
        }

        public void SetConfirmButtonEnabled(object sender, EventArgs e)
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
        public void SetConfirmButtonEnabledToFalse()
        {
            ConfirmCustomButton.Enabled = false;
        }
        public void SetConfirmButtonEnabledToTrue()
        {
            ConfirmCustomButton.Enabled = true;
        }

        private void ConfirmCustomButton_Click(object sender, EventArgs e)
        {
            string ProfilePictureId = ProfilePictureControl.GetImageNameID();
            JsonObject profilePictureIdJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.UploadProfilePictureRequest, ProfilePictureId);
            string profilePictureIdJson = JsonConvert.SerializeObject(profilePictureIdJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            serverCommunicator.SendMessage(profilePictureIdJson);
        }
    }
}
