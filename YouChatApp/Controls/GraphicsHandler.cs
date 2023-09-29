using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.Controls
{
    internal class GraphicsHandler
    {
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
    }
}
