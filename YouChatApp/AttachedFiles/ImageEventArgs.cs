using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles
{
    public class PictureBoxEventArgs : EventArgs
    {
        public PictureBox pictureBox { get; }

        public PictureBoxEventArgs(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }
    }
}
