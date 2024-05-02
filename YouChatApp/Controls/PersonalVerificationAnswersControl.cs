using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.JsonClasses;
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
    public partial class PersonalVerificationAnswersControl : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "ApproveVerificationInformationCustomButtonClick" event is raised when the approve verification information custom button is clicked.
        /// </summary>
        public event EventHandler ApproveVerificationInformationCustomButtonClick;

        #endregion

        #region Private Fields

        /// <summary>
        /// The string "questionNumber1" represents the first verification question number.
        /// </summary>
        private string questionNumber1;

        /// <summary>
        /// The string "questionNumber2" represents the second verification question number.
        /// </summary>
        private string questionNumber2;

        /// <summary>
        /// The string "questionNumber3" represents the third verification question number.
        /// </summary>
        private string questionNumber3;

        #endregion

        #region Constructors

        /// <summary>
        /// The "PersonalVerificationAnswersControl" constructor initializes a new instance of the <see cref="PersonalVerificationAnswersControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the PersonalVerificationAnswersControl by initializing its components.
        /// </remarks>
        public PersonalVerificationAnswersControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods  

        /// <summary>
        /// The "VerificationQuestionNumberOneCustomComboBox_OnSelectedIndexChanged" method handles the SelectedIndexChanged event of the VerificationQuestionNumberOneCustomComboBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adds the value of the first verification question to the questionNumber1 variable.
        /// It then checks if the selected index is not 0 (indicating a valid question selection).
        /// If a valid question is selected, it enables the VerificationAnswerNumberOneCustomTextBox for user input and removes the selected question from the available options.
        /// If the selected index is 0, it clears the questionNumber1 variable and disables the VerificationAnswerNumberOneCustomTextBox.
        /// Finally, it clears the text content of the VerificationAnswerNumberOneCustomTextBox.
        /// </remarks>
        private void VerificationQuestionNumberOneCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            AddValue(questionNumber1,1);
            int questionIndex = VerificationQuestionNumberOneCustomComboBox.SelectedIndex;
            if (questionIndex != 0)
            {
                questionNumber1 = VerificationQuestionNumberOneCustomComboBox.SelectedItem as string;
                VerificationAnswerNumberOneCustomTextBox.Enabled = true;
                RemoveValue(questionNumber1, 1);
            }
            else
            {
                questionNumber1 = "";
                VerificationAnswerNumberOneCustomTextBox.Enabled = false;
            }
            VerificationAnswerNumberOneCustomTextBox.TextContent = "";
        }

        /// <summary>
        /// The "VerificationQuestionNumberTwoCustomComboBox_OnSelectedIndexChanged" method handles the SelectedIndexChanged event of the VerificationQuestionNumberTwoCustomComboBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adds the value of the second verification question to the questionNumber2 variable.
        /// It then checks if the selected index is not 0 (indicating a valid question selection).
        /// If a valid question is selected, it enables the VerificationAnswerNumberTwoCustomTextBox for user input and removes the selected question from the available options.
        /// If the selected index is 0, it clears the questionNumber2 variable and disables the VerificationAnswerNumberTwoCustomTextBox.
        /// Finally, it clears the text content of the VerificationAnswerNumberTwoCustomTextBox.
        /// </remarks>
        private void VerificationQuestionNumberTwoCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            AddValue(questionNumber2,2);
            int questionIndex = VerificationQuestionNumberTwoCustomComboBox.SelectedIndex;
            if (questionIndex != 0)
            {
                questionNumber2 = VerificationQuestionNumberTwoCustomComboBox.SelectedItem as string;
                VerificationAnswerNumberTwoCustomTextBox.Enabled = true;
                RemoveValue(questionNumber2, 2);
            }
            else
            {
                questionNumber2 = "";
                VerificationAnswerNumberTwoCustomTextBox.Enabled = false;
            }
            VerificationAnswerNumberTwoCustomTextBox.TextContent = "";
        }

        /// <summary>
        /// The "VerificationQuestionNumberThreeCustomComboBox_OnSelectedIndexChanged" method handles the SelectedIndexChanged event of the VerificationQuestionNumberThreeCustomComboBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adds the value of the third verification question to the questionNumber3 variable.
        /// It then checks if the selected index is not 0 (indicating a valid question selection).
        /// If a valid question is selected, it enables the VerificationAnswerNumberThreeCustomTextBox for user input and removes the selected question from the available options.
        /// If the selected index is 0, it clears the questionNumber3 variable and disables the VerificationAnswerNumberThreeCustomTextBox.
        /// Finally, it clears the text content of the VerificationAnswerNumberThreeCustomTextBox.
        /// </remarks>
        private void VerificationQuestionNumberThreeCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            AddValue(questionNumber3,3);
            int questionIndex = VerificationQuestionNumberThreeCustomComboBox.SelectedIndex;
            if (questionIndex != 0)
            {
                questionNumber3 = VerificationQuestionNumberThreeCustomComboBox.SelectedItem as string;
                VerificationAnswerNumberThreeCustomTextBox.Enabled = true;
                RemoveValue(questionNumber3, 3);
            }
            else
            {
                questionNumber3 = "";
                VerificationAnswerNumberThreeCustomTextBox.Enabled = false;
            }
            VerificationAnswerNumberThreeCustomTextBox.TextContent = "";   
        }

        /// <summary>
        /// The "RemoveValue" method removes a value from the dropdown list of verification questions based on the question number.
        /// </summary>
        /// <param name="value">The value to remove from the dropdown list.</param>
        /// <param name="questionNumber">The number of the verification question.</param>
        /// <remarks>
        /// This method removes the specified value from the dropdown list of verification questions for the corresponding question number.
        /// It ensures that the value is removed from the dropdown list of all other questions except the one specified by the question number.
        /// </remarks>
        private void RemoveValue(string value, int questionNumber)
        {
            if (questionNumber != 1)
                VerificationQuestionNumberOneCustomComboBox.Items.Remove(value);
            if (questionNumber != 2)
                VerificationQuestionNumberTwoCustomComboBox.Items.Remove(value);
            if (questionNumber != 3)
                VerificationQuestionNumberThreeCustomComboBox.Items.Remove(value);
        }

        /// <summary>
        /// The "AddValue" method adds a value to the dropdown list of verification questions based on the question number.
        /// </summary>
        /// <param name="value">The value to add to the dropdown list.</param>
        /// <param name="questionNumber">The number of the verification question.</param>
        /// <remarks>
        /// This method adds the specified value to the dropdown list of verification questions for the corresponding question number.
        /// It ensures that the value is added to the dropdown list of all other questions except the one specified by the question number.
        /// </remarks>
        private void AddValue(string value,int questionNumber)
        {
            if (value != "")
            {
                if (questionNumber != 1)
                    VerificationQuestionNumberOneCustomComboBox.Items.Add(value);
                if (questionNumber != 2)
                    VerificationQuestionNumberTwoCustomComboBox.Items.Add(value);
                if (questionNumber != 3)
                    VerificationQuestionNumberThreeCustomComboBox.Items.Add(value);
            }
        }

        /// <summary>
        /// The "VerificationAnswerCustomTextBoxs_TextChangedEvent" method handles the TextChanged event of the verification answer text boxes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if all three verification answer text boxes contain a value.
        /// If they do, it enables the ApproveVerificationInformationCustomButton.
        /// Otherwise, it disables the button.
        /// </remarks>
        private void VerificationAnswerCustomTextBoxs_TextChangedEvent(object sender, EventArgs e)
        {
            if (VerificationAnswerNumberOneCustomTextBox.IsContainingValue() && VerificationAnswerNumberTwoCustomTextBox.IsContainingValue() && VerificationAnswerNumberThreeCustomTextBox.IsContainingValue())
            {
                ApproveVerificationInformationCustomButton.Enabled = true;
            }
            else
            {
                ApproveVerificationInformationCustomButton.Enabled = false;
            }
        }

        /// <summary>
        /// The "ApproveVerificationInformationCustomButton_Click" method handles the Click event of the ApproveVerificationInformationCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the ApproveVerificationInformationCustomButton is clicked.
        /// It disables the button and sets the form to a disabled state.
        /// It then invokes the ApproveVerificationInformationCustomButtonClick event, allowing external code to handle the approval process.
        /// </remarks>
        private void ApproveVerificationInformationCustomButton_Click(object sender, EventArgs e)
        {
            ApproveVerificationInformationCustomButton.Enabled = false;
            SetEnable(false);
            ApproveVerificationInformationCustomButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// The "SetEnable" method enables or disables the input controls related to verification questions and answers.
        /// </summary>
        /// <param name="enable">A boolean value indicating whether to enable (true) or disable (false) the controls.</param>
        /// <remarks>
        /// This method is used to enable or disable the input controls for selecting and entering verification questions and answers.
        /// It accepts a boolean parameter to determine the state of the controls.
        /// </remarks>
        private void SetEnable(bool enable)
        {
            VerificationQuestionNumberOneCustomComboBox.Enabled = enable;
            VerificationAnswerNumberOneCustomTextBox.Enabled = enable;
            VerificationQuestionNumberTwoCustomComboBox.Enabled = enable;
            VerificationAnswerNumberTwoCustomTextBox.Enabled = enable;
            VerificationQuestionNumberThreeCustomComboBox.Enabled = enable;
            VerificationAnswerNumberThreeCustomTextBox.Enabled = enable;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "AddApproveVerificationInformationCustomButtonClickHandler" method adds an event handler to the ApproveVerificationInformationCustomButtonClick event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method subscribes to the ApproveVerificationInformationCustomButtonClick event, which is triggered when the 
        /// ApproveVerificationInformationCustomButton is clicked. It allows external code to respond to the button click event.
        /// </remarks>
        public void AddApproveVerificationInformationCustomButtonClickHandler(EventHandler handler)
        {
            ApproveVerificationInformationCustomButtonClick += handler;
        }

        /// <summary>
        /// The "SetQuestions" method sets the verification questions for the user interface.
        /// </summary>
        /// <param name="personalVerificationQuestions">A PersonalVerificationQuestions object containing the verification questions.</param>
        /// <remarks>
        /// This method initializes the verification question ComboBoxes with the provided questions.
        /// It clears any existing selections and sets the ComboBoxes to the default "Select a question" option.
        /// </remarks>
        public void SetQuestions(PersonalVerificationQuestions personalVerificationQuestions)
        {
            questionNumber1 = "";
            questionNumber2 = "";
            questionNumber3 = "";
            string question1 = personalVerificationQuestions.QuestionNumber1;
            string question2 = personalVerificationQuestions.QuestionNumber2;
            string question3 = personalVerificationQuestions.QuestionNumber3;
            string question4 = personalVerificationQuestions.QuestionNumber4;
            string question5 = personalVerificationQuestions.QuestionNumber5;

            object[] questionsToBeInserted = new object[] {
            "Select a quesion 😊",
            question1,
            question2,
            question3,
            question4,
            question5,
            };

            VerificationQuestionNumberOneCustomComboBox.Items.AddRange(questionsToBeInserted);
            VerificationQuestionNumberTwoCustomComboBox.Items.AddRange(questionsToBeInserted);
            VerificationQuestionNumberThreeCustomComboBox.Items.AddRange(questionsToBeInserted);
            VerificationQuestionNumberOneCustomComboBox.SelectedIndex = 0;
            VerificationQuestionNumberTwoCustomComboBox.SelectedIndex = 0;
            VerificationQuestionNumberThreeCustomComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// The "CancelDisabled" method enables the input fields for verification questions and answers.
        /// </summary>
        /// <remarks>
        /// This method sets the enable state of the input fields for verification questions and answers to true, allowing the user to interact with them.
        /// </remarks>
        public void CancelDisabled()
        {
            SetEnable(true);
        }

        /// <summary>
        /// The "GetPersonalVerificationAnswers" method retrieves the user's answers to the verification questions.
        /// </summary>
        /// <returns>A PersonalVerificationAnswers object containing the user's answers.</returns>
        /// <remarks>
        /// This method creates a PersonalVerificationAnswers object using the user's answers to the verification questions.
        /// </remarks>
        public PersonalVerificationAnswers GetPersonalVerificationAnswers()
        {
            string answerNumber1 = VerificationAnswerNumberOneCustomTextBox.TextContent;
            string answerNumber2 = VerificationAnswerNumberTwoCustomTextBox.TextContent;
            string answerNumber3 = VerificationAnswerNumberThreeCustomTextBox.TextContent;

            PersonalVerificationAnswers personalVerificationAnswers = new JsonClasses.PersonalVerificationAnswers(questionNumber1, questionNumber2, questionNumber3, answerNumber1, answerNumber2, answerNumber3);
            return personalVerificationAnswers;
        }

        #endregion
    }
}
