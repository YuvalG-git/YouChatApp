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
        }
        private int VerificationQuestionNumber = 1;

        private void HandleQuestionVerification() //instead of all those methods i can make a method that gets a bool that will represents the needed values and the name of the button to enable..
        {
            //if ((VerificationQuestionComboBox.SelectedIndex) != 0 && (VerificationAnswerTextBox.TextContent != ""))
            //{
            //    ApproveVerificationInformationCustomButton.Enabled = true;
            //}
            //else
            //{
            //    ApproveVerificationInformationCustomButton.Enabled = false;
            //}
            if ((VerificationQuestionCustomComboBox.SelectedIndex) != 0 && (VerificationAnswerTextBox.TextContent != ""))
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

        }

        private void ApproveVerificationInformationCustomButton_Click(object sender, EventArgs e)
        {
            //string question = VerificationQuestionComboBox.Text;
            string question = VerificationQuestionCustomComboBox.TextContent;

            string answer = VerificationAnswerTextBox.TextContent;
            int questionIndex = VerificationQuestionCustomComboBox.SelectedIndex;
            VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber - 1] = new VerificationQuestionDetails(question, answer, questionIndex);
            VerificationQuestionCustomComboBox.Items.RemoveAt(questionIndex);
            VerificationQuestionNumber++;
            if (VerificationQuestionNumber != 6)
            {
                if (VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber - 1] != null)
                {
                    HandleVerificationScroll();
                }
                else
                {
                    VerificationQuestionCustomComboBox.SelectedIndex = 0;

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
            HandleVerificationScroll();
            //HandleQuestionVerification();

        }

        private void LeftScrollCustomButton_Click(object sender, EventArgs e)
        {
            VerificationQuestionNumber++;
            if ((VerificationQuestionNumber == 5) || (VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber] == null))
            {
                LeftScrollCustomButton.Enabled = false;
            }
            RightScrollCustomButton.Enabled = true;
            HandleVerificationScroll();
            //HandleQuestionVerification();
        }
        private void HandleVerificationScroll()
        {
            VerificationQuestionNumberLabel.Text = VerificationQuestionNumber + "/5";
            VerificationQuestionDetails verificationQuestionDetails = VerificationQuestionHandler.VerificationQuestionDetails[VerificationQuestionNumber - 1];
            //VerificationQuestionComboBox.Items.Insert(verificationQuestionDetails.Index, verificationQuestionDetails.Question);
            //VerificationQuestionComboBox.SelectedValue = verificationQuestionDetails.Question;
            //VerificationQuestionComboBox.Text = verificationQuestionDetails.Question;
            VerificationQuestionCustomComboBox.Items.Insert(verificationQuestionDetails.Index, verificationQuestionDetails.Question);
            VerificationQuestionCustomComboBox.SelectedValue = verificationQuestionDetails.Question;
            VerificationQuestionCustomComboBox.TextContent = verificationQuestionDetails.Question;

            VerificationAnswerTextBox.TextContent = verificationQuestionDetails.Answer; //doesnt work for some reason - maybe i should a bool mentioning it is for going back to selected answer
                                                                                        //probably the problem is because i said when the combobox value changed i should restart the text;

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
            //RegistButtonSetEnabled();
        }

        private void VerificationQuestionCustomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificationAnswerTextBox.TextContent = "";
            HandleQuestionVerification();
        }

        private void VerificationQuestionCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            VerificationAnswerTextBox.TextContent = "";
            HandleQuestionVerification();
        }
    }
}
