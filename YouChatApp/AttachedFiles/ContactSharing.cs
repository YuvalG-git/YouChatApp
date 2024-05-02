using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YouChatApp.Controls;
using YouChatApp.ContactHandler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;

namespace YouChatApp.AttachedFiles
{
    /// <summary>
    /// The "ContactSharing" class represents a form for sharing contacts and managing selected contacts for sharing.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for selecting contacts to share, adding them to a list, and managing the list of selected contacts.
    /// It includes methods for adding, removing, and displaying selected contacts, as well as for searching and filtering contacts.
    /// The form also allows users to reset the sharing process, view selected contacts, and send the contact information.
    /// </remarks>
    public partial class ContactSharing : Form
    {
        #region Private Fields

        /// <summary>
        /// The int "LastContactControlHeightLocation" represents the last height location of the contact control.
        /// </summary>
        private int LastContactControlHeightLocation = 0;

        /// <summary>
        /// The int "LastProfileControlWidthLocation" represents the last width location of the profile control.
        /// </summary>
        private int LastProfileControlWidthLocation = 0;

        /// <summary>
        /// The int "ProfileControlNumber" represents the number of profile controls.
        /// </summary>
        private int ProfileControlNumber = 0;

        /// <summary>
        /// The int "ContactNumber" represents the number of contacts.
        /// </summary>
        private int ContactNumber = 0;

        /// <summary>
        /// The List "SelectedContactsList" contains the list of selected contacts.
        /// </summary>
        private List<string> SelectedContactsList = new List<string>();

        /// <summary>
        /// The Image "AnonymousProfile" represents the anonymous profile image.
        /// </summary>
        private Image AnonymousProfile = global::YouChatApp.Properties.Resources.AnonymousProfile;

        #endregion

        #region Public Static Fields

        /// <summary>
        /// The static string "contactData" represents the contact data.
        /// </summary>
        public static string contactData;

        /// <summary>
        /// The static int "SelectedContacts" represents the number of selected contacts.
        /// </summary>
        public static int SelectedContacts = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ContactSharing" constructor initializes a new instance of the <see cref="ContactSharing"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the ContactSharing class, initializing its components, 
        /// event handlers, and lists for managing contacts and profiles. It also sets up the search functionality, 
        /// resets the contact sharing state, and adjusts the layout of contact panels.
        /// </remarks>
        public ContactSharing()
        {
            InitializeComponent();
            ContactControlList = new List<ContactSharingControl>();
            ProfileControlList = new List<ProfileControl>();
            SearchBar.AddSearchOnClickHandler(SearchContacts);
            RestartContactSharing();
            SetContactControlList();
            PanelHandler.DeletePanelScrollBars(ChosenContactsPanel);
            ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
            ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height + ChosenContactsPanel.Height);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "RestartContactSharing" method restarts the contact sharing process.
        /// </summary>
        /// <remarks>
        /// It clears the text content of the search bar, sets it to "Search...", and then restarts the sharing process.
        /// </remarks>
        private void RestartContactSharing()
        {
            SearchBar.SeacrhBar.TextContent = "";
            SearchBar.SeacrhBar.TextContent = "Search...";
            Restart();
        }

        /// <summary>
        /// The "AddProfileControl" method adds a profile control to the ChosenContactsPanel based on the provided name and profile picture.
        /// </summary>
        /// <param name="name">The name associated with the profile.</param>
        /// <param name="profilePicture">The profile picture to display.</param>
        /// <remarks>
        /// If a profile picture is provided, it is used; otherwise, a default profile picture (AnonymousProfile) is used.
        /// If the ChosenContactsPanel already contains controls, it scrolls to the last control.
        /// If the ChosenContactsPanel is empty, it resizes the ContactPanel and enables the RestartCustomButton and ShareContactsCustomButton.
        /// The method adds a new ProfileControl to the ProfileControlList, sets its location, name, size, profile picture, and user name.
        /// It then sets a tooltip for the new ProfileControl, adds it to the form's Controls collection, and to the ChosenContactsPanel.
        /// Finally, it adjusts the layout of the ContactPanel based on the new controls added.
        /// </remarks>
        private void AddProfileControl(string name, Image profilePicture)
        {
            Image profilePictureTobeUsed;
            if (profilePicture != null)
            {
                profilePictureTobeUsed = profilePicture;
            }
            else
            {
                profilePictureTobeUsed = AnonymousProfile;
            }
            if (this.ChosenContactsPanel.Controls.Count > 0)
            {
                Control LastControl = this.ProfileControlList[0];
                this.ChosenContactsPanel.ScrollControlIntoView(LastControl);
            }
            else
            {
                ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height - ChosenContactsPanel.Height);
                RestartCustomButton.Enabled = true;
                ShareContactsCustomButton.Enabled = true;
            }
            ProfileControlList.Add(new ProfileControl());
            ProfileControlList[ProfileControlNumber].Location = new System.Drawing.Point(LastProfileControlWidthLocation, 0);
            ProfileControlList[ProfileControlNumber].Name = name;
            ProfileControlList[ProfileControlNumber].Size = new System.Drawing.Size(90, 90);
            ProfileControlList[ProfileControlNumber].TabIndex = 0;
            ProfileControlList[ProfileControlNumber].SetProfilePicture(profilePictureTobeUsed);
            ProfileControlList[ProfileControlNumber].SetUserName(name);

            ProfileControlList[ProfileControlNumber].SetToolTip();
            this.Controls.Add(this.ProfileControlList[ProfileControlNumber]);

            ChosenContactsPanel.Controls.Add(ProfileControlList[ProfileControlNumber]);
            LastProfileControlWidthLocation += ProfileControlList[ProfileControlNumber].Width + 10;
            ProfileControlNumber++;
            ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y + ChosenContactsPanel.Height);
        }

        /// <summary>
        /// The "RemoveProfileControl" methods removes a profile control from the ChosenContactsPanel based on the provided name.
        /// </summary>
        /// <param name="name">The name associated with the profile control to remove.</param>
        /// <remarks>
        /// Iterates through the ProfileControlList to find a profile control with the specified name.
        /// If found, removes the profile control from both the ProfileControlList and the ChosenContactsPanel,
        /// disposes of the profile control, and decrements the ProfileControlNumber.
        /// After removing the profile control, it adjusts the layout of the ContactPanel and enables/disables
        /// the RestartCustomButton and ShareContactsCustomButton based on the number of remaining profile controls.
        /// </remarks>
        private void RemoveProfileControl(string name)
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                if (profile.Name == name)
                {
                    ProfileControlList.Remove(profile);
                    ChosenContactsPanel.Controls.Remove(profile);
                    profile.Dispose();
                    ProfileControlNumber--;
                    break;
                }
            }
            RestartProfileControlListLocation();
            if (this.ChosenContactsPanel.Controls.Count > 0)
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y + ChosenContactsPanel.Height);
            }
            else
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
                ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height + ChosenContactsPanel.Height);
                RestartCustomButton.Enabled = false;
                ShareContactsCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "RemoveAllProfileControls" method removes all profile controls from the ChosenContactsPanel.
        /// </summary>
        /// <remarks>
        /// Disposes of all profile controls in the ProfileControlList and clears both the ProfileControlList
        /// and the ChosenContactsPanel.Controls collections. Resets the ProfileControlNumber and
        /// LastProfileControlWidthLocation variables to their initial values. Adjusts the layout of the ContactPanel
        /// to its original state.
        /// </remarks>
        private void RemoveAllProfileControls()
        {
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Dispose();
            }
            ProfileControlList.Clear();
            ChosenContactsPanel.Controls.Clear();
            ProfileControlNumber = 0;
            LastProfileControlWidthLocation = 0;
            ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
            ContactPanel.Size = new Size(ContactPanel.Width, ContactPanel.Height + ChosenContactsPanel.Height);
        }

        /// <summary>
        /// The "RestartProfileControlListLocation" method resets the location of all profile controls in the ProfileControlList.
        /// </summary>
        /// <remarks>
        /// Sets the LastProfileControlWidthLocation to 0 and iterates through each profile control in the ProfileControlList.
        /// Sets the location of each profile control based on the LastProfileControlWidthLocation and adjusts the
        /// LastProfileControlWidthLocation for the next profile control.
        /// </remarks>
        private void RestartProfileControlListLocation()
        {
            LastProfileControlWidthLocation = 0;
            foreach (ProfileControl profile in ProfileControlList)
            {
                profile.Location = new System.Drawing.Point(LastProfileControlWidthLocation, 0);
                LastProfileControlWidthLocation += profile.Width + 10;
            }
        }

        /// <summary>
        /// The "SearchContacts" method filters and displays contacts based on the search text entered in the SearchBar.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Adjusts the location of the ContactPanel based on the presence of chosen contacts in the ChosenContactsPanel.
        /// Removes trailing spaces from the search text.
        /// Iterates through each ContactSharingControl in the ContactControlList.
        /// If the search text is empty, shows all contacts; otherwise, shows only the contacts whose names match the search text.
        /// Updates the location of visible contacts and adjusts the LastContactControlHeightLocation accordingly.
        /// </remarks>
        private void SearchContacts(object sender, System.EventArgs e)
        {
            if (this.ChosenContactsPanel.Controls.Count > 0)
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y + ChosenContactsPanel.Height);
            }
            else
            {
                ContactPanel.Location = new System.Drawing.Point(ContactPanel.Location.X, ChosenContactsPanel.Location.Y);
            }
            string Text = SearchBar.SeacrhBar.TextContent;
            while (Text.EndsWith(" "))
            {
                Text = Text.Substring(0, Text.Length - 1);
            }
            string ContactName;
            LastContactControlHeightLocation = 0;
            if (Text.Length == 0)
            {
                foreach (ContactSharingControl Contact in ContactControlList)
                {
                    Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                    LastContactControlHeightLocation += Contact.Height;
                    Contact.Visible = true;
                }
            }
            else
            {
                foreach (ContactSharingControl Contact in ContactControlList) 
                {
                    bool IsVisible = false;
                    ContactName = Contact.ContactName.Text;
                    if (Text.ToLower().Contains(" "))
                    {
                        if (ContactName.ToLower().StartsWith(Text.ToLower())) 
                        {
                            Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                            IsVisible = true;
                        }
                    }
                    else
                    {
                        string[] NameParts = ContactName.Split(' ');
                        foreach (string NamePart in NameParts)
                        {
                            if (NamePart.ToLower().StartsWith(Text.ToLower()))
                            {
                                Contact.Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                                IsVisible = true;
                            }
                        }
                    }
                    if (IsVisible)
                    {
                        LastContactControlHeightLocation += Contact.Height;
                    }
                    Contact.Visible = IsVisible;
                }
            }
        }
        /// <summary>
        /// The "SetContactControlList" method initializes and populates the ContactControlList with ContactSharingControl instances based on the UserContacts from the ContactManager.
        /// </summary>
        /// <remarks>
        /// Iterates through each Contact in the ContactManager.UserContacts list.
        /// For each Contact, creates a new ContactSharingControl instance, sets its properties (Location, Name, TabIndex, ContactName, ProfilePicture, ContactId),
        /// and adds event handlers for checkbox clicks.
        /// Adds the ContactSharingControl instance to both the form's Controls collection and the ContactPanel's Controls collection.
        /// Increments the ContactNumber after each iteration.
        /// </remarks>
        private void SetContactControlList()
        {
            foreach (Contact Contact in ContactManager.UserContacts)
            {
                if (ContactNumber != 0)
                    LastContactControlHeightLocation = this.ContactControlList[ContactNumber - 1].Location.Y + this.ContactControlList[ContactNumber - 1].Size.Height;
                this.ContactControlList.Add(new ContactSharingControl());
                this.ContactControlList[ContactNumber].Location = new System.Drawing.Point(0, LastContactControlHeightLocation);
                this.ContactControlList[ContactNumber].Name = Contact.Name;
                this.ContactControlList[ContactNumber].TabIndex = 0;
                this.ContactControlList[ContactNumber].ContactName.Text = Contact.Name;
                this.ContactControlList[ContactNumber].ProfilePicture.Image = Contact.ProfilePicture;
                this.ContactControlList[ContactNumber].ContactId = Contact.Id;
                this.ContactControlList[ContactNumber].OnCheckBoxClickAcceptedHandler(IsChecked);
                this.ContactControlList[ContactNumber].OnCheckBoxClickDeniedHandler(IsNotChecked);
                this.Controls.Add(this.ContactControlList[ContactNumber]);
                this.ContactPanel.Controls.Add(this.ContactControlList[ContactNumber]);
                ContactNumber++;
            }
        }

        /// <summary>
        /// The "IsChecked" method handles the event when a checkbox in a ContactSharingControl is checked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Retrieves the ContactName from the sender's ContactSharingControl and adds it to the SelectedContactsList.
        /// Retrieves the Contact object from the ContactManager using the ContactName and gets the Contact's profile picture.
        /// Calls the AddProfileControl method to add a profile control for the selected contact.
        /// </remarks>
        private void IsChecked(object sender, System.EventArgs e)
        {
            string ContactName = ((ContactSharingControl)(sender)).ContactName.Text;
            SelectedContactsList.Add(ContactName);
            Contact contact = ContactManager.GetContact(ContactName);
            if (contact != null)
            {
                Image ContactProfilePicture = contact.ProfilePicture;
                AddProfileControl(ContactName, ContactProfilePicture);
            }
        }

        /// <summary>
        /// The "IsNotChecked" method handles the event when a checkbox in a ContactSharingControl is unchecked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Retrieves the ContactName from the sender's ContactSharingControl and removes it from the SelectedContactsList.
        /// Calls the RemoveProfileControl method to remove the profile control for the unselected contact.
        /// </remarks>
        private void IsNotChecked(object sender, System.EventArgs e)
        {
            string ContactName = ((ContactSharingControl)(sender)).ContactName.Text;
            SelectedContactsList.Remove(ContactName);
            RemoveProfileControl(ContactName);
        }

        /// <summary>
        /// The "SendCustomButton_Click" method handles the click event of the SendCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Constructs a string with selected contact information.
        /// Iterates through the ContactControlList and appends the ContactName and ContactId
        /// to the contactData string for each ContactSharingControl with a checked ContactSelection.
        /// If any contacts are selected, removes the last newline character from contactData,
        /// sets the dialog result to OK, displays a message box with the contactData, and closes the form.
        /// </remarks>
        private void SendCustomButton_Click(object sender, EventArgs e)
        {
            contactData = "Contact Information:\n";
            foreach (ContactSharingControl Contact in ContactControlList) 
            {
                if (Contact.ContactSelection.Checked)
                {
                    contactData += $"{Contact.ContactName.Text}#{Contact.ContactId}\n";
                }
            }
            if (contactData != "")
            {
                contactData = contactData.Substring(0, contactData.Length - 1);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(contactData);
                this.Close();
            }
        }

        /// <summary>
        /// The "RestartCustomButton_Click" method handles the click event of the RestartCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// Calls the Restart method to reset the state of the form or control.
        /// </remarks>
        private void RestartCustomButton_Click(object sender, EventArgs e)
        {
            Restart();
        }

        /// <summary>
        /// The "Restart" method resets the state of the form or control.
        /// </summary>
        /// <remarks>
        /// If there are selected contacts, it unchecks all contact selection checkboxes, resets the SelectedContacts count to 0,
        /// removes all profile controls, and disables the RestartCustomButton and ShareContactsCustomButton.
        /// </remarks>
        private void Restart()
        {
            if (SelectedContacts != 0)
            {
                foreach (ContactSharingControl Contact in ContactControlList)
                {
                    Contact.ContactSelection.Checked = false;
                }
                SelectedContacts = 0;
                RemoveAllProfileControls();
                RestartCustomButton.Enabled = false;
                ShareContactsCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "CancelCustomButton_Click" method closes the current form.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is an event handler for the cancel button in a form. It simply closes the form without performing any additional actions.
        /// </remarks>
        private void CancelCustomButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
