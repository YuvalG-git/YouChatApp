using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles.PaintHandler
{
    /// <summary>
    /// The class represents a drawing that can be used to save a past drawing in a paint application, allowing for undo and redo functionality.
    /// </summary>
    internal class Drawing
    {
        /// <summary>
        /// The width of the drawing.
        /// </summary>
        private int _width;

        /// <summary>
        /// The height of the drawing.
        /// </summary>
        private int _height;

        /// <summary>
        /// The image representing the drawing.
        /// </summary>
        private Image _drawingImage;

        /// <summary>
        /// The method initializes a new instance of the <see cref="Drawing"/> class with the specified width, height, and drawing image.
        /// </summary>
        /// <param name="width">The width of the drawing.</param>
        /// <param name="height">The height of the drawing.</param>
        /// <param name="drawingImage">The image representing the drawing.</param>
        public Drawing(int width, int height, Image drawingImage)
        {
            _width = width;
            _height = height;
            _drawingImage = drawingImage;
        }

        /// <summary>
        /// Gets the width of the drawing.
        /// </summary>
        public int Width
        {
            get { return _width; }
        }

        /// <summary>
        /// Gets the height of the drawing.
        /// </summary>
        public int Height
        {
            get { return _height; }
        }

        /// <summary>
        /// Gets the image representing the drawing.
        /// </summary>
        public Image DrawingImage
        {
            get { return _drawingImage; }
        }
    }
}
