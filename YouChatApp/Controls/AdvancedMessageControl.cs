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
    /// <summary>
    /// The "AdvancedMessageControl" class represents a custom UserControl for displaying messages with advanced functionality.
    /// </summary>
    /// <remarks>
    /// This control includes various features such as message deletion, message type handling (text, image, deleted), and customizable design.
    /// It provides events for message deletion and after deletion actions. The control supports different message sender styles
    /// based on whether the message is from the current user or another user.
    /// </remarks>
    public partial class AdvancedMessageControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "MessageDelete" event is raised when a message is deleted.
        /// </summary>
        public event EventHandler MessageDelete;

        /// <summary>
        /// The EventHandler "AfterMessageDelete" event is raised after a message is deleted.
        /// </summary>
        public event EventHandler AfterMessageDelete;

        #endregion

        #region Private Fields

        /// <summary>
        /// The int "NoramlWidth" represents the normal width of the control.
        /// </summary>
        private int NoramlWidth;

        /// <summary>
        /// The int "ControlHeight" represents the height of the control.
        /// </summary>
        private int ControlHeight;

        /// <summary>
        /// The int "ExtendedWidth" represents the extended width of the control.
        /// </summary>
        private int ExtendedWidth;

        /// <summary>
        /// The int "RectangleWidth" represents the width of the rectangle.
        /// </summary>
        private int RectangleWidth = 30;

        /// <summary>
        /// The Rectangle "MenuAreaRectangle" represents the rectangle for the menu area.
        /// </summary>
        private Rectangle MenuAreaRectangle;

        /// <summary>
        /// The Rectangle "MenuItemsAreaRectangle" represents the rectangle for the menu items area.
        /// </summary>
        private Rectangle MenuItemsAreaRectangle;

        /// <summary>
        /// The bool "MenuItemsIsVisible" indicates whether the menu items are visible.
        /// </summary>
        private bool MenuItemsIsVisible = false;

        /// <summary>
        /// The bool "IsOnMenuItem" indicates whether the control is on a menu item.
        /// </summary>
        private bool IsOnMenuItem = false;

        /// <summary>
        /// The bool "WasDeleted" indicates whether the message was deleted.
        /// </summary>
        private bool WasDeleted = false;

        /// <summary>
        /// The bool "isYourMessage" indicates whether the message is yours.
        /// </summary>
        private bool isYourMessage = true;

        /// <summary>
        /// The MessageType_Enum "messageType" represents the type of the message.
        /// </summary>
        private MessageType_Enum messageType = MessageType_Enum.Text;

        /// <summary>
        /// The DateTime "messageTime" represents the time of the message.
        /// </summary>
        private DateTime messageTime;

        /// <summary>
        /// The System.Windows.Forms.Button[] "MenuButtons" represents an array of menu buttons.
        /// </summary>
        private System.Windows.Forms.Button[] MenuButtons;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "DeleteImage" represents the delete image.
        /// </summary>
        private readonly Image DeleteImage = global::YouChatApp.Properties.Resources.Delete;

        /// <summary>
        /// The readonly Image "CopyImage" represents the copy image.
        /// </summary>
        private readonly Image CopyImage = global::YouChatApp.Properties.Resources.Copy;

        /// <summary>
        /// The readonly int "TextMessageNormalWidth" represents the normal width of a text message.
        /// </summary>
        private readonly int TextMessageNormalWidth = 193;

        /// <summary>
        /// The readonly string "DeletedMessage" represents the message displayed for a deleted message.
        /// </summary>
        private readonly string DeletedMessage = "This message has been deleted";

        #endregion

        #region Constructors

        /// <summary>
        /// The "AdvancedMessageControl" constructor initializes a new instance of the <see cref="AdvancedMessageControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the AdvancedMessageControl by initializing its components and adding event handlers for mouse down and mouse move events.
        /// </remarks>
        public AdvancedMessageControl()
        {
            InitializeComponent();
            ControlsMouseDown();
            ControlsMouseMove();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Username" property represents the username associated with the message.
        /// It gets the username associated with the message.
        /// </summary>
        /// <value>
        /// The username associated with the message.
        /// </value>
        public System.Windows.Forms.Label Username
        {
            get
            {
                return UsernameLabel;
            }
        }

        /// <summary>
        /// The "MessageContent" property represents the content of the message.
        /// It gets the content of the message.
        /// </summary>
        /// <value>
        /// The content of the message.
        /// </value>
        public System.Windows.Forms.Label MessageContent
        {
            get
            {
                return MessageLabel;
            }
        }

        /// <summary>
        /// The "Time" property represents the time when the message was sent.
        /// It gets the time when the message was sent.
        /// </summary>
        /// <value>
        /// The time when the message was sent.
        /// </value>
        public System.Windows.Forms.Label Time
        {
            get
            {
                return TimeLabel;
            }
        }

        /// <summary>
        /// The "ProfilePicture" property represents the profile picture associated with the message.
        /// It gets the profile picture associated with the message.
        /// </summary>
        /// <value>
        /// The profile picture associated with the message.
        /// </value>
        public PictureBox ProfilePicture
        {
            get
            {
                return ProfilePictureCircularPictureBox;
            }
        }

        /// <summary>
        /// The "Image" property represents the image attached to the message.
        /// It gets the image attached to the message.
        /// </summary>
        /// <value>
        /// The image attached to the message.
        /// </value>
        public PictureBox Image
        {
            get
            {
                return ImagePictureBox;
            }
        }

        /// <summary>
        /// The "MessageTime" property represents the time when the message was sent.
        /// It gets or sets the time when the message was sent.
        /// </summary>
        /// <value>
        /// The time when the message was sent.
        /// </value>
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

        /// <summary>
        /// The "IsYourMessage" property represents whether the message belongs to the current user.
        /// It gets or sets whether the message belongs to the current user.
        /// </summary>
        /// <value>
        /// Whether the message belongs to the current user.
        /// </value>
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

        /// <summary>
        /// The "MessageType" property represents the type of the message.
        /// It gets or sets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
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

        #endregion

        #region Override Methods

        /// <summary>
        /// The "OnPaint" method overrides the base class method to customize the appearance of the control.
        /// </summary>
        /// <param name="pevent">A PaintEventArgs that contains information about the control to paint.</param>
        /// <remarks>
        /// This method sets the SmoothingMode of the graphics object to AntiAlias for smoother drawing.
        /// It defines two rectangles representing the surface and border of the control.
        /// It uses the GraphicsHandler.GetFigurePath method to create GraphicsPaths for the surface and border.
        /// It then draws the surface and border using different colors depending on the parent control's BackColor.
        /// </remarks>
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

        #endregion

        #region Private Methods

        /// <summary>
        /// The "HandleMessageTypeChange" method adjusts the visibility and size of message components based on the message type.
        /// </summary>
        /// <remarks>
        /// This method hides the MessageLabel and ImagePictureBox.
        /// It then uses a switch statement on the messageType enum to determine which components to show and set the control's AutoSize property.
        /// - If the messageType is MessageType_Enum.Text, it shows the MessageLabel and sets AutoSize to true.
        /// - If the messageType is MessageType_Enum.Image, it shows the ImagePictureBox and sets AutoSize to false.
        /// - If the messageType is MessageType_Enum.DeletedMessage, it hides the MenuBarPictureBox, sets the MessageLabel text to DeletedMessage, shows the MessageLabel, and sets AutoSize to true.
        /// Finally, it calls the HandleMessageControlDesign method to handle the design of the message control.
        /// </remarks>
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

        /// <summary>
        /// The "HandleMessageControlDesign" method adjusts the design of the message control based on the message type.
        /// </summary>
        /// <remarks>
        /// This method uses a switch statement on the messageType enum to determine which design method to call.
        /// - If the messageType is MessageType_Enum.Text, it calls HandleMessageControlTextDesign.
        /// - If the messageType is MessageType_Enum.DeletedMessage, it calls HandleMessageControlDeletedMessageDesign.
        /// - If the messageType is MessageType_Enum.Image, it calls HandleMessageControlImageDesign.
        /// </remarks>
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

        /// <summary>
        /// The "SetMenuBarLocation" method sets the location of the MenuBarPictureBox within the message control.
        /// </summary>
        /// <remarks>
        /// This method calculates the Y-coordinate to vertically center the MenuBarPictureBox within the message control.
        /// It also calculates the X-coordinate to align the MenuBarPictureBox to the right side with a margin of 10 pixels.
        /// The MenuBarPictureBox's Location property is then set using these coordinates.
        /// </remarks>
        private void SetMenuBarLocation()
        {
            int MenuBarPictureBoxYCoordination = (this.Height - MenuBarPictureBox.Height) / 2;
            int MenuBarPictureBoxXCoordination = this.Width - MenuBarPictureBox.Width - 10;
            MenuBarPictureBox.Location = new System.Drawing.Point(MenuBarPictureBoxXCoordination, MenuBarPictureBoxYCoordination);
        }

        /// <summary>
        /// The "HandleMessageControlTextDesign" method adjusts the design of the message control for text messages.
        /// </summary>
        /// <remarks>
        /// This method calculates the new width of the message control based on the width of the MessageLabel and adds a margin.
        /// If the calculated width is greater than TextMessageNormalWidth, it uses the calculated width; otherwise, it uses TextMessageNormalWidth.
        /// The method then sets the width of the message control to the calculated width.
        /// It also adjusts the position of the TimeLabel to be aligned to the right side of the message control.
        /// Finally, it sets the height of the message control to accommodate the TimeLabel and updates the size of the message control.
        /// This method also calls SetMenuBarLocation to set the location of the MenuBarPictureBox.
        /// </remarks>
        private void HandleMessageControlTextDesign()
        {
            int NewWidth = MessageLabel.Location.X + MessageLabel.Width + RectangleWidth + 10;
            int realWidth = NewWidth > TextMessageNormalWidth ? NewWidth : TextMessageNormalWidth;
            this.Width = realWidth;
            int TimeLabelYCoordination = MessageLabel.Height + MessageLabel.Location.Y + 5;
            int TimeLabelXCoordination = realWidth - TimeLabel.Width - 25;
            TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination);
            this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            SetMenuBarLocation();
        }

        /// <summary>
        /// The "HandleMessageControlDeletedMessageDesign" method adjusts the design of the message control for deleted messages.
        /// </summary>
        /// <remarks>
        /// This method resizes the ImagePictureBox to fit its content.
        /// It calculates the new width of the message control based on the width of the MessageLabel and adds a margin.
        /// If the calculated width is greater than TextMessageNormalWidth, it uses the calculated width; otherwise, it uses TextMessageNormalWidth.
        /// The method then sets the width of the message control to the calculated width.
        /// It also adjusts the position of the TimeLabel to be aligned to the right side of the message control, next to the MessageLabel.
        /// Finally, it sets the height of the message control to accommodate the TimeLabel and updates the size of the message control.
        /// This method also calls SetMenuBarLocation to set the location of the MenuBarPictureBox.
        /// </remarks>
        private void HandleMessageControlDeletedMessageDesign()
        {
            FitPictureBoxToImage(ImagePictureBox);
            int NewWidth = MessageLabel.Location.X + MessageLabel.Width + 10;
            int realWidth = NewWidth > TextMessageNormalWidth ? NewWidth : TextMessageNormalWidth;
            this.Width = realWidth;
            int TimeLabelYCoordination = MessageLabel.Height + MessageLabel.Location.Y + 5;
            int TimeLabelXCoordination = MessageLabel.Width + MessageLabel.Location.X - TimeLabel.Width + 5;
            TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination);
            this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            SetMenuBarLocation();
        }

        /// <summary>
        /// The "HandleMessageControlImageDesign" method adjusts the design of the message control for image messages.
        /// </summary>
        /// <remarks>
        /// This method calculates the new width of the message control based on the width of the ImagePictureBox and adds a margin.
        /// It then sets the width of the message control to the calculated width.
        /// It also adjusts the position of the TimeLabel to be aligned to the right side of the message control, next to the ImagePictureBox.
        /// Finally, it sets the height of the message control to accommodate the TimeLabel and updates the size of the message control.
        /// It also sets the location of the MenuBarPictureBox within the message control.
        /// </remarks>
        private void HandleMessageControlImageDesign()
        {
            int NewWidth = ImagePictureBox.Location.X + ImagePictureBox.Width + RectangleWidth + 10;
            this.Width = NewWidth;
            int TimeLabelYCoordination = ImagePictureBox.Height + ImagePictureBox.Location.Y + 5;
            int TimeLabelXCoordination = ImagePictureBox.Width + ImagePictureBox.Location.X - TimeLabel.Width + 5;
            TimeLabel.Location = new System.Drawing.Point(TimeLabelXCoordination, TimeLabelYCoordination);
            this.Height = TimeLabel.Height + TimeLabel.Location.Y + 10;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            int MenuBarPictureBoxYCoordination = (this.Height - MenuBarPictureBox.Height) / 2;
            int MenuBarPictureBoxXCoordination = this.Width - MenuBarPictureBox.Width - 10;
            MenuBarPictureBox.Location = new System.Drawing.Point(MenuBarPictureBoxXCoordination, MenuBarPictureBoxYCoordination);
        }

        /// <summary>
        /// The "FitPictureBoxToImage" method resizes a PictureBox to fit its image while maintaining the aspect ratio.
        /// </summary>
        /// <param name="pictureBox">The PictureBox to resize.</param>
        /// <remarks>
        /// This method calculates the zoom factor required to fit the image inside the PictureBox.
        /// It then calculates the new width and height of the PictureBox based on the zoom factor and sets the PictureBox's size accordingly.
        /// </remarks>
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

        /// <summary>
        /// The "SetMenuAreaRectangle" method sets the rectangle representing the menu area in the control.
        /// </summary>
        /// <remarks>
        /// This method calculates the height of the rectangle based on the control's height.
        /// It sets the X coordinate of the rectangle to be at the right edge of the normal width of the control.
        /// It sets the Y coordinate of the rectangle to be at the top of the control.
        /// The width of the rectangle is set to the predefined RectangleWidth value.
        /// </remarks>
        private void SetMenuAreaRectangle()
        {
            int RectangleHeight = ControlHeight;
            int RectangleXCoordinate = NoramlWidth - RectangleWidth;
            int RectangleYCoordinate = 0;
            MenuAreaRectangle = new Rectangle(RectangleXCoordinate, RectangleYCoordinate, RectangleWidth, RectangleHeight);
        }

        /// <summary>
        /// The "SetMenuItemsAreaRectangle" method sets the rectangle representing the menu items area in the control.
        /// </summary>
        /// <remarks>
        /// This method calculates the width of the rectangle to be the difference between the extended width and the normal width of the control, plus the RectangleWidth value.
        /// It calculates the height of the rectangle based on the control's height.
        /// It sets the X coordinate of the rectangle to be at the right edge of the normal width of the control.
        /// It sets the Y coordinate of the rectangle to be at the top of the control.
        /// </remarks>
        private void SetMenuItemsAreaRectangle()
        {
            int MenuItemsAreaRectangleWidth = ExtendedWidth - NoramlWidth + RectangleWidth;
            int MenuItemsAreaRectangleHeight = ControlHeight;
            int MenuItemsAreaRectangleXCoordinate = NoramlWidth - RectangleWidth;
            int MenuItemsAreaRectangleYCoordinate = 0;
            MenuItemsAreaRectangle = new Rectangle(MenuItemsAreaRectangleXCoordinate, MenuItemsAreaRectangleYCoordinate, MenuItemsAreaRectangleWidth, MenuItemsAreaRectangleHeight);
        }

        /// <summary>
        /// The "InitializeMenu" method initializes the menu buttons for the message control.
        /// </summary>
        /// <remarks>
        /// This method determines the number of buttons based on whether the message is yours or not.
        /// It creates button instances, sets their properties, and adds event handlers.
        /// The buttons are positioned next to each other with a specified margin.
        /// </remarks>
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

        /// <summary>
        /// The "MenuButtons_Click" method handles the click event of the menu buttons.
        /// </summary>
        /// <param name="sender">The button that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method determines the action based on the clicked button's name.
        /// If the "DeleteOptionButton" is clicked, it prompts the user to confirm message deletion.
        /// If the "CopyOptionButton" is clicked, it copies the message content to the clipboard.
        /// </remarks>
        private void MenuButtons_Click(object sender, EventArgs e)
        {
            string ButtonName = ((Button)(sender)).Name;
            if (ButtonName == "DeleteOptionButton")
            {
                if (MessageBox.Show("Are you sure you want to delete this message?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // maybe to show a little bit of the message
                {
                    MessageDelete?.Invoke(this, e);
                    CloseMenuItems();
                    HandleDelete();
                    AfterMessageDelete?.Invoke(this, e);
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

        /// <summary>
        /// The "MessageControl_MouseDown" method handles the mouse down event for the message control.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        /// <remarks>
        /// This method checks if the mouse press is on the right edge rectangle of the control.
        /// If so, it expands the control to show the menu items and hides the menu bar.
        /// It adds the menu buttons to the control's controls collection.
        /// </remarks>
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

        /// <summary>
        /// The "ControlsMouseDown" method adds a mouse down event handler to all controls within the message control.
        /// </summary>
        /// <remarks>
        /// This method iterates through all controls within the message control and attaches a mouse down event handler to each control.
        /// The event handler is used to handle mouse down events for expanding the menu items.
        /// </remarks>
        private void ControlsMouseDown()
        {
            foreach (Control Control in this.Controls)
                Control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseDown);
        }

        /// <summary>
        /// The "PressIsOnRightEdgeRectangle" method checks if the mouse press is on the right edge rectangle of the message control.
        /// </summary>
        /// <param name="CursorLocation">The location of the mouse cursor.</param>
        /// <returns>True if the mouse press is on the right edge rectangle, otherwise false.</returns>
        /// <remarks>
        /// This method is used to determine if the mouse press is within the area where the menu items should be expanded.
        /// </remarks>
        private bool PressIsOnRightEdgeRectangle(Point CursorLocation)
        {
            return MenuAreaRectangle.Contains(CursorLocation);
        }

        /// <summary>
        /// The "MessageControl_MouseMove" method handles the mouse move event for the message control.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        /// <remarks>
        /// This method checks if the mouse cursor is outside the menu items area rectangle and not on a menu item.
        /// If so, it closes the menu items.
        /// </remarks>
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

        /// <summary>
        /// The "IsMouseCursorOverMenuItemsRectangle" method checks if the mouse cursor is over the menu items area rectangle.
        /// </summary>
        /// <param name="cursorLocation">The location of the mouse cursor.</param>
        /// <returns>True if the mouse cursor is over the menu items area rectangle, otherwise false.</returns>
        /// <remarks>
        /// This method is used to determine if the mouse cursor is over the area where the menu items are displayed.
        /// </remarks>
        private bool IsMouseCursorOverMenuItemsRectangle(Point cursorLocation)
        {
            return MenuItemsAreaRectangle.Contains(cursorLocation);
        }

        /// <summary>
        /// The "ControlsMouseMove" method adds a mouse move event handler to all controls within the message control.
        /// </summary>
        /// <remarks>
        /// This method iterates through all controls within the message control and attaches a mouse move event handler to each control.
        /// The event handler is used to handle mouse move events for closing the menu items when the mouse cursor moves out of the menu items area.
        /// </remarks>
        private void ControlsMouseMove()
        {
            foreach (Control Control in this.Controls)
                Control.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);
        }

        /// <summary>
        /// The "MessageControl_MouseLeave" method handles the mouse leave event for the message control.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the mouse cursor has left the message control's client rectangle.
        /// If the menu items are visible, it closes them.
        /// </remarks>
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

        /// <summary>
        /// The "CloseMenuItems" method closes the menu items and restores the message control to its normal width.
        /// </summary>
        /// <remarks>
        /// This method is called to close the menu items and restore the message control to its normal width.
        /// It makes the menu bar picture box visible again and removes the menu buttons from the controls collection.
        /// </remarks>
        private void CloseMenuItems()
        {
            this.Width = NoramlWidth;
            MenuBarPictureBox.Visible = true;
            RemoveMenuButtonsFromControls();
        }

        /// <summary>
        /// The "RemoveMenuButtonsFromControls" method removes the menu buttons from the controls collection.
        /// </summary>
        /// <remarks>
        /// This method is called to remove the menu buttons from the controls collection when closing the menu items.
        /// It also unsubscribes the mouse move event handler from each menu button to prevent further processing.
        /// </remarks>
        private void RemoveMenuButtonsFromControls()
        {
            MenuItemsIsVisible = false;
            foreach (Button MenuButton in MenuButtons)
            {
                this.Controls.Remove(MenuButton);
                MenuButton.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.MessageControl_MouseMove);
            }
        }

        /// <summary>
        /// The "ImagePictureBox_Click" method handles the click event for the image picture box.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method creates a new instance of the ImageViewer form with the background image of the image picture box,
        /// and then displays the form.
        /// </remarks>
        private void ImagePictureBox_Click(object sender, EventArgs e)
        {
            FormHandler._imageViewer = new ImageViewer(new Bitmap(ImagePictureBox.BackgroundImage));
            this.Invoke(new Action(() => FormHandler._imageViewer.Show()));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "SetMessageControl" method sets the initial design and dimensions of the message control.
        /// </summary>
        /// <remarks>
        /// This method sets the initial design and dimensions of the message control based on its message type.
        /// It also initializes the menu for non-deleted messages and sets the menu area rectangles.
        /// </remarks>
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

        /// <summary>
        /// The "AddMessageDeleteHandler" method adds an event handler for the message delete event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        public void AddMessageDeleteHandler(EventHandler handler)
        {
            MessageDelete += handler;
        }

        /// <summary>
        /// The "AddAfterMessageDeleteHandler" method adds an event handler for the after message delete event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        public void AddAfterMessageDeleteHandler(EventHandler handler)
        {
            AfterMessageDelete += handler;
        }

        /// <summary>
        /// The "HandleDelete" method handles the deletion of a message.
        /// </summary>
        /// <remarks>
        /// This method is called to handle the deletion of a message.
        /// It sets the message label to display the deleted message text,
        /// hides the image picture box, sets a flag indicating that the message was deleted,
        /// and updates the message type to DeletedMessage to trigger the appropriate design changes.
        /// </remarks>
        public void HandleDelete()
        {
            MessageLabel.Visible = true;
            ImagePictureBox.Visible = false;
            WasDeleted = true;
            messageType = EnumHandler.MessageType_Enum.DeletedMessage;
            HandleMessageTypeChange();
        }

        /// <summary>
        /// The "SetBackColorByMessageSender" method sets the background color of the message control for the message sender.
        /// </summary>
        /// <remarks>
        /// This method sets the background color of the message control to PaleTurquoise for the message sender.
        /// It also sets the background color, flat style, and border color of menu buttons if the message is not a deleted message.
        /// </remarks>
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

        /// <summary>
        /// The "SetBackColorByOtherSender" method sets the background color of the message control for other senders.
        /// </summary>
        /// <remarks>
        /// This method sets the background color of the message control to LightGray for other senders.
        /// It also sets the background color, flat style, and border color of menu buttons if the message is not a deleted message.
        /// </remarks>
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

        #endregion
    }
}
