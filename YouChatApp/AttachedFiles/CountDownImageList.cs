using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouChatApp.Properties;

namespace YouChatApp.AttachedFiles
{
    internal class CountDownImageList
    {
        public static ImageList _CountDownImageList { get; private set; }

        static CountDownImageList()
        {
            _CountDownImageList = new ImageList();
            _CountDownImageList.TransparentColor = System.Drawing.Color.Transparent;
            _CountDownImageList.ImageSize = new Size(124, 124);
            _CountDownImageList.ColorDepth = ColorDepth.Depth32Bit;
            LoadImagesFromResources();

        }
        private static void LoadImagesFromResources()
        {
            List<string> ImageNames = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                ImageNames.Add("CountDownNumber" + i);
            }

            foreach (string resourceName in ImageNames)
            {
                Image image = Properties.CountDown.ResourceManager.GetObject(resourceName) as Image;
                if (image != null)
                {
                    _CountDownImageList.Images.Add(image);
                }
            }
        }

        
    }
}
