using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace YouChatApp.AttachedFiles
{
    public partial class VideoCall : Form
    {
        bool CameraIsOpen = false;
        Image passwordNotShown = global::YouChatApp.Properties.Resources.showPassword;
        Image passwordShown = global::YouChatApp.Properties.Resources.dontShowPassword;
        // https://www.flaticon.com/search?author_id=1828&style_id=1236&type=standard&word=conversation

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public VideoCall()
        {
            InitializeComponent();
            // Get available video capture devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Check if there are any available devices
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video capture devices found.");
                return;
            }

            // Create and set the video source
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
        }

        private void StartStreaming()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
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
        }

        private void CameraModeButton_Click(object sender, EventArgs e)
        {
            if (CameraIsOpen == false)
                CameraIsOpen = true;
            else
                CameraIsOpen = false;
            if (CameraIsOpen == true)
            {
                CameraModeButton.BackgroundImage = passwordShown;
            }
            else
            {
                CameraModeButton.BackgroundImage = passwordNotShown;
            }
        }

        private void AudioDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
