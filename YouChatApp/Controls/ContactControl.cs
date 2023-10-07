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
using YouChatApp.Controls;

namespace YouChatApp
{
    public partial class ContactControl : UserControl
    {
        public ContactControl()
        {
            InitializeComponent();
        }
        public event EventHandler OnCheckBoxCheckedChanged;

        public CircularPictureBox ProfilePicture => ProfilePictureCircularPictureBox;

        public System.Windows.Forms.Label ContactName => ContactNameLabel;

        public System.Windows.Forms.CheckBox ContactSelection => ContactSharingCheckBox;

        private Color BorderColorProperty = Color.RoyalBlue;
        private int BorderSizeProperty = 2;

        public Color BorderColor
        {
            get 
            { 
                return BorderColorProperty; 
            }
            set
            {
                BorderColorProperty = value;
                this.Invalidate();
            }
        }
        public int BorderSize
        {
            get 
            { 
                return BorderSizeProperty;
            }
            set
            {
                BorderSizeProperty = value;
                this.Invalidate();
            }
        }

        private void ContactSharingCheckBox_Click(object sender, EventArgs e)
        {

            if (ContactSharingCheckBox.Checked)
            {
                if (ServerCommunication.SelectedContacts >= 3)
                {
                    ContactSharingCheckBox.Checked = false;

                }
                else
                {
                    ServerCommunication.SelectedContacts++;
                }
            }
            else
            {
                ServerCommunication.SelectedContacts--;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(BorderColorProperty, BorderSizeProperty))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawRectangle(BorderPen, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }
        public void OnCheckBoxCheckedChangedHandler(EventHandler handler)
        {
            OnCheckBoxCheckedChanged += handler;
        }

        private void ContactSharingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckBoxCheckedChanged?.Invoke(this, e);

        }
    }
}
