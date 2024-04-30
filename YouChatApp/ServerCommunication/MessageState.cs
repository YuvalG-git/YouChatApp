using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    /// <summary>
    /// The "MessageState" class represents the state of a message, including its JSON content and encryption status.
    /// </summary>
    /// <remarks>
    /// This class provides properties for managing the JSON message content and encryption status.
    /// </remarks>
    internal class MessageState
    {
        #region Private Fields

        /// <summary>
        /// The string "_jsonMessage" represents the JSON message.
        /// </summary>
        private string _jsonMessage;

        /// <summary>
        /// The bool "_needsEncryption" indicates whether encryption is needed for the message.
        /// </summary>
        private bool _needsEncryption;

        #endregion

        #region Constructors

        /// <summary>
        /// The "MessageState" constructor initializes a new instance of the <see cref="MessageState"/> class with the specified JSON message and encryption flag.
        /// </summary>
        /// <param name="jsonMessage">The JSON message to be sent.</param>
        /// <param name="needsEncryption">A flag indicating whether the message needs to be encrypted.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the MessageState class, setting its JSON message and encryption flag.
        /// </remarks>
        public MessageState(string jsonMessage, bool needsEncryption)
        {
            _jsonMessage = jsonMessage;
            _needsEncryption = needsEncryption;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "JsonMessage" property represents a JSON-formatted message.
        /// It gets or sets the JSON-formatted message.
        /// </summary>
        /// <value>
        /// The JSON-formatted message.
        /// </value>
        public string JsonMessage
        {
            get
            {
                return _jsonMessage;
            }
            set
            {
                _jsonMessage = value;
            }
        }

        /// <summary>
        /// The "NeedsEncryption" property indicates whether the message needs to be encrypted.
        /// It gets or sets the encryption status of the message.
        /// </summary>
        /// <value>
        /// True if the message needs encryption; otherwise, false.
        /// </value>
        public bool NeedsEncryption
        {
            get
            {
                return _needsEncryption;
            }
            set
            {
                _needsEncryption = value;
            }
        }

        #endregion
    }
}
