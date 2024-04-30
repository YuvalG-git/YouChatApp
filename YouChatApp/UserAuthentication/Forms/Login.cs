﻿using Newtonsoft.Json;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.UserAuthentication.Forms
{
    public partial class Login : Form
    {
        EnumHandler.LoginPhases_Enum loginPhase;
        private readonly ServerCommunicator serverCommunicator;
        public Login()
        {
            InitializeComponent();
            serverCommunicator = ServerCommunicator.Instance;
            FormHandler._login = this;
            SmtpControl.AddRestartSmtpCodeCustomButtonClickHandler(HandleSendingEmailProcess);
            SmtpControl.AddVerifyCustomButtonClickHandler(SendSmtpCode);
            CaptchaCodeControl.AddCaptchaCheckerCustomButtonClickHandler(SendCaptchaCode);
            CaptchaCodeControl.AddRestartCaptchaCustomButtonClickHandler(RequestCaptchaBitmap);
            PersonalVerificationAnswersControl.AddApproveVerificationInformationCustomButtonClickHandler(SendPersonalVerificationAnswers);
            CaptchaRotatingImageControl.AddCaptchaCheckerCustomButtonClickHandler(SendCaptchaAngle);
            loginPhase = EnumHandler.LoginPhases_Enum.Login;
        }
        public void HandleWrongPersonalVerificationAnswers()
        {
            PersonalVerificationAnswersControl.CancelDisabled();
        }
        public void SendPersonalVerificationAnswers(object sender, EventArgs e)
        {
            PersonalVerificationAnswers personalVerificationAnswers = PersonalVerificationAnswersControl.GetPersonalVerificationAnswers();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.PersonalVerificationAnswersRequest;
            object messageContent = personalVerificationAnswers;
            serverCommunicator.SendMessage(messageType, messageContent);


        }
        public void RequestCaptchaBitmap(object sender, EventArgs e)
        {
            bool afterFail = CaptchaCodeControl.IsNotificationLabelVisible();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.CaptchaImageRequest;
            object messageContent = afterFail;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void SendCaptchaCode(object sender, EventArgs e)
        {
            string enteredCaptchaCode = CaptchaCodeControl.GetCaptchaCode();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.CaptchaCodeRequest;
            object messageContent = enteredCaptchaCode;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void SendCaptchaAngle(object sender, EventArgs e)
        {
            double captchaImageAngle = CaptchaRotatingImageControl.GetAngle();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.CaptchaImageAngleRequest;
            object messageContent = captchaImageAngle;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.LoginRequest_SmtpLoginCode;
            object messageContent = enteredSmtpCode;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void HandleCorrectCodeResponse(Image captchaCodeImage)
        {
            loginPhase = EnumHandler.LoginPhases_Enum.CaptchaCode;
            CaptchaCodeControl.Visible = true;
            CaptchaCodeControl.SetCaptchaImage(captchaCodeImage);
        }
        public void HandleWrongCodeResponse()
        {
            SmtpControl.HandleWrongCodeCase();

        }
        public void SetPersonalVerificationQuestions(PersonalVerificationQuestions personalVerificationQuestions)
        {
            loginPhase = EnumHandler.LoginPhases_Enum.VerificationQuestion;
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
            loginPhase = EnumHandler.LoginPhases_Enum.CaptchaRotatingImage;
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
            bool afterFail = SmtpControl.IsAfterFail();
            SmtpVerification smtpVerification = new SmtpVerification(username, afterFail);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.loginRequest_SmtpLoginMessage;
            object messageContent = smtpVerification;
            serverCommunicator.SendMessage(messageType, messageContent);
        }
        public void HandlePasswordUpdateCase()
        {
            this.Hide(); // Hide the login form
            FormHandler._passwordUpdate = new PasswordUpdate();
            this.Invoke(new Action(() => FormHandler._passwordUpdate.Show()));
        }
        public void OpenStatusSelector()
        {
            this.Hide();
            FormHandler._profileStatusSelector = new ProfileStatusSelector();
            this.Invoke(new Action(() => FormHandler._profileStatusSelector.Show()));
        }
        public void OpenProfilePictureSelector()
        {
            this.Hide();
            FormHandler._profilePictureSelector = new ProfilePictureSelector();
            this.Invoke(new Action(() => FormHandler._profilePictureSelector.Show()));
        }
        public void OpenApp()
        {
            this.Hide();
            FormHandler._youChat = new YouChat();
            this.Invoke(new Action(() => FormHandler._youChat.Show()));
        }

        private void ResetPasswordCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._passwordRestart = new PasswordRestart();
            this.Invoke(new Action(() => FormHandler._passwordRestart.ShowDialog()));
        }
        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            SetVisibility(false);
        }
        public void HandleBanOver(Image captchaCircularImage = null, Image captchaImage = null, int score = 0, int attempts = 5)
        {
            BanControl.Visible = false;
            SetVisibility(true, captchaCircularImage, captchaImage, score, attempts);
        }
        public void SetVisibility(bool visible, Image captchaCircularImage = null, Image captchaImage = null, int score = 0, int attempts = 5)
        {
            for (int i = 0; i <= (int)loginPhase; i++)
            {
                EnumHandler.LoginPhases_Enum currentEnumValue = (EnumHandler.LoginPhases_Enum)i;

                switch (currentEnumValue)
                {
                    case EnumHandler.LoginPhases_Enum.Login:
                        LoginPanel.Visible = visible;
                        break;
                    case EnumHandler.LoginPhases_Enum.Smtp:
                        SmtpControl.Visible = visible;
                        if (currentEnumValue == loginPhase)
                        {
                            SmtpControl.HandleWrongCodeCase();
                        }
                        break;
                    case EnumHandler.LoginPhases_Enum.CaptchaCode:
                        CaptchaCodeControl.Visible = visible;
                        if (currentEnumValue == loginPhase)
                        {
                            CaptchaCodeControl.HandleWrongCodeCase();
                        }
                        break;
                    case EnumHandler.LoginPhases_Enum.CaptchaRotatingImage:
                        CaptchaRotatingImageControl.Visible = visible;
                        if (visible && currentEnumValue == loginPhase)
                        {
                            CaptchaRotatingImageControl.SetCaptchaImages(captchaCircularImage, captchaImage, score, attempts);
                        }
                        break;
                    case EnumHandler.LoginPhases_Enum.VerificationQuestion:
                        PersonalVerificationAnswersControl.Visible = visible;
                        if (currentEnumValue == loginPhase)
                        {
                            PersonalVerificationAnswersControl.CancelDisabled();
                        }
                        break;
                }
            }
        }


        private void SignUpCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHandler._registration = new Registration();
            this.Invoke(new Action(() => FormHandler._registration.ShowDialog()));
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
            loginPhase = EnumHandler.LoginPhases_Enum.Smtp;
            SmtpControl.Visible = true;
            ResetPasswordCustomButton.Enabled = false;
            SignUpCustomButton.Enabled = false;
            SmtpControl.HandleCode();
        }
        public void setLoginButtonEnabled()
        {
            LoginCustomButton.Enabled = false;
        }
        private void LoginCustomButton_Click(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string password = PasswordGeneratorControl.GetNewPassword();
            LoginCustomButton.Enabled = false;
            //string userLoginDetails = username + "#" + password;
            LoginDetails userLoginDetails = new LoginDetails(username, password);

            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.loginRequest;
            object messageContent = userLoginDetails;
            serverCommunicator.SendMessage(messageType, messageContent);

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.Disconnect;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);
            serverCommunicator.Disconnect();
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
