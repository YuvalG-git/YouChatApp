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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.UserAuthentication.Forms
{
    /// <summary>
    /// The "Login" class represents the main login form for the application.
    /// It handles the user's login process, including sending verification codes, captcha challenges, and personal verification questions.
    /// </summary>
    /// <remarks>
    /// This form provides the user interface for logging into the application.
    /// It includes functionality for verifying the user's identity through various means such as email verification codes, captcha challenges, and personal verification questions.
    /// </remarks>
    public partial class Login : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly ServerCommunicator "serverCommunicator" represents the server communicator instance.
        /// </summary>
        private readonly ServerCommunicator serverCommunicator;

        #endregion

        #region Private Fields

        /// <summary>
        /// The EnumHandler.LoginPhases_Enum "loginPhase" represents the current phase of the login process.
        /// </summary>
        private EnumHandler.LoginPhases_Enum loginPhase;

        #endregion

        #region Constructors

        /// <summary>
        /// The "Login" constructor initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new Login instance and set up its components.
        /// It initializes the server communicator instance, sets the login form in the FormHandler, and adds event handlers for
        /// restarting the SMTP code sending process, verifying the SMTP code, sending the captcha code, restarting the captcha image, 
        /// approving the verification information, and sending the captcha angle. It also sets the login phase to the Login phase.
        /// </remarks>
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

        #endregion

        #region Private Personal Verification Methods

        /// <summary>
        /// The "SendPersonalVerificationAnswers" method sends the user's personal verification answers to the server for verification.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the personal verification answers from the PersonalVerificationAnswersControl and sends them to the server as a message.
        /// </remarks>
        private void SendPersonalVerificationAnswers(object sender, EventArgs e)
        {
            PersonalVerificationAnswers personalVerificationAnswers = PersonalVerificationAnswersControl.GetPersonalVerificationAnswers();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.PersonalVerificationAnswersRequest;
            object messageContent = personalVerificationAnswers;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Private Captcha Methods

        /// <summary>
        /// The "RequestCaptchaBitmap" method is used to request a captcha image from the server for authentication.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if there was a failed attempt to submit the captcha code by inspecting the visibility of the notification label.
        /// It then sends a captcha image request to the server with the information about the previous attempt.
        /// </remarks>
        private void RequestCaptchaBitmap(object sender, EventArgs e)
        {
            bool afterFail = CaptchaCodeControl.IsNotificationLabelVisible();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.CaptchaImageRequest;
            object messageContent = afterFail;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "SendCaptchaCode" method is used to send the entered captcha code to the server for verification.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the entered captcha code using the GetCaptchaCode method from the CaptchaCodeControl.
        /// It then sends a captcha code request to the server with the entered code as the message content.
        /// </remarks>
        private void SendCaptchaCode(object sender, EventArgs e)
        {
            string enteredCaptchaCode = CaptchaCodeControl.GetCaptchaCode();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.CaptchaCodeRequest;
            object messageContent = enteredCaptchaCode;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "SendCaptchaAngle" method is used to send the current angle of the captcha image to the server.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the current angle of the captcha image using the GetAngle method from the CaptchaRotatingImageControl.
        /// It then sends a captcha image angle request to the server with the angle as the message content.
        /// </remarks>
        private void SendCaptchaAngle(object sender, EventArgs e)
        {
            double captchaImageAngle = CaptchaRotatingImageControl.GetAngle();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.CaptchaImageAngleRequest;
            object messageContent = captchaImageAngle;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Private SMTP Methods

        /// <summary>
        /// The "SendSmtpCode" method is used to send the SMTP login code to the server for verification.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the SMTP login code from the SmtpControl using the GetCode method.
        /// It then sends a login request with the SMTP login code as the message content to the server.
        /// </remarks>
        private void SendSmtpCode(object sender, EventArgs e)
        {
            string enteredSmtpCode = SmtpControl.GetCode();
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.LoginRequest_SmtpLoginCode;
            object messageContent = enteredSmtpCode;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "HandleSendingEmailProcess" method is used to handle the process of requesting an email for the login process.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "HandleSendingEmailProcess" method to request the email.
        /// </remarks>
        private void HandleSendingEmailProcess(object sender, EventArgs e)
        {
            HandleSendingEmailProcess();
        }

        /// <summary>
        /// The "HandleSendingEmailProcess" method is used to handle the process of requesting an email for the login process.
        /// </summary>
        /// <remarks>
        /// This method retrieves the SMTP verification object using the GetSmtpDetailsObject method.
        /// It then sends a login request to the server with the SMTP verification object as the message content.
        /// </remarks>
        private void HandleSendingEmailProcess()
        {
            string username = UsernameCustomTextBox.TextContent;
            bool afterFail = SmtpControl.IsAfterFail();
            SmtpVerification smtpVerification = new SmtpVerification(username, afterFail);
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.loginRequest_SmtpLoginMessage;
            object messageContent = smtpVerification;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "LoginFieldsTextChangedEvent" method handles the TextChanged event for the login fields.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the username and password fields have values.
        /// If both fields have values, it enables the LoginCustomButton; otherwise, it disables it.
        /// </remarks>
        private void LoginFieldsTextChangedEvent(object sender, EventArgs e)
        {
            if (UsernameCustomTextBox.IsContainingValue() && PasswordGeneratorControl.DoesAllFieldsHaveValue())
                LoginCustomButton.Enabled = true;
            else
                LoginCustomButton.Enabled = false;
        }

        /// <summary>
        /// The "LoginCustomButton_Click" method is used to handle the click event of the LoginCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method retrieves the username and password from the UsernameCustomTextBox and PasswordGeneratorControl respectively.
        /// It then disables the LoginCustomButton, creates a LoginDetails object with the username and password,
        /// and sends a login request message to the server with the LoginDetails object as the message content.
        /// </remarks>
        private void LoginCustomButton_Click(object sender, EventArgs e)
        {
            string username = UsernameCustomTextBox.TextContent;
            string password = PasswordGeneratorControl.GetNewPassword();
            LoginCustomButton.Enabled = false;
            LoginDetails userLoginDetails = new LoginDetails(username, password);
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.loginRequest;
            object messageContent = userLoginDetails;
            serverCommunicator.SendMessage(messageType, messageContent);
        }

        /// <summary>
        /// The "Login_FormClosing" method is used to handle the form's closing event.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sends a Disconnect message to the server to indicate that the client is disconnecting.
        /// It then disconnects the server communicator and exits the application's message loop thread.
        /// </remarks>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = EnumHandler.CommunicationMessageID_Enum.Disconnect;
            object messageContent = null;
            serverCommunicator.SendMessage(messageType, messageContent);
            serverCommunicator.Disconnect();
            System.Windows.Forms.Application.ExitThread();
        }

        #endregion

        #region Public Personal Verification Methods

        /// <summary>
        /// The "SetPersonalVerificationQuestions" method is used to set the personal verification questions for the user.
        /// </summary>
        /// <param name="personalVerificationQuestions">The personal verification questions to set.</param>
        /// <remarks>
        /// This method sets the login phase to VerificationQuestion and makes the PersonalVerificationAnswersControl visible.
        /// It then sets the questions using the SetQuestions method of the PersonalVerificationAnswersControl.
        /// </remarks>
        public void SetPersonalVerificationQuestions(PersonalVerificationQuestions personalVerificationQuestions)
        {
            loginPhase = EnumHandler.LoginPhases_Enum.VerificationQuestion;
            PersonalVerificationAnswersControl.Visible = true;
            PersonalVerificationAnswersControl.SetQuestions(personalVerificationQuestions);
        }

        /// <summary>
        /// The "HandleWrongPersonalVerificationAnswers" method is used to handle the situation when the user provides incorrect personal verification answers.
        /// </summary>
        /// <remarks>
        /// This method triggers the PersonalVerificationAnswersControl to disable the cancel option, indicating that the user cannot cancel the verification process.
        /// </remarks>
        public void HandleWrongPersonalVerificationAnswers()
        {
            PersonalVerificationAnswersControl.CancelDisabled();
        }

        #endregion

        #region Public SMTP Methods

        /// <summary>
        /// The "HandleRecievedEmail" method handles the process after an email is received during the login phase.
        /// </summary>
        /// <remarks>
        /// This method sets the login phase to Smtp, making the SmtpControl visible.
        /// It also disables the ResetPasswordCustomButton and SignUpCustomButton.
        /// Finally, it calls SmtpControl.HandleCode() to handle the received email code.
        /// </remarks>
        public void HandleRecievedEmail()
        {
            loginPhase = EnumHandler.LoginPhases_Enum.Smtp;
            SmtpControl.Visible = true;
            ResetPasswordCustomButton.Enabled = false;
            SignUpCustomButton.Enabled = false;
            SmtpControl.HandleCode();
        }

        /// <summary>
        /// The "HandleCorrectCodeResponse" method is used to handle the response when a correct code is received.
        /// </summary>
        /// <param name="captchaCodeImage">The captcha code image to be displayed.</param>
        /// <remarks>
        /// This method sets the login phase to CaptchaCode.
        /// It makes the CaptchaCodeControl visible and sets the captcha code image using the SetCaptchaImage method.
        /// </remarks>
        public void HandleCorrectCodeResponse(Image captchaCodeImage)
        {
            loginPhase = EnumHandler.LoginPhases_Enum.CaptchaCode;
            CaptchaCodeControl.Visible = true;
            CaptchaCodeControl.SetCaptchaImage(captchaCodeImage);
        }

        /// <summary>
        /// The "HandleWrongCodeResponse" method is used to handle the response when an incorrect code is received.
        /// </summary>
        /// <remarks>
        /// This method calls the HandleWrongCodeCase method of the SmtpControl to handle the incorrect code response.
        /// </remarks>
        public void HandleWrongCodeResponse()
        {
            SmtpControl.HandleWrongCodeCase();
        }

        #endregion

        #region Public Captcha Methods

        /// <summary>
        /// The "HandleSuccessfulCaptchaImageAngleResponse" method handles the successful response for the captcha image angle request.
        /// </summary>
        /// <param name="personalVerificationQuestions">The personal verification questions to set.</param>
        /// <param name="score">The score indicating the success rate of the captcha solving process.</param>
        /// <param name="attempts">The number of attempts made to solve the captcha.</param>
        /// <remarks>
        /// This method sets the personal verification questions using the SetPersonalVerificationQuestions method.
        /// It then handles the success rate of the captcha solving process and disables the CaptchaRotatingImageControl.
        /// </remarks>
        public void HandleSuccessfulCaptchaImageAngleResponse(PersonalVerificationQuestions personalVerificationQuestions, int score, int attempts)
        {
            SetPersonalVerificationQuestions(personalVerificationQuestions);
            CaptchaRotatingImageControl.HandleSuccessRate(score, attempts);
            CaptchaRotatingImageControl.Enabled = false;
        }

        /// <summary>
        /// The "HandleCaptchaImageRenewal" method handles the renewal of the captcha image.
        /// </summary>
        /// <param name="captchaCodeImage">The new captcha image to be displayed.</param>
        /// <remarks>
        /// This method sets the new captcha image to be displayed in the CaptchaCodeControl.
        /// </remarks>
        public void HandleCaptchaImageRenewal(Image captchaCodeImage)
        {
            CaptchaCodeControl.SetCaptchaImage(captchaCodeImage);
        }

        /// <summary>
        /// The "HandleCorrectCaptchaCode" method handles the case when the user enters the correct captcha code.
        /// </summary>
        /// <param name="captchaCircularImage">The circular captcha image.</param>
        /// <param name="captchaImage">The regular captcha image.</param>
        /// <param name="score">The score indicating the success rate of the captcha verification.</param>
        /// <param name="attempts">The number of attempts made for captcha verification.</param>
        /// <remarks>
        /// This method sets the circular and regular captcha images and the success rate information in the CaptchaRotatingImageControl.
        /// </remarks>
        public void HandleCorrectCaptchaCode(Image captchaCircularImage, Image captchaImage, int score, int attempts)
        {
            loginPhase = EnumHandler.LoginPhases_Enum.CaptchaRotatingImage;
            CaptchaRotatingImageControl.Visible = true;
            CaptchaRotatingImageControl.SetCaptchaImages(captchaCircularImage, captchaImage,score,attempts);
        }

        /// <summary>
        /// The "HandleWrongCaptchaCode" method handles the case when the user enters the wrong captcha code.
        /// </summary>
        /// <remarks>
        /// This method triggers the CaptchaCodeControl to handle the wrong code case, displaying an appropriate message.
        /// </remarks>
        public void HandleWrongCaptchaCode()
        {
            CaptchaCodeControl.HandleWrongCodeCase();
        }

        #endregion

        #region Public Ban Handling Methods

        /// <summary>
        /// The "HandleBan" method handles the ban process.
        /// </summary>
        /// <param name="banDuration">The duration of the ban in seconds.</param>
        /// <remarks>
        /// This method sets the visibility of the BanControl to true and handles the ban duration.
        /// It then sets the visibility of the current form to false.
        /// </remarks>
        public void HandleBan(double banDuration)
        {
            BanControl.Visible = true;
            BanControl.HandleBan(banDuration);
            SetVisibility(false);
        }

        /// <summary>
        /// The "HandleBanOver" method handles the end of a ban process.
        /// </summary>
        /// <param name="captchaCircularImage">The circular captcha image to display.</param>
        /// <param name="captchaImage">The captcha image to display.</param>
        /// <param name="score">The captcha success rate score.</param>
        /// <param name="attempts">The number of captcha attempts.</param>
        /// <remarks>
        /// This method sets the visibility of the BanControl to false.
        /// It then sets the visibility of the current form to true, along with optional captcha images and score.
        /// </remarks>
        public void HandleBanOver(Image captchaCircularImage = null, Image captchaImage = null, int score = 0, int attempts = 5)
        {
            BanControl.Visible = false;
            SetVisibility(true, captchaCircularImage, captchaImage, score, attempts);
        }

        /// <summary>
        /// The "SetVisibility" method sets the visibility of various controls based on the current login phase.
        /// </summary>
        /// <param name="visible">A flag indicating whether the controls should be visible.</param>
        /// <param name="captchaCircularImage">The circular captcha image to display.</param>
        /// <param name="captchaImage">The captcha image to display.</param>
        /// <param name="score">The captcha success rate score.</param>
        /// <param name="attempts">The number of captcha attempts.</param>
        /// <remarks>
        /// This method iterates through the login phases up to the current phase and sets the visibility of controls accordingly.
        /// It also handles specific actions for each control based on the current phase, such as handling wrong code cases or setting captcha images.
        /// </remarks>
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

        #endregion

        #region Public Form Opening Methods

        /// <summary>
        /// The "SignUpCustomButton_Click" method is used to handle the click event of the SignUpCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method hides the current form and shows the registration form using FormHandler._registration.
        /// </remarks>
        private void SignUpCustomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHandler._registration = new Registration();
            this.Invoke(new Action(() => FormHandler._registration.ShowDialog()));
        }

        /// <summary>
        /// The "HandlePasswordUpdateCase" method is used to handle the case where a password update is required.
        /// </summary>
        /// <remarks>
        /// This method hides the current form (presumably the login form) and shows the password update form.
        /// </remarks>
        public void HandlePasswordUpdateCase()
        {
            this.Hide(); // Hide the login form
            FormHandler._passwordUpdate = new PasswordUpdate();
            this.Invoke(new Action(() => FormHandler._passwordUpdate.Show()));
        }

        /// <summary>
        /// The "OpenStatusSelector" method is used to open the profile status selector form.
        /// </summary>
        /// <remarks>
        /// This method hides the current form and shows the profile status selector form.
        /// </remarks>
        public void OpenStatusSelector()
        {
            this.Hide();
            FormHandler._profileStatusSelector = new ProfileStatusSelector();
            this.Invoke(new Action(() => FormHandler._profileStatusSelector.Show()));
        }

        /// <summary>
        /// The "OpenProfilePictureSelector" method is used to open the profile picture selector form.
        /// </summary>
        /// <remarks>
        /// This method hides the current form and shows the profile picture selector form.
        /// </remarks>
        public void OpenProfilePictureSelector()
        {
            this.Hide();
            FormHandler._profilePictureSelector = new ProfilePictureSelector();
            this.Invoke(new Action(() => FormHandler._profilePictureSelector.Show()));
        }

        /// <summary>
        /// The "OpenApp" method is used to open the YouChat application.
        /// </summary>
        /// <remarks>
        /// This method hides the current form and shows the YouChat form.
        /// </remarks>
        public void OpenApp()
        {
            this.Hide();
            FormHandler._youChat = new YouChat();
            this.Invoke(new Action(() => FormHandler._youChat.Show()));
        }

        /// <summary>
        /// The "ResetPasswordCustomButton_Click" method handles the click event of the ResetPasswordCustomButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method creates a new instance of the PasswordRestart form and shows it as a dialog.
        /// </remarks>
        private void ResetPasswordCustomButton_Click(object sender, EventArgs e)
        {
            FormHandler._passwordRestart = new PasswordRestart();
            this.Invoke(new Action(() => FormHandler._passwordRestart.ShowDialog()));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "setLoginButtonEnabled" method disables the login button.
        /// </summary>
        public void setLoginButtonEnabled()
        {
            LoginCustomButton.Enabled = false;
        }

        #endregion
    }
}
