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
    /// <summary>
    /// The "CountDownImageList" class represents an image list for countdown.
    /// </summary>
    /// <remarks>
    /// This class contains a static image list that is used to store images for countdown.
    /// It provides methods to load images from project resources and configure the image list.
    /// </remarks>
    internal class CountDownImageList
    {
        #region Private Static Fields

        /// <summary>
        /// The static ImageList "_countDownImageList" represents the image list for countdown.
        /// </summary>
        private static ImageList _countDownImageList;

        #endregion

        #region Static Constructor

        /// <summary>
        /// The "<see cref="CountDownImageList"/>" static constructor initializes the count down image list.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create and configure the count down image list.
        /// It sets the transparency color, image size, and color depth for the image list,
        /// and then loads images from resources to populate the list.
        /// </remarks>
        static CountDownImageList()
        {
            _countDownImageList = new ImageList();
            _countDownImageList.TransparentColor = System.Drawing.Color.Transparent;
            _countDownImageList.ImageSize = new Size(124, 124);
            _countDownImageList.ColorDepth = ColorDepth.Depth32Bit;
            LoadImagesFromResources();
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// The "CountDownImages" property represents an image list for countdown.
        /// It gets or sets the image list for countdown.
        /// </summary>
        /// <value>
        /// The image list for countdown.
        /// </value>
        public static ImageList CountDownImages
        {
            get
            {
                return _countDownImageList;
            }
            set
            {
                _countDownImageList = value;
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// The "LoadImagesFromResources" method loads a series of images from the project's resources and adds them to an ImageList.
        /// </summary>
        /// <remarks>
        /// This method generates a list of resource names for images "CountDownNumber1" through "CountDownNumber10".
        /// It then iterates through this list, loads each image from the resources using ResourceManager.GetObject,
        /// and adds it to the _countDownImageList ImageList if the image is successfully loaded.
        /// </remarks>
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
                    _countDownImageList.Images.Add(image);
                }
            }
        }

        #endregion
    }
}
