using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChatApp.AttachedFiles;
using YouChatApp.UserAuthentication.Forms;

namespace YouChatApp
{
    internal class FormHandler
    {
        /// <summary>
        /// Declares a variable of type LoginRegistPage which represents the loginRegistPage form's object and is used to perform actions on the form
        /// </summary>
        public static LoginAndRegistration loginAndRegistration;

        /// <summary>
        /// Declares a variable of type Login which represents the _login form's object and is used to perform actions on this form
        /// </summary>
        public static Login _login;

        /// <summary>
        /// Declares a variable of type Registration which represents the _registration form's object and is used to perform actions on this form
        /// </summary>
        public static Registration _registration;

        /// <summary>
        /// Declares a variable of type PasswordUpdate which represents the _passwordUpdate form's object and is used to perform actions on this form
        /// </summary>
        public static PasswordUpdate _passwordUpdate;

        /// <summary>
        /// Declares a variable of type PasswordRestart which represents the _passwordRestart form's object and is used to perform actions on this form
        /// </summary>
        public static PasswordRestart _passwordRestart;

        /// <summary>
        /// Declares a variable of type Profile which represents the _profile form's object and is used to perform actions on this form
        /// </summary>
        public static Profile _profile;

        /// <summary>
        /// Declares a variable of type YouChat which represents the _youChat form's object and is used to perform actions on this form
        /// </summary>
        public static YouChat _youChat;

        /// <summary>
        /// Declares a variable of type InitialProfileSelection which represents the _initialProfileSelection form's object and is used to perform actions on this form
        /// </summary>
        public static InitialProfileSelection _initialProfileSelection;

        /// <summary>
        /// Declares a variable of type EmojiKeyboard which represents the _emojiKeyboard form's object and is used to perform actions on this form
        /// </summary>
        public static EmojiKeyboard _emojiKeyboard = null;

        /// <summary>
        /// Declares a variable of type ContactSharing which represents the _contactSharing form's object and is used to perform actions on this form
        /// </summary>
        public static ContactSharing _contactSharing = null;

        /// <summary>
        /// Declares a variable of type Camera which represents the _camera form's object and is used to perform actions on this form
        /// </summary>
        public static Camera _camera = null;

        /// <summary>
        /// Declares a variable of type VideoCall which represents the _videoCall form's object and is used to perform actions on this form
        /// </summary>
        public static VideoCall _videoCall;


        /// <summary>
        /// Declares a variable of type AudioCall which represents the _audioCall form's object and is used to perform actions on this form
        /// </summary>
        public static AudioCall _audioCall;

        /// <summary>
        /// Declares a variable of type WaitingForm which represents the _waitingForm form's object and is used to perform actions on this form
        /// </summary>
        public static WaitingForm _waitingForm;

        /// <summary>
        /// Declares a variable of type CallInvitation which represents the _callInvitation form's object and is used to perform actions on this form
        /// </summary>
        public static CallInvitation _callInvitation;

        /// <summary>
        /// Declares a variable of type Paint which represents the _paint form's object and is used to perform actions on this form
        /// </summary>
        public static Paint _paint = null;

        public static ImageSender _imageSender;

        public static BanForm _banForm;

        public static ProfilePictureSelector _profilePictureSelector;
        public static ProfileStatusSelector _profileStatusSelector;

    }
}
