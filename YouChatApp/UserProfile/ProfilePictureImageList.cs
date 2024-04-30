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
    /// <summary>
    /// The "ProfilePictureImageList" class provides static properties and methods for managing image lists containing profile pictures.
    /// It includes image lists for male, female, and animal profile pictures, as well as methods for loading images from resources and retrieving images by ID.
    /// </summary>
    /// <remarks>
    /// This class uses static fields to store image lists for different categories of profile pictures.
    /// The static constructor initializes these image lists and loads images from project resources.
    /// It also includes methods for retrieving images based on ID and loading images from resources.
    /// </remarks>
    internal class ProfilePictureImageList
    {
        #region Private Static Fields

        /// <summary>
        /// The static ImageList "maleProfilePictureImageList" represents the image list for male profile pictures.
        /// </summary>
        private static ImageList maleProfilePictureImageList;

        /// <summary>
        /// The static ImageList "femaleProfilePictureImageList" represents the image list for female profile pictures.
        /// </summary>
        private static ImageList femaleProfilePictureImageList;

        /// <summary>
        /// The static ImageList "animalProfilePictureImageList" represents the image list for animal profile pictures.
        /// </summary>
        private static ImageList animalProfilePictureImageList;

        #endregion

        #region Static Constructor

        /// <summary>
        /// The "ProfilePictureImageList" static constructor initializes a new instance of the <see cref="ProfilePictureImageList"/> class with the profile picture image lists for male, female, and animal characters.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create and configure the image lists for different profile picture categories.
        /// It sets the transparency color, image size, and color depth for each image list, 
        /// and then loads images from resources for each category.
        /// </remarks>
        static ProfilePictureImageList()
        {
            maleProfilePictureImageList = new ImageList();
            femaleProfilePictureImageList = new ImageList();
            animalProfilePictureImageList = new ImageList();
            ImageList[] ImageListArray = new ImageList[] { maleProfilePictureImageList, femaleProfilePictureImageList, animalProfilePictureImageList };

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

        #endregion

        #region Static Properties

        /// <summary>
        /// The "MaleProfilePictureImageList" property represents an image list containing male profile pictures.
        /// It gets the image list containing male profile pictures.
        /// </summary>
        /// <value>
        /// The image list containing male profile pictures.
        /// </value>
        public static ImageList MaleProfilePictureImageList
        {
            get
            {
                return maleProfilePictureImageList;
            }
        }

        /// <summary>
        /// The "FemaleProfilePictureImageList" property represents an image list containing female profile pictures.
        /// It gets the image list containing female profile pictures.
        /// </summary>
        /// <value>
        /// The image list containing female profile pictures.
        /// </value>
        public static ImageList FemaleProfilePictureImageList
        {
            get
            {
                return femaleProfilePictureImageList;
            }
        }

        /// <summary>
        /// The "AnimalProfilePictureImageList" property represents an image list containing animal profile pictures.
        /// It gets the image list containing animal profile pictures.
        /// </summary>
        /// <value>
        /// The image list containing animal profile pictures.
        /// </value>
        public static ImageList AnimalProfilePictureImageList
        {
            get
            {
                return animalProfilePictureImageList;
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// The "LoadImagesFromResources" method loads a set of images from project resources based on the specified ProfilePictureKind.
        /// </summary>
        /// <param name="ProfilePictureKind">The kind of profile pictures to load ("BoyCharacter", "GirlCharacter", or "AnimalCharacter").</param>
        /// <remarks>
        /// This method creates a list of image names based on the ProfilePictureKind and the maximum number of images available.
        /// It then iterates over the list of image names and attempts to load each image from the project's resources.
        /// If the image is successfully loaded, it is added to the corresponding image list (maleProfilePictureImageList, femaleProfilePictureImageList, or animalProfilePictureImageList).
        /// </remarks>
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
                        maleProfilePictureImageList.Images.Add(image);
                    }
                }
                else if (ProfilePictureKind == "GirlCharacter")
                {
                    Image image = Properties.FemaleProfilePicture.ResourceManager.GetObject(resourceName) as Image;
                    if (image != null)
                    {
                        femaleProfilePictureImageList.Images.Add(image);
                    }
                }
                else if (ProfilePictureKind == "AnimalCharacter")
                {
                    Image image = Properties.AnimalProfilePicture.ResourceManager.GetObject(resourceName) as Image;
                    if (image != null)
                    {
                        animalProfilePictureImageList.Images.Add(image);
                    }
                }
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// The "GetImageByImageId" method gets an image based on the provided ImageId.
        /// </summary>
        /// <param name="ImageId">The ImageId of the image to retrieve.</param>
        /// <returns>The image corresponding to the ImageId.</returns>
        /// <remarks>
        /// This method parses the ImageId to determine the type of image (Male, Female, or Animal)
        /// and retrieves the image from the appropriate image list (maleProfilePictureImageList, femaleProfilePictureImageList, or animalProfilePictureImageList).
        /// </remarks>
        public static Image GetImageByImageId(string ImageId)
        {
            Image profilePicture;
            string IdAsString;
            int Id;
            if (ImageId.StartsWith("Male"))
            {
                IdAsString = ImageId.Replace("Male", "");
                Id = int.Parse(IdAsString);
                profilePicture = maleProfilePictureImageList.Images[Id];
            }
            else if (ImageId.StartsWith("Female"))
            {
                IdAsString = ImageId.Replace("Female", "");
                Id = int.Parse(IdAsString);
                profilePicture = femaleProfilePictureImageList.Images[Id];
            }
            else
            {
                IdAsString = ImageId.Replace("Animal", "");
                Id = int.Parse(IdAsString);
                profilePicture = animalProfilePictureImageList.Images[Id];
            }
            return profilePicture;
        }

        #endregion
    }
}
