using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YouChatApp.Controls
{
    public partial class ProfileControl : UserControl
    {
        public ProfileControl()
        {
            InitializeComponent();
        }
        private Image _redColoredX = global::YouChatApp.Properties.Resources.CloseRedColor;
        private Image _blackColoredX = global::YouChatApp.Properties.Resources.CloseBlackColor;

        private bool _isCloseVisible = false;
        public bool IsCloseVisible
        {
            get 
            { 
                return _isCloseVisible;
            }
            set 
            { 
                _isCloseVisible = value;
                RemoveCustomButton.Visible = _isCloseVisible;
            }
        }
        public event EventHandler CloseControl;
        public void OnClickHandler(EventHandler handler)
        {
            CloseControl += handler;
        }


        public void SetToolTip()
        {
            //if (TextRenderer.MeasureText(UsernameLabel.Text, UsernameLabel.Font).Width > this.ClientSize.Width)
            //{
            //    ToolTip.SetToolTip(UsernameLabel, UsernameLabel.Text);
            //}
            //else
            //{
            //    ToolTip.SetToolTip(UsernameLabel, null); // Clear the tooltip if not needed
            //}
            ToolTipSetter.SetToolTipBySpaceOver(UsernameLabel, ToolTip);
        }
        public void SetProfilePicture(Image image)
        {
            ProfilePictureCircularPictureBox.BackgroundImage = image;
        }
        public void SetUserName(string name)
        {
            UsernameLabel.Text = name;
        }
        private void UsernameLabel_Click(object sender, EventArgs e)
        {
        }

        private void RemoveCustomButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveCustomButton.BackgroundImage = _redColoredX;

        }

        private void RemoveCustomButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveCustomButton.BackgroundImage = _blackColoredX;

        }

        private void RemoveCustomButton_Click(object sender, EventArgs e)
        {
            CloseControl?.Invoke(this, e);
        }
    }
    
}
