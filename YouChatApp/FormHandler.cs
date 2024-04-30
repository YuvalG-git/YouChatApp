using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.AttachedFiles;
using YouChatApp.AttachedFiles.CallHandler;
using YouChatApp.AttachedFiles.CameraHandler;
using YouChatApp.UserAuthentication.Forms;

namespace YouChatApp
{
    /// <summary>
    /// The "FormHandler" class manages references to various forms used in the application.
    /// </summary>
    /// <remarks>
    /// This class provides static references to different forms used in the application, allowing easy access to them from various parts of the codebase.
    /// </remarks>
    internal class FormHandler
    {
        #region Public Static Fields

        /// <summary>
        /// The static Login "_login" represents the login form.
        /// </summary>
        public static Login _login;

        /// <summary>
        /// The static Registration "_registration" represents the registration form.
        /// </summary>
        public static Registration _registration;

        /// <summary>
        /// The static PasswordUpdate "_passwordUpdate" represents the password update form.
        /// </summary>
        public static PasswordUpdate _passwordUpdate;

        /// <summary>
        /// The static PasswordRestart "_passwordRestart" represents the password restart form.
        /// </summary>
        public static PasswordRestart _passwordRestart;

        /// <summary>
        /// The static Profile "_profile" represents the profile form.
        /// </summary>
        public static Profile _profile;

        /// <summary>
        /// The static YouChat "_youChat" represents the main chat window.
        /// </summary>
        public static YouChat _youChat;

        /// <summary>
        /// The static EmojiKeyboard "_emojiKeyboard" represents the emoji keyboard.
        /// </summary>
        public static EmojiKeyboard _emojiKeyboard = null;

        /// <summary>
        /// The static ContactSharing "_contactSharing" represents the contact sharing form.
        /// </summary>
        public static ContactSharing _contactSharing = null;

        /// <summary>
        /// The static Camera "_camera" represents the camera form.
        /// </summary>
        public static Camera _camera = null;

        /// <summary>
        /// The static VideoCall "_videoCall" represents the video call form.
        /// </summary>
        public static VideoCall _videoCall;

        /// <summary>
        /// The static AudioCall "_audioCall" represents the audio call form.
        /// </summary>
        public static AudioCall _audioCall;

        /// <summary>
        /// The static WaitingForm "_waitingForm" represents the waiting form.
        /// </summary>
        public static WaitingForm _waitingForm;

        /// <summary>
        /// The static CallInvitation "_callInvitation" represents the call invitation form.
        /// </summary>
        public static CallInvitation _callInvitation;

        /// <summary>
        /// The static AttachedFiles.PaintHandler.Paint "_paint" represents the paint form.
        /// </summary>
        public static AttachedFiles.PaintHandler.Paint _paint = null;

        /// <summary>
        /// The static ImageSender "_imageSender" represents the image sender.
        /// </summary>
        public static ImageSender _imageSender;

        /// <summary>
        /// The static ImageViewer "_imageViewer" represents the image viewer.
        /// </summary>
        public static ImageViewer _imageViewer;

        /// <summary>
        /// The static ProfilePictureSelector "_profilePictureSelector" represents the profile picture selector form.
        /// </summary>
        public static ProfilePictureSelector _profilePictureSelector;

        /// <summary>
        /// The static ProfileStatusSelector "_profileStatusSelector" represents the profile status selector form.
        /// </summary>
        public static ProfileStatusSelector _profileStatusSelector;

        #endregion
    }
}
