using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles
{
    /// <summary>
    /// The class represents an emoji object.
    /// </summary>
    internal class EmojiObject
    {
        /// <summary>
        /// The image of the emoji.
        /// </summary>
        public Image EmojiImage { get; set; }

        /// <summary>
        /// The name of the emoji.
        /// </summary>
        public string EmojiName { get; set; }

        /// <summary>
        /// The ID of the emoji.
        /// </summary>
        public string EmojiID { get; set; }

        /// <summary>
        /// The color ID of the emoji.
        /// </summary>
        public string EmojiColorID { get; set; }

        /// <summary>
        /// The number of parts the emoji ID is split into.
        /// </summary>
        public int EmojiIdParts { get; set; }

        /// <summary>
        /// The method initializes a new instance of the <see cref="EmojiObject"/> class with the specified image, name, ID, and number of ID parts.
        /// This method is used when the emoji ID does not include a part for the color.
        /// </summary>
        /// <param name="emojiImage">The image of the emoji.</param>
        /// <param name="emojiName">The name of the emoji.</param>
        /// <param name="emojiID">The ID of the emoji.</param>
        /// <param name="emojiIdParts">The number of parts the emoji ID is split into.</param>
        public EmojiObject(Image EmojiImage, string EmojiName, string EmojiID, int EmojiIdParts)
        {
            this.EmojiImage = EmojiImage;
            this.EmojiName = EmojiName;
            this.EmojiID = EmojiID;
            this.EmojiColorID = "first";
            this.EmojiIdParts = EmojiIdParts;
        }

        /// <summary>
        /// The method initializes a new instance of the <see cref="EmojiObject"/> class with the specified image, name, ID, color ID, and number of ID parts.
        /// </summary>
        /// <param name="emojiImage">The image of the emoji.</param>
        /// <param name="emojiName">The name of the emoji.</param>
        /// <param name="emojiID">The ID of the emoji.</param>
        /// <param name="emojiColorID">The color ID of the emoji.</param>
        /// <param name="emojiIdParts">The number of parts the emoji ID is split into.</param>
        public EmojiObject(Image EmojiImage, string EmojiName, string EmojiID, string EmojiColorID, int EmojiIdParts)
        {
            this.EmojiImage = EmojiImage;
            this.EmojiName = EmojiName;
            this.EmojiID = EmojiID;
            this.EmojiColorID = EmojiColorID;
            this.EmojiIdParts = EmojiIdParts;
        }
    }
}
