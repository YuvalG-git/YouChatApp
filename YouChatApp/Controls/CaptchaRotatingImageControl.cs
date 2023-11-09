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
    public partial class CaptchaRotatingImageControl : UserControl
    {
        private double currentAngle;
        public CaptchaRotatingImageControl()
        {
            InitializeComponent();
        }

        private void CaptchaPictureBox_Click(object sender, EventArgs e)
        {
            //maybe i will send the rotated picture and the number of the picture i have rotated so i will be able to put it in the background...
        }

        private void CaptchaPicturesScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void CaptchaCircularPictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            CircularPictureBox circularPictureBox = sender as CircularPictureBox; 
            if (mouseEventArgs != null)
            {
                Point clickPoint = mouseEventArgs.Location;
                ImageRotationHandler.RotateImageToPoint(circularPictureBox, circularPictureBox.BackgroundImage /*todo - proably need to do that - maybe i would like to use a image var and not the backgroundimage... */, currentAngle, clickPoint);
            }//will it change the current angle or should i use current angle = and return something w/ the method..
        }
    }
}
