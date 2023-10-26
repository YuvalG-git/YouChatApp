using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YouChatApp.AttachedFiles
{
    public partial class ImageViewer : Form
    {
        Image _imageToView;
        private float rotationAngle = 0.0f;
        private float zoomFactor = 1.0f;
        private float zoomStep = .05f;

        private RectangleF imageRect = RectangleF.Empty;
        private PointF imageLocation = PointF.Empty;
        private PointF mouseLocation = PointF.Empty;

        private Bitmap drawingImage = null;
        private ZoomMode zoomMode = ZoomMode.ImageLocation;
        public ImageViewer(Image ImageToView)
        {
            InitializeComponent();
            _imageToView = ImageToView;
            drawingImage = (Bitmap)_imageToView;
            imageRect = new RectangleF(Point.Empty, drawingImage.Size);
            ImagePictureBox.MouseWheel += canvas_MouseWheel;
            ImagePictureBox.MouseMove += canvas_MouseMove;
            ImagePictureBox.MouseDown += canvas_MouseDown;
            ImagePictureBox.MouseUp += canvas_MouseUp;
            ImagePictureBox.Paint += canvas_Paint;
        }

        private void ImageViewer_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (BackgroundPanel.Bounds.Contains(BackgroundPanel.PointToClient(Cursor.Position)))
            //{
            //    if (e.Delta > 0)
            //    {
            //        // Zoom in
            //        ImagePictureBox.Width = (int)(ImagePictureBox.Width * 1.1);
            //        ImagePictureBox.Height = (int)(ImagePictureBox.Height * 1.1);
            //    }
            //    else
            //    {
            //        // Zoom out
            //        ImagePictureBox.Width = (int)(ImagePictureBox.Width / 1.1);
            //        ImagePictureBox.Height = (int)(ImagePictureBox.Height / 1.1);
            //    }
            //}
        }
        private Image Zoom(Image image, Size size)
        {
            Bitmap bitmap = new Bitmap(image, image.Width + (image.Width * size.Width / 100), image.Height + (image.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bitmap;
        }

        private void BackgroundPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            //if (ZoomTrackBar.Value > 0)
            //{
            //    ImagePictureBox.Image = Zoom(_imageToView, new Size(ZoomTrackBar.Value, ZoomTrackBar.Value));
            //}
        }


        private enum ZoomMode
        {
            ImageLocation,
            CenterCanvas,
            CenterMouse,
            MouseOffset
        }


        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;
            float zoomCurrent = zoomFactor;
            zoomFactor += e.Delta > 0 ? zoomStep : -zoomStep;
            if (zoomFactor < .10f) zoomStep = .01f;
            if (zoomFactor >= .10f) zoomStep = .05f;
            if (zoomFactor < .0f) zoomFactor = zoomStep;


            switch (zoomMode)
            {
                case ZoomMode.CenterCanvas:
                    imageRect = CenterScaledRectangleOnCanvas(imageRect, ImagePictureBox.ClientRectangle);
                    break;
                case ZoomMode.CenterMouse:
                    imageRect = CenterScaledRectangleOnMousePosition(imageRect, e.Location);
                    break;
                case ZoomMode.MouseOffset:
                    imageRect = OffsetScaledRectangleOnMousePosition(imageRect, zoomCurrent, e.Location);
                    break;
                default:
                    break;
            }
            ImagePictureBox.Invalidate();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            mouseLocation = e.Location;
            imageLocation = imageRect.Location;
            ImagePictureBox.Cursor = Cursors.NoMove2D;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            imageRect.Location =
                new PointF(imageLocation.X + (e.Location.X - mouseLocation.X),
                           imageLocation.Y + (e.Location.Y - mouseLocation.Y));
            ImagePictureBox.Invalidate();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e) =>
            ImagePictureBox.Cursor = Cursors.Default;

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var drawingRect = GetDrawingImageRect(imageRect);

            using (var mxRotation = new Matrix())
            using (var mxTransform = new Matrix())
            {

                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

                mxRotation.RotateAt(rotationAngle, GetDrawingImageCenterPoint(drawingRect));
                mxTransform.Multiply(mxRotation);

                e.Graphics.Transform = mxTransform;
                e.Graphics.DrawImage(drawingImage, drawingRect);
            }
        }

        private void trkRotationAngle_ValueChanged(object sender, EventArgs e)
        {
            //rotationAngle = trkAngle.Value;
            //ImagePictureBox.Invalidate();
            //ImagePictureBox.Focus();
        }
        private void ZoomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var selectedRadioButton = sender as RadioButton;
            if (selectedRadioButton.Checked)
            {
                zoomMode = (ZoomMode)int.Parse(selectedRadioButton.Tag.ToString());
            }
            foreach (RadioButton radioButton in ZoomMethodGroupBox.Controls.OfType<RadioButton>())
            {
                if (radioButton != selectedRadioButton)
                {
                    radioButton.ForeColor = Color.White;
                }
                else
                {
                    radioButton.ForeColor = Color.LimeGreen;
                }
            }
            ImagePictureBox.Focus();

        }
        private void RotationTrackBar_Scroll(object sender, EventArgs e)
        {
            rotationAngle = RotationTrackBar.Value;
            RotationAngleValueLabel.Text = rotationAngle.ToString();
            ImagePictureBox.Invalidate();
            ImagePictureBox.Focus();
        }

        private void ImageViewer_Deactivate(object sender, EventArgs e)
        {
            rotationAngle = 0.0f;
            zoomFactor = 1.0f;
            zoomStep = .05f;
            imageRect = RectangleF.Empty;
            imageLocation = PointF.Empty;
            mouseLocation = PointF.Empty;
            drawingImage = null;
            zoomMode = ZoomMode.ImageLocation;
            this.Hide();
        }

        #region Drawing Methods

        public RectangleF GetScaledRect(RectangleF rect, float scaleFactor) =>
            new RectangleF(rect.Location,
            new SizeF(rect.Width * scaleFactor, rect.Height * scaleFactor));

        public RectangleF GetDrawingImageRect(RectangleF rect) =>
            GetScaledRect(rect, zoomFactor);

        public PointF GetDrawingImageCenterPoint(RectangleF rect) =>
            new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);

        public RectangleF CenterScaledRectangleOnCanvas(RectangleF rect, RectangleF canvas)
        {
            var scaled = GetScaledRect(rect, zoomFactor);
            rect.Location = new PointF((canvas.Width - scaled.Width) / 2,
                                       (canvas.Height - scaled.Height) / 2);
            return rect;
        }

        public RectangleF CenterScaledRectangleOnMousePosition(RectangleF rect, PointF mousePosition)
        {
            var scaled = GetScaledRect(rect, zoomFactor);
            rect.Location = new PointF(mousePosition.X - (scaled.Width / 2),
                                       mousePosition.Y - (scaled.Height / 2));
            return rect;
        }

        public RectangleF OffsetScaledRectangleOnMousePosition(RectangleF rect, float currentZoom, PointF mousePosition)
        {
            var currentRect = GetScaledRect(imageRect, currentZoom);
            if (!currentRect.Contains(mousePosition)) return rect;

            float scaleRatio = currentRect.Width / GetScaledRect(rect, zoomFactor).Width;

            PointF mouseOffset = new PointF(mousePosition.X - rect.X, mousePosition.Y - rect.Y);
            PointF scaledOffset = new PointF(mouseOffset.X / scaleRatio, mouseOffset.Y / scaleRatio);
            PointF position = new PointF(rect.X - (scaledOffset.X - mouseOffset.X),
                                         rect.Y - (scaledOffset.Y - mouseOffset.Y));
            rect.Location = position;
            return rect;
        }
    }
    #endregion
}
