using Spire.Pdf.Exporting.XPS.Schema;
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
    /// <summary>
    /// The "ImageViewer" class represents a form for viewing images with zoom and rotation functionality.
    /// </summary>
    /// <remarks>
    /// This class allows users to view images with the ability to zoom in and out, rotate, and move the image within the viewport.
    /// It provides a user-friendly interface for interacting with images and supports various zoom modes for different viewing experiences.
    /// Credit: https://stackoverflow.com/questions/61924051/zoom-and-translate-an-image-from-the-mouse-location
    /// </remarks>
    public partial class ImageViewer : Form
    {
        #region Private Fields

        /// <summary>
        /// The Image "_imageToView" represents the image to be viewed.
        /// </summary>
        private Image _imageToView;

        /// <summary>
        /// The float "rotationAngle" represents the rotation angle of the image.
        /// </summary>
        private float rotationAngle = 0.0f;

        /// <summary>
        /// The float "zoomFactor" represents the zoom factor of the image.
        /// </summary>
        private float zoomFactor = 1.0f;

        /// <summary>
        /// The float "zoomStep" represents the step size for zooming.
        /// </summary>
        private float zoomStep = .05f;

        /// <summary>
        /// The RectangleF "imageRect" represents the rectangle area of the image.
        /// </summary>
        private RectangleF imageRect = RectangleF.Empty;

        /// <summary>
        /// The PointF "imageLocation" represents the location of the image.
        /// </summary>
        private PointF imageLocation = PointF.Empty;

        /// <summary>
        /// The PointF "mouseLocation" represents the location of the mouse.
        /// </summary>
        private PointF mouseLocation = PointF.Empty;

        /// <summary>
        /// The Bitmap "drawingImage" represents the image used for drawing.
        /// </summary>
        private Bitmap drawingImage = null;

        /// <summary>
        /// The ZoomMode "zoomMode" represents the mode of zooming.
        /// </summary>
        private ZoomMode zoomMode = ZoomMode.ImageLocation;

        #endregion

        #region Constructors

        /// <summary>
        /// The "ImageViewer" constructor initializes a new instance of the <see cref="ImageViewer"/> class with the specified image to view.
        /// </summary>
        /// <param name="ImageToView">The image to be displayed in the image viewer.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the ImageViewer class, initializing its components and event handlers
        /// for mouse and paint events to allow interaction with the displayed image.
        /// </remarks>
        public ImageViewer(Image ImageToView)
        {
            InitializeComponent();
            _imageToView = ImageToView;
            drawingImage = (Bitmap)_imageToView;
            imageRect = new RectangleF(Point.Empty, drawingImage.Size);
            ImagePictureBox.MouseWheel += ImagePictureBox_MouseWheel;
            ImagePictureBox.MouseMove += ImagePictureBox_MouseMove;
            ImagePictureBox.MouseDown += ImagePictureBox_MouseDown;
            ImagePictureBox.MouseUp += ImagePictureBox_MouseUp;
            ImagePictureBox.Paint += ImagePictureBox_Paint;
        }

        #endregion

        #region Enum

        /// <summary>
        /// Enum representing different zoom modes.
        /// </summary>
        private enum ZoomMode
        {
            /// <summary>
            /// Zoom mode based on image location.
            /// </summary>
            ImageLocation,

            /// <summary>
            /// Zoom mode centered on the canvas.
            /// </summary>
            CenterCanvas,

            /// <summary>
            /// Zoom mode centered on the mouse pointer.
            /// </summary>
            CenterMouse,

            /// <summary>
            /// Zoom mode with a mouse offset.
            /// </summary>
            MouseOffset
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "ImagePictureBox_MouseWheel" method handles the mouse wheel event to zoom in or out on the image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments containing information about the mouse wheel movement.</param>
        /// <remarks>
        /// This method adjusts the zoom factor based on the mouse wheel movement. It also updates the image rectangle 
        /// based on the current zoom mode to ensure the image remains centered or follows the mouse cursor during zoom.
        /// </remarks>
        private void ImagePictureBox_MouseWheel(object sender, MouseEventArgs e)
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

        /// <summary>
        /// The "ImagePictureBox_MouseDown" method handles the mouse down event on the image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments containing information about the mouse button state.</param>
        /// <remarks>
        /// This method captures the mouse location and image location when the left mouse button is pressed. 
        /// It also changes the cursor to indicate that the image can be moved.
        /// </remarks>
        private void ImagePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) 
                return;
            mouseLocation = e.Location;
            imageLocation = imageRect.Location;
            ImagePictureBox.Cursor = Cursors.NoMove2D;
        }

        /// <summary>
        /// The "ImagePictureBox_MouseMove" method handles the mouse move event on the image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments containing information about the mouse position.</param>
        /// <remarks>
        /// This method adjusts the image's location based on the mouse movement when the left mouse button is held down.
        /// It updates the image's position and refreshes the display to reflect the new position.
        /// </remarks>
        private void ImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) 
                return;
            float x = imageLocation.X + (e.Location.X - mouseLocation.X);
            float y = imageLocation.Y + (e.Location.Y - mouseLocation.Y);
            imageRect.Location = new PointF(x, y);
            ImagePictureBox.Invalidate();
        }

        /// <summary>
        /// The "ImagePictureBox_MouseUp" method handles the mouse up event on the image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments containing information about the mouse button state.</param>
        /// <remarks>
        /// This method sets the cursor back to the default cursor after the mouse button is released.
        /// </remarks>
        private void ImagePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            ImagePictureBox.Cursor = Cursors.Default;
        }

        /// <summary>
        /// The "ImagePictureBox_Paint" method handles the painting of the image on the PictureBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments containing information about the graphics context.</param>
        /// <remarks>
        /// This method calculates the drawing rectangle for the image and applies any transformations such as rotation before drawing the image.
        /// </remarks>
        private void ImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            RectangleF drawingRect = GetDrawingImageRect(imageRect);

            using (Matrix matrixRotation = new Matrix())
            {
                using (Matrix matrixTransform = new Matrix())
                {

                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

                    matrixRotation.RotateAt(rotationAngle, GetDrawingImageCenterPoint(drawingRect));
                    matrixTransform.Multiply(matrixRotation);

                    e.Graphics.Transform = matrixTransform;
                    e.Graphics.DrawImage(drawingImage, drawingRect);
                }
            }
        }

        /// <summary>
        /// The "ZoomRadioButton_CheckedChanged" method handles the event when a zoom radio button is checked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the zoom mode based on the selected radio button. It also changes the foreground color of the selected radio button to indicate the current selection.
        /// </remarks>
        private void ZoomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;
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

        /// <summary>
        /// The "RotationTrackBar_Scroll" method handles the event when the rotation trackbar value changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the rotation angle based on the value of the rotation trackbar. It also updates the rotation angle value label to display the current angle.
        /// </remarks>
        private void RotationTrackBar_Scroll(object sender, EventArgs e)
        {
            rotationAngle = RotationTrackBar.Value;
            RotationAngleValueLabel.Text = rotationAngle.ToString();
            ImagePictureBox.Invalidate();
            ImagePictureBox.Focus();
        }

        /// <summary>
        /// The "ImageViewer_Deactivate" method handles the event when the image viewer form loses focus.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method resets the rotation angle, zoom factor, and other image display settings to their default values. It then hides the image viewer form.
        /// </remarks>
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

        #endregion

        #region Private Drawing Methods

        /// <summary>
        /// The "GetScaledRect" method calculates a scaled rectangle based on the input rectangle and scale factor.
        /// </summary>
        /// <param name="rectangle">The input rectangle to scale.</param>
        /// <param name="scaleFactor">The factor by which to scale the rectangle.</param>
        /// <returns>A new rectangle that is the result of scaling the input rectangle by the scale factor.</returns>
        /// <remarks>
        /// This method calculates the size of the scaled rectangle by multiplying the width and height of the input rectangle by the scale factor.
        /// It then creates a new rectangle with the same location as the input rectangle and the calculated size, and returns it.
        /// </remarks>
        private RectangleF GetScaledRect(RectangleF rectangle, float scaleFactor)
        {
            SizeF sizeF = new SizeF(rectangle.Width * scaleFactor, rectangle.Height * scaleFactor);
            RectangleF rectangleF = new RectangleF(rectangle.Location, sizeF);
            return rectangleF;
        }

        /// <summary>
        /// The "GetDrawingImageRect" method calculates the size of the drawing image rectangle based on the input rectangle and zoom factor.
        /// </summary>
        /// <param name="rectangle">The input rectangle representing the image location and size.</param>
        /// <returns>A new rectangle representing the scaled image location and size.</returns>
        /// <remarks>
        /// This method calculates the size of the scaled image rectangle by multiplying the width and height of the input rectangle by the zoom factor.
        /// It then creates a new rectangle with the same location as the input rectangle and the calculated size, and returns it.
        /// </remarks>
        private RectangleF GetDrawingImageRect(RectangleF rectangle)
        {
            return GetScaledRect(rectangle, zoomFactor);
        }

        /// <summary>
        /// The "GetDrawingImageCenterPoint" method calculates the center point of the drawing image rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle representing the image location and size.</param>
        /// <returns>A point representing the center of the rectangle.</returns>
        /// <remarks>
        /// This method calculates the center point of the rectangle by adding half of its width to its X coordinate,
        /// and half of its height to its Y coordinate. It then returns a new point with these coordinates.
        /// </remarks>
        private PointF GetDrawingImageCenterPoint(RectangleF rectangle)
        {
            float x = rectangle.X + rectangle.Width / 2;
            float y = rectangle.Y + rectangle.Height / 2;
            PointF pointF = new PointF(x, y);
            return pointF;
        }

        /// <summary>
        /// The "CenterScaledRectangleOnCanvas" method centers a scaled rectangle on the canvas.
        /// </summary>
        /// <param name="rectangle">The rectangle to center.</param>
        /// <param name="canvas">The canvas rectangle.</param>
        /// <returns>A rectangle centered on the canvas.</returns>
        /// <remarks>
        /// This method first calculates the scaled version of the input rectangle using the current zoom factor.
        /// It then calculates the X and Y coordinates to center the scaled rectangle on the canvas.
        /// Finally, it updates the location of the input rectangle and returns it.
        /// </remarks>
        private RectangleF CenterScaledRectangleOnCanvas(RectangleF rectangle, RectangleF canvas)
        {
            RectangleF scaled = GetScaledRect(rectangle, zoomFactor);
            float x = (canvas.Width - scaled.Width) / 2;
            float y = (canvas.Height - scaled.Height) / 2;
            rectangle.Location = new PointF(x, y);
            return rectangle;
        }

        /// <summary>
        /// The "CenterScaledRectangleOnMousePosition" method centers a scaled rectangle on a specified mouse position.
        /// </summary>
        /// <param name="rectangle">The rectangle to center.</param>
        /// <param name="mousePosition">The position of the mouse.</param>
        /// <returns>A rectangle centered on the mouse position.</returns>
        /// <remarks>
        /// This method first calculates the scaled version of the input rectangle using the current zoom factor.
        /// It then calculates the X and Y coordinates to center the scaled rectangle on the specified mouse position.
        /// Finally, it updates the location of the input rectangle and returns it.
        /// </remarks>
        private RectangleF CenterScaledRectangleOnMousePosition(RectangleF rectangle, PointF mousePosition)
        {
            RectangleF scaled = GetScaledRect(rectangle, zoomFactor);
            float x = mousePosition.X - (scaled.Width / 2);
            float y = mousePosition.Y - (scaled.Height / 2);
            rectangle.Location = new PointF(x, y);
            return rectangle;
        }

        /// <summary>
        /// The "OffsetScaledRectangleOnMousePosition" method offsets a rectangle based on a mouse position and zoom factor.
        /// </summary>
        /// <param name="rectangle">The rectangle to offset.</param>
        /// <param name="currentZoom">The current zoom factor.</param>
        /// <param name="mousePosition">The position of the mouse.</param>
        /// <returns>The offset rectangle.</returns>
        /// <remarks>
        /// This method calculates the scaled version of the input rectangle using the current zoom factor.
        /// It then calculates the offset of the mouse position relative to the top-left corner of the input rectangle.
        /// Next, it calculates the scaled offset based on the current zoom factor.
        /// Finally, it adjusts the position of the input rectangle based on the scaled offset and returns the updated rectangle.
        /// </remarks>
        private RectangleF OffsetScaledRectangleOnMousePosition(RectangleF rectangle, float currentZoom, PointF mousePosition)
        {
            RectangleF currentRect = GetScaledRect(imageRect, currentZoom);
            if (!currentRect.Contains(mousePosition)) 
                return rectangle;
            float scaleRatio = currentRect.Width / GetScaledRect(rectangle, zoomFactor).Width;
            float mouseOffsetX = mousePosition.X - rectangle.X;
            float mouseOffsetY = mousePosition.Y - rectangle.Y;
            PointF mouseOffset = new PointF(mouseOffsetX, mouseOffsetY);
            float scaledOffsetX = mouseOffset.X / scaleRatio;
            float scaledOffsetY = mouseOffset.Y / scaleRatio;
            PointF scaledOffset = new PointF(scaledOffsetX, scaledOffsetY);
            float positionX = rectangle.X - (scaledOffset.X - mouseOffset.X);
            float positionY = rectangle.Y - (scaledOffset.Y - mouseOffset.Y);
            PointF position = new PointF(positionX, positionY);
            rectangle.Location = position;
            return rectangle;
        }

        #endregion
    }
}
