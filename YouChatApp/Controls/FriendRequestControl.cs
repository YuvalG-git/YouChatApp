using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "FriendRequestControl" class represents a user control for managing friend requests.
    /// </summary>
    /// <remarks>
    /// This control includes events for handling friend request approval and refusal.
    /// It also provides properties for setting the background color, border color, and profile picture.
    /// The control can be customized to display the contact's name and the time of the friend request.
    /// </remarks>
    public partial class FriendRequestControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "OnFriendRequestApproval" event is raised when a friend request is approved.
        /// </summary>
        public event EventHandler OnFriendRequestApproval;

        /// <summary>
        /// The EventHandler "OnFriendRequestRefusal" event is raised when a friend request is refused.
        /// </summary>
        public event EventHandler OnFriendRequestRefusal;

        #endregion

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

        #endregion

        #region Constructors

        /// <summary>
        /// The "FriendRequestControl" constructor initializes a new instance of the <see cref="FriendRequestControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the FriendRequestControl by initializing its components
        /// and adding event handlers for mouse enter and leave events to its child controls.
        /// </remarks>
        public FriendRequestControl()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.MouseEnter += new System.EventHandler(this.FriendRequestControl_MouseEnter);
                control.MouseLeave += new System.EventHandler(this.FriendRequestControl_MouseLeave);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "BorderColor" property represents the border color of a control.
        /// It gets or sets the border color of the control.
        /// </summary>
        /// <value>
        /// The border color of the control.
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
        /// The "BackgroundColor" property represents the background color of a control.
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
        /// The "OnFocusBackgroundColor" property represents the background color of a control when it is focused.
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
        /// The "ProfilePicture" property represents the profile picture of a contact.
        /// It gets the circular picture box control used for displaying the profile picture.
        /// </summary>
        /// <value>
        /// The circular picture box control used for displaying the profile picture.
        /// </value>
        public CircularPictureBox ProfilePicture
        {
            get
            {
                return ProfilePictureCircularPictureBox;
            }
        }

        /// <summary>
        /// The "ContactName" property represents the name of a contact.
        /// It gets the label control used for displaying the contact's name.
        /// </summary>
        /// <value>
        /// The label control used for displaying the contact's name.
        /// </value>
        public System.Windows.Forms.Label ContactName
        {
            get
            {
                return ChatNameLabel;
            }
        }

        /// <summary>
        /// The "FriendRequestTime" property represents the time of a friend request.
        /// It gets the label control used for displaying the time of the friend request.
        /// </summary>
        /// <value>
        /// The label control used for displaying the time of the friend request.
        /// </value>
        public System.Windows.Forms.Label FriendRequestTime
        {
            get
            {
                return TimeLabel;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Overrides the default OnPaint method to customize the appearance of the control.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control is redrawn. It customizes the appearance of the control by drawing a border at the bottom of the control.
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
        /// The "AddFriendCustomButton_Click" method invokes the OnFriendRequestApproval event.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the AddFriendCustomButton is clicked. It triggers the OnFriendRequestApproval event,
        /// which can be used to handle friend request approvals.
        /// </remarks>
        private void AddFriendCustomButton_Click(object sender, EventArgs e)
        {
            OnFriendRequestApproval?.Invoke(this, e);
        }

        /// <summary>
        /// The "DenyFriendRequestCustomButton_Click" method invokes the OnFriendRequestRefusal event.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the DenyFriendRequestCustomButton is clicked. It triggers the OnFriendRequestRefusal event,
        /// which can be used to handle friend request refusals.
        /// </remarks>
        private void DenyFriendRequestCustomButton_Click(object sender, EventArgs e)
        {
            OnFriendRequestRefusal?.Invoke(this, e);
        }

        /// <summary>
        /// The "FriendRequestControl_MouseEnter" method changes the background color of the control when the mouse enters it.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse enters the FriendRequestControl. It changes the background color of the control
        /// to the specified onFocusBackgroundColor, providing visual feedback to the user.
        /// </remarks>
        private void FriendRequestControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundColor = _onFocusBackgroundColor;
        }

        /// <summary>
        /// The "FriendRequestControl_MouseLeave" method changes the background color of the control when the mouse leaves it.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse leaves the FriendRequestControl. It changes the background color of the control
        /// back to the default background color, providing visual feedback to the user.
        /// </remarks>
        private void FriendRequestControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundColor = _backgroundColor;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "OnFriendRequestApprovalHandler" method adds an event handler to the OnFriendRequestApproval event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method subscribes to the OnFriendRequestApproval event, which is triggered when the user approves a friend request.
        /// It allows external code to respond to the friend request approval event.
        /// </remarks>
        public void OnFriendRequestApprovalHandler(EventHandler handler)
        {
            OnFriendRequestApproval += handler;
        }

        /// <summary>
        /// The "OnFriendRequestRefusalHandler" method adds an event handler to the OnFriendRequestRefusal event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method subscribes to the OnFriendRequestRefusal event, which is triggered when the user refuses a friend request.
        /// It allows external code to respond to the friend request refusal event.
        /// </remarks>
        public void OnFriendRequestRefusalHandler(EventHandler handler)
        {
            OnFriendRequestRefusal += handler;
        }

        /// <summary>
        /// The "SetFriendRequestTimeLocation" method adjusts the location of the TimeLabel within the FriendRequestControl.
        /// </summary>
        /// <remarks>
        /// This method is used to set the location of the TimeLabel within the FriendRequestControl.
        /// It ensures that the TimeLabel is aligned to the right edge of the control, with a small margin.
        /// </remarks>
        public void SetFriendRequestTimeLocation()
        {
            this.TimeLabel.Location = new System.Drawing.Point(this.Width - TimeLabel.Size.Width - 5, TimeLabel.Location.Y);
        }

        /// <summary>
        /// The "SetToolTip" method sets the tooltip for the ChatNameLabel.
        /// </summary>
        /// <remarks>
        /// This method is used to set a tooltip for the ChatNameLabel, which provides additional information
        /// when the user hovers over the label with the mouse cursor.
        /// </remarks>
        public void SetToolTip()
        {
            ToolTipSetter.SetToolTip(ChatNameLabel, ToolTip);
        }

        #endregion
    }
}
