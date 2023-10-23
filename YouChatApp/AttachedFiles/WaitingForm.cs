using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles
{
    public partial class WaitingForm : Form
    {
        public WaitingForm()
        {
            InitializeComponent();
        }

        private void WaitingForm_SizeChanged(object sender, EventArgs e)
        {
            int newSize = Math.Max(this.Width, this.Height);
            this.Width = newSize;
            this.Height = newSize;
        }

        //maybe for furure use.. - will need to add a panel as well

        //private bool isResizing = false;
        //private Point lastMouseLocation;

        //private void panel1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        isResizing = true;
        //        lastMouseLocation = e.Location;
        //    }
        //}

        //private void panel1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isResizing)
        //    {
        //        int deltaX = e.X - lastMouseLocation.X;
        //        int deltaY = e.Y - lastMouseLocation.Y;

        //        int newSize = Math.Max(panel1.Width + deltaX, panel1.Height + deltaY);

        //        panel1.Width = newSize;
        //        panel1.Height = newSize;
        //    }
        //}

        //private void panel1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isResizing = false;
        //}
    }
}
