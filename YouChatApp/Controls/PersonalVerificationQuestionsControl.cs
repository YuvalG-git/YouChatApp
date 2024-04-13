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
    public partial class PersonalVerificationQuestionsControl : UserControl
    {
        private VerificationQuestionHandler VerificationQuestionHandler;

        public PersonalVerificationQuestionsControl()
        {
            InitializeComponent();
            VerificationQuestionHandler = new VerificationQuestionHandler(5);
            VerificationQuestionCustomComboBox.SelectedIndex = 0;
        }
        private int VerificationQuestionNumber = 1;
        private bool isUserInteraction = true;
        private string viewedQuestionValue = "";

        public event EventHandler VerificationInformationSaverCustomButtonClick;

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

        private void VerificationAnswerTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            HandleQuestionVerification();
            CharNumberLabel.Text = VerificationAnswerTextBox.TextContent.Length.ToString() + "/" + VerificationAnswerTextBox.MaxLength;
        }

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

            VerificationAnswerTextBox.TextContent = verificationQuestionDetails.Answer; //doesnt work for some reason - maybe i should a bool mentioning it is for going back to selected answer
                                                                                        //probably the problem is because i said when the combobox value changed i should restart the text;
            ApproveVerificationInformationCustomButton.Enabled = true;
            //i also needs to delete the object because the question and answer are changing...

        }

        private void VerificationInformationChangerCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionNumber = 1;
            this.PersonalVerificationQuestionsPanel.Visible = true;
            this.PersonalVerificationResultsPanel.Visible = false;
            LeftScrollCustomButton.Enabled = true;
            RightScrollCustomButton.Enabled = false;

            HandleVerificationScroll();

        }

        private void VerificationInformationSaverCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionHandler.wasSelected = true;
            this.Enabled = false;
            VerificationInformationSaverCustomButtonClick?.Invoke(this, e);
        }
        public void AddButtonClickHandler(EventHandler handler)
        {
            VerificationInformationSaverCustomButtonClick += handler;
        }
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
    }
}
