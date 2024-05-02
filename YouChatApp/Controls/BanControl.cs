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
    /// <summary>
    /// The "BanControl" class represents a custom UserControl for displaying a ban message and countdown.
    /// </summary>
    /// <remarks>
    /// This control includes a picture box for displaying a ban image, a label for showing the countdown time,
    /// and a timer for handling the countdown. It allows setting a ban duration and automatically updating
    /// the countdown display until the ban is lifted.
    /// </remarks>
    public partial class BanControl : UserControl
    {
        #region Private Fields

        /// <summary>
        /// The TimeSpan "TimerTickTimeSpan" represents the time span for timer ticks.
        /// </summary>
        private TimeSpan TimerTickTimeSpan;

        /// <summary>
        /// The TimeSpan "CountDownTimeSpan" represents the time span for countdown.
        /// </summary>
        private TimeSpan CountDownTimeSpan;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "BackgroundGif" represents the background image for the stopwatch.
        /// </summary>
        private readonly Image BackgroundGif = global::YouChatApp.Properties.Resources.StopWatch;

        #endregion

        #region Constructors

        /// <summary>
        /// The "BanControl" constructor initializes a new instance of the <see cref="BanControl"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up the BanControl by initializing its components.
        /// It also initializes the TimerTickTimeSpan property with the interval of the CountDownTimer.
        /// </remarks>

        public BanControl()
        {
            InitializeComponent();
            TimerTickTimeSpan = TimeSpan.FromMilliseconds(CountDownTimer.Interval);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "SetCountDownTimeLabelLocation" method sets the location of the CountDownTimeLabel to center it horizontally within the control.
        /// </summary>
        /// <remarks>This method calculates the new X coordinate based on the control's width and the label's width.</remarks>
        private void SetCountDownTimeLabelLocation()
        {
            CountDownTimeLabel.Location = new Point((this.Width - CountDownTimeLabel.Width) / 2, CountDownTimeLabel.Location.Y);
        }

        /// <summary>
        /// The "GetCurrentFrame" method extracts the first frame from an animated image.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <returns>The first frame of the image.</returns>
        /// <remarks>This method creates a new bitmap and draws the original image onto it, returning the new bitmap.</remarks>
        private Image GetCurrentFrame(Image image)
        {
            Image firstFrame = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(firstFrame))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return firstFrame;
        }

        /// <summary>
        /// The "DrawCenteredText" method draws two lines of text centered horizontally on an image within a PictureBox control.
        /// </summary>
        /// <param name="line1">The first line of text.</param>
        /// <param name="line2">The second line of text.</param>
        /// <param name="pictureBox">The PictureBox control containing the image.</param>
        /// <remarks>
        /// This method creates a bitmap from the PictureBox's image and uses Graphics.DrawString to draw the text on the bitmap.
        /// It then sets the PictureBox's image to the modified bitmap with the text.
        /// </remarks>
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

        /// <summary>
        /// The "CountDownTimer_Tick" method handles the Tick event of the CountDownTimer, updating the countdown display and handling the end of the countdown.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method decrements the CountDownTimeSpan by a specified interval and updates the CountDownTimeLabel text.
        /// If the countdown reaches zero, it stops the timer, hides the CountDownTimeLabel, and updates the BanPictureBox image and text.
        /// </remarks>
        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            CountDownTimeSpan -= TimerTickTimeSpan;
            if (CountDownTimeSpan.TotalMilliseconds <= 0)
            {
                CountDownTimer.Stop();
                CountDownTimeLabel.Visible = false;
                BanPictureBox.Image = GetCurrentFrame(BanPictureBox.Image);
                DrawCenteredText("Countdown Complete!", "Soon you will be able to continue", BanPictureBox);
            }
            else
            {
                CountDownTimeLabel.Text = $"{CountDownTimeSpan:mm\\:ss\\.fff}";
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "HandleBan" method handles a ban by displaying a ban image and starting a countdown timer.
        /// </summary>
        /// <param name="time">The duration of the ban in minutes.</param>
        /// <remarks>
        /// This method sets the BanPictureBox's image to a specified background GIF, makes the CountDownTimeLabel visible, and sets its text to the ban duration in minutes.
        /// It then converts the ban duration to a TimeSpan and sets the CountDownTimeLabel's text to the formatted time (mm:ss.fff).
        /// Finally, it starts the CountDownTimer to countdown the ban duration.
        /// </remarks>
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

        #endregion
    }
}
