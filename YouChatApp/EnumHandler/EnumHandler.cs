﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    public static class EnumHandler
    {
        public enum ChatType_Enum
        {
            Direct,
            Group
        }
        public enum UserAuthentication_Enum
        {
            Login,
            Registration,
            PasswordUpdate,
            PasswordRestart
        }

        public enum LoginPhases_Enum
        {
            Login,
            Smtp,
            CaptchaCode,
            CaptchaRotatingImage,
            VerificationQuestion
        }
        public enum RegistrationPhases_Enum
        {
            Smtp,
            Registration
        }
        /// <summary>
        /// Enum used to ...
        /// </summary>
        public enum SmtpMessageType_Enum
        {
            RegistrationMessage,
            LoginMessage,
            PasswordRenewalMessage
        }
        public enum MessageType_Enum
        {
            Text,
            Image,
            DeletedMessage
        }
        public enum CommunicationMessageID_Enum
        {
            loginRequest,
            loginRequest_SmtpLoginMessage,
            loginResponse_SmtpLoginMessage,
            loginResponse_FailedLogin,
            LoginRequest_SmtpLoginCode,
            LoginResponse_SuccessfulSmtpLoginCode,
            LoginResponse_FailedSmtpLoginCode,
            RegistrationRequest_SmtpRegistrationMessage,
            RegistrationResponse_SmtpRegistrationMessage,
            RegistrationRequest_SmtpRegistrationCode,
            RegistrationResponse_SuccessfulSmtpRegistrationCode,
            RegistrationResponse_FailedSmtpRegistrationCode,
            RegistrationRequest_Registration,
            RegistrationResponse_SuccessfulRegistration,
            RegistrationResponse_FailedRegistration,
            EncryptionClientPublicKeySender,
            EncryptionServerPublicKeyAndSymmetricKeyReciever,
            EncryptionServerPublicKeyReciever,
            EncryptionSymmetricKeyReciever,
            EncryptionRenewKeys,
            FriendRequestSender,
            FriendRequestReciever,
            FriendRequestResponseSender,
            FriendRequestResponseReciever,
            UploadProfilePictureRequest,
            UploadProfilePictureResponse,
            UploadStatusRequest,
            UploadStatusResponse,
            CaptchaImageRequest,
            CaptchaImageResponse,
            CaptchaCodeRequest,
            SuccessfulCaptchaCodeResponse,
            FailedCaptchaCodeResponse,
            CaptchaImageAngleRequest,
            CaptchaImageAngleResponse,
            SuccessfulCaptchaImageAngleResponse,
            FailedCaptchaImageAngleResponse,
            PersonalVerificationAnswersRequest,
            SuccessfulPersonalVerificationAnswersResponse_UpdatePassword,
            SuccessfulPersonalVerificationAnswersResponse_SetUserProfilePicture,
            SuccessfulPersonalVerificationAnswersResponse_SetUserStatus,
            SuccessfulPersonalVerificationAnswersResponse_OpenChat,
            SuccessfulPersonalVerificationAnswersResponse_HandleError,
            FailedPersonalVerificationAnswersResponse,
            Disconnect,
            SendMessageRequest,
            SendMessageResponse,
            UdpAudioConnectionRequest,
            UdpAudioConnectionResponse,
            PasswordUpdateRequest,
            SuccessfulPasswordUpdateResponse,
            FailedPasswordUpdateResponse_UnmatchedDetails,
            FailedPasswordUpdateResponse_PasswordExist,
            ErrorHandlePasswordUpdateResponse,
            InitialProfileSettingsCheckRequest,
            InitialProfileSettingsCheckResponse_SetUserProfilePicture,
            InitialProfileSettingsCheckResponse_SetUserStatus,
            InitialProfileSettingsCheckResponse_OpenChat,
            InitialProfileSettingsCheckResponse_HandleError,
            UserDetailsRequest,
            UserDetailsResponse,
            ChatSettingsChangeRequest,
            ChatSettingsChangeResponse,
            LoginBanStart,
            LoginBanFinish,
            RegistrationBanStart,
            RegistrationBanFinish,
            ResetPasswordBanStart,
            ResetPasswordBanFinish,
            PasswordUpdateBanStart,
            PasswordUpdateBanFinish,
            ResetPasswordRequest,
            SuccessfulResetPasswordResponse,
            FailedResetPasswordResponse,
            ResetPasswordRequest_SmtpMessage,
            ResetPasswordResponse_SmtpMessage,
            ResetPasswordRequest_SmtpCode,
            SuccessfulResetPasswordResponse_SmtpCode,
            FailedResetPasswordResponse_SmtpCode,
            PastFriendRequestsRequest,
            PastFriendRequestsResponse,
            PasswordRenewalMessageRequest,
            SuccessfulRenewalMessageResponse,
            FailedRenewalMessageResponse,
            ErrorHandleRenewalMessageResponse,
            ChatAndContactDetailsRequest,
            ChatAndContactDetailsResponse_Contacts,
            ChatAndContactDetailsResponse_Chats,
            ContactInformationRequest,
            ContactInformationResponse,
            ChatInformationRequest,
            ChatInformationResponse,
            GroupCreatorRequest,
            GroupCreatorResponse
        }
    }
}