using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class CustomButton : Button
    {
        private int BorderSizeProperty = 0;
        private int BorderRadiusProperty = 10;
        private Color BorderColorProperty = Color.PaleVioletRed;

        [Category("YouChat")]
        public int BorderSize
        {
            get { return BorderSizeProperty; }
            set
            {
                BorderSizeProperty = value;
                this.Invalidate();
            }
        }

        [Category("YouChat")]
        public int BorderRadius
        {
            get { return BorderRadiusProperty; }
            set
            {
                if (value <= this.Height/2)
                {
                    BorderRadiusProperty = value;
                }
                else
                {
                    BorderRadiusProperty = this.Height/2;

                }
                this.Invalidate();
            }
        }

        [Category("YouChat")]
        public Color BorderColor
        {
            get { return BorderColorProperty; }
            set
            {
                BorderColorProperty = value;
                this.Invalidate();
            }
        }

        [Category("YouChat")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor; 
            }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("YouChat")]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }
        public CustomButton()
        {
            InitializeComponent();
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(CustomButton_Resize);
        }


        protected override void OnPaint(PaintEventArgs Pevent)
        {
            base.OnPaint(Pevent);
            Pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle RectangleSurface = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle RectangleBorder = new Rectangle(1, 1, this.Width - 1, this.Height - 1);

            if (BorderRadiusProperty > 2)
            {
                using (GraphicsPath PathSurface = GraphicsHandler.GetFigurePath(RectangleSurface, BorderRadiusProperty))
                {
                    using (GraphicsPath PathBorder = GraphicsHandler.GetFigurePath(RectangleBorder, BorderRadiusProperty - 1))
                    {
                        using (Pen PenSurface = new Pen(this.Parent.BackColor, 2))
                        {
                            using (Pen PenBorder = new Pen(BorderColorProperty, BorderSizeProperty))
                            {
                                PenBorder.Alignment = PenAlignment.Inset;
                                this.Region = new Region(PathSurface);
                                Pevent.Graphics.DrawPath(PenSurface, PathSurface);
                                if (BorderSizeProperty >= 1)
                                {
                                    Pevent.Graphics.DrawPath(PenBorder, PathBorder);

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this.Region = new Region(RectangleSurface);
                if (BorderSizeProperty >= 1)
                {
                    using (Pen PenBorder = new Pen(BorderColorProperty, BorderSizeProperty))
                    {
                        PenBorder.Alignment = PenAlignment.Inset;
                        Pevent.Graphics.DrawRectangle(PenBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(ContainerBackColorChanged);
        }
        private void ContainerBackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
        private void CustomButton_Resize(object sender, EventArgs e)
        {
            if (BorderRadiusProperty > this.Height)
            {
                BorderRadius = this.Height;
            }
        }
    }
       
}
