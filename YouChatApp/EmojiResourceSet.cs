using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    internal class EmojiResourceSet
    {
        //public static ImageList MaleProfilePictureImageList { get; private set; }
        //public static ImageList FemaleProfilePictureImageList { get; private set; }
        //public static ImageList AnimalProfilePictureImageList { get; private set; }

        public static ResourceSet[] resourceSetArray { get; private set; }

        public static void InitializeResourceSetArray()
        {
            resourceSetArray = new ResourceSet[9];
            {
                resourceSetArray[0] = Properties.Smileys_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[1] = Properties.People_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[2] = Properties.AnimalsAndNature_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[3] = Properties.FoodAndDrink_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[4] = Properties.Activities_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[5] = Properties.TravelAndPlaces_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[6] = Properties.Objects_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[7] = Properties.Symbols_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
                resourceSetArray[8] = Properties.Flags_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);

            }

        }

    }
}
