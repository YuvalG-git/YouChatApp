    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles
{
    /// <summary>
    /// The "EmojiObject" class represents an emoji object.
    /// </summary>
    /// <remarks>
    /// This class provides properties for managing the emoji image, name, ID, color ID, and ID parts.
    /// </remarks>
    internal class EmojiObject
    {
        #region Private Fields

        /// <summary>
        /// The Image "emojiImage" represents the emoji image.
        /// </summary>
        private Image emojiImage;

        /// <summary>
        /// The string "emojiName" represents the name of the emoji.
        /// </summary>
        private string emojiName;

        /// <summary>
        /// The string "emojiID" represents the ID of the emoji.
        /// </summary>
        private string emojiID;

        /// <summary>
        /// The string "emojiColorID" represents the color ID of the emoji.
        /// </summary>
        private string emojiColorID;

        /// <summary>
        /// The int "emojiIdParts" represents the parts of the emoji ID.
        /// </summary>
        private int emojiIdParts;

        #endregion

        #region Constructors

        /// <summary>
        /// The "EmojiObject" constructor initializes a new instance of the <see cref="EmojiObject"/> class with the specified image, name, ID, and ID parts.
        /// </summary>
        /// <param name="emojiImage">The image representing the emoji.</param>
        /// <param name="emojiName">The name of the emoji.</param>
        /// <param name="emojiID">The unique ID of the emoji.</param>
        /// <param name="emojiIdParts">The number of parts the emoji ID is divided into.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the EmojiObject class, setting its image, name, ID, color ID, and number of ID parts.
        /// The color ID is set to "first" by default.
        /// </remarks>
        public EmojiObject(Image emojiImage, string emojiName, string emojiID, int emojiIdParts)
        {
            this.emojiImage = emojiImage;
            this.emojiName = emojiName;
            this.emojiID = emojiID;
            this.emojiColorID = "first";
            this.emojiIdParts = emojiIdParts;
        }

        /// <summary>
        /// The "EmojiObject" constructor initializes a new instance of the <see cref="EmojiObject"/> class with the specified image, name, ID, color ID, and ID parts.
        /// </summary>
        /// <param name="emojiImage">The image representing the emoji.</param>
        /// <param name="emojiName">The name of the emoji.</param>
        /// <param name="emojiID">The unique ID of the emoji.</param>
        /// <param name="emojiColorID">The color ID of the emoji.</param>
        /// <param name="emojiIdParts">The number of parts the emoji ID is divided into.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the EmojiObject class, setting its image, name, ID, color ID, and number of ID parts.
        /// </remarks>
        public EmojiObject(Image emojiImage, string emojiName, string emojiID, string emojiColorID, int emojiIdParts)
        {
            this.emojiImage = emojiImage;
            this.emojiName = emojiName;
            this.emojiID = emojiID;
            this.emojiColorID = emojiColorID;
            this.emojiIdParts = emojiIdParts;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "EmojiImage" property represents the emoji image used in the chat.
        /// It gets or sets the emoji image for the chat.
        /// </summary>
        /// <value>
        /// The emoji image for the chat.
        /// </value>
        public Image EmojiImage
        {
            get
            {
                return this.emojiImage;
            }
            set
            {
                this.emojiImage = value;
            }
        }

        /// <summary>
        /// The "EmojiName" property represents the name of the emoji.
        /// It gets or sets the name of the emoji.
        /// </summary>
        /// <value>
        /// The name of the emoji.
        /// </value>
        public string EmojiName
        {
            get
            {
                return this.emojiName;
            }
            set
            {
                this.emojiName = value;
            }
        }

        /// <summary>
        /// The "EmojiID" property represents the unique identifier of the emoji.
        /// It gets or sets the unique identifier of the emoji.
        /// </summary>
        /// <value>
        /// The unique identifier of the emoji.
        /// </value>
        public string EmojiID
        {
            get
            {
                return this.emojiID;
            }
            set
            {
                this.emojiID = value;
            }
        }

        /// <summary>
        /// The "EmojiColorID" property represents the unique identifier of the emoji color.
        /// It gets or sets the unique identifier of the emoji color.
        /// </summary>
        /// <value>
        /// The unique identifier of the emoji color.
        /// </value>
        public string EmojiColorID
        {
            get
            {
                return this.emojiColorID;
            }
            set
            {
                this.emojiColorID = value;
            }
        }

        /// <summary>
        /// The "EmojiIdParts" property represents the parts of the unique identifier of the emoji.
        /// It gets or sets the parts of the unique identifier of the emoji.
        /// </summary>
        /// <value>
        /// The parts of the unique identifier of the emoji.
        /// </value>
        public int EmojiIdParts
        {
            get
            {
                return this.emojiIdParts;
            }
            set
            {
                this.emojiIdParts = value;
            }
        }

        #endregion
    }
}
