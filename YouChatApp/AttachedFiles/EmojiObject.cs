using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles
{
    internal class EmojiObject
    {
        public Image EmojiImage { get; set; } //public? or private?
        public string EmojiName { get; set; }
        public string EmojiID { get; set; }
        public string EmojiColorID { get; set; }
        public int EmojiIdParts { get; set; }
        public EmojiObject(Image EmojiImage, string EmojiName, string EmojiID, int EmojiIdParts)
        {
            this.EmojiImage = EmojiImage;
            this.EmojiName = EmojiName;
            this.EmojiID = EmojiID;
            this.EmojiColorID = "first";
            this.EmojiIdParts = EmojiIdParts;
        }
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
