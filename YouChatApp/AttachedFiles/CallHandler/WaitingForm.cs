using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles.CallHandler
{
    /// <summary>
    /// The "VideoCall" class represents a form that displays a waiting indicator.
    /// </summary>
    /// <remarks>
    /// This form is designed to be square and resizes itself to the larger of its width or height to maintain a consistent appearance.
    /// </remarks>
    public partial class WaitingForm : Form
    {
        #region Constructors

        /// <summary>
        /// The "WaitingForm" constructor initializes a new instance of the <see cref="WaitingForm"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor calls the InitializeComponent method to initialize the form's components.
        /// </remarks>
        public WaitingForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The "WaitingForm_SizeChanged" method handles the SizeChanged event of the waiting form by ensuring the form remains square, resizing it to the larger of its width or height.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method ensures that the waiting form remains square by setting its width and height to the larger of the two dimensions whenever the form is resized.
        /// This helps maintain a consistent appearance for the waiting form, which is designed to be a square shape.
        /// </remarks>
        private void WaitingForm_SizeChanged(object sender, EventArgs e)
        {
            int newSize = Math.Max(this.Width, this.Height);
            this.Width = newSize;
            this.Height = newSize;
        }

        #endregion
    }
}
