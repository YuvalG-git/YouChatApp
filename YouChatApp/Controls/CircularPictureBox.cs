using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class CircularPictureBox : PictureBox
    {
        private bool _hasBorder = false;
        private int _borderSize = 1;
        private Color _borderColor = Color.Gray;
        public bool HasBorder
        {
            get { return _hasBorder; }
            set { _hasBorder = value; }
        }
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; }
        }
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //using (GraphicsPath path = new GraphicsPath())
            //{
            //    path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            //    Region = new Region(path);
            //    base.OnPaint(e);

            //}
            using (GraphicsPath path = new GraphicsPath())
            {
                using (Pen PenBorder = new Pen(_borderColor, _borderSize))
                {
                    if (_hasBorder)
                    {
                        PenBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawEllipse(PenBorder, 1, 1, ClientSize.Width - 2, ClientSize.Height - 2);
                    }
                    path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                    Region = new Region(path);
                    base.OnPaint(e);

                }


            }

        }
    }
}
