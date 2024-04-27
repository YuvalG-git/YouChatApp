using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles
{
    /// <summary>
    /// The "PictureBoxEventArgs" class represents the event arguments for events related to a PictureBox control.
    /// </summary>
    public class PictureBoxEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the PictureBox associated with the event.
        /// </summary>
        public PictureBox pictureBox { get; }

        /// <summary>
        /// The "PictureBoxEventArgs" constructor initializes a new instance of the "PictureBoxEventArgs" class with the specified PictureBox.
        /// </summary>
        /// <param name="pictureBox">The PictureBox associated with the event.</param>
        public PictureBoxEventArgs(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }
    }
}
