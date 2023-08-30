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

//using System.Drawing.Drawing2D;

namespace YouChatApp.Controls
{
    public partial class ToggleButton : CheckBox
    {
        private Color backColorSituationOn = Color.MediumSlateBlue;
        private Color toggleColorSituationOn = Color.WhiteSmoke;
        private Color backColorSituationOff = Color.Gray;
        private Color toggleColorSituationOff = Color.Gainsboro;
        private bool solidStyle = true;
        //Properties
        public Color BackColorSituationOn
        {
            get { return backColorSituationOn; }
            set
            {
                backColorSituationOn = value;
                this.Invalidate();
            }
        }
        public Color ToggleColorSituationOn
        {
            get { return toggleColorSituationOn; }
            set
            {
                toggleColorSituationOn = value;
                this.Invalidate();
            }
        }
        public Color BackColorSituationOff
        {
            get { return backColorSituationOff; }
            set
            {
                backColorSituationOff = value;
                this.Invalidate();
            }
        }
        public Color ToggleColorSituationOff
        {
            get { return toggleColorSituationOff; }
            set
            {
                toggleColorSituationOff = value;
                this.Invalidate();
            }
        }
        public override string Text
        {
            get { return base.Text; }
            set { }
        }
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }
        public ToggleButton()
        {
            InitializeComponent();
            this.MinimumSize = new Size(45, 22);

        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs PaintEvent)
        {
            int toggleSize = this.Height - 5;
            PaintEvent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            PaintEvent.Graphics.Clear(this.Parent.BackColor);
            if (this.Checked) 
            {
                //Draw the control surface
                if (solidStyle)
                    PaintEvent.Graphics.FillPath(new SolidBrush(BackColorSituationOn), GetFigurePath());
                else 
                    PaintEvent.Graphics.DrawPath(new Pen(BackColorSituationOn, 2), GetFigurePath());
                //Draw the toggle
                PaintEvent.Graphics.FillEllipse(new SolidBrush(ToggleColorSituationOn),
                  new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                //Draw the control surface
                if (solidStyle)
                    PaintEvent.Graphics.FillPath(new SolidBrush(BackColorSituationOff), GetFigurePath());
                else 
                    PaintEvent.Graphics.DrawPath(new Pen(BackColorSituationOff, 2), GetFigurePath());
                //Draw the toggle
                PaintEvent.Graphics.FillEllipse(new SolidBrush(ToggleColorSituationOff),
                  new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
