using AForge.Video.DirectShow;
using AForge.Video;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Tracing;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using YouChatApp.UserProfile;

namespace YouChatApp.AttachedFiles.CameraHandler
{
    /// <summary>
    /// The "Camera" class represents a form for capturing and managing camera operations.
    /// </summary>
    /// <remarks>
    /// This form provides functionality for capturing images and managing camera-related operations.
    /// It includes features such as setting up the camera, capturing images, managing image cropping,
    /// and handling various camera states.
    /// </remarks>
    public partial class Camera : Form
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly Image "CameraNotOpen" represents the image for a closed camera.
        /// </summary>
        private readonly Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;

        /// <summary>
        /// The readonly Image "CameraOpen" represents the image for an open camera.
        /// </summary>
        private readonly Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;

        /// <summary>
        /// The readonly Image "VideoOffImage" represents the image for a video off state.
        /// </summary>
        private readonly Image VideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile;

        #endregion

        #region Private Video Fields

        /// <summary>
        /// The FilterInfoCollection "videoDevices" represents the collection of video devices.
        /// </summary>
        private FilterInfoCollection videoDevices;

        /// <summary>
        /// The VideoCaptureDevice "videoSource" represents the video source.
        /// </summary>
        private VideoCaptureDevice videoSource;

        #endregion

        #region Private Timer Fields

        /// <summary>
        /// The int "waitingTime" represents the waiting time.
        /// </summary>
        private int waitingTime = 0;

        /// <summary>
        /// The TimeSpan "TimerTickTimeSpan" represents the timer tick time span.
        /// </summary>
        private TimeSpan TimerTickTimeSpan;

        /// <summary>
        /// The TimeSpan "CountDownTimeSpan" represents the countdown time span.
        /// </summary>
        private TimeSpan CountDownTimeSpan;

        #endregion

        #region Private Management Fields

        /// <summary>
        /// The ManagementEventWatcher "watcher" represents the management event watcher.
        /// </summary>
        private ManagementEventWatcher watcher;

        #endregion

        #region Private Cropping Fields

        /// <summary>
        /// The Rectangle "selectionCropRectangle" represents the rectangle for selection crop.
        /// </summary>
        private Rectangle selectionCropRectangle;

        /// <summary>
        /// The bool "isCropping" indicates whether cropping is in progress.
        /// </summary>
        private bool isCropping = false;

        /// <summary>
        /// The int "_cropSize" represents the crop size.
        /// </summary>
        private int _cropSize;

        /// <summary>
        /// The int "_cropXLocation" represents the crop X location.
        /// </summary>
        private int _cropXLocation;

        /// <summary>
        /// The int "_cropYLocation" represents the crop Y location.
        /// </summary>
        private int _cropYLocation;

        #endregion

        #region Private Fields

        /// <summary>
        /// The bool "isImageForGroupChat" indicates whether the image is for a group chat.
        /// </summary>
        private bool isImageForGroupChat;

        /// <summary>
        /// The bool "CameraIsOpen" indicates whether the camera is open.
        /// </summary>
        private bool CameraIsOpen = false;

        /// <summary>
        /// The bool "_isImageTaken" indicates whether an image is taken.
        /// </summary>
        private bool _isImageTaken = false;

        /// <summary>
        /// The Bitmap "capturedImage" represents the captured image.
        /// </summary>
        private Bitmap capturedImage;

        /// <summary>
        /// The Image "imageTaken" represents the taken image.
        /// </summary>
        private Image imageTaken;

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The static Image "imageToSend" represents the image to send.
        /// </summary>
        private static Image imageToSend;

        #endregion

        #region Constructors

        /// <summary>
        /// The "Camera" constructor initializes a new instance of the  <see cref="Camera"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up various components for the Camera application, including initializing the form,
        /// setting the default timer option, setting up the crop rectangle selection, enabling crop controls, setting scroll bars,
        /// and initializing the video off image from the ProfileDetailsHandler.
        /// </remarks>
        public Camera()
        {
            InitializeComponent();
            TimerOptionComboBox.SelectedIndex = 0;
            SetSelectionCropRectangle();
            SetCropControlsEnabledProperty();
            SetScrollBars();
            VideoOffImage = ProfileDetailsHandler.ProfilePicture;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "IsImageForGroupChat" property indicates whether the image is intended for a group chat.
        /// It gets or sets a value indicating whether the image is intended for a group chat.
        /// </summary>
        /// <value>
        /// true if the image is intended for a group chat; otherwise, false.
        /// </value>
        public bool IsImageForGroupChat
        {
            get
            {
                return isImageForGroupChat;
            }
            set
            {
                isImageForGroupChat = value;
            }
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// The "ImageToSend" property represents the image to send.
        /// It gets or sets the image to send.
        /// </summary>
        /// <value>
        /// The image to send.
        /// </value>
        public static Image ImageToSend
        {
            get
            {
                return imageToSend;
            }
            set
            {
                imageToSend = value;
            }
        }
        #endregion

        #region Private Initializtion Methods

        /// <summary>
        /// The "SetScrollBars" method initializes the scroll bars for adjusting the crop size and position.
        /// </summary>
        /// <remarks>
        /// This method sets the minimum and maximum values for the crop size horizontal scroll bar
        /// based on the available space in the UserImageTakenPictureBox.
        /// It sets the initial value of the crop size horizontal scroll bar to the current crop size.
        /// It sets the minimum and maximum values for the crop X location horizontal scroll bar
        /// based on the available horizontal space in the UserImageTakenPictureBox for moving the crop rectangle.
        /// It sets the initial value of the crop X location horizontal scroll bar to the current X location of the crop rectangle.
        /// It sets the minimum and maximum values for the crop Y location horizontal scroll bar
        /// based on the available vertical space in the UserImageTakenPictureBox for moving the crop rectangle.
        /// It sets the initial value of the crop Y location horizontal scroll bar to the current Y location of the crop rectangle.
        /// </remarks>
        private void SetScrollBars()
        {
            CropSizeHorizontalScrollBar.Minimum = 50;
            CropSizeHorizontalScrollBar.Maximum = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation);
            CropSizeHorizontalScrollBar.Value = _cropSize;
            CropXLocationHorizontalScrollBar.Minimum = 0;
            CropXLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Width - _cropSize;
            CropXLocationHorizontalScrollBar.Value = _cropXLocation;
            CropYLocationHorizontalScrollBar.Minimum = 0;
            CropYLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Height - _cropSize;
            CropYLocationHorizontalScrollBar.Value = _cropYLocation;
        }

        /// <summary>
        /// The "InitializeCameraList" method initializes the list of available camera devices by retrieving information about video input devices.
        /// </summary>
        /// <remarks>
        /// This method creates a new FilterInfoCollection object to retrieve information about video input devices.
        /// If no video devices are found, it disables the CameraModeCustomButton and displays a message box indicating no devices were found.
        /// If video devices are found, it enables the CameraModeCustomButton and populates the CameraDeviceComboBox with the names of the devices.
        /// It then selects the first device in the list by default and calls the "StartVideoSource" method to start capturing video from the selected device.
        /// </remarks>
        private void InitializeCameraList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                CameraModeCustomButton.Enabled = false;
                MessageBox.Show("No video devices found.");
                return;
            }
            else
            {
                CameraModeCustomButton.Enabled = true;
                CameraDeviceComboBox.Items.Clear();
                foreach (FilterInfo device in videoDevices)
                {
                    CameraDeviceComboBox.Items.Add(device.Name);
                }
                CameraDeviceComboBox.SelectedIndex = 0;
            }
            StartVideoSource();
        }

        /// <summary>
        /// The "InitializeCameraChangeDetection" method initializes the camera change detection by creating a management event watcher and setting up a query to monitor hardware changes.
        /// </summary>
        /// <remarks>
        /// This method creates a ManagementEventWatcher object to monitor hardware changes related to video devices.
        /// It sets up an event handler to handle the event when a video device change is detected.
        /// It then sets up a WqlEventQuery to listen for device arrival and device removal events.
        /// Finally, it starts the watcher to begin listening for hardware changes.
        /// </remarks>
        private void InitializeCameraChangeDetection()
        {
            // Create a management event watcher to monitor hardware changes.
            watcher = new ManagementEventWatcher();
            watcher.EventArrived += new EventArrivedEventHandler(HandleVideoDeviceChange);

            // Set up a query to listen for device arrival and device removal events.
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            watcher.Query = query;

            // Start listening for hardware changes.
            watcher.Start();
        }

        /// <summary>
        /// The "Camera_Load" method handles the load event of the Camera form to initialize camera devices and start monitoring camera changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the Camera form is loaded.
        /// It calls the "InitializeCameraList" method to load the initial camera devices.
        /// It also calls the "InitializeCameraChangeDetection" method to start monitoring camera changes.
        /// </remarks>
        private void Camera_Load(object sender, EventArgs e)
        {
            InitializeCameraList(); // Load the initial camera devices when the form loads.
            InitializeCameraChangeDetection(); // Start monitoring camera changes.
        }

        #endregion

        #region Private Crop Methods

        /// <summary>
        /// The "SetSelectionCropRectangle" method initializes the selection crop rectangle for cropping an image.
        /// </summary>
        /// <remarks>
        /// This method sets the crop size to 200 pixels and calculates the X and Y locations
        /// to center the crop rectangle in the UserImageTakenPictureBox.
        /// It updates the corresponding text boxes with the crop size, X location, and Y location.
        /// Finally, it creates a new selection crop rectangle with the calculated dimensions.
        /// </remarks>
        private void SetSelectionCropRectangle()
        {
            _cropSize = 200;
            _cropXLocation = (UserImageTakenPictureBox.Width - _cropSize) / 2;
            _cropYLocation = (UserImageTakenPictureBox.Height - _cropSize) / 2;
            CropSizeCustomTextBox.TextContent = _cropSize.ToString();
            CropXLocationustomTextBox.TextContent = _cropXLocation.ToString();
            CropYLocationustomTextBox.TextContent = _cropYLocation.ToString();
            selectionCropRectangle = new Rectangle(_cropXLocation, _cropYLocation, _cropSize, _cropSize);
        }

        /// <summary>
        /// The "Camera_MouseWheel" method handles the mouse wheel event of the camera to zoom in or out on the image being cropped.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the mouse wheel is scrolled while the cursor is over the UserImageTakenPictureBox.
        /// If cropping is active, it calculates the new size for the crop rectangle based on the mouse wheel delta.
        /// It ensures that the new size is within the valid range and updates the crop rectangle, scroll bars, and UI controls accordingly.
        /// </remarks>
        private void Camera_MouseWheel(object sender, MouseEventArgs e)
        {
            if (UserImageTakenPictureBox.Bounds.Contains(Cursor.Position))
            {
                if (isCropping)
                {
                    int newSize;
                    if (e.Delta > 0)
                    {
                        // Zoom in
                        newSize = (int)(_cropSize * 1.1);
                    }
                    else
                    {
                        // Zoom out
                        newSize = (int)(_cropSize / 1.1);
                    }
                    if ((newSize <= (UserImageTakenPictureBox.Width - _cropXLocation)) && (newSize <= (UserImageTakenPictureBox.Height - _cropYLocation)) && (newSize >= CropSizeHorizontalScrollBar.Minimum) && (newSize >= CropSizeHorizontalScrollBar.Minimum))
                    {
                        _cropSize = newSize;
                        CropSizeHorizontalScrollBar.Value = _cropSize;
                        CropSizeCustomTextBox.TextContent = _cropSize.ToString();
                        CropSizeCustomTextBox.SelectText(CropSizeCustomTextBox.Text.Length, 0);
                        selectionCropRectangle.Width = _cropSize;
                        selectionCropRectangle.Height = _cropSize;
                        CropXLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Width - _cropSize;
                        CropYLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Height - _cropSize;
                        UserImageTakenPictureBox.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// The "UserImageTakenPictureBox_MouseDown" method handles the mouse down event of the UserImageTakenPictureBox during cropping.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        /// <remarks>
        /// This method is triggered when the left mouse button is pressed down on the UserImageTakenPictureBox during cropping.
        /// It updates the crop X and Y locations based on the mouse cursor position, updates the selection crop rectangle, and updates related UI controls.
        /// </remarks>
        private void UserImageTakenPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if ((isCropping) && (e.Button == MouseButtons.Left))
            {
                if ((e.X < (UserImageTakenPictureBox.Width - _cropSize)) && (e.Y < (UserImageTakenPictureBox.Height - _cropSize)))
                {
                    _cropXLocation = e.X;
                    _cropYLocation = e.Y;
                    selectionCropRectangle.X = _cropXLocation;
                    selectionCropRectangle.Y = _cropYLocation;
                    CropXLocationustomTextBox.TextContent = _cropXLocation.ToString();
                    CropYLocationustomTextBox.TextContent = _cropYLocation.ToString();
                    CropSizeHorizontalScrollBar.Maximum = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation);
                    CropXLocationHorizontalScrollBar.Value = _cropXLocation;
                    CropYLocationHorizontalScrollBar.Value = _cropYLocation;
                    UserImageTakenPictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// The "CropImageCustomButton_Click" method handles the click event of the CropImageCustomButton to crop the image and open a viewer for the cropped image.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "CropImage" method to get a cropped image.
        /// If the cropped image is not null, it opens a viewer for the cropped image using the "OpenCroppedImageViewer" method.
        /// </remarks>
        private void CropImageCustomButton_Click(object sender, EventArgs e)
        {
            Image croppedImage = CropImage();
            if (croppedImage != null)
            {
                OpenCroppedImageViewer(croppedImage);
            }
        }

        /// <summary>
        /// The "CropImage" method crops the selected region from the image taken by the camera.
        /// </summary>
        /// <returns>
        /// A cropped image if cropping parameters are valid; otherwise, returns null.
        /// </returns>
        /// <remarks>
        /// This method checks if an image has been taken by the camera.
        /// If the selection crop rectangle has a width and height greater than 0, it creates a new bitmap with the size of the selection crop rectangle.
        /// It then draws the selected region from the original image onto the new bitmap.
        /// Finally, it enables the SaveImageCustomButton and returns the cropped image.
        /// If the image is null or the selection crop rectangle dimensions are invalid, it returns null.
        /// </remarks>
        private Image CropImage()
        {
            if (imageTaken != null)
            {
                if (selectionCropRectangle.Width > 0 && selectionCropRectangle.Height > 0)
                {
                    // Crop the selected region
                    Bitmap croppedImage = new Bitmap(selectionCropRectangle.Width, selectionCropRectangle.Height);
                    using (Graphics g = Graphics.FromImage(croppedImage))
                    {
                        g.DrawImage(imageTaken, 0, 0, selectionCropRectangle, GraphicsUnit.Pixel);
                    }
                    SaveImageCustomButton.Enabled = true;
                    return croppedImage;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// The "OpenCroppedImageViewer" method opens a new instance of the ImageViewer form to display the specified image.
        /// </summary>
        /// <param name="imageToView">The image to be displayed in the ImageViewer form.</param>
        private void OpenCroppedImageViewer(Image imageToView)
        {
            ImageViewer image = new ImageViewer(imageToView);
            image.Show();
        }

        /// <summary>
        /// The "SetCropControlsEnabledProperty" method sets the enabled property of crop-related controls based on the value of the isCropping flag.
        /// </summary>
        /// <remarks>
        /// This method enables or disables the following controls based on the isCropping flag:
        /// - CropSizeCustomTextBox
        /// - CropXLocationustomTextBox
        /// - CropYLocationustomTextBox
        /// - CropSizeHorizontalScrollBar
        /// - CropXLocationHorizontalScrollBar
        /// - CropYLocationHorizontalScrollBar
        /// - CropImageCustomButton
        /// </remarks>
        private void SetCropControlsEnabledProperty()
        {
            CropSizeCustomTextBox.Enabled = isCropping;
            CropXLocationustomTextBox.Enabled = isCropping;
            CropYLocationustomTextBox.Enabled = isCropping;
            CropSizeHorizontalScrollBar.Enabled = isCropping;
            CropXLocationHorizontalScrollBar.Enabled = isCropping;
            CropYLocationHorizontalScrollBar.Enabled = isCropping;
            CropImageCustomButton.Enabled = isCropping;
        }

        /// <summary>
        /// The "HandleCropSizeCustomTextBoxValue" method handles the validation and processing of the crop size value in the CropSizeCustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if cropping is active and the entered text in the CropSizeCustomTextBox is numeric.
        /// If so, it parses the text to an integer and updates the crop size of the selection rectangle accordingly.
        /// It ensures that the crop size is within the valid range based on the image size and the current crop location.
        /// If the entered value is out of range, it adjusts the crop size to the nearest valid value and updates the scroll bars' maximum values accordingly.
        /// Finally, it updates the text content of the CropSizeCustomTextBox, selects the text, and invalidates the UserImageTakenPictureBox to redraw the image with the updated selection crop rectangle.
        /// </remarks>
        private void HandleCropSizeCustomTextBoxValue()
        {
            if (isCropping)
            {
                string Text = CropSizeCustomTextBox.TextContent;
                if ((Text != "") && (StringHandler.IsNumeric(Text)))
                {
                    int newSize = int.Parse(Text);
                    if (newSize < 50)
                    {
                        _cropSize = 50;
                    }
                    else if ((newSize > (UserImageTakenPictureBox.Width - _cropXLocation)) || (newSize > (UserImageTakenPictureBox.Height - _cropYLocation)))
                    {
                        _cropSize = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation); ;
                    }
                    else
                    {
                        _cropSize = newSize;
                    }
                    CropSizeHorizontalScrollBar.Value = _cropSize;
                    CropSizeCustomTextBox.TextContent = _cropSize.ToString();
                    CropSizeCustomTextBox.SelectText(CropSizeCustomTextBox.Text.Length, 0);
                    selectionCropRectangle.Width = _cropSize;
                    selectionCropRectangle.Height = _cropSize;
                    CropXLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Width - _cropSize;
                    CropYLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Height - _cropSize;
                    UserImageTakenPictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// The "HandleCropXLocationCustomTextBoxValue" method handles the validation and processing of the X location value in the CropXLocationustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if cropping is active and the entered text in the CropXLocationustomTextBox is numeric.
        /// If so, it parses the text to an integer and updates the X location of the selection crop rectangle accordingly.
        /// It also ensures that the X location is within the valid range based on the image size and the crop size.
        /// If the entered value is out of range, it adjusts the X location to the nearest valid value and updates the scroll bar maximum accordingly.
        /// Finally, it updates the text content of the CropXLocationustomTextBox, selects the text, and invalidates the UserImageTakenPictureBox to redraw the image with the updated selection crop rectangle.
        /// </remarks>
        private void HandleCropXLocationCustomTextBoxValue()
        {
            if (isCropping)
            {
                string Text = CropXLocationustomTextBox.TextContent;
                if ((Text != "") && (StringHandler.IsNumeric(Text)))
                {
                    int newXLocation = int.Parse(Text);
                    if (newXLocation < 0)
                    {
                        _cropXLocation = 0;
                        CropSizeHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Height - _cropYLocation;
                    }
                    else if (newXLocation > (UserImageTakenPictureBox.Width - _cropSize))
                    {
                        _cropXLocation = UserImageTakenPictureBox.Width - _cropSize;
                        CropSizeHorizontalScrollBar.Maximum = _cropSize;
                    }
                    else
                    {
                        _cropXLocation = newXLocation;
                        CropSizeHorizontalScrollBar.Maximum = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation);
                    }
                    CropXLocationHorizontalScrollBar.Value = _cropXLocation;
                    CropXLocationustomTextBox.TextContent = _cropXLocation.ToString();
                    CropXLocationustomTextBox.SelectText(CropXLocationustomTextBox.Text.Length, 0);
                    selectionCropRectangle.X = _cropXLocation;
                    UserImageTakenPictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// The "HandleCropYLocationCustomTextBoxValue" method handles the validation and processing of the Y location value in the CropYLocationustomTextBox.
        /// </summary>
        /// <remarks>
        /// This method checks if cropping is active and the entered text in the CropYLocationustomTextBox is numeric.
        /// If so, it parses the text to an integer and updates the Y location of the selection crop rectangle accordingly.
        /// It also ensures that the Y location is within the valid range based on the image size and the crop size.
        /// If the entered value is out of range, it adjusts the Y location to the nearest valid value and updates the scroll bar maximum accordingly.
        /// Finally, it updates the text content of the CropYLocationustomTextBox, selects the text, and invalidates the UserImageTakenPictureBox to redraw the image with the updated selection crop rectangle.
        /// </remarks>
        private void HandleCropYLocationCustomTextBoxValue()
        {
            if (isCropping)
            {
                string Text = CropYLocationustomTextBox.TextContent;
                if ((Text != "") && (StringHandler.IsNumeric(Text)))
                {
                    int newYLocation = int.Parse(Text);
                    if (newYLocation < 0)
                    {
                        _cropYLocation = 0;
                        CropSizeHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Width - _cropXLocation;
                    }
                    else if (newYLocation > (UserImageTakenPictureBox.Height - _cropSize))
                    {
                        _cropYLocation = UserImageTakenPictureBox.Height - _cropSize;
                        CropSizeHorizontalScrollBar.Maximum = _cropSize;
                    }
                    else
                    {
                        _cropYLocation = newYLocation;
                        CropSizeHorizontalScrollBar.Maximum = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation);
                    }
                    CropYLocationHorizontalScrollBar.Value = _cropYLocation;
                    CropYLocationustomTextBox.TextContent = _cropYLocation.ToString();
                    CropYLocationustomTextBox.SelectText(CropYLocationustomTextBox.Text.Length, 0);
                    selectionCropRectangle.Y = _cropYLocation;
                    UserImageTakenPictureBox.Invalidate();
                }
            }
        }

        /// <summary>
        /// The "CropYLocationustomTextBox_TextChangedEvent" method handles the TextChanged event of the CropYLocationustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method updates the Y location of the selection crop rectangle based on the new value in the CropYLocationustomTextBox.
        /// If cropping is active, it parses the text content of the text box to an integer and updates the Y location of the selection crop rectangle.
        /// It then invalidates the UserImageTakenPictureBox to redraw the image with the updated selection crop rectangle.
        /// </remarks>
        private void CropYLocationustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            if (isCropping)
            {
                selectionCropRectangle.Y = int.Parse(CropYLocationustomTextBox.TextContent);
                UserImageTakenPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// The "CropSizeCustomTextBox_KeyDown" method handles the KeyDown event of the CropSizeCustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the key pressed is the Enter key.
        /// If it is, it calls the HandleCropSizeCustomTextBoxValue method to handle the new value in the text box.
        /// </remarks>
        private void CropSizeCustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCropSizeCustomTextBoxValue();
            }
        }

        /// <summary>
        /// The "CropSizeCustomTextBox_Leave" method handles the Leave event of the CropSizeCustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleCropSizeCustomTextBoxValue method to handle the new value in the text box.
        /// </remarks>
        private void CropSizeCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCropSizeCustomTextBoxValue();
        }

        /// <summary>
        /// The "CropXLocationustomTextBox_Leave" method handles the Leave event of the CropXLocationustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleCropXLocationCustomTextBoxValue method to handle the new value in the text box.
        /// </remarks>
        private void CropXLocationustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCropXLocationCustomTextBoxValue();
        }

        /// <summary>
        /// The "CropXLocationustomTextBox_KeyDown" method handles the KeyDown event of the CropXLocationustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the key pressed is the Enter key.
        /// If it is, it calls the HandleCropXLocationCustomTextBoxValue method to handle the new value in the text box.
        /// </remarks>
        private void CropXLocationustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCropXLocationCustomTextBoxValue();
            }
        }

        /// <summary>
        /// The "CropYLocationustomTextBox_KeyDown" method handles the KeyDown event of the CropYLocationustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method checks if the key pressed is the Enter key.
        /// If it is, it calls the HandleCropYLocationCustomTextBoxValue method to handle the new value in the text box.
        /// </remarks>
        private void CropYLocationustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCropYLocationCustomTextBoxValue();
            }
        }

        /// <summary>
        /// The "CropYLocationustomTextBox_MouseLeave" method handles the MouseLeave event of the CropYLocationustomTextBox.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method handles the mouse leaving the CropYLocationustomTextBox.
        /// It calls the HandleCropYLocationCustomTextBoxValue method to handle the new value in the text box.
        /// </remarks>
        private void CropYLocationustomTextBox_MouseLeave(object sender, EventArgs e)
        {
            HandleCropYLocationCustomTextBoxValue();
        }

        /// <summary>
        /// The "CropSizeHorizontalScrollBar_Scroll" method handles the Scroll event of the CropSizeHorizontalScrollBar.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adjusts the size of the crop rectangle based on the scroll bar's value.
        /// It also updates the text box displaying the size value, updates the maximum values of the X and Y location scroll bars to keep the crop rectangle within bounds,
        /// and redraws the image.
        /// </remarks>
        private void CropSizeHorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (isCropping)
            {
                if (e.Type == ScrollEventType.SmallIncrement)
                {
                    HandleLargeChangeValue(CropSizeHorizontalScrollBar);
                }
                int newSize = CropSizeHorizontalScrollBar.Value;
                _cropSize = newSize;
                CropSizeHorizontalScrollBar.Value = _cropSize;
                CropSizeCustomTextBox.TextContent = _cropSize.ToString();
                CropSizeCustomTextBox.SelectText(CropSizeCustomTextBox.Text.Length, 0);
                selectionCropRectangle.Width = _cropSize;
                selectionCropRectangle.Height = _cropSize;
                CropXLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Width - _cropSize;
                CropYLocationHorizontalScrollBar.Maximum = UserImageTakenPictureBox.Height - _cropSize;
                UserImageTakenPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// The "CropXLocationHorizontalScrollBar_Scroll" method handles the Scroll event of the CropXLocationHorizontalScrollBar.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adjusts the crop rectangle's X location based on the scroll bar's value.
        /// It also updates the maximum value of the CropSizeHorizontalScrollBar to ensure the crop rectangle stays within bounds.
        /// Finally, it updates the text box displaying the X location value and redraws the image.
        /// </remarks>
        private void CropXLocationHorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (isCropping)
            {
                if (e.Type == ScrollEventType.SmallIncrement)
                {
                    HandleLargeChangeValue(CropXLocationHorizontalScrollBar);
                }
                int newXLocation = CropXLocationHorizontalScrollBar.Value;
                _cropXLocation = newXLocation;
                CropSizeHorizontalScrollBar.Maximum = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation);
                CropXLocationHorizontalScrollBar.Value = _cropXLocation;
                CropXLocationustomTextBox.TextContent = _cropXLocation.ToString();
                CropXLocationustomTextBox.SelectText(CropXLocationustomTextBox.Text.Length, 0);
                selectionCropRectangle.X = _cropXLocation;
                UserImageTakenPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// The "CropYLocationHorizontalScrollBar_Scroll" method handles the Scroll event of the CropYLocationHorizontalScrollBar.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method adjusts the crop rectangle's Y location based on the scroll bar's value.
        /// It also updates the maximum value of the CropSizeHorizontalScrollBar to ensure the crop rectangle stays within bounds.
        /// Finally, it updates the text box displaying the Y location value and redraws the image.
        /// </remarks>
        private void CropYLocationHorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (isCropping)
            {
                if (e.Type == ScrollEventType.SmallIncrement)
                {
                    HandleLargeChangeValue(CropYLocationHorizontalScrollBar);
                }
                int newYLocation = CropYLocationHorizontalScrollBar.Value;
                _cropYLocation = newYLocation;
                CropSizeHorizontalScrollBar.Maximum = Math.Min(UserImageTakenPictureBox.Width - _cropXLocation, UserImageTakenPictureBox.Height - _cropYLocation);
                CropYLocationHorizontalScrollBar.Value = _cropYLocation;
                CropYLocationustomTextBox.TextContent = _cropYLocation.ToString();
                CropYLocationustomTextBox.SelectText(CropYLocationustomTextBox.Text.Length, 0);
                selectionCropRectangle.Y = _cropYLocation;
                UserImageTakenPictureBox.Invalidate();
            }
        }

        /// <summary>
        /// The "CropSizeHorizontalScrollBar_ValueChanged" method handles the ValueChanged event of the CropSizeHorizontalScrollBar.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleLargeChangeValue method to adjust the LargeChange property of the CropSizeHorizontalScrollBar.
        /// The adjustment ensures smooth scrolling behavior when the scroll bar is near its maximum value.
        /// </remarks>
        private void CropSizeHorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            HandleLargeChangeValue(CropSizeHorizontalScrollBar);
        }

        /// <summary>
        /// The "HandleLargeChangeValue" method adjusts the LargeChange property of a scroll bar based on its current value and maximum value.
        /// </summary>
        /// <param name="scrollBar">The scroll bar whose LargeChange property needs to be adjusted.</param>
        /// <remarks>
        /// If the current value of the scroll bar is less than the maximum value minus the LargeChange value,
        /// the LargeChange property is set to 10. Otherwise, it is set to 1.
        /// This adjustment ensures smooth scrolling behavior when the scroll bar is near its maximum value.
        /// </remarks>
        private void HandleLargeChangeValue(HScrollBar scrollBar)
        {
            if (scrollBar.Value < (scrollBar.Maximum - scrollBar.LargeChange))
            {
                scrollBar.LargeChange = 10;
            }
            else
            {
                scrollBar.LargeChange = 1;
            }
        }

        /// <summary>
        /// The "CropXLocationHorizontalScrollBar_ValueChanged" method handles the ValueChanged event for the CropXLocationHorizontalScrollBar.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleLargeChangeValue method with the CropXLocationHorizontalScrollBar.
        /// </remarks>
        private void CropXLocationHorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            HandleLargeChangeValue(CropXLocationHorizontalScrollBar);
        }

        /// <summary>
        /// The "CropYLocationHorizontalScrollBar_ValueChanged" method handles the ValueChanged event for the CropYLocationHorizontalScrollBar.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the HandleLargeChangeValue method with the CropYLocationHorizontalScrollBar.
        /// </remarks>
        private void CropYLocationHorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            HandleLargeChangeValue(CropYLocationHorizontalScrollBar);
        }

        #endregion

        #region Private Video Methods

        /// <summary>
        /// The "StartVideoSource" method starts the video source to capture video from the selected camera device.
        /// </summary>
        /// <remarks>
        /// This method checks if the video source is already running and stops it if so.
        /// It then creates a new VideoCaptureDevice object using the selected camera device's MonikerString.
        /// It subscribes to the NewFrame event to handle new frames received from the video source.
        /// If the camera mode is open, it starts the video source to begin capturing video.
        /// If the camera mode is closed, it sets the UserVideoPictureBox to display a placeholder image indicating that the video is off.
        /// </remarks>
        private void StartVideoSource()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            videoSource = new VideoCaptureDevice(videoDevices[CameraDeviceComboBox.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);

            if (CameraIsOpen)
            {
                videoSource.Start();
            }
            else
            {
                UserVideoPictureBox.Image = VideoOffImage;
            }
        }

        /// <summary>
        /// The "HandleVideoDeviceChange" method handles the event of a video device change to refresh the camera list.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when a hardware change related to video devices is detected.
        /// It invokes the "RefreshCameraList" method to refresh the camera list on the UI thread.
        /// </remarks>
        private void HandleVideoDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshCameraList));
        }

        /// <summary>
        /// The "RefreshCameraList" method refreshes the list of available camera devices.
        /// </summary>
        /// <remarks>
        /// This method calls the "InitializeCameraList" method to refresh the camera list.
        /// </remarks>
        private void RefreshCameraList()
        {
            InitializeCameraList(); // Refresh the camera list.
        }

        /// <summary>
        /// The "VideoSource_NewFrame" method handles the new frame event of the video source to display the new frame in the UserVideoPictureBox.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="eventArgs">The event arguments containing the new frame.</param>
        /// <remarks>
        /// This method is triggered when a new frame is received from the video source.
        /// It saves the new frame as a JPEG image in a memory stream and sets it as the image for the UserVideoPictureBox.
        /// </remarks>
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            using (var stream = new MemoryStream())
            {
                eventArgs.Frame.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            UserVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();
        }

        /// <summary>
        /// The "RefreshCameraOptionsCustomButton_Click" method handles the Click event for the RefreshCameraOptionsCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the InitializeCameraList method to refresh the list of available cameras.
        /// </remarks>
        private void RefreshCameraOptionsCustomButton_Click(object sender, EventArgs e)
        {
            InitializeCameraList(); // Refresh the camera list.
        }

        #endregion

        #region Private Camera Process Methods

        /// <summary>
        /// The "SaveImageCustomButton_Click" method handles the click event of the SaveImageCustomButton to save the cropped image and close the form.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method calls the "CropImage" method to get the cropped image.
        /// It assigns the cropped image to the "imageToSend" variable and sets the dialog result to OK, indicating that the operation was successful.
        /// Finally, it closes the form.
        /// </remarks>
        private void SaveImageCustomButton_Click(object sender, EventArgs e)
        {
            imageToSend = CropImage();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// The "UserImageTakenPictureBox_Paint" method handles the paint event of the UserImageTakenPictureBox to draw the selection crop rectangle.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The paint event arguments.</param>
        /// <remarks>
        /// This method is triggered when the UserImageTakenPictureBox is repainted.
        /// If cropping is active or an image has been taken, it draws a red rectangle representing the selection crop rectangle using the specified pen.
        /// </remarks>
        private void UserImageTakenPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (isCropping || _isImageTaken)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionCropRectangle);
                }
            }
        }

        /// <summary>
        /// The "CameraModeCustomButton_Click" method handles the click event of the CameraModeCustomButton to toggle the camera mode between open and closed.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the CameraModeCustomButton is clicked.
        /// It toggles the CameraIsOpen flag to indicate whether the camera is open or closed.
        /// If the camera is opened, it updates the button's background image and tooltip, starts the camera open timer, and enables the StartVideoSource method.
        /// If the camera is closed, it updates the button's background image and tooltip, and disables the ImageTakerCustomButton.
        /// </remarks>
        private void CameraModeCustomButton_Click(object sender, EventArgs e)
        {
            if (CameraIsOpen == false)
                CameraIsOpen = true;
            else
                CameraIsOpen = false;
            if (CameraIsOpen)
            {
                CameraModeCustomButton.BackgroundImage = CameraNotOpen;
                ToolTip.SetToolTip(CameraModeCustomButton, "To stop video");
                CameraOpenTimer.Start();
            }
            else
            {
                CameraModeCustomButton.BackgroundImage = CameraOpen;
                ToolTip.SetToolTip(CameraModeCustomButton, "To start video");
                ImageTakerCustomButton.Enabled = false;
            }
            StartVideoSource();
        }

        /// <summary>
        /// The "ImageTakerCustomButton_Click" method handles the click event of the ImageTakerCustomButton to capture an image for cropping.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the ImageTakerCustomButton is clicked.
        /// If the camera is open, it sets the cropping flag to false, enables the SaveImageCustomButton, and checks if a waiting time is set.
        /// If no waiting time is set, it calls the "SetImage" method to capture and set the image immediately.
        /// If a waiting time is set, it initializes the countdown timer and sets the UserImageTakenPictureBox to display the countdown images.
        /// Finally, it starts the timer to begin the countdown and enables/disables UI controls accordingly.
        /// </remarks>
        private void ImageTakerCustomButton_Click(object sender, EventArgs e)
        {
            if (CameraIsOpen)
            {
                isCropping = false;
                SaveImageCustomButton.Enabled = true;

                if (waitingTime == 0)
                {
                    SetImage();
                }
                else
                {
                    _isImageTaken = false;
                    SaveImageCustomButton.Enabled = false;
                    UserImageTakenPictureBox.BackColor = Color.LightGray;
                    CountDownTimeSpan = TimeSpan.FromSeconds(waitingTime);
                    TimerTickTimeSpan = TimeSpan.FromMilliseconds(Timer.Interval);
                    UserImageTakenPictureBox.Image = CountDownImageList.CountDownImages.Images[(int)CountDownTimeSpan.TotalSeconds - 1];

                    Timer.Start();
                }
                SetCropControlsEnabledProperty();
            }
        }

        /// <summary>
        /// The "SetImage" method sets the captured image from the UserVideoPictureBox to the UserImageTakenPictureBox for cropping.
        /// </summary>
        /// <remarks>
        /// This method checks if there is an image in the UserVideoPictureBox.
        /// If an image is present, it clones the image and sets it to the UserImageTakenPictureBox for cropping.
        /// It also sets flags to indicate that an image has been taken and cropping is active.
        /// Finally, it invalidates the UserImageTakenPictureBox to redraw the image.
        /// If no image is present, it shows a message box indicating that there is no image to capture.
        /// </remarks>
        private void SetImage()
        {
            if (UserVideoPictureBox.Image != null)
            {
                capturedImage = (Bitmap)UserVideoPictureBox.Image.Clone();
                imageTaken = capturedImage;

                UserImageTakenPictureBox.Image = capturedImage;

                _isImageTaken = true;
                isCropping = true;

                UserImageTakenPictureBox.Invalidate();
            }
            else
            {
                MessageBox.Show("No image to capture.");
            }
        }

        #endregion

        #region Private Form Closing Methods

        /// <summary>
        /// The "Camera_FormClosing" method handles the form closing event of the Camera form to stop the video source and dispose of the watcher.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The form closing event arguments.</param>
        /// <remarks>
        /// This method is triggered when the Camera form is closing.
        /// It checks if the video source is running and stops it if so.
        /// It also disposes of the watcher used for monitoring camera changes.
        /// </remarks>
        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }

        /// <summary>
        /// The "ReturnCustomButton_Click" method handles the Click event for the ReturnCustomButton.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method sets the DialogResult to None, indicating that no specific result is available.
        /// It then closes the form.
        /// </remarks>
        private void ReturnCustomButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        #endregion

        #region Private Timer Methods

        /// <summary>
        /// The "TimerOptionComboBox_SelectedIndexChanged" method handles the selected index changed event of the TimerOptionComboBox to set the waiting time based on the selected timer option.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the selected index of the TimerOptionComboBox changes.
        /// If the selected index is 0, it sets the waiting time to 0, indicating no timer.
        /// If the selected index is between 1 and 3 (inclusive), it parses the selected timer option text to extract the time value and sets the waiting time accordingly.
        /// </remarks>
        private void TimerOptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TimerOptionComboBox.SelectedIndex == 0)
            {
                waitingTime = 0;
            }
            else if (TimerOptionComboBox.SelectedIndex <= 3)
            {
                string TimerComboBoxContent = TimerOptionComboBox.Text;
                TimerComboBoxContent = TimerComboBoxContent.Substring(0, TimerComboBoxContent.Length - 8);
                int Time = int.Parse(TimerComboBoxContent);
                waitingTime = Time;
            }
        }

        /// <summary>
        /// The "Timer_Tick" method handles the tick event of the Timer to update the countdown display and enable crop controls when the countdown reaches zero.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the Timer ticks.
        /// It decrements the countdown TimeSpan by the TimerTickTimeSpan interval.
        /// If the countdown TimeSpan reaches zero or less, it stops the Timer, sets the background color of the UserImageTakenPictureBox to black, sets the image, enables crop controls, and enables the SaveImageCustomButton.
        /// Otherwise, it updates the UserImageTakenPictureBox to display the current countdown image.
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            CountDownTimeSpan -= TimerTickTimeSpan;
            if (CountDownTimeSpan.TotalMilliseconds <= 0)
            {
                Timer.Stop();
                UserImageTakenPictureBox.BackColor = Color.Black;
                SetImage();
                SetCropControlsEnabledProperty();
                SaveImageCustomButton.Enabled = true;
            }
            else
            {
                UserImageTakenPictureBox.Image = CountDownImageList.CountDownImages.Images[(int)CountDownTimeSpan.TotalSeconds-1];
            }
        }

        /// <summary>
        /// The "CameraOpenTimer_Tick" method handles the tick event of the CameraOpenTimer to enable the ImageTakerCustomButton and stop the timer.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is triggered when the CameraOpenTimer ticks.
        /// It enables the ImageTakerCustomButton to allow taking a picture and stops the timer to prevent further ticks.
        /// </remarks>
        private void CameraOpenTimer_Tick(object sender, EventArgs e)
        {
            ImageTakerCustomButton.Enabled = true;
            CameraOpenTimer.Stop();
        }

        #endregion
    }
}
