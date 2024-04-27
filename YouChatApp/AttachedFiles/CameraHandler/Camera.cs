using AForge.Video.DirectShow;
using AForge.Video;
//using AForge.Video.FFMPEG;

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
    public partial class Camera : Form
    {
        private bool isImageForGroupChat;


        private bool CameraIsOpen = false;
        private readonly Image CameraNotOpen = global::YouChatApp.Properties.Resources.VideoClose;
        private readonly Image CameraOpen = global::YouChatApp.Properties.Resources.VideoOpen;
        private readonly Image VideoOffImage = global::YouChatApp.Properties.Resources.AnonymousProfile;
        private bool _isImageTaken = false;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private int waitingTime = 0;

        private ManagementEventWatcher watcher;

        private Rectangle selectionCropRectangle;
        private Bitmap capturedImage;
        private bool isResizing = false;
        private bool isCropping = false;
        private int _cropSize;
        private int _cropXLocation;
        private int _cropYLocation;
        private Image imageTaken;

        public static Image ImageToSend;

        public Camera()
        {
            InitializeComponent();
            TimerOptionComboBox.SelectedIndex = 0;
            SetSelectionCropRectangle();
            SetCropControlsEnabledProperty();
            SetScrollBars();
            VideoOffImage = ProfileDetailsHandler.ProfilePicture;
        }
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

                CameraDeviceComboBox.Items.Clear(); // Clear existing items.

                foreach (FilterInfo device in videoDevices)
                {
                    CameraDeviceComboBox.Items.Add(device.Name);
                }

                // Select the first device by default.
                CameraDeviceComboBox.SelectedIndex = 0;
            }

            // Start the video source with the selected camera.
            StartVideoSource();

        }
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
        private void HandleVideoDeviceChange(object sender, EventArrivedEventArgs e)
        {
            // Refresh the camera list when a hardware change is detected.
            BeginInvoke(new Action(RefreshCameraList));
        }
        private void RefreshCameraList()
        {
            InitializeCameraList(); // Refresh the camera list.
        }


        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Convert the video frame to an image (e.g., JPEG)
            using (var stream = new MemoryStream())
            {
                eventArgs.Frame.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = stream.ToArray();

                // Send the image over UDP
                //udpClient.Send(imageBytes, imageBytes.Length, endPoint);
            }
            UserVideoPictureBox.Image = (System.Drawing.Image)eventArgs.Frame.Clone();
        }

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



        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }


            // Stop monitoring hardware changes.
            if (watcher != null)
            {
                watcher.Stop();
                watcher.Dispose();
            }
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            InitializeCameraList(); // Load the initial camera devices when the form loads.
            InitializeCameraChangeDetection(); // Start monitoring camera changes.
        }

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
                    UserImageTakenPictureBox.Image = CountDownImageList._CountDownImageList.Images[(int)CountDownTimeSpan.TotalSeconds - 1];

                    Timer.Start();
                }
                SetCropControlsEnabledProperty();
            }
        }
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


                //// Create a unique filename for the saved image (e.g., using a timestamp)
                //string fileName = $"captured_image_{DateTime.Now:yyyyMMddHHmmss}.jpg";

                //// Save the captured image to disk
                //capturedImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                //MessageBox.Show($"Image saved as {fileName}");
            }
            else
            {
                MessageBox.Show("No image to capture.");
            }
        }

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
        private int lastValidTime;

        private void TimerOptionComboBox_TextChanged(object sender, EventArgs e)
        {
            //if (TimerOptionComboBox.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
            //{
            //    if (TimerOptionComboBox.Text.)
            //}
            //else
            //{
            //    if (TimerOptionComboBox.SelectedIndex == 4)
            //    {
            //        TimerOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            //    }
            //    else
            //    {
            //        TimerOptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //        if (TimerOptionComboBox.SelectedIndex == 0)
            //        {
            //            waitingTime = 0;
            //        }
            //        else if (TimerOptionComboBox.SelectedIndex <= 3)
            //        {
            //            string TimerComboBoxContent = TimerOptionComboBox.Text;
            //            TimerComboBoxContent = TimerComboBoxContent.Substring(0, TimerComboBoxContent.Length - 8);
            //            int Time = int.Parse(TimerComboBoxContent);
            //            waitingTime = Time;
            //        }
            //    }
            //}

        }
        TimeSpan TimerTickTimeSpan;
        TimeSpan CountDownTimeSpan;
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
                UserImageTakenPictureBox.Image = CountDownImageList._CountDownImageList.Images[(int)CountDownTimeSpan.TotalSeconds-1];
                //WaitingTimeLabel.Text = $"{CountDownTimeSpan:ss}";
            }
        }
        private void CameraOpenTimer_Tick(object sender, EventArgs e)
        {
            ImageTakerCustomButton.Enabled = true;

            CameraOpenTimer.Stop();
        }


        private void SaveImageCustomButton_Click(object sender, EventArgs e)
        {
            ImageToSend = CropImage();
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void PictureBoxImage_Paint(object sender, PaintEventArgs e)
        {
            // Draw the selection rectangle on the PictureBox
            if (isCropping)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionCropRectangle);
                }
            }
        }



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

        private void UserImageTakenPictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            if ((isCropping) && (e.Button == MouseButtons.Left))
            {
                // Start selecting the region
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

        private void UserImageTakenPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //if ((isCropping)&& (e.Button == MouseButtons.Left))
            //{
            //    // Resize the selection region
            //    selectionCropRectangle.Width = e.X - selectionCropRectangle.X;
            //    selectionCropRectangle.Height = e.Y - selectionCropRectangle.Y;
            //    UserImageTakenPictureBox.Invalidate();
            //}
        }

        private void CropImageCustomButton_Click(object sender, EventArgs e)
        {
            //if (imageTaken != null)
            //{
            //    if (selectionCropRectangle.Width > 0 && selectionCropRectangle.Height > 0)
            //    {
            //        // Crop the selected region
            //        Bitmap croppedImage = new Bitmap(selectionCropRectangle.Width, selectionCropRectangle.Height);
            //        using (Graphics g = Graphics.FromImage(croppedImage))
            //        {
            //            g.DrawImage(imageTaken, 0, 0, selectionCropRectangle, GraphicsUnit.Pixel);
            //        }

            //        // Display the cropped image
            //        OpenCroppedImageViewer(croppedImage);
            //        ImageToSend = croppedImage;
            //        SaveImageCustomButton.Enabled = true;
            //    }
            //}
            Image croppedImage = CropImage();
            if (croppedImage != null)
            {
                OpenCroppedImageViewer(croppedImage);
            }
        }
        private Image CropImage()
        {
            Image image;
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
        private void OpenCroppedImageViewer(Image imageToView)
        {
            ImageViewer image = new ImageViewer(imageToView);
            image.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CropCustomTextBoxFields_TextChangedEvent(object sender, EventArgs e)
        {
            if ((isCropping))
            {
                selectionCropRectangle.Width = int.Parse(CropSizeCustomTextBox.TextContent);
                selectionCropRectangle.Height = int.Parse(CropSizeCustomTextBox.TextContent);
                selectionCropRectangle.X = int.Parse(CropXLocationustomTextBox.TextContent);
                selectionCropRectangle.Y = int.Parse(CropYLocationustomTextBox.TextContent);
                UserImageTakenPictureBox.Invalidate();
            }
        }
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
        private void HandleCropSizeCustomTextBoxValue()
        {
            if ((isCropping))
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
        private void HandleCropXLocationCustomTextBoxValue()
        {
            if ((isCropping))
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
        private void HandleCropYLocationCustomTextBoxValue()
        {
            if ((isCropping))
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

        private void CropSizeCustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            //if ((isCropping))
            //{
            //    string Text = CropSizeCustomTextBox.TextContent;
            //    if ((Text != "") && (StringHandler.IsNumeric(Text)))
            //    {
            //        int newSize = int.Parse(Text);
            //        if (newSize < 50)
            //        {
            //            CropSizeHorizontalScrollBar.Value = 50;
            //            CropSizeCustomTextBox.Text = "50";
            //            CropSizeCustomTextBox.SelectText(CropSizeCustomTextBox.TextContent.Length, 0);
            //        }
            //        else if((newSize < (UserImageTakenPictureBox.Width - selectionCropRectangle.X)) && (newSize < (UserImageTakenPictureBox.Height - selectionCropRectangle.Y)))
            //        {
            //            CropSizeHorizontalScrollBar.Value = UserImageTakenPictureBox.Width - selectionCropRectangle.X;
            //            CropSizeHorizontalScrollBar.Text = (UserImageTakenPictureBox.Width - selectionCropRectangle.X).ToString();
            //            CropSizeCustomTextBox.SelectText(CropSizeCustomTextBox.Text.Length, 0);
            //        }
            //        else 
            //        {
            //            CropSizeHorizontalScrollBar.Value = int.Parse(CropSizeCustomTextBox.TextContent);
            //            selectionCropRectangle.Width = int.Parse(CropSizeCustomTextBox.TextContent);
            //            selectionCropRectangle.Height = int.Parse(CropSizeCustomTextBox.TextContent);
            //            UserImageTakenPictureBox.Invalidate();
            //        }
            //    }
            //}

        }

        private void CropXLocationustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            //if ((isCropping))
            //{
            //    selectionCropRectangle.X = int.Parse(CropXLocationustomTextBox.TextContent);
            //    UserImageTakenPictureBox.Invalidate();
            //}
        }

        private void CropYLocationustomTextBox_TextChangedEvent(object sender, EventArgs e)
        {
            if ((isCropping))
            {
                selectionCropRectangle.Y = int.Parse(CropYLocationustomTextBox.TextContent);
                UserImageTakenPictureBox.Invalidate();
            }
        }

        private void CropSizeCustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCropSizeCustomTextBoxValue();
            }
        }

        private void CropSizeCustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCropSizeCustomTextBoxValue();
        }

        private void CropXLocationustomTextBox_Leave(object sender, EventArgs e)
        {
            HandleCropXLocationCustomTextBoxValue();
        }

        private void CropXLocationustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCropXLocationCustomTextBoxValue();
            }
        }

        private void CropYLocationustomTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleCropYLocationCustomTextBoxValue();
            }
        }

        private void CropYLocationustomTextBox_MouseLeave(object sender, EventArgs e)
        {
            HandleCropYLocationCustomTextBoxValue();

        }

        private void CropSizeHorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            
            if ((isCropping))
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

        private void CropXLocationHorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if ((isCropping))
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

        private void CropYLocationHorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if ((isCropping))
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

        private void CropSizeHorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            HandleLargeChangeValue(CropSizeHorizontalScrollBar);
        }
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

        private void CropXLocationHorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            HandleLargeChangeValue(CropXLocationHorizontalScrollBar);
        }

        private void CropYLocationHorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            HandleLargeChangeValue(CropYLocationHorizontalScrollBar);
        }

        private void CroppedImagePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void UserVideoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void RefreshCameraOptionsCustomButton_Click(object sender, EventArgs e)
        {
            InitializeCameraList(); // Refresh the camera list.

        }

        private void UserImageTakenPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ReturnCustomButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            this.Close();
        }
    }
}
