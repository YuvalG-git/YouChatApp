using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles
{
    internal class MessageImage : Emoji
    {
        public Image EmojiImage { get; set; }
        public Image OnRichTextBoxImage { get; set; }
        public string ImageName { get; set; }
        public void ResizeImage(int NewSize)
        {
            using (Image originalImage = OnRichTextBoxImage)
            {
                using (Bitmap resizedImage = new Bitmap(NewSize, NewSize))
                {
                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(OnRichTextBoxImage, 0, 0, NewSize, NewSize);
                    }

                    OnRichTextBoxImage = resizedImage;
                }
            }
        }







    }
}
