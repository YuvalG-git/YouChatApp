using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace YouChatApp.Controls
{
    public partial class BanControl : UserControl
    {
        TimeSpan TimerTickTimeSpan;
        TimeSpan CountDownTimeSpan;
        Image BackgroundGif = global::YouChatApp.Properties.Resources.StopWatch;

        public BanControl()
        {
            InitializeComponent();
            TimerTickTimeSpan = TimeSpan.FromMilliseconds(CountDownTimer.Interval);

        }

        public void HandleBan(double time)
        {
            this.BanPictureBox.Image = BackgroundGif;
            CountDownTimeLabel.Visible = true;
            CountDownTimeLabel.Text = time.ToString();

            CountDownTimeSpan = TimeSpan.FromMinutes(time);
            CountDownTimeLabel.Text = $"{CountDownTimeSpan:mm\\:ss\\.fff}";
            SetCountDownTimeLabelLocation();
            CountDownTimer.Start();
        }
        private void SetCountDownTimeLabelLocation()
        {
            CountDownTimeLabel.Location = new Point((this.Width - CountDownTimeLabel.Width) / 2, CountDownTimeLabel.Location.Y);
        }
        private Image GetCurrentFrame(Image image)
        {
            // Create an image object to store the first frame
            Image firstFrame = new Bitmap(image.Width, image.Height);

            // Create a graphics object to draw the first frame
            using (Graphics graphics = Graphics.FromImage(firstFrame))
            {
                // Draw the first frame onto the image object
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }

            return firstFrame;
        }
        private void DrawCenteredText(string line1, string line2, PictureBox pictureBox)
        {
            // Create a bitmap from the original image
            Bitmap bitmap = new Bitmap(pictureBox.Image);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Set the font and brush for drawing
                Font font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                Brush brush = Brushes.Black;

                // Measure the size of each line of text
                SizeF textSize1 = graphics.MeasureString(line1, font);
                SizeF textSize2 = graphics.MeasureString(line2, font);

                // Calculate the position to draw the first line of text
                float x1 = (bitmap.Width - textSize1.Width) / 2;
                float y1 = bitmap.Height - (textSize1.Height + textSize2.Height + 15);

                // Calculate the position to draw the second line of text
                float x2 = (bitmap.Width - textSize2.Width) / 2;
                float y2 = bitmap.Height - (textSize2.Height + 15);  // Place the second line below the first line

                // Draw the first line of text
                graphics.DrawString(line1, font, brush, x1, y1);

                // Draw the second line of text
                graphics.DrawString(line2, font, brush, x2, y2);
            }

            // Display the bitmap with text in the PictureBox
            pictureBox.Image = bitmap;
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            CountDownTimeSpan -= TimerTickTimeSpan;
            if (CountDownTimeSpan.TotalMilliseconds <= 0)
            {
                CountDownTimer.Stop();
                //CountDownTimeLabel.Text = "Countdown Complete!\nSoon you will be able to continue";
                //this.CountDownTimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //SetCountDownTimeLabelLocation();
                CountDownTimeLabel.Visible = false;
                BanPictureBox.Image = GetCurrentFrame(BanPictureBox.Image);
                DrawCenteredText("Countdown Complete!", "Soon you will be able to continue", BanPictureBox);

            }
            else
            {
                CountDownTimeLabel.Text = $"{CountDownTimeSpan:mm\\:ss\\.fff}";
            }
        }
    }
}
