using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    public partial class ContactControl : UserControl
    {
        public ContactControl()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Click += new System.EventHandler(this.OnControlClick);
                control.MouseEnter += new System.EventHandler(this.ContactControl_MouseEnter);
                control.MouseLeave += new System.EventHandler(this.ContactControl_MouseLeave);
            }
 
        }
        public CircularPictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public System.Windows.Forms.Label ContactName => ContactNameLabel;

        public System.Windows.Forms.Label ContactStatus => ContactStatusLabel;

        private Color _backgroundColor = Color.Transparent;
        private Color _onFocusBackgroundColor = Color.CornflowerBlue;
        private Color _borderColor = Color.CornflowerBlue;

        private bool _wasSelected = false;

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                this.Invalidate();
            }
        }
        public Color OnFocusBackgroundColor
        {
            get { return _onFocusBackgroundColor; }
            set
            {
                _onFocusBackgroundColor = value;
            }
        }
        public bool WasSelected
        {
            get { return _wasSelected; }
            set
            {
                _wasSelected = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(_onFocusBackgroundColor, 1))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawLine(BorderPen, this.ContactNameLabel.Location.X, this.Height - 1, this.Width, this.Height - 1);
            }
        }
        public void SetToolTip()
        {
            ToolTip.SetToolTip(ContactNameLabel, ContactNameLabel.Text);
            ToolTip.SetToolTip(ContactStatusLabel, ContactStatusLabel.Text);
        }

        private void ContactNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void ContactControl_Load(object sender, EventArgs e)
        {

        }
        private void OnControlClick(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void ContactControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = _onFocusBackgroundColor;
        }

        private void ContactControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _backgroundColor;
        }

    }
}
