using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Messaging;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.AttachedFiles;

namespace YouChatApp
{
    public partial class YouChat : Form
    {
        Profile profile;
        public static int MessageNumber = 0;
        public static int height = 10;
        public static int messageGap = 10; 
        public static DateTime Time;
        public static int ContactChatNumber = 0;
        public static ResourceSet[] resourceSetArray;

        public YouChat()
        {
            InitializeComponent();
            ServerCommunication.BeginRead();
            MessageLabels = new List<Label>();
            MessageControlListOfLists = new List<List<MessageControl>>();
            ChatControlListOfContacts = new List<ChatControl>();
            IDNameLabel.Text = ServerCommunication.name;
            MessageControlListOfLists.Add(new List<MessageControl>());

            ProfilePictureImageList.InitializeImageLists();
            SetResourceSetArray();
        }
        private void SetResourceSetArray()
        {
             resourceSetArray = new ResourceSet[9];
            {
                resourceSetArray[0] = Properties.Activities_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[1] = Properties.AnimalsAndNature_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[2] = Properties.Flags_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[3] = Properties.FoodAndDrink_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[4] = Properties.Objects_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[5] = Properties.People_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[6] = Properties.Smileys_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[7] = Properties.Symbols_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[8] = Properties.TravelAndPlaces_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                //maybe i can send the needed location when i send the image name... this way i wouldn't need to check all of them
                // i can send something like that: "¥2¥_43af"
            }
        }

        private string[] SeparateLettersAndNumbers(string Text)
        {
            string[] LettersAndNumbersArray = new string[2];
            for (int i = 0; i < LettersAndNumbersArray.Length; i++)
            {
                LettersAndNumbersArray[i] = "";
            }
            string Letters = "";
            string Numbers = "";

            foreach (char Character in Text)
            {
                if (char.IsLetter(Character))
                {
                    Letters += Character;
                }
                else if (char.IsDigit(Character))
                {
                    Numbers += Character;
                }
            }
            LettersAndNumbersArray[0] = Letters;
            LettersAndNumbersArray[1] = Numbers;
            return LettersAndNumbersArray;
        }

        public void SetChatControlListOfContacts(string ChatInformation)
        {
            string[] ContactsInformation = ChatInformation.Split('#'); //todo check how i can allow the users to send # and more without the split activating - i thing maybe i need to put / or something before 
            string ContactUsername;
            string ContactLastMessageContent;
            string ContactLastMessageTime;
            string ContactProfilePictureID;
            string ContactProfilePictureKind;
            string ContactProfilePictureNumber;
            for (int i = 0; i < ContactsInformation.Length; i++)
            {
                string[] ContactDetails = ContactsInformation[i].Split('^');
                ContactUsername = ContactDetails[0];
                ContactLastMessageContent = ContactDetails[1];
                ContactLastMessageTime = ContactDetails[2];
                ContactProfilePictureID = ContactDetails[3];
                string[] ContactProfilePictureInformation = SeparateLettersAndNumbers(ContactProfilePictureID);
                ContactProfilePictureKind = ContactProfilePictureInformation[0];
                ContactProfilePictureNumber = ContactProfilePictureInformation[1]; // to understand how to seperate them

                if (ContactChatNumber == 0)
                    height = 0;
                else
                    height = this.ChatControlListOfContacts[ContactChatNumber - 1].Location.Y + this.ChatControlListOfContacts[ContactChatNumber - 1].Size.Height;
                this.ChatControlListOfContacts.Add(new ChatControl());
                this.ChatControlListOfContacts[ContactChatNumber].Location = new System.Drawing.Point(0, height);
                this.ChatControlListOfContacts[ContactChatNumber].Name = "ChatControlNumber:" + ContactChatNumber;
                this.ChatControlListOfContacts[ContactChatNumber].TabIndex = 0;
                this.ChatControlListOfContacts[ContactChatNumber].BackColor = SystemColors.Control;
                this.ChatControlListOfContacts[ContactChatNumber].ChatName.Text = ContactUsername;
                this.ChatControlListOfContacts[ContactChatNumber].LastMessageContent.Text = ContactLastMessageContent;
                this.ChatControlListOfContacts[ContactChatNumber].LastMessageTime.Text = ContactLastMessageTime;
                if (ContactProfilePictureKind == "Male")
                {
                    this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.MaleProfilePictureImageList.Images[ContactProfilePictureNumber];
                }
                else if (ContactProfilePictureKind == "Female")
                {
                    this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.FemaleProfilePictureImageList.Images[ContactProfilePictureNumber];

                }
                else if (ContactProfilePictureKind == "Animal")
                {
                    this.ChatControlListOfContacts[ContactChatNumber].ProfilePicture.BackgroundImage = ProfilePictureImageList.AnimalProfilePictureImageList.Images[ContactProfilePictureNumber];


                }
                this.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                this.ChatPanel.Controls.Add(this.ChatControlListOfContacts[ContactChatNumber]);
                if (this.ChatPanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
                {
                    Control LastControl = this.ChatPanel.Controls[this.ChatPanel.Controls.Count - 1];
                    this.ChatPanel.ScrollControlIntoView(LastControl);
                }
                ContactChatNumber++;


            }
        }


        private void ProfileButton_Click(object sender, EventArgs e)
        {
            profile = new Profile(this);
            profile.Show();
            ProfileButton.Enabled = false;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (MessageTextBox.Text != "")
            {
                string Message = MessageTextBox.Text;
                string SendMessageTime = DateTime.Now.ToString("HH:mm");
                string MessageContant = Message + "#" + SendMessageTime;
                ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + MessageContant);
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
            else if (LoadedPicturePictureBox.BackgroundImage!=null)
            {
                //ServerCommunication.SendImage(ServerCommunication.sendMessageRequest + "$" + MessageContant); need to figure out how to send a message as well - not nesserally perhaps - could use the username from the server and take the time the message got to the server...

            }

        }

        private void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageTextBox.Text !="")
            {
                SendMessageButton.Enabled = true;
            }
            else
                SendMessageButton.Enabled = false;
        }

        //public void Message(string MessageInfo)
        //{
        //    if (MessageNumber != 0)
        //        height = this.MessageLabels[MessageNumber - 1].Location.Y + this.MessageLabels[MessageNumber - 1].Size.Height + messageGap;
        //    this.MessageLabels.Add(new System.Windows.Forms.Label());
        //    this.MessageLabels[MessageNumber].Location = new System.Drawing.Point(30, height);
        //    this.MessageLabels[MessageNumber].Name = "MessageLabelNumber:" + MessageNumber;
        //    this.MessageLabels[MessageNumber].Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
        //    this.MessageLabels[MessageNumber].AutoSize = true;
        //    this.MessageLabels[MessageNumber].TabIndex = 0;
        //    this.MessageLabels[MessageNumber].Text = MessageInfo;
        //    this.MessageLabels[MessageNumber].BackColor = SystemColors.Control;
        //    this.Controls.Add(this.MessageLabels[MessageNumber]);
        //    this.MessagePanel.Controls.Add(this.MessageLabels[MessageNumber]);
        //    MessageNumber++;
        //    height = this.MessageLabels[MessageNumber - 1].Location.Y + this.MessageLabels[MessageNumber-1].Size.Height + messageGap;

        //    if (this.MessagePanel.Controls.Count > 0)
        //    {
        //        Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
        //        this.MessagePanel.ScrollControlIntoView(lastControl);
        //    }
        //}
        //public void Message2(string MessageInfo)
        //{
        //    this.MessageGroupBoxs.Add(new System.Windows.Forms.GroupBox());
        //    this.Controls.Add(this.MessageLabels[MessageNumber]);
        //    this.MessagePanel.Controls.Add(this.MessageLabels[MessageNumber]);
        //    this.MessageGroupBoxs.Add()

        //}
        public void SetProfileButtonEnabled()
        {
            ProfileButton.Enabled = true;
        }



        public void Message(string MessageInfo)
        {
            string[] MessageDetails = MessageInfo.Split('#');
            string SenderUsername = MessageDetails[0];
            string MessageContent = MessageDetails[1];
            string SendMessageTime = MessageDetails[2];

            if (MessageNumber != 0)
                height = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID].Add(new MessageControl());
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Location = new System.Drawing.Point(30, height);
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Name = "MessageControlNumber:" + MessageNumber;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].TabIndex = 0;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].BackColor = SystemColors.Control;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Username.Text = SenderUsername;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = MessageContent;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Time.Text = SendMessageTime;
            this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].SetMessageControl();
            this.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);
            this.MessagePanel.Controls.Add(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber]);

            if (this.MessagePanel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                //Control lastControl = this.MessagePanel.Controls[this.MessagePanel.Controls.Count - 1];
                Control LastControl = this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber];
                this.MessagePanel.ScrollControlIntoView(LastControl);
            }
            MessageNumber++;

        }

        private void MessageContentBuilder(string MessageContent)
        {
            if (MessageContent.Contains("€"))
            {
                string[] MessageParts = MessageContent.Split('€');
                foreach (string part in MessageParts)
                {
                    if (part.StartsWith("¥"))
                    {
                        Image EmojiImage = SearchEmojiImageInAllResources(part.Substring(1));
                        if (EmojiImage != null)
                        {
                            Bitmap bitmap = new Bitmap(EmojiImage, 20, 20);
                            Clipboard.SetDataObject(bitmap);
                            //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Paste(); //will work when i switch the label to richtextbox
                            Clipboard.Clear();
                        }

                    }
                    else
                    {
                        this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text += MessageContent;
                        //this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Select(this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text.Length, 0);


                    }
                }


            }
            else
            {
                this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber].Message.Text = MessageContent;

            }
        }

        private Image SearchEmojiImageInAllResources(string ImageName)
        {
            foreach (ResourceSet ResourceSetObject in resourceSetArray)
            {
                if (ResourceSetObject != null)
                {
                    foreach (DictionaryEntry entry in ResourceSetObject)
                    {
                        string resourceName = entry.Key.ToString();
                        if (entry.Value is Image image)
                        {
                            if (resourceName == ImageName)
                            {
                                return ResourceSetObject.GetObject(resourceName) as Image;

                            }
                        }
                    }
                }
            }
            return null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        private void UserIDTextBox_Enter(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text == "YouChat ID")
            {
                UserIDTextBox.Text = "";
                UserIDTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void UserIDTextBox_Leave(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text == "")
            {
                UserIDTextBox.Text = "YouChat ID";
                UserIDTextBox.ForeColor = Color.Silver;
            }
        }

        private void UserTagLineTextBox_Enter(object sender, EventArgs e)
        {
            if (UserTagLineTextBox.Text == "TAGLINE")
            {
                UserTagLineTextBox.Text = "";
                UserTagLineTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void UserTagLineTextBox_Leave(object sender, EventArgs e)
        {
            if (UserTagLineTextBox.Text == "")
            {
                UserTagLineTextBox.Text = "TAGLINE";
                UserTagLineTextBox.ForeColor = Color.Silver;
            }
        }

        private void MessageTextBox_Enter(object sender, EventArgs e)
        {
            if (MessageTextBox.Text == "Here You Write Your Message")
            {
                MessageTextBox.Text = "";
                MessageTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void MessageTextBox_Leave(object sender, EventArgs e)
        {
            if (MessageTextBox.Text == "")
            {
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
        }

        private void YouChat_Load(object sender, EventArgs e)
        {
            ServerCommunication.SendMessage(ServerCommunication.ContactInformationRequest + "$" + "Chat Information");

        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }
            else if ((e.KeyCode == Keys.Enter) && (MessageTextBox.Text !="") && (ServerCommunication.EnterKeyPress))
            {
                string message = MessageTextBox.Text;
                ServerCommunication.SendMessage(ServerCommunication.sendMessageRequest + "$" + message);
                MessageTextBox.Text = "Here You Write Your Message";
                MessageTextBox.ForeColor = Color.Silver;
            }

        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            GroupCreatorPanel.Visible = false;
            ContactManagementPanel.Visible = false;
            ChatPanel.Visible = true;
        }
        private void NewContactButton_Click(object sender, EventArgs e)
        {
            GroupCreatorPanel.Visible = false;
            ContactManagementPanel.Visible = true;
            ChatPanel.Visible = false;
        }

        private void NewGroupButton_Click(object sender, EventArgs e)
        {
            GroupCreatorPanel.Visible = true;
            ContactManagementPanel.Visible = false;
            ChatPanel.Visible = false;
        }

        private void PhotoFileButton_Click(object sender, EventArgs e)
        {
            LoadedPictureGroupBox.Visible = true;

            UploadedPictureOpenFileDialog.InitialDirectory = Application.StartupPath;
            UploadedPictureOpenFileDialog.Filter = "*.png|*.png|*.jpg|*.jpg";
            if (UploadedPictureOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadedPicturePictureBox.BackgroundImage = Image.FromFile(UploadedPictureOpenFileDialog.FileName);
            }
        }

        private void UploadedPictureRotationButton_Click(object sender, EventArgs e)
        {
            if (LoadedPicturePictureBox.BackgroundImage != null)
            {
                Bitmap RotatedPicture = new Bitmap(LoadedPicturePictureBox.BackgroundImage.Width, LoadedPicturePictureBox.BackgroundImage.Height);
                using (Graphics graphics = Graphics.FromImage(RotatedPicture))
                {
                    graphics.TranslateTransform(RotatedPicture.Width / 2, RotatedPicture.Height / 2);
                    graphics.RotateTransform((float)90);
                    graphics.TranslateTransform(-RotatedPicture.Width / 2, -RotatedPicture.Height / 2);
                    graphics.DrawImage(LoadedPicturePictureBox.BackgroundImage, new PointF(0, 0));
                }

                LoadedPicturePictureBox.BackgroundImage = RotatedPicture;
            }
        }
        public void ChangeMessagesAppearance()
        {
            height = 10;
            int NumberOfMessage = 0;
            foreach (List<MessageControl> MessageList in MessageControlListOfLists)
            {
                NumberOfMessage = 0;
                foreach (MessageControl Message in MessageList)
                {
                    Message.SetMessageControlTextSize();
                    if (MessageNumber != 0)
                        height = this.MessageControlListOfLists[MessageList.Count][NumberOfMessage - 1].Location.Y + this.MessageControlListOfLists[ServerCommunication.CurrentChatNumberID][MessageNumber - 1].Size.Height + messageGap;
                    this.MessageControlListOfLists[MessageList.Count][NumberOfMessage].SetMessageControl();
                    this.MessageControlListOfLists[MessageList.Count][NumberOfMessage].Location = new System.Drawing.Point(30, height);

                    NumberOfMessage++;
                }
            }
            //foreach (MessageControl Message in MessagePanel.Controls)
            //{

            //}
        }

        private void VideoFileButton_Click(object sender, EventArgs e)
        {

        }
    }
}
