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
    public partial class PersonalVerificationAnswersControl : UserControl
    {
        public PersonalVerificationAnswersControl()
        {
            InitializeComponent();
        }
        private string questionNumber1;
        private string questionNumber2;
        private string questionNumber3;

        public void SetQuestions(string[] questions)
        {
            questionNumber1 = "";
            questionNumber2 = "";
            questionNumber3 = "";
            object[] questionsToBeInserted = new object[] {
            "Select a quesion 😊",
            questions[0],
            questions[1],
            questions[2],
            questions[3],
            questions[4],
            };
            VerificationQuestionNumberOneCustomComboBox.Items.AddRange(questionsToBeInserted);
            VerificationQuestionNumberTwoCustomComboBox.Items.AddRange(questionsToBeInserted);
            VerificationQuestionNumberThreeCustomComboBox.Items.AddRange(questionsToBeInserted);
            VerificationQuestionNumberOneCustomComboBox.SelectedIndex = 0;
            VerificationQuestionNumberTwoCustomComboBox.SelectedIndex = 0;
            VerificationQuestionNumberThreeCustomComboBox.SelectedIndex = 0;

        }

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

        private void RemoveValue(string value, int questionNumber)
        {
            if (questionNumber != 1)
                VerificationQuestionNumberOneCustomComboBox.Items.Remove(value);
            if (questionNumber != 2)
                VerificationQuestionNumberTwoCustomComboBox.Items.Remove(value);
            if (questionNumber != 3)
                VerificationQuestionNumberThreeCustomComboBox.Items.Remove(value);
        }
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

        private void ApproveVerificationInformationCustomButton_Click(object sender, EventArgs e)
        {
            //send answers and questions to server...
            string answerNumber1 = VerificationAnswerNumberOneCustomTextBox.TextContent;
            string answerNumber2 = VerificationAnswerNumberTwoCustomTextBox.TextContent;
            string answerNumber3 = VerificationAnswerNumberThreeCustomTextBox.TextContent;

            JsonClasses.PersonalVerificationAnswers results = new JsonClasses.PersonalVerificationAnswers(questionNumber1,questionNumber2,questionNumber3, answerNumber1, answerNumber2, answerNumber3);
            string resultsJson = JsonConvert.SerializeObject(results);

        }
    }
}
