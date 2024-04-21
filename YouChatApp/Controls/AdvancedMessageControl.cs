using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using YouChatApp.AttachedFiles;
using YouChatApp.Controls;
using YouChatApp.UserAuthentication.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static YouChatApp.EnumHandler;

namespace YouChatApp
{
    public partial class AdvancedMessageControl : UserControl
    {
        private const int TextMessageNormalWidth = 193;
        private const string DeletedMessage = "This message has been deleted";
        private int NoramlWidth;
        private int ControlHeight;
        private int ExtendedWidth;
        private int RectangleWidth = 30;
        private Rectangle MenuAreaRectangle;
        private Rectangle MenuItemsAreaRectangle;
        private bool MenuItemsIsVisible = false;
        private bool IsOnMenuItem = false;
        private bool WasDeleted = false;
        private bool isYourMessage = true;
        private MessageType_Enum messageType = MessageType_Enum.Text;
        Image DeleteImage = global::YouChatApp.Properties.Resources.Delete;
        Image CopyImage = global::YouChatApp.Properties.Resources.Copy;
        
        private System.Windows.Forms.Button[] MenuButtons;
        public AdvancedMessageControl()
        {
            InitializeComponent();
            SetMessageControlTextSize();
            ControlsMouseDown();
            ControlsMouseMove();
        }
        public System.Windows.Forms.Label Username => UsernameLabel;
        public System.Windows.Forms.Label MessageContent => MessageLabel;
        public System.Windows.Forms.Label Time => TimeLabel;
        public PictureBox ProfilePicture => ProfilePictureCircularPictureBox;
        public PictureBox Image => ImagePictureBox;
        public event EventHandler MessageDelete;
        public event EventHandler AfterMessageDelete;

        private DateTime messageTime;
        public DateTime MessageTime
        {
            get
            {
                return messageTime;
            }
            set
            {
                messageTime = value;
            }
        }
        public void AddMessageDeleteHandler(EventHandler handler)
        {
            MessageDelete += handler;
        }
        public void AddAfterMessageDeleteHandler(EventHandler handler)
        {
            AfterMessageDelete += handler;
        }

        public float CurrentUsernameLabelTextSize = 12F;
        public float CurrentNessageLabelTextSize = 15.75F;
        public bool IsYourMessage
        {
            get
            {
                return isYourMessage;
            }
            set
            {
                isYourMessage = value;
            }
        }
        public MessageType_Enum MessageType
        {
            get
            {
                return messageType;
            }
            set
            {
                messageType = value;

                HandleMessageTypeChange();
            }
        }
        private void HandleMessageTypeChange()
        {
            MessageLabel.Visible = false;
            ImagePictureBox.Visible = false;
            switch (messageType)
            {
                case MessageType_Enum.Text:
                    MessageLabel.Visible = true;
                    this.AutoSize = true;
                    break;
                case MessageType_Enum.Image:
                    ImagePictureBox.Visible = true;
                    this.AutoSize = false;
                    break;
                case MessageType_Enum.DeletedMessage:
                    MenuBarPictureBox.Visible = false;
                    MessageLabel.Text = DeletedMessage;
                    MessageLabel.Visible = true;
                    this.AutoSize = true;
                    break;
            }
            HandleMessageControlDesign();
        }
        public void SetMessageControl()
        {
            HandleMessageControlDesign();
            NoramlWidth = this.Width;
            ControlHeight = this.Height;
            if (messageType != MessageType_Enum.DeletedMessage)
            {
                InitializeMenu();
                SetMenuAreaRectangle();
                SetMenuItemsAreaRectangle();
            }
        }
        private void HandleMessageControlDesign()
        {
            switch (messageType)
            {
                case MessageType_Enum.Text:
                    HandleMessageControlTextDesign();
                    break;
                case MessageType_Enum.DeletedMessage:
                    HandleMessageControlDeletedMessageDesign();
                    break;
                case MessageType_Enum.Image:
                    HandleMessageControlImageDesign();
                    break;
            }
        }
        private void SetMenuBarLocation()
        {
            int MenuBarPictureBoxYCoordination = (this.Height - MenuBarPictureBox.Height) / 2;
            int MenuBarPictureBoxXCoordination = this.Width - MenuBarPictureBox.Width - 10;
            MenuBarPictureBox.Location = new System.Drawing.Point(MenuBarPictureBoxXCoordination, MenuBarPictureBoxYCoordination);
        }
        private void HandleMessageControlTextDesign()
        {
            int NewWidth = MessageLabel.Location.X + MessageLabel.Width + RectangleWidth + 10;
            int realWidth = NewWidth > TextMessageNormalWidth ? NewWidth : TextMessageNormalWidth;
            this.Width = realWidth;
            int TimeLabelYCoordination = MessageLabel.Height + MessageLabel.Location.Y + 5;
            int TimeLabelXCoordination = realWidth - TimeLabel.Width - 25;
            TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination); //todo fix the height when sending multiline for the whole control,timelabel and menubutton
            this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            SetMenuBarLocation();
        }
        private void HandleMessageControlDeletedMessageDesign()
        {
            FitPictureBoxToImage(ImagePictureBox);
            int NewWidth = MessageLabel.Location.X + MessageLabel.Width + 10;
            int realWidth = NewWidth > TextMessageNormalWidth ? NewWidth : TextMessageNormalWidth;
            this.Width = realWidth;
            int TimeLabelYCoordination = MessageLabel.Height + MessageLabel.Location.Y + 5;
            int TimeLabelXCoordination = MessageLabel.Width + MessageLabel.Location.X - TimeLabel.Width + 5;
            TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination); //todo fix the height when sending multiline for the whole control,timelabel and menubutton
            this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            SetMenuBarLocation();
        }
        private void FitPictureBoxToImage(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                // Calculate the zoomed size of the image
                float zoomFactor = Math.Min((float)pictureBox.Width / pictureBox.Image.Width,
                                             (float)pictureBox.Height / pictureBox.Image.Height);

                // Calculate the new size of the PictureBox
                int newWidth = (int)(pictureBox.Image.Width * zoomFactor);
                int newHeight = (int)(pictureBox.Image.Height * zoomFactor);

                // Set the new size of the PictureBox
                pictureBox.Width = newWidth;
                pictureBox.Height = newHeight;
            }
        }
        private void HandleMessageControlImageDesign()
        {
            int NewWidth = ImagePictureBox.Location.X + ImagePictureBox.Width + RectangleWidth + 10;
            this.Width = NewWidth;
            int TimeLabelYCoordination = ImagePictureBox.Height + ImagePictureBox.Location.Y + 5;
            int TimeLabelXCoordination = ImagePictureBox.Width + ImagePictureBox.Location.X - TimeLabel.Width + 5;
            TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination); //todo fix the height when sending multiline for the whole control,timelabel and menubutton
            this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            int MenuBarPictureBoxYCoordination = (this.Height - MenuBarPictureBox.Height) / 2;
            int MenuBarPictureBoxXCoordination = this.Width - MenuBarPictureBox.Width - 10;
            MenuBarPictureBox.Location = new System.Drawing.Point(MenuBarPictureBoxXCoordination, MenuBarPictureBoxYCoordination);
        }

        private void SetMenuAreaRectangle()
        {
            int RectangleHeight = ControlHeight;
            int RectangleXCoordinate = NoramlWidth - RectangleWidth;
            int RectangleYCoordinate = 0;
            MenuAreaRectangle = new Rectangle(RectangleXCoordinate, RectangleYCoordinate, RectangleWidth, RectangleHeight);
        }
        private void SetMenuItemsAreaRectangle()
        {
            int MenuItemsAreaRectangleWidth = ExtendedWidth - NoramlWidth + RectangleWidth;
            int MenuItemsAreaRectangleHeight = ControlHeight;
            int MenuItemsAreaRectangleXCoordinate = NoramlWidth - RectangleWidth;
            int MenuItemsAreaRectangleYCoordinate = 0;
            MenuItemsAreaRectangle = new Rectangle(MenuItemsAreaRectangleXCoordinate, MenuItemsAreaRectangleYCoordinate, MenuItemsAreaRectangleWidth, MenuItemsAreaRectangleHeight);
        }

        private void InitializeMenu()
        {
            int size;
            if (isYourMessage)
            {
                size = 2;              
            }
            else
            {
                size = 1;
            }
            MenuButtons = new System.Windows.Forms.Button[size];
            int XValue = NoramlWidth + 20;
            for (int i = 0; i < MenuButtons.Length; i++)
            {
                MenuButtons[i] = new System.Windows.Forms.Button();
                this.MenuButtons[i].Location = new System.Drawing.Point(XValue, (ControlHeight - 40) / 2);
                this.MenuButtons[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
                this.MenuButtons[i].Size = new System.Drawing.Size(40, 40);
                this.MenuButtons[i].TabIndex = 0;
                this.MenuButtons[i].Text = "";
                this.MenuButtons[i].BackColor = SystemColors.Control;
                this.MenuButtons[i].UseVisualStyleBackColor = true;
                this.MenuButtons[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

                this.MenuButtons[i].Click += new System.EventHandler(MenuButtons_Click);
                //this.MenuButtons[i].MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
                //this.MenuButtons[i].MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);


                XValue += this.MenuButtons[i].Size.Width + 10;
            }
            ExtendedWidth = XValue;
            this.MenuButtons[0].Name = "CopyOptionButton";
            this.MenuButtons[0].BackgroundImage = CopyImage;
            if (isYourMessage)
            {
                this.MenuButtons[1].Name = "DeleteOptionButton";
                this.MenuButtons[1].BackgroundImage = DeleteImage;
            }
        }
        public void HandleDelete()
        {
            MessageLabel.Visible = true;
            ImagePictureBox.Visible = false;
            WasDeleted = true;
            messageType = EnumHandler.MessageType_Enum.DeletedMessage;
            HandleMessageTypeChange();
        }
        private void MenuButtons_Click(object sender, EventArgs e)
        {
            string ButtonName = ((Button)(sender)).Name;
            if (ButtonName == "DeleteOptionButton")
            {
                if (MessageBox.Show("Are you sure you want to delete this message?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // maybe to show a little bit of the message
                {
                    //MessageLabel.Text = DeletedMessage;
                    MessageDelete?.Invoke(this, e);
                    CloseMenuItems();
                    HandleDelete();
                    AfterMessageDelete?.Invoke(this, e);

                    //to do a check when sending the messages if this is a deleted message - in case it is, make sure the menubar is invisible
                    //when deleting need to update the chat member so they will change it and the xml chat file
                }
            }
            else if (ButtonName == "CopyOptionButton")
            {
                switch (messageType)
                {
                    case MessageType_Enum.Text:
                        Clipboard.SetText(MessageLabel.Text);
                        break;
                    case MessageType_Enum.Image:
                        Clipboard.SetImage(ImagePictureBox.BackgroundImage);
                        break;
                }
                MessageBox.Show("This message has been copied!", "Message Copied");
            }
            this.Invalidate();
        }

        //todo make sure that this function isnt on a specific control of this type...
        public void SetMessageControlTextSize()//לשנות גם את הגודל של הcontrol עצמו בהתאם...
        {
            if (ServerCommunication.SelectedMessageTextSize == 0)
            {
                CurrentUsernameLabelTextSize = 9F;
                CurrentNessageLabelTextSize = 11.00F;

            }
            else if (ServerCommunication.SelectedMessageTextSize == 1)
            {
                CurrentUsernameLabelTextSize = 10.5F;
                CurrentNessageLabelTextSize = 13.25F;
            }
            else if (ServerCommunication.SelectedMessageTextSize == 2)
            {
                CurrentUsernameLabelTextSize = 12F;
                CurrentNessageLabelTextSize = 15.75F;
            }
            else if (ServerCommunication.SelectedMessageTextSize == 3)
            {
                CurrentUsernameLabelTextSize = 14F;
                CurrentNessageLabelTextSize = 18.25F;
            }
            else 
            {
                CurrentUsernameLabelTextSize = 16F;
                CurrentNessageLabelTextSize = 21.75F;
            }
            this.UsernameLabel.Font = new System.Drawing.Font(this.UsernameLabel.Font.Name, CurrentUsernameLabelTextSize, this.UsernameLabel.Font.Style, this.UsernameLabel.Font.Unit);
            this.MessageLabel.Font = new System.Drawing.Font(this.MessageLabel.Font.Name, CurrentNessageLabelTextSize, this.MessageLabel.Font.Style, this.MessageLabel.Font.Unit);


        }
        public void SetBackColorByMessageSender()
        {
            this.BackColor = Color.PaleTurquoise;
            if (messageType != MessageType_Enum.DeletedMessage)
            {
                foreach (Button MenuButton in MenuButtons)
                {
                    MenuButton.BackColor = Color.PaleTurquoise;
                    MenuButton.FlatStyle = FlatStyle.Flat;
                    MenuButton.FlatAppearance.BorderColor = Color.PaleTurquoise;

                }
            }
        }
        public void SetBackColorByOtherSender()
        {
            this.BackColor = Color.LightGray;
            if (messageType != MessageType_Enum.DeletedMessage)
            {
                foreach (Button MenuButton in MenuButtons)
                {
                    MenuButton.BackColor = Color.LightGray;
                    MenuButton.FlatStyle = FlatStyle.Flat;
                    MenuButton.FlatAppearance.BorderColor = Color.LightGray;

                }
            }
        }
        protected override void OnPaint(PaintEventArgs Pevent)
        {
            base.OnPaint(Pevent);
            Pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle RectangleSurface = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle RectangleBorder = new Rectangle(1, 1, this.Width - 1, this.Height - 1);
            using (GraphicsPath PathSurface = GraphicsHandler.GetFigurePath(RectangleSurface, 2))
            {
                using (GraphicsPath PathBorder = GraphicsHandler.GetFigurePath(RectangleBorder, 1))
                {
                    using (Pen PenSurface = new Pen(this.Parent.BackColor, 2))
                    {
                        Color color = (this.Parent.BackColor == Color.PaleTurquoise) ? Color.MediumTurquoise : Color.DimGray;
                        using (Pen PenBorder = new Pen(color, 2))
                        {
                            PenBorder.Alignment = PenAlignment.Inset;
                            this.Region = new Region(PathSurface);
                            Pevent.Graphics.DrawPath(PenSurface, PathSurface);
                            Pevent.Graphics.DrawPath(PenBorder, PathBorder);
                        }
                    }
                }
            }
        }

        //private void MenuBarButton_Click(object sender, EventArgs e) //if the mouse is not on the button or on the menuoptions close this and use this.controls.remove()...
        //{
        //    this.Width += 120;
        //    foreach(Button MenuButton in MenuButtons)
        //    {
        //        this.Controls.Add(MenuButton);
        //    }

        //}

        private void MessageControl_MouseDown(object sender, MouseEventArgs e)
        {
            Point cursorLocation = this.PointToClient(((Control)sender).PointToScreen(e.Location));

            if ((PressIsOnRightEdgeRectangle(cursorLocation)) && (!WasDeleted))
            {
                this.Width = ExtendedWidth;
                MenuBarPictureBox.Visible = false;
                MenuItemsIsVisible = true;
                foreach (Button MenuButton in MenuButtons)
                {
                    this.Controls.Add(MenuButton);
                }
            }
        }
        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            IsOnMenuItem = true;
        }
        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            IsOnMenuItem = false;
        }
        private void ControlsMouseDown()
        {
            foreach (Control Control in this.Controls)
                Control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseDown);

        }

        private bool PressIsOnRightEdgeRectangle(Point CursorLocation)
        {
            return MenuAreaRectangle.Contains(CursorLocation);

        }

        private void MessageControl_MouseEnter(object sender, EventArgs e)
        {
            //if (MenuItemsIsVisible)
            //{
            //    //keep showing
            //}
        }

        private void MessageControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (MenuItemsIsVisible)
            {
                Point cursorLocation = this.PointToClient(((Control)sender).PointToScreen(e.Location));

                if ((!IsMouseCursorOverMenuItemsRectangle(cursorLocation)) && (!IsOnMenuItem))
                {
                    CloseMenuItems();
                }
            }
        }
        private bool IsMouseCursorOverMenuItemsRectangle(Point cursorLocation)
        {
            return MenuItemsAreaRectangle.Contains(cursorLocation);
        }
        private void ControlsMouseMove()
        {
            foreach (Control Control in this.Controls)
                Control.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);

        }

        private void MessageControl_MouseLeave(object sender, EventArgs e)
        {
            Point cursorPos = Cursor.Position;

            // Convert the screen coordinates to client coordinates of the control
            Point controlPos = PointToClient(cursorPos);

            // Check if the cursor is still within the control's client rectangle
            if (!ClientRectangle.Contains(controlPos))
            {
                if (MenuItemsIsVisible)
                {
                    CloseMenuItems();
                }
            }

        }
        private void CloseMenuItems()
        {
            this.Width = NoramlWidth;
            MenuBarPictureBox.Visible = true;
            RemoveMenuButtonsFromControls();
        }
        private void RemoveMenuButtonsFromControls()
        {
            MenuItemsIsVisible = false;
            foreach (Button MenuButton in MenuButtons)
            {
                this.Controls.Remove(MenuButton);
                MenuButton.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);

            }
        }

        private void MenuBarPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ImagePictureBox_Click(object sender, EventArgs e)
        {
            ImageViewer imageViewer = new ImageViewer(new Bitmap(ImagePictureBox.BackgroundImage));
            this.Invoke(new Action(() => imageViewer.ShowDialog()));
        }
    }
}
