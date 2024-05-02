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
using YouChatApp.AttachedFiles;
using YouChatApp.Controls;

namespace YouChatApp
{
    public partial class ContactSharingControl : UserControl
    {
        #region Public Event Handlers

        public event EventHandler OnCheckBoxClickAccepted;
        public event EventHandler OnCheckBoxClickDenied;

        #endregion

        #region Private Fields

        private Color BorderColorProperty = Color.RoyalBlue;
        private int BorderSizeProperty = 2;
        private string ContactIdProperty = "";

        #endregion

        #region Constructors

        public ContactSharingControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public CircularPictureBox ProfilePicture
        {
            get
            {
                return ProfilePictureCircularPictureBox;
            }
        }
        public System.Windows.Forms.Label ContactName
        {
            get
            {
                return ContactNameLabel;
            }
        }
        public System.Windows.Forms.CheckBox ContactSelection
        {
            get
            {
                return ContactSharingCheckBox;
            }
        }


        public string ContactId
        {
            get
            {
                return ContactIdProperty;
            }
            set
            {
                ContactIdProperty = value;
            }
        }
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

        #endregion

        #region Override Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics Graphics = e.Graphics;
            using (Pen BorderPen = new Pen(BorderColorProperty, BorderSizeProperty))
            {
                this.Region = new Region(this.ClientRectangle);
                BorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                Graphics.DrawLine(BorderPen, this.ContactNameLabel.Location.X, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        #endregion

        #region Private Methods

        private void ContactSharingCheckBox_Click(object sender, EventArgs e)
        {
            if (ContactSharingCheckBox.Checked)
            {
                if (ContactSharing.SelectedContacts >= 3)
                {
                    ContactSharingCheckBox.Checked = false;
                }
                else
                {
                    ContactSharing.SelectedContacts++;
                    OnCheckBoxClickAccepted?.Invoke(this, e);
                }
            }
            else
            {
                ContactSharing.SelectedContacts--;
                OnCheckBoxClickDenied?.Invoke(this, e);
            }
        }

        #endregion

        #region Public Methods

        public void OnCheckBoxClickAcceptedHandler(EventHandler handler)
        {
            OnCheckBoxClickAccepted += handler;
        }
        public void OnCheckBoxClickDeniedHandler(EventHandler handler)
        {
            OnCheckBoxClickDenied += handler;
        }

        #endregion
    }
}
