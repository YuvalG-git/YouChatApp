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
        public bool HasBorder
        {
            get { return _hasBorder; }
            set { _hasBorder = value; }
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
                using (Pen PenBorder = new Pen(Color.Gray, 1))
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
