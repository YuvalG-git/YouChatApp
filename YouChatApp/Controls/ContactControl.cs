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
    /// The "ContactControl" class represents a custom UserControl for displaying contact information.
    /// </summary>
    /// <remarks>
    /// This control includes a profile picture, contact name, and contact status. It allows customization of
    /// background color, border color, and behavior on mouse hover and click events.
    /// </remarks>
    public partial class ContactControl : UserControl
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
        /// The bool "_wasSelected" indicates whether the control was selected.
        /// </summary>
        private bool _wasSelected = false;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ContactControl" constructor initializes a new instance of the <see cref="ContactControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the ContactControl by initializing its components.
        /// It also adds event handlers for the Click, MouseEnter, and MouseLeave events for its child controls.
        /// </remarks>
        public ContactControl()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Click += new System.EventHandler(this.OnControlClick);
                control.MouseEnter += new System.EventHandler(this.ContactControl_MouseEnter);
                control.MouseLeave += new System.EventHandler(this.ContactControl_MouseLeave);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "ProfilePicture" property represents the circular picture box used for displaying the profile picture.
        /// It gets the circular picture box used for displaying the profile picture.
        /// </summary>
        /// <value>
        /// The circular picture box used for displaying the profile picture.
        /// </value>
        public CircularPictureBox ProfilePicture
        {
            get
            {
                return ProfilePictureCircularPictureBox;
            }
        }

        /// <summary>
        /// The "ContactName" property represents the label used for displaying the contact's name.
        /// It gets the label used for displaying the contact's name.
        /// </summary>
        /// <value>
        /// The label used for displaying the contact's name.
        /// </value>
        public System.Windows.Forms.Label ContactName
        {
            get
            {
                return ContactNameLabel;
            }
        }

        /// <summary>
        /// The "ContactStatus" property represents the label used for displaying the contact's status.
        /// It gets the label used for displaying the contact's status.
        /// </summary>
        /// <value>
        /// The label used for displaying the contact's status.
        /// </value>
        public System.Windows.Forms.Label ContactStatus
        {
            get
            {
                return ContactStatusLabel;
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
        /// The "WasSelected" property represents whether the control was selected.
        /// It gets or sets whether the control was selected.
        /// </summary>
        /// <value>
        /// Whether the control was selected.
        /// </value>
        public bool WasSelected
        {
            get 
            { 
                return _wasSelected;
            }
            set
            {
                _wasSelected = value;
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// The "OnPaint" method is called when the control needs to be repainted. It draws a border at the bottom of the control.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method is called when the control needs to be repainted, typically as a result of a visual change or when first displayed.
        /// It draws a border at the bottom of the control using the specified _onFocusBackgroundColor.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(_onFocusBackgroundColor, 1))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawLine(BorderPen, this.ContactNameLabel.Location.X, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "OnControlClick" method forwards the Click event to the control's parent.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is used to forward the Click event to the parent control, allowing the parent to handle the event.
        /// </remarks>
        private void OnControlClick(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        /// <summary>
        /// The "ContactControl_MouseEnter" event handler method is called when the mouse enters the contact control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse enters the contact control, changing its back color to _onFocusBackgroundColor.
        /// </remarks>
        private void ContactControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = _onFocusBackgroundColor;
        }

        /// <summary>
        /// The "ContactControl_MouseLeave" event handler method is called when the mouse leaves the contact control.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse leaves the contact control, changing its back color to _backgroundColor.
        /// </remarks>
        private void ContactControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _backgroundColor;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "SetToolTip" method sets tooltips for the contact name and status label.
        /// </summary>
        /// <remarks>
        /// This method is used to set tooltips for the ContactNameLabel and ContactStatusLabel, displaying their respective texts as tooltips.
        /// </remarks>
        public void SetToolTip()
        {
            ToolTip.SetToolTip(ContactNameLabel, ContactNameLabel.Text);
            ToolTip.SetToolTip(ContactStatusLabel, ContactStatusLabel.Text);
        }

        #endregion
    }
}
