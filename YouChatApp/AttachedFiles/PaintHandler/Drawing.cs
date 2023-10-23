using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.AttachedFiles.PaintHandler
{
    internal class Drawing
    {
        private int _width;
        private int _height;
        private Image _drawingImage;
        public Drawing(int width, int height, Image drawingImage)
        {
            _width = width;
            _height = height;
            _drawingImage = drawingImage;
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        { get { return _height; } }
        public Image DrawingImage
        { get { return _drawingImage; } }
    }
}
