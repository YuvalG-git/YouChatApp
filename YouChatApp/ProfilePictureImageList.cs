using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;


namespace YouChatApp
{
    internal class ProfilePictureImageList
    {
        public static ImageList MaleProfilePictureImageList { get; private set; }
        public static ImageList FemaleProfilePictureImageList { get; private set; }
        public static ImageList AnimalProfilePictureImageList { get; private set; }

        private static ImageList[] ImageListArray;

        public static void InitializeImageLists()
        {
            MaleProfilePictureImageList = new ImageList();
            FemaleProfilePictureImageList = new ImageList();
            AnimalProfilePictureImageList = new ImageList();
            ImageListArray = new ImageList[] { MaleProfilePictureImageList, FemaleProfilePictureImageList, AnimalProfilePictureImageList };

            foreach (ImageList ProfilePictureImageList in ImageListArray)
            {
                ProfilePictureImageList.TransparentColor = System.Drawing.Color.Transparent;
                ProfilePictureImageList.ImageSize = new Size(124, 124);
                ProfilePictureImageList.ColorDepth = ColorDepth.Depth32Bit;
            }
            LoadImagesFromResources("BoyCharacter");
            LoadImagesFromResources("GirlCharacter");
            LoadImagesFromResources("AnimalCharacter");

        }
        private static void LoadImagesFromResources(string ProfilePictureKind)
        {
            List<string> ImageNames = new List<string>();
            int Maximum;
            if (ProfilePictureKind == "BoyCharacter")
            {
                Maximum = 28;
            }
            else
            {
                Maximum = 27;
            }
            for (int i = 1; i<= Maximum; i++)
            {
                ImageNames.Add(ProfilePictureKind + i);
            }

            foreach (string resourceName in ImageNames)
            {
                if (ProfilePictureKind == "BoyCharacter")
                {
                    Image image = Properties.MaleProfilePicture.ResourceManager.GetObject(resourceName) as Image;
                    if (image != null)
                    {
                        MaleProfilePictureImageList.Images.Add(image);
                    }
                }
                else if (ProfilePictureKind == "GirlCharacter")
                {
                    Image image = Properties.FemaleProfilePicture.ResourceManager.GetObject(resourceName) as Image;
                    if (image != null)
                    {
                        FemaleProfilePictureImageList.Images.Add(image);
                    }
                }
                else if (ProfilePictureKind == "AnimalCharacter")
                {
                    Image image = Properties.AnimalProfilePicture.ResourceManager.GetObject(resourceName) as Image;
                    if (image != null)
                    {
                        AnimalProfilePictureImageList.Images.Add(image);
                    }
                }
            }
        }


    }
}
