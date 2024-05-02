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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "ProfileControl" class represents a user control for managing profile information and interactions.
    /// </summary>
    /// <remarks>
    /// This control provides functionality for displaying a profile picture, username, and a close button.
    /// It includes methods for setting the profile picture, username, and tooltip for the control.
    /// The control also provides an event ("CloseControl") that is raised when the control is being closed.
    /// </remarks>
    public partial class ProfileControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "CloseControl" event is raised when the control is being closed.
        /// </summary>
        public event EventHandler CloseControl;

        #endregion

        #region Private Fields

        /// <summary>
        /// The bool "_isCloseVisible" indicates whether the close button is visible.
        /// </summary>
        private bool _isCloseVisible = false;

        #endregion

        #region Private Readonly  Fields

        /// <summary>
        /// The readonly Image "_redColoredX" represents the red-colored close button image.
        /// </summary>
        private readonly Image _redColoredX = global::YouChatApp.Properties.Resources.CloseRedColor;

        /// <summary>
        /// The readonly Image "_blackColoredX" represents the black-colored close button image.
        /// </summary>
        private readonly Image _blackColoredX = global::YouChatApp.Properties.Resources.CloseBlackColor;


        #endregion

        #region Constructors

        /// <summary>
        /// The "ProfileControl" constructor initializes a new instance of the <see cref="ProfileControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the ProfileControl by initializing its components.
        /// </remarks>
        public ProfileControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "IsCloseVisible" property represents whether the close button is visible.
        /// It gets the value indicating whether the close button is visible or sets it to a new value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the close button is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsCloseVisible
        {
            get 
            { 
                return _isCloseVisible;
            }
            set 
            { 
                _isCloseVisible = value;
                RemoveCustomButton.Visible = _isCloseVisible;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "RemoveCustomButton_MouseEnter" method handles the mouse enter event for the remove custom button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse enters the area of the remove custom button.
        /// It changes the background color of the button to transparent and updates the background image to a red-colored 'X' image (_redColoredX).
        /// This visual change provides feedback to the user that the button is interactive and can be clicked for removal.
        /// </remarks>
        private void RemoveCustomButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveCustomButton.BackColor = Color.Transparent;
            RemoveCustomButton.BackgroundImage = _redColoredX;
        }

        /// <summary>
        /// The "RemoveCustomButton_MouseLeave" method handles the mouse leave event for the remove custom button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse leaves the area of the remove custom button.
        /// It changes the background color of the button to transparent and updates the background image to a black-colored 'X' image (_blackColoredX).
        /// This reverts the visual change made in the MouseEnter event, indicating to the user that the button is no longer actively focused.
        /// </remarks>
        private void RemoveCustomButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveCustomButton.BackColor = Color.Transparent;
            RemoveCustomButton.BackgroundImage = _blackColoredX;
        }

        /// <summary>
        /// The "RemoveCustomButton_Click" method handles the click event for the remove custom button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the remove custom button is clicked.
        /// It invokes the CloseControl event, which is used to notify external code that this control should be closed or removed from the form.
        /// By invoking this event, the control signals to its parent or containing form that it should be removed from the user interface.
        /// </remarks>
        private void RemoveCustomButton_Click(object sender, EventArgs e)
        {
            CloseControl?.Invoke(this, e);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "OnClickHandler" method adds an event handler to the CloseControl event.
        /// </summary>
        /// <param name="handler">The event handler to add to the CloseControl event.</param>
        /// <remarks>
        /// This method allows external code to subscribe to the CloseControl event, which is raised when the control should be closed or removed from the form.
        /// By adding an event handler to this event, external code can respond to the control's request to be closed or removed.
        /// </remarks>
        public void OnClickHandler(EventHandler handler)
        {
            CloseControl += handler;
        }

        /// <summary>
        /// The "SetToolTip" method sets a tooltip for the UsernameLabel control.
        /// </summary>
        /// <remarks>
        /// This method uses the ToolTipSetter class to set a tooltip for the UsernameLabel control.
        /// The tooltip provides additional information or context about the control when the user hovers over it with the mouse.
        /// </remarks>
        public void SetToolTip()
        {
            ToolTipSetter.SetToolTipBySpaceOver(UsernameLabel, ToolTip);
        }

        /// <summary>
        /// The "SetProfilePicture" method sets the profile picture for the circular picture box.
        /// </summary>
        /// <param name="image">The image to set as the profile picture.</param>
        /// <remarks>
        /// This method sets the background image of the ProfilePictureCircularPictureBox control to the specified image.
        /// The circular picture box is typically used to display a profile picture or avatar image for the user.
        /// </remarks>
        public void SetProfilePicture(Image image)
        {
            ProfilePictureCircularPictureBox.BackgroundImage = image;
        }

        /// <summary>
        /// The "SetUserName" method sets the username displayed on the UsernameLabel control.
        /// </summary>
        /// <param name="name">The username to display.</param>
        /// <remarks>
        /// This method sets the text of the UsernameLabel control to the specified username.
        /// The UsernameLabel control is typically used to display the username or name of the user associated with the profile picture.
        /// </remarks>
        public void SetUserName(string name)
        {
            UsernameLabel.Text = name;
        }

        #endregion
    }
}
