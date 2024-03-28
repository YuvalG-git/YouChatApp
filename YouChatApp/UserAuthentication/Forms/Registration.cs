using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YouChatApp.JsonClasses;
using YouChatApp.VerificationQuestion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class Registration : Form
    {

        Boolean MaleButtonIsChecked = false, FemaleButtonIsChecked = false, AnotherGenderButtonIsChecked = false;
        string Gender = "";
        public Registration()
        {
            InitializeComponent();
            GenderOptionsCustomComboBox.SelectedIndex = 0;
        }

        private void UsernameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
            HandleUsernameContent();

        }

        private void UsernameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleUsernameContent();
        }
        private void HandleUsernameContent()
        {
            string username = UsernameCustomTextBox.TextContent;
            string error = "";
            if (UsernameCustomTextBox.isPlaceHolder())
            {
                UsernameCustomTextBox.BorderColor = Color.MediumSlateBlue;
            }
            else
            {
                if (!StringHandler.IsAlphanumeric(username))
                {
                    error += "The username can only contain letters and numbers\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(username);
                if (length < 4)
                {
                    error += "The username must be longer than 4 letters";
                }
                else if (length >= 30)
                {
                    error += "The username must be shorter than 31 letters";
                }

                if (error != "")
                {
                    UsernameCustomTextBox.BorderColor = Color.Red;
                    UsernameExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(UsernameExclamationCustomButton, error);
                }
                else
                {
                    UsernameExclamationCustomButton.Visible = false;
                    UsernameCustomTextBox.BorderColor = Color.LimeGreen;

                }
            }
        }

        private void FirstNameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleFirstNameContent();

        }
        private void HandleFirstNameContent()
        {
            string firstName = FirstNameCustomTextBox.TextContent;
            string error = "";
            if (FirstNameCustomTextBox.isPlaceHolder())
            {
                FirstNameCustomTextBox.BorderColor = Color.MediumSlateBlue;
            }
            else
            {
                if (!StringHandler.IsAlphaOrWhiteSpace(firstName))
                {
                    error += "The first name can only contain letters and white spaces\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(firstName);
                if (length < 4)
                {
                    error += "The first name must be longer than 4 letters";
                }
                else if (length >= 30)
                {
                    error += "The first name must be shorter than 31 letters";
                }

                if (error != "")
                {
                    FirstNameCustomTextBox.BorderColor = Color.Red;
                    FirstNameExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(FirstNameExclamationCustomButton, error);
                }
                else
                {
                    FirstNameExclamationCustomButton.Visible = false;
                    FirstNameCustomTextBox.BorderColor = Color.LimeGreen;

                }
            }
        }
        private void HandleLastNameContent()
        {
            string lastName = FirstNameCustomTextBox.TextContent;
            string error = "";
            if (LastNameCustomTextBox.isPlaceHolder())
            {
                LastNameCustomTextBox.BorderColor = Color.MediumSlateBlue;
            }
            else
            {
                if (!StringHandler.IsAlphaOrWhiteSpace(lastName))
                {
                    error += "The last name can only contain letters\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(lastName);

                if (length < 4)
                {
                    error += "The last name must be longer than 4 letters";
                }
                else if (length >= 30)
                {
                    error += "The last name must be shorter than 31 letters";
                }


                if (error != "")
                {
                    LastNameCustomTextBox.BorderColor = Color.Red;
                    LastNameExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(LastNameExclamationCustomButton, error);
                }
                else
                {
                    LastNameExclamationCustomButton.Visible = false;
                    LastNameCustomTextBox.BorderColor = Color.LimeGreen;

                }
            }
        }
        private void HandleCityNameContent()
        {
            string cityName = CityCustomTextBox.TextContent;
            string error = "";
            if (CityCustomTextBox.isPlaceHolder())
            {
                CityCustomTextBox.BorderColor = Color.MediumSlateBlue;
            }
            else
            {
                if (!StringHandler.IsAlphaOrWhiteSpace(cityName))
                {
                    error += "The city can only contain letters and white spaces\r\n";
                }
                int length = StringHandler.LengthWithoutWhiteSpace(cityName);

                if (length < 4)
                {
                    error += "The city name must be longer than 4 letters";
                }
                else if (length >= 60)
                {
                    error += "The city name must be shorter than 60 letters (included)";
                }


                if (error != "")
                {
                    CityCustomTextBox.BorderColor = Color.Red;
                    CityExclamationCustomButton.Visible = true;
                    ToolTip.SetToolTip(CityExclamationCustomButton, error);
                }
                else
                {
                    CityExclamationCustomButton.Visible = false;
                    CityCustomTextBox.BorderColor = Color.LimeGreen;
                }
            }
        }

        private void LastNameCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleLastNameContent();

        }


        private void GenderOptionsCustomComboBox_Enter(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsCustomComboBox.TextContent = "";
            }
        }

        private void GenderOptionsCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.TextContent != "<Select A Gender>")
            {
                //Gender = GenderOptionsCustomComboBox.Text;
                //RegistButtonSetEnabled();
            }
            if (GenderOptionsCustomComboBox.TextContent == "Other...")
            {
                GenderOptionsCustomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            }
            else
            {
                GenderOptionsCustomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }

        private void GenderOptionsCustomComboBox_OnTextUpdate(object sender, EventArgs e)
        {
            if (GenderOptionsCustomComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            {
                GenderOptionsCustomComboBox.TextContent = "";
            }
        }

        private void SignUpCustomButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("good job");
            string RegistrationDate = DateTime.Today.ToString("yyyy-MM-dd");
            List<string[]> VerificationQuestionsAndAnswers = GenerateVerificationQuestionListOfArrays();
            //RegistrationInformation registrationInformation = new RegistrationInformation(username, password, firstname, lastname, email, city, Gender, BirthDateDateTimePicker.Value, DateTime.Today, VerificationQuestionsAndAnswers);
            //string chatDetailsJson = JsonConvert.SerializeObject(registrationInformation);
            //ServerCommunication.SendMessage(ServerCommunication.registerRequest, chatDetailsJson);
        }
        private List<string[]> GenerateVerificationQuestionListOfArrays()
        {
            List<string[]> VerificationQuestionsAndAnswers = new List<string[]>();
            VerificationQuestionDetails verificationQuestionDetails;
            string Question;
            string Answer;
            for (int i = 0; i < 5; i++)
            {
                verificationQuestionDetails = VerificationQuestionHandler.VerificationQuestionDetails[i];
                Question = verificationQuestionDetails.Question;
                Answer = verificationQuestionDetails.Answer;
                VerificationQuestionsAndAnswers.Add(new string[] { Question, Answer });
            }
            return VerificationQuestionsAndAnswers;
        }

        private void RegisterDetails(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
        }
        private void ContinueCustomButtonSetEnabled()
        {
            if ((FirstNameCustomTextBox.BorderColor == Color.LimeGreen) && (PasswordGeneratorControl.IsSamePassword()) && (FirstNameCustomTextBox.BorderColor == Color.LimeGreen) && (LastNameCustomTextBox.BorderColor == Color.LimeGreen) && /*(EmailAddressCustomTextBox.BorderColor == Color.LimeGreen) &&*/ (CityCustomTextBox.BorderColor == Color.LimeGreen) && (BirthDateCustomDateTimePicker.CustomFormat != " ")  /*&&(RadioButtonIsChecked()) &&  (VerificationQuestionHandler.wasSelected)*/)
                ContinueCustomButton.Enabled = true;
            else
                ContinueCustomButton.Enabled = false;
        }

        private void ContinueCustomButton_Click(object sender, EventArgs e)
        {
            //PersonalVerificationQuestionsControl.Visible = true;
        }

        private void LoginReturnerCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServerCommunication._login = new Login();
            ServerCommunication._login.ShowDialog();
        }

        private void FemaleRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
            GenderOptionsCustomComboBox.Visible = false;
            if (FemaleButtonIsChecked == false)
            {
                FemaleButtonIsChecked = true;
                Gender = "Female";
            }
            else
            {
                FemaleButtonIsChecked = false;
                Gender = "";
            }
            if (FemaleButtonIsChecked == true)
            {
                FemaleRadioButton.Checked = true;

            }
            else
            {
                FemaleRadioButton.Checked = false;
            }
            ContinueCustomButtonSetEnabled();
        }

        private void AnotherGenderRadioButton_Click(object sender, EventArgs e)
        {
            MaleButtonIsChecked = false;
            FemaleButtonIsChecked = false;
            if (AnotherGenderButtonIsChecked == false)
            {
                GenderOptionsCustomComboBox.Visible = true;
                AnotherGenderButtonIsChecked = true;
            }
            else
            {
                GenderOptionsCustomComboBox.Visible = false;
                AnotherGenderButtonIsChecked = false;
                Gender = "";
            }
            if (AnotherGenderButtonIsChecked == true)
            {
                AnotherGenderRadioButton.Checked = true;

            }
            else
            {
                AnotherGenderRadioButton.Checked = false;
            }//יכול להיות חכם לעשות מערך של שלושת הכפתורים, ואז בקלט לקבל גם מספר שמייצג מיקום
            ContinueCustomButtonSetEnabled();
        }

        private void CityCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCityNameContent();
        }

        private void FirstNameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
            HandleFirstNameContent();
        }

        private void LastNameCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
            HandleLastNameContent();
        }

        private void EmailAddressCustomTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void CityCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            ContinueCustomButtonSetEnabled();
            HandleCityNameContent();
        }

        private void BirthDateCustomDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BirthDateCustomDateTimePicker.CustomFormat = "dd/MM/yyyy";
            ContinueCustomButtonSetEnabled();
        }

        private void BirthDateCustomDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                RestartBirthDateCustomDateTimePickerContent();
            }
        }

        private void RestartBirthDateCustomButton_Click(object sender, EventArgs e)
        {
            RestartBirthDateCustomDateTimePickerContent();
        }
        private void RestartBirthDateCustomDateTimePickerContent()
        {
            BirthDateCustomDateTimePicker.CustomFormat = " ";
            ContinueCustomButtonSetEnabled();
        }

        private void MaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            GenderOptionsCustomComboBox.SelectedIndex = 0; // Automatically select the placeholder item
        }

        private void MaleRadioButton_Click(object sender, EventArgs e)
        {
            FemaleButtonIsChecked = false;
            AnotherGenderButtonIsChecked = false;
            GenderOptionsCustomComboBox.Visible = false;
            if (MaleButtonIsChecked == false)
            {
                MaleButtonIsChecked = true;
                Gender = "Male";
            }
            else
            {
                MaleButtonIsChecked = false;
                Gender = "";
            }
            if (MaleButtonIsChecked == true)
            {
                MaleRadioButton.Checked = true;

            }
            else
            {
                MaleRadioButton.Checked = false;

            }
            ContinueCustomButtonSetEnabled();
        }

        private Boolean RadioButtonIsChecked()
        {
            return (MaleButtonIsChecked || FemaleButtonIsChecked || (AnotherGenderButtonIsChecked && (GenderOptionsCustomComboBox.TextContent != "<Select A Gender>")));
        }
    }
}
