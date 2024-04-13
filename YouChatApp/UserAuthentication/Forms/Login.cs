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
using YouChatApp.Controls;
using YouChatApp.JsonClasses;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            ServerCommunication.Connect("10.100.102.3");
            ServerCommunication._login = this;
            SmtpControl.AddRestartSmtpCodeCustomButtonClickHandler(HandleSendingEmailProcess);
            SmtpControl.AddVerifyCustomButtonClickHandler(SendSmtpCode);
            CaptchaCodeControl.AddCaptchaCheckerCustomButtonClickHandler(SendCaptchaCode);
            CaptchaCodeControl.AddRestartCaptchaCustomButtonClickHandler(RequestCaptchaBitmap);
            PersonalVerificationAnswersControl.AddApproveVerificationInformationCustomButtonClickHandler(SendPersonalVerificationAnswers);
            CaptchaRotatingImageControl.AddCaptchaCheckerCustomButtonClickHandler(SendCaptchaAngle);
        }
        public void HandleWrongPersonalVerificationAnswers()
        {
            PersonalVerificationAnswersControl.CancelDisabled();
        }
        public void SendPersonalVerificationAnswers(object sender, EventArgs e)
        {
            PersonalVerificationAnswers personalVerificationAnswers = PersonalVerificationAnswersControl.GetPersonalVerificationAnswers();
            JsonObject personalVerificationAnswersJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.PersonalVerificationAnswersRequest, personalVerificationAnswers);
            string personalVerificationAnswersJson = JsonConvert.SerializeObject(personalVerificationAnswersJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(personalVerificationAnswersJson);
        }
        public void RequestCaptchaBitmap(object sender, EventArgs e)
        {
            JsonObject captchaImageRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.CaptchaImageRequest, null);
            string captchaImageRequestJson = JsonConvert.SerializeObject(captchaImageRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(captchaImageRequestJson);
        }
        public void SendCaptchaCode(object sender, EventArgs e)
        {
            string enteredCaptchaCode = CaptchaCodeControl.GetCaptchaCode();
            JsonObject CaptchaCodeRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.CaptchaCodeRequest, enteredCaptchaCode);
            string CaptchaCodeRequestJson = JsonConvert.SerializeObject(CaptchaCodeRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(CaptchaCodeRequestJson);
        }
        public void SendCaptchaAngle(object sender, EventArgs e)
        {
            double captchaImageAngle = CaptchaRotatingImageControl.GetAngle();
            JsonObject CaptchaAngleRequestJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.CaptchaImageAngleRequest, captchaImageAngle);
            string CaptchaAngleRequestJson = JsonConvert.SerializeObject(CaptchaAngleRequestJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(CaptchaAngleRequestJson);
        }
        public void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.LoginRequest_SmtpLoginCode, enteredSmtpCode);
            string enteredSmtpCodeJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(enteredSmtpCodeJson);
        }
        public void HandleCorrectCodeResponse(Image captchaCodeImage)
        {
            CaptchaCodeControl.Visible = true;
            CaptchaCodeControl.SetCaptchaImage(captchaCodeImage);
        }
        public void HandleWrongCodeResponse()
        {
            SmtpControl.HandleWrongCodeCase();

        }
        public void SetPersonalVerificationQuestions(PersonalVerificationQuestions personalVerificationQuestions)
        {
            PersonalVerificationAnswersControl.Visible = true;
            PersonalVerificationAnswersControl.SetQuestions(personalVerificationQuestions);
        }
        public void HandleSuccessfulCaptchaImageAngleResponse(PersonalVerificationQuestions personalVerificationQuestions, int score, int attempts)
        {
            SetPersonalVerificationQuestions(personalVerificationQuestions);
            CaptchaRotatingImageControl.HandleSuccessRate(score, attempts);
            CaptchaRotatingImageControl.Enabled = false;
        }
        public void HandleCaptchaImageRenewal(Image captchaCodeImage)
        {
            CaptchaCodeControl.SetCaptchaImage(captchaCodeImage);
        }
        public void HandleCorrectCaptchaCode(Image captchaCircularImage, Image captchaImage, int score, int attempts)
        {
            CaptchaRotatingImageControl.Visible = true;
            CaptchaRotatingImageControl.SetCaptchaImages(captchaCircularImage, captchaImage,score,attempts);
        }
        public void HandleWrongCaptchaCode()
        {
            CaptchaCodeControl.HandleWrongCodeCase();
        }

        public void HandleSendingEmailProcess(object sender, EventArgs e)
        {
            HandleSendingEmailProcess();
        }
        private void HandleSendingEmailProcess()
        {
            string username = UsernameCustomTextBox.TextContent;
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.loginRequest_SmtpLoginMessage, username);
            string userUsernameJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(userUsernameJson);
        }
        public void HandlePasswordUpdateCase()
        {
            this.Hide(); // Hide the login form
            ServerCommunication._passwordUpdate = new PasswordUpdate();
            ServerCommunication._passwordUpdate.ShowDialog(); // Show the registration form
        }
        public void OpenInitialProfileSelection(Boolean IsPhaseOne)
        {
            this.Hide();
            ServerCommunication._initialProfileSelection = new InitialProfileSelection(IsPhaseOne);
            this.Invoke(new Action(() => ServerCommunication._initialProfileSelection.ShowDialog()));
        }
        public void OpenApp()
        {
            this.Hide();
            ServerCommunication._youChat = new YouChat();
            this.Invoke(new Action(() => ServerCommunication._youChat.ShowDialog()));
        }

        private void ResetPasswordCustomButton_Click(object sender, EventArgs e)
        {
            ServerCommunication._passwordRestart = new PasswordRestart();
            this.Invoke(new Action(() => ServerCommunication._passwordRestart.ShowDialog()));
        }

        private void SignUpCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the login form
            ServerCommunication._registration = new Registration();
            ServerCommunication._registration.ShowDialog(); // Show the registration form
        }

        private void LoginFieldsTextChangedEvent(object sender, EventArgs e)
        {
            if (UsernameCustomTextBox.IsContainingValue() && PasswordGeneratorControl.DoesAllFieldsHaveValue())
                LoginCustomButton.Enabled = true;
            else
                LoginCustomButton.Enabled = false;
        }

        private void PasswordGeneratorControl_Load(object sender, EventArgs e)
        {

        }
        public void HandleRecievedEmail()
        {
            SmtpControl.Visible = true;
            SmtpControl.HandleCode();
        }
        public void setLoginButtonEnabled()
        {
            LoginCustomButton.Enabled = true;
        }
        private void LoginCustomButton_Click(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string password = PasswordGeneratorControl.GetNewPassword();
            LoginCustomButton.Enabled = false;
            //string userLoginDetails = username + "#" + password;
            LoginDetails userLoginDetails = new LoginDetails(username, password);
            JsonObject jsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.loginRequest, userLoginDetails);
            string userLoginDetailsJson = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(userLoginDetailsJson);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            JsonObject disconnectJsonObject = new JsonObject(EnumHandler.CommunicationMessageID_Enum.Disconnect, null);
            string disconnectJson = JsonConvert.SerializeObject(disconnectJsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            ServerCommunication.SendMessage(disconnectJson);
            ServerCommunication.Disconnect();
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
