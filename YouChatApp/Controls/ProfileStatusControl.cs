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
    /// <summary>
    /// The "ProfileStatusControl" class represents a user control for managing profile status.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for setting and displaying the user's profile status.
    /// </remarks>
    public partial class ProfileStatusControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "SaveStatusCustomButtonClick" event is raised when the save status custom button is clicked.
        /// </summary>
        public event EventHandler SaveStatusCustomButtonClick;

        #endregion

        #region Private Fields

        /// <summary>
        /// The boolean variable "IsSelectedStatusShownProperty" indicates whether the selected status is shown.
        /// </summary>
        private bool IsSelectedStatusShownProperty = true;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ProfileStatusControl" constructor initializes a new instance of the <see cref="ProfileStatusControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the ProfileStatusControl class, initializing its components.
        /// </remarks>
        public ProfileStatusControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "IsSelectedStatusShown" property represents whether the selected status is shown.
        /// It gets the value indicating whether the selected status is shown or sets it to a new value.
        /// </summary>
        /// <value>
        /// true if the selected status is shown; otherwise, false.
        /// </value>
        /// <remarks>
        /// This property controls the visibility of the selected status in the user interface.
        /// When set to true, the selected status will be displayed; otherwise, it will be hidden.
        /// </remarks>
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

        #endregion

        #region Private Methods

        /// <summary>
        /// The "RefreshProfileStatusCustomTextBoxContent" method refreshes the content of the profile status custom text box.
        /// </summary>
        /// <remarks>
        /// This method clears the text content of the ProfileStatusCustomTextBox and updates the CharNumberLabel
        /// to display the current character count (0) and the maximum allowed characters.
        /// </remarks>
        private void RefreshProfileStatusCustomTextBoxContent()
        {
            ProfileStatusCustomTextBox.TextContent = "";
            CharNumberLabel.Text = "0/" + ProfileStatusCustomTextBox.MaxLength;
        }

        /// <summary>
        /// The "HandleSelectedStatusVisibility" method controls the visibility of the selected status panel.
        /// </summary>
        /// <remarks>
        /// This method checks the value of the IsSelectedStatusShown property.
        /// If true, it makes the StatusTextPanel visible and adjusts the position of the StatusMainPanel to accommodate the StatusTextPanel.
        /// If false, it hides the StatusTextPanel and adjusts the position of the StatusMainPanel accordingly.
        /// Finally, it adjusts the height of the form to fit the updated layout.
        /// </remarks>
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

        /// <summary>
        /// The "RefreshStatusCustomButton_Click" method handles the Click event of the RefreshStatusCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the RefreshStatusCustomButton is clicked.
        /// It triggers the RefreshProfileStatusCustomTextBoxContent method to update the content of the profile status custom text box.
        /// </remarks>
        private void RefreshStatusCustomButton_Click(object sender, EventArgs e)
        {
            RefreshProfileStatusCustomTextBoxContent();
        }

        /// <summary>
        /// The "ProfileStatusCustomTextBox_TextChangedEvent" method handles the TextChanged event of the ProfileStatusCustomTextBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the CharNumberLabel to display the current character count and the maximum allowed characters.
        /// It also enables or disables the SaveStatusCustomButton and RefreshStatusCustomButton based on whether the ProfileStatusCustomTextBox contains a value.
        /// </remarks>
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

        /// <summary>
        /// The "SaveStatusCustomButton_Click" method handles the Click event of the SaveStatusCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the ProfileStatusCustomTextBox contains a value.
        /// If it does, it calls the setStatus method to set the status with the text content of the ProfileStatusCustomTextBox.
        /// It then invokes the SaveStatusCustomButtonClick event and refreshes the content of the ProfileStatusCustomTextBox.
        /// </remarks>
        private void SaveStatusCustomButton_Click(object sender, EventArgs e)
        {
            if (ProfileStatusCustomTextBox.IsContainingValue())
                setStatus(ProfileStatusCustomTextBox.TextContent);
            SaveStatusCustomButtonClick?.Invoke(this, e);
            RefreshProfileStatusCustomTextBoxContent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "AddSaveStatusCustomButtonClickHandler" method adds an event handler to the SaveStatusCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add to the SaveStatusCustomButtonClick event.</param>
        /// <remarks>
        /// This method allows external code to subscribe to the SaveStatusCustomButtonClick event by providing an event handler.
        /// </remarks>
        public void AddSaveStatusCustomButtonClickHandler(EventHandler handler)
        {
            SaveStatusCustomButtonClick += handler;
        }

        /// <summary>
        /// The "setStatus" method updates the status text displayed in the CurrentStatusLabel.
        /// </summary>
        /// <param name="status">The new status text to set.</param>
        /// <remarks>
        /// This method appends the provided status text to the existing text in the CurrentStatusLabel, 
        /// ensuring that the total length of the text does not exceed 16 characters.
        /// </remarks>
        public void setStatus(string status)
        {
            CurrentStatusLabel.Text = CurrentStatusLabel.Text.Substring(0, 16) + status;
        }

        /// <summary>
        /// The "GetStatus" method retrieves the current status text from the ProfileStatusCustomTextBox.
        /// </summary>
        /// <returns>The current status text.</returns>
        public string GetStatus()
        {
            return ProfileStatusCustomTextBox.TextContent;
        }

        #endregion
    }
}
