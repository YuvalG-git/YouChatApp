using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Controls;

namespace YouChatApp
{
    /// <summary>
    /// The "ChatControl" class represents a custom UserControl for displaying chat information.
    /// </summary>
    /// <remarks>
    /// This control includes a profile picture, chat name, last message content, and last message time. 
    /// It allows customization of background color, border color, and behavior on mouse hover and click events.
    /// </remarks>
    public partial class ChatControl : UserControl
    {
        #region Private Fields

        /// <summary>
        /// The Color "_backgroundColor" represents the background color.
        /// </summary>
        private Color _backgroundColor = Color.Transparent;

        /// <summary>
        /// The Color "_onFocusBackgroundColor" represents the background color when focused.
        /// </summary>
        private Color _onFocusBackgroundColor = Color.CornflowerBlue;

        /// <summary>
        /// The Color "_borderColor" represents the border color.
        /// </summary>
        private Color _borderColor = Color.CornflowerBlue;

        /// <summary>
        /// The string "_chatId" represents the ID of the chat.
        /// </summary>
        private string _chatId;

        /// <summary>
        /// The bool "firstClick" indicates whether it is the first click.
        /// </summary>
        private bool firstClick = true;

        /// <summary>
        /// The DateTime "_lastMessageTime" represents the time of the last message.
        /// </summary>
        private DateTime? _lastMessageTime;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ChatControl" constructor initializes a new instance of the <see cref="ChatControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the ChatControl by initializing its components.
        /// It also adds event handlers for the Click, MouseEnter, and MouseLeave events for its child controls.
        /// </remarks>
        public ChatControl()
        {
            InitializeComponent();
            foreach(Control control in this.Controls)
            {
                control.Click += new System.EventHandler(this.OnControlClick);
                control.MouseEnter += new System.EventHandler(this.ChatControl_MouseEnter);
                control.MouseLeave += new System.EventHandler(this.ChatControl_MouseLeave);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "LastMessageDateTime" property represents the date and time of the last message in the chat.
        /// It gets or sets the date and time of the last message.
        /// </summary>
        /// <value>
        /// The date and time of the last message in the chat.
        /// </value>
        public DateTime? LastMessageDateTime
        {
            get 
            { 
                return _lastMessageTime;
            }
            set
            {
                _lastMessageTime = value;
            }
        }

        /// <summary>
        /// The "ChatId" property represents the unique identifier of the chat.
        /// It gets or sets the chat's unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier of the chat.
        /// </value>
        public string ChatId
        {
            get 
            { 
                return _chatId;
            }
            set
            {
                _chatId = value;
            }
        }

        /// <summary>
        /// The "BorderColor" property represents the color of the control's border.
        /// It gets or sets the color of the control's border.
        /// </summary>
        /// <value>
        /// The color of the control's border.
        /// </value>
        public Color BorderColor
        {
            get 
            { 
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BackgroundColor" property represents the background color of the control.
        /// It gets or sets the background color of the control.
        /// </summary>
        /// <value>
        /// The background color of the control.
        /// </value>
        public Color BackgroundColor
        {
            get 
            { 
                return _backgroundColor; 
            }
            set
            {
                _backgroundColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "OnFocusBackgroundColor" property represents the background color of the control when it is focused.
        /// It gets or sets the background color of the control when it is focused.
        /// </summary>
        /// <value>
        /// The background color of the control when it is focused.
        /// </value>
        public Color OnFocusBackgroundColor
        {
            get 
            { 
                return _onFocusBackgroundColor;
            }
            set
            {
                _onFocusBackgroundColor = value;
            }
        }

        /// <summary>
        /// The "ProfilePicture" property represents the profile picture of the chat.
        /// It gets the profile picture of the chat.
        /// </summary>
        /// <value>
        /// The profile picture of the chat.
        /// </value>
        public CircularPictureBox ProfilePicture
        {
            get
            {
                return ProfilePicturePictureBox;
            }
        }

        /// <summary>
        /// The "ChatName" property represents the name of the chat.
        /// It gets the name of the chat.
        /// </summary>
        /// <value>
        /// The name of the chat.
        /// </value>
        public System.Windows.Forms.Label ChatName
        {
            get
            {
                return ChatNameLabel;
            }
        }

        /// <summary>
        /// The "LastMessageContent" property represents the content of the last message in the chat.
        /// It gets the content of the last message in the chat.
        /// </summary>
        /// <value>
        /// The content of the last message in the chat.
        /// </value>
        public System.Windows.Forms.Label LastMessageContent
        {
            get
            {
                return LastMessageLabel;
            }
        }

        /// <summary>
        /// The "LastMessageTime" property represents the time when the last message was sent in the chat.
        /// It gets the time when the last message was sent in the chat.
        /// </summary>
        /// <value>
        /// The time when the last message was sent in the chat.
        /// </value>
        public System.Windows.Forms.Label LastMessageTime
        {
            get
            {
                return TimeLabel;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// The "OnPaint" method handles the painting of the control.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control needs to be painted. It sets the region of the control to its client rectangle and draws a line at the bottom using the specified color.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(_onFocusBackgroundColor, 1))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawLine(BorderPen, this.ChatNameLabel.Location.X, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "ChatControl_MouseEnter" event handler method is called when the mouse enters the chat control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse enters the chat control, changing its background color to the specified "on focus" background color.
        /// </remarks>
        private void ChatControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = _onFocusBackgroundColor;
        }

        /// <summary>
        /// The "ChatControl_MouseLeave" event handler method is called when the mouse leaves the chat control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse leaves the chat control, changing its background color back to the default background color.
        /// </remarks>
        private void ChatControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _backgroundColor;
        }

        /// <summary>
        /// The "OnControlClick" event handler method is called when the chat control is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the chat control is clicked, triggering the Click event. If it is the first click, it sets the "firstClick" flag to false.
        /// </remarks>
        private void OnControlClick(object sender, EventArgs e)
        {
            this.OnClick(e);
            if (firstClick)
                firstClick = false;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "SetLastMessageTimeLocation" method sets the location of the TimeLabel within the ChatControl.
        /// </summary>
        /// <remarks>
        /// This method is used to set the location of the TimeLabel within the ChatControl.
        /// It ensures that the TimeLabel is aligned to the right edge of the control, with a small margin.
        /// </remarks>
        public void SetLastMessageTimeLocation()
        {
            this.TimeLabel.Location = new System.Drawing.Point(this.Width - TimeLabel.Size.Width - 5, TimeLabel.Location.Y);
        }

        /// <summary>
        /// The "SetToolTip" method sets the tooltip text for the ChatNameLabel and LastMessageLabel.
        /// </summary>
        /// <remarks>
        /// This method sets the tooltip text for the ChatNameLabel and LastMessageLabel to the specified tooltip string.
        /// </remarks>
        public void SetToolTip()
        {
            ToolTipSetter.SetToolTip(ChatNameLabel, ToolTip);
            ToolTipSetter.SetToolTip(LastMessageLabel, ToolTip);
        }

        /// <summary>
        /// The "GetFirstClick" method returns the value of the firstClick flag.
        /// </summary>
        /// <returns>A boolean value indicating whether it is the first click on the ChatControl.</returns>
        /// <remarks>
        /// This method returns the value of the firstClick flag, which is used to track if it is the first click on the ChatControl.
        /// </remarks>
        public bool GetFirstClick()
        {
            return firstClick;
        }

        #endregion
    }
}
