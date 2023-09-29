using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace YouChatApp
{
    public partial class MessageControl : UserControl
    {
        private int NoramlWidth;
        private int ControlHeight;
        private int ExtendedWidth;
        private int RectangleWidth = 30;
        private Rectangle MenuAreaRectangle;
        private Rectangle MenuItemsAreaRectangle;
        private bool MenuItemsIsVisible = false;

        Image DeleteImage = global::YouChatApp.Properties.Resources.Delete;
        Image CopyImage = global::YouChatApp.Properties.Resources.Copy;
        Image FowardImage = global::YouChatApp.Properties.Resources.Foward;

        private System.Windows.Forms.Button[] MenuButtons;
        public MessageControl()
        {
            InitializeComponent();
            SetMessageControlTextSize();
            ControlsMouseDown();
            ControlsMouseMove();
        }
        public System.Windows.Forms.Label Username => UsernameLabel;
        public System.Windows.Forms.Label Message => MessageLabel;
        public System.Windows.Forms.Label Time => TimeLabel;
        public PictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public float CurrentUsernameLabelTextSize = 12F;
        public float CurrentNessageLabelTextSize = 15.75F;

        public void SetMessageControl()
        {
            int MessageControlToMessageLabelWidth = MessageLabel.Location.X - this.Location.X;
            int NewWidth = MessageLabel.Width + MessageControlToMessageLabelWidth + RectangleWidth + 10;
            if (NewWidth > this.Width)
            {
                this.Width = NewWidth;
                int TimeLabelYCoordination = MessageLabel.Height + MessageLabel.Location.Y + 5;
                int TimeLabelXCoordination = MessageLabel.Width + MessageLabel.Location.X - TimeLabel.Width + 5;
                TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination);
                this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
                int MenuBarPictureBoxYCoordination = (this.Height - MenuBarPictureBox.Height) / 2;
                int MenuBarPictureBoxXCoordination = this.Width - MenuBarPictureBox.Width;
                MenuBarPictureBox.Location = new System.Drawing.Point(MenuBarPictureBoxXCoordination, MenuBarPictureBoxYCoordination);
                this.Size = new System.Drawing.Size(this.Width, this.Height);
            }
            NoramlWidth = this.Width;
            ControlHeight = this.Height;
            InitializeMenu();
            SetMenuAreaRectangle();
            SetMenuItemsAreaRectangle();




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
            MenuButtons = new System.Windows.Forms.Button[3];
            int XValue = NoramlWidth + 20;
            for (int i = 0; i <MenuButtons.Length; i++)
            {
                MenuButtons[i] = new System.Windows.Forms.Button();
                this.MenuButtons[i].Location = new System.Drawing.Point(XValue, (ControlHeight - 40)/2);
                this.MenuButtons[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177))); ;
                this.MenuButtons[i].Size = new System.Drawing.Size(40, 40);
                this.MenuButtons[i].TabIndex = 0;
                this.MenuButtons[i].Text = "";
                this.MenuButtons[i].BackColor = SystemColors.Control;
                this.MenuButtons[i].UseVisualStyleBackColor = true;
                this.MenuButtons[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                this.Controls.Add(MenuButtons[i]);

                this.MenuButtons[i].Click += new System.EventHandler(MenuButtons_Click);

                XValue += this.MenuButtons[i].Size.Width + 10;
            }
            ExtendedWidth = XValue;
            this.MenuButtons[0].Name = "DeleteOptionButton";
            this.MenuButtons[1].Name = "CopyOptionButton";
            this.MenuButtons[2].Name = "FowardOptionButton";
            this.MenuButtons[0].BackgroundImage = DeleteImage;
            this.MenuButtons[1].BackgroundImage = CopyImage;
            this.MenuButtons[2].BackgroundImage = FowardImage;

        }

        private void MenuButtons_Click(object sender, EventArgs e)
        {
            bool WasChosen = false;
            string ButtonName = ((Button)(sender)).Name;
            if (ButtonName == "DeleteOptionButton")
            {
                if (MessageBox.Show("Are you sure you want to delete this message?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // maybe to show a little bit of the message
                {
                    MessageLabel.Text = "This message has been deleted";
                    MenuBarPictureBox.Visible = false; //to do a check when sending the messages if this is a deleted message - in case it is, make sure the menubar is invisible
                    //when deleting need to update the chat member so they will change it and the xml chat file
                    SetMessageControl();
                    WasChosen = true;
                }
            }
            else if (ButtonName == "CopyOptionButton")
            {
                Clipboard.SetText(MessageLabel.Text);
                MessageBox.Show("This message has been copied!", "Message Copied");
                WasChosen = true;

            }
            else
            {

            }
            if (WasChosen)
            {
                CloseMenuItems();
            }
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
            this.BackColor = Color.MediumSeaGreen;
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

            if (PressIsOnRightEdgeRectangle(cursorLocation))
            {
                this.Width += 120;
                MenuBarPictureBox.Visible = false;
                MenuItemsIsVisible = true;
                foreach (Button MenuButton in MenuButtons)
                {
                    //this.Controls.Add(MenuButton);
                    //MenuButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);

                }
            }
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

                if (!IsMouseCursorOverMenuItemsRectangle(cursorLocation))
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
            if (MenuItemsIsVisible)
            {
                CloseMenuItems();
            }
        }
        private void CloseMenuItems()
        {
            this.Width = NoramlWidth;
            MenuItemsIsVisible = false;
            MenuBarPictureBox.Visible = true;
            foreach (Button MenuButton in MenuButtons)
            {
                //this.Controls.Remove(MenuButton);
                //MenuButton.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);

            }
        }
    }
}
