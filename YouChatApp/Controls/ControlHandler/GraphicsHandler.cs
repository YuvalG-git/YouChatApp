using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "GraphicsHandler" class provides methods for creating and manipulating graphics objects.
    /// </summary>
    /// <remarks>
    /// This class includes a method for creating a graphics path representing a rounded rectangle with a specified radius.
    /// </remarks>
    internal class GraphicsHandler
    {
        #region Public Static Methods

        /// <summary>
        /// The "GetFigurePath" method creates a graphics path representing a rounded rectangle with the specified radius.
        /// </summary>
        /// <param name="Rectangle">The rectangle to create the rounded rectangle from.</param>
        /// <param name="Radius">The radius of the rounded corners.</param>
        /// <returns>A graphics path representing the rounded rectangle.</returns>
        /// <remarks>
        /// This method creates a graphics path that outlines a rounded rectangle shape based on the specified rectangle and radius.
        /// The rounded rectangle is created by adding arcs at the corners and closing the figure to complete the path.
        /// </remarks>
        public static GraphicsPath GetFigurePath(Rectangle Rectangle, int Radius)
        {
            GraphicsPath Path = new GraphicsPath();
            float CurveSize = Radius * 2F;

            Path.StartFigure();
            Path.AddArc(Rectangle.X, Rectangle.Y, CurveSize, CurveSize, 180, 90);
            Path.AddArc(Rectangle.Right - CurveSize, Rectangle.Y, CurveSize, CurveSize, 270, 90);
            Path.AddArc(Rectangle.Right - CurveSize, Rectangle.Bottom - CurveSize, CurveSize, CurveSize, 0, 90);
            Path.AddArc(Rectangle.X, Rectangle.Bottom - CurveSize, CurveSize, CurveSize, 90, 90);
            Path.CloseFigure();
            return Path;
        }

        #endregion
    }
}
