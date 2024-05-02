using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.VerificationQuestion;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "PersonalVerificationQuestionsControl" class represents a user control for managing personal verification questions and answers.
    /// </summary>
    /// <remarks>
    /// This control provides functionality for selecting, answering, and managing personal verification questions.
    /// It includes methods for handling question selection, answer validation, and saving verification information.
    /// The control also provides events for notifying external code about user interactions, such as clicking the save button or changing a question.
    /// </remarks>
    public partial class PersonalVerificationQuestionsControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "VerificationInformationSaverCustomButtonClick" event is raised when the verification information saver custom button is clicked.
        /// </summary>
        public event EventHandler VerificationInformationSaverCustomButtonClick;

        #endregion

        #region Private Fields

        /// <summary>
        /// The int "VerificationQuestionNumber" represents the verification question number.
        /// </summary>
        private int VerificationQuestionNumber = 1;

        /// <summary>
        /// The bool "isUserInteraction" indicates whether there is user interaction.
        /// </summary>
        private bool isUserInteraction = true;

        /// <summary>
        /// The string "viewedQuestionValue" represents the viewed question value.
        /// </summary>
        private string viewedQuestionValue = "";

        /// <summary>
        /// The VerificationQuestionHandler "VerificationQuestionHandler" represents the verification question handler.
        /// </summary>
        private VerificationQuestionHandler VerificationQuestionHandler;

        #endregion

        #region Constructors

        /// <summary>
        /// The "PersonalVerificationQuestionsControl" constructor initializes a new instance of the <see cref="PersonalVerificationQuestionsControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the PersonalVerificationQuestionsControl by initializing its components and creating a new VerificationQuestionHandler with 5 questions.
        /// It also sets the selected index of the VerificationQuestionCustomComboBox to 0.
        /// </remarks>
        public PersonalVerificationQuestionsControl()
        {
            InitializeComponent();
            VerificationQuestionHandler = new VerificationQuestionHandler(5);
            VerificationQuestionCustomComboBox.SelectedIndex = 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "HandleQuestionVerification" method handles the verification question and answer validation.
        /// </summary>
        /// <remarks>
        /// This method checks if a verification question is selected (other than the default "Select a question") and if the verification answer is not empty.
        /// If both conditions are met, it enables the ApproveVerificationInformationCustomButton, which is used to proceed with the verification process.
        /// Otherwise, it disables the button to prevent proceeding with incomplete or invalid verification information.
        /// </remarks>
        private void HandleQuestionVerification()
        {
            if ((VerificationQuestionCustomComboBox.SelectedIndex) != 0 && (VerificationAnswerTextBox.IsContainingValue()))
            {
                ApproveVerificationInformationCustomButton.Enabled = true;
            }
            else
            {
                ApproveVerificationInformationCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "VerificationAnswerTextBox_TextChangedEvent" method handles the text changed event for the verification answer text box.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "HandleQuestionVerification" method to validate the verification question and answer.
        /// It also updates the CharNumberLabel to display the current length of the verification answer text and the maximum allowed length.
        /// The CharNumberLabel is typically used to provide feedback to the user about the length of the input text.
        /// </remarks>
        private void VerificationAnswerTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleQuestionVerification();
            CharNumberLabel.Text = VerificationAnswerTextBox.TextContent.Length.ToString() + "/" + VerificationAnswerTextBox.MaxLength;
        }

        /// <summary>
        /// The "ApproveVerificationInformationCustomButton_Click" method handles the click event for the approve verification information custom button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the verification question, answer, and index from the corresponding controls.
        /// It then updates the verification question details in the VerificationQuestionHandler with the new question, answer, and index.
        /// The method removes the selected question from the verification question combo box items and increments the VerificationQuestionNumber.
        /// If the VerificationQuestionNumber is not 6, the method checks if scrolling is needed and enables/disables the scroll buttons accordingly.
        /// If the VerificationQuestionNumber is 6, the method builds a StringBuilder containing all verification questions and answers, hides the PersonalVerificationQuestionsPanel, and shows the PersonalVerificationResultsPanel.
        /// </remarks>
        private void ApproveVerificationInformationCustomButton_Click(object sender, EventArgs e)
        {
            string question = VerificationQuestionCustomComboBox.TextContent;
            string answer = VerificationAnswerTextBox.TextContent;
            int questionIndex = VerificationQuestionCustomComboBox.SelectedIndex;
            VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber - 1] = new VerificationQuestionDetails(question, answer, questionIndex);
            VerificationQuestionCustomComboBox.Items.RemoveAt(questionIndex);
            VerificationQuestionNumber++;
            if (VerificationQuestionNumber != 6)
            {
                if ((VerificationQuestionNumber == 5) || (VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber] == null))
                {
                    LeftScrollCustomButton.Enabled = false;
                }
                if (VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber - 1] != null)
                {
                    HandleVerificationScroll();
                }
                else
                {
                    VerificationQuestionCustomComboBox.SelectedIndex = 0;
                    VerificationAnswerTextBox.TextContent = "";
                    VerificationQuestionNumberLabel.Text = VerificationQuestionNumber + "/5";
                }
                RightScrollCustomButton.Enabled = true;
            }
            else
            {
                StringBuilder verificationQuestionInformation = new StringBuilder();
                this.PersonalVerificationQuestionsPanel.Visible = false;
                this.PersonalVerificationResultsPanel.Visible = true;
                foreach (VerificationQuestionDetails verificationQuestion in VerificationQuestionHandler.VerificationQuestionDetails)
                {
                    verificationQuestionInformation.Append(verificationQuestion.Question + "\n");
                    verificationQuestionInformation.Append(verificationQuestion.Answer + "\n\n");
                }
                PersonalVerificationQuestionResultsLabel.Text = verificationQuestionInformation.ToString();
            }
        }

        /// <summary>
        /// The "RightScrollCustomButton_Click" method handles the click event for the right scroll custom button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method decrements the VerificationQuestionNumber and disables the RightScrollCustomButton if the number becomes 1.
        /// If the VerificationQuestionNumber is not 5 and the next question is not null, the method enables the LeftScrollCustomButton.
        /// It then cancels the placeholder for the verification answer text box and handles the verification scroll.
        /// </remarks>
        private void RightScrollCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionNumber--;
            if (VerificationQuestionNumber == 1)
            {
                RightScrollCustomButton.Enabled = false;
            }
            if ((VerificationQuestionNumber != 5) && (VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber] != null))
            {
                LeftScrollCustomButton.Enabled = true;
            }
            VerificationAnswerTextBox.CancelPlaceHolder();
            HandleVerificationScroll();
        }

        /// <summary>
        /// The "LeftScrollCustomButton_Click" method handles the click event for the left scroll custom button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method increments the VerificationQuestionNumber and disables the LeftScrollCustomButton if the number is 5 or the next question is null.
        /// It enables the RightScrollCustomButton and cancels the placeholder for the verification answer text box.
        /// Finally, it handles the verification scroll.
        /// </remarks>
        private void LeftScrollCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionNumber++;
            if ((VerificationQuestionNumber == 5) || (VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber] == null))
            {
                LeftScrollCustomButton.Enabled = false;
            }
            RightScrollCustomButton.Enabled = true;
            VerificationAnswerTextBox.CancelPlaceHolder();
            HandleVerificationScroll();
        }

        /// <summary>
        /// The "HandleVerificationScroll" method handles the scrolling through verification questions.
        /// </summary>
        /// <remarks>
        /// This method removes the previously viewed question from the ComboBox items if it's not empty.
        /// It updates the VerificationQuestionNumberLabel with the current question number out of 5.
        /// It retrieves the details of the verification question at the current index and sets it as the viewed question.
        /// The method then inserts the viewed question at its original index in the ComboBox items.
        /// It disables user interaction to prevent multiple changes at once.
        /// Finally, it selects the viewed question in the ComboBox, sets the answer text, and enables the approval button.
        /// </remarks>
        private void HandleVerificationScroll()
        {
            if (viewedQuestionValue != "")
            {
               VerificationQuestionCustomComboBox.Items.Remove(viewedQuestionValue);
            }
            VerificationQuestionNumberLabel.Text = VerificationQuestionNumber + "/5";
            VerificationQuestionDetails verificationQuestionDetails = VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber - 1];
            viewedQuestionValue = verificationQuestionDetails.Question;
            VerificationQuestionCustomComboBox.Items.Insert(verificationQuestionDetails.Index, verificationQuestionDetails.Question);
            isUserInteraction = false;
            VerificationQuestionCustomComboBox.SelectedItem = verificationQuestionDetails.Question;
            VerificationQuestionCustomComboBox.TextContent = verificationQuestionDetails.Question;
            VerificationAnswerTextBox.Enabled = true;
            VerificationAnswerTextBox.TextContent = verificationQuestionDetails.Answer; 
            ApproveVerificationInformationCustomButton.Enabled = true;
        }

        /// <summary>
        /// The "VerificationInformationChangerCustomButton_Click" method handles the click event of the VerificationInformationChangerCustomButton.
        /// </summary>
        /// <remarks>
        /// This method resets the VerificationQuestionNumber to 1, indicating the first question.
        /// It makes the PersonalVerificationQuestionsPanel visible and hides the PersonalVerificationResultsPanel.
        /// It enables the LeftScrollCustomButton and disables the RightScrollCustomButton to reset the scroll state.
        /// Finally, it calls the HandleVerificationScroll method to update the view with the first question's details.
        /// </remarks>
        private void VerificationInformationChangerCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionNumber = 1;
            this.PersonalVerificationQuestionsPanel.Visible = true;
            this.PersonalVerificationResultsPanel.Visible = false;
            LeftScrollCustomButton.Enabled = true;
            RightScrollCustomButton.Enabled = false;
            HandleVerificationScroll();
        }

        /// <summary>
        /// The "VerificationInformationSaverCustomButton_Click" method handles the click event of the VerificationInformationSaverCustomButton.
        /// </summary>
        /// <remarks>
        /// This method sets the WasSelected property of VerificationQuestionHandler to true, indicating that the user has selected verification questions.
        /// It disables the current form to prevent further interaction.
        /// Finally, it raises the VerificationInformationSaverCustomButtonClick event to notify subscribers, passing the current form and event arguments.
        /// </remarks>
        private void VerificationInformationSaverCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionHandler.WasSelected = true;
            this.Enabled = false;
            VerificationInformationSaverCustomButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// The "VerificationQuestionCustomComboBox_OnSelectedIndexChanged" method handles the SelectedIndexChanged event of the VerificationQuestionCustomComboBox.
        /// </summary>
        /// <remarks>
        /// This method checks if the change in the combo box selection is due to user interaction.
        /// If it is, it clears the text content of the VerificationAnswerTextBox and resets the viewedQuestionValue.
        /// It then enables or disables the VerificationAnswerTextBox based on the selected index.
        /// Finally, it calls the HandleQuestionVerification method to handle the verification question selection.
        /// </remarks>
        private void VerificationQuestionCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUserInteraction)
            {
                VerificationAnswerTextBox.TextContent = "";
                viewedQuestionValue = "";
            }
            isUserInteraction = true;
            if (VerificationQuestionCustomComboBox.SelectedIndex != 0)
            {
                VerificationAnswerTextBox.Enabled = true;
            }
            else
            {
                VerificationAnswerTextBox.Enabled = false;
            }
            HandleQuestionVerification();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "AddButtonClickHandler" method adds an event handler to the VerificationInformationSaverCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method is used to subscribe to the VerificationInformationSaverCustomButtonClick event, which is triggered when the
        /// VerificationInformationSaverCustomButton is clicked. It allows external code to respond to the button click event.
        /// </remarks>
        public void AddButtonClickHandler(EventHandler handler)
        {
            VerificationInformationSaverCustomButtonClick += handler;
        }

        /// <summary>
        /// The "GetVerificationQuestionHandler" method returns the VerificationQuestionHandler object.
        /// </summary>
        /// <returns>The VerificationQuestionHandler object.</returns>
        /// <remarks>
        /// This method is used to retrieve the VerificationQuestionHandler object, which manages the verification questions
        /// and answers for the user. It allows other parts of the code to access and modify the verification questions.
        /// </remarks>
        public VerificationQuestionHandler GetVerificationQuestionHandler()
        {
            return VerificationQuestionHandler;
        }

        #endregion
    }
}
