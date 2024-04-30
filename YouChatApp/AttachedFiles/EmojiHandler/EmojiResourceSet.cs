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
        #region Private Static Fields

        /// <summary>
        /// The static array "resourceSetArray" contains ResourceSet objects.
        /// </summary>
        private static ResourceSet[] resourceSetArray;

        #endregion

        #region Public Static Properties

        /// <summary>
        /// The "ResourceSetArray" property represents an array of resource sets.
        /// It gets the array of resource sets.
        /// </summary>
        public static ResourceSet[] ResourceSetArray
        {
            get
            {
                return resourceSetArray;
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// The "InitializeResourceSetArray" method initializes the array of ResourceSet objects for different emoji categories.
        /// </summary>
        /// <remarks>
        /// This method initializes a static array of ResourceSet objects, with each element containing the ResourceSet for a specific emoji category.
        /// The emoji categories include Smileys & Emojis, People & Body, Animals & Nature, Food & Drink, Activities, Travel & Places, Objects, Symbols, and Flags.
        /// Each ResourceSet is obtained from the corresponding ResourceManager in the Properties namespace.
        /// </remarks>
        public static void InitializeResourceSetArray()
        {
            resourceSetArray = new ResourceSet[9];
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

        #endregion
    }
}
