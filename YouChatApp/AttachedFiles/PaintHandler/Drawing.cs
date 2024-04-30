using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles.PaintHandler
{
    /// <summary>
    /// The "Drawing" class represents a drawing with a specified width, height, and image.
    /// </summary>
    /// <remarks>
    /// This class provides properties to get the width, height, and drawing image of the drawing.
    /// </remarks>
    internal class Drawing
    {
        #region Private Fields

        /// <summary>
        /// The int "_width" represents the width of the drawing.
        /// </summary>
        private int _width;

        /// <summary>
        /// The int "_height" represents the height of the drawing.
        /// </summary>
        private int _height;

        /// <summary>
        /// The Image "_drawingImage" represents the image used for drawing.
        /// </summary>
        private Image _drawingImage;

        #endregion

        #region Constructors

        /// <summary>
        /// The "Drawing" constructor initializes a new instance of the <see cref="Drawing"/> class with the specified width, height, and drawing image.
        /// </summary>
        /// <param name="width">The width of the drawing.</param>
        /// <param name="height">The height of the drawing.</param>
        /// <param name="drawingImage">The image used for drawing.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the Drawing class, setting the width, height, and drawing image.
        /// </remarks>
        public Drawing(int width, int height, Image drawingImage)
        {
            _width = width;
            _height = height;
            _drawingImage = drawingImage;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Width" property represents the width of the object.
        /// It gets the width of the object.
        /// </summary>
        public int Width
        {
            get 
            { 
                return _width;
            }
        }

        /// <summary>
        /// The "Height" property represents the height of the object.
        /// It gets the height of the object.
        /// </summary>
        public int Height
        {
            get 
            { 
                return _height;
            }
        }

        /// <summary>
        /// The "DrawingImage" property represents the image used for drawing.
        /// It gets the drawing image.
        /// </summary>
        public Image DrawingImage
        {
            get 
            { 
                return _drawingImage;
            }
        }

        #endregion
    }
}
