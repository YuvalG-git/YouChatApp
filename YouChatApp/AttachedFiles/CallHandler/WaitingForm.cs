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
    /// The "WaitingForm" class represents a form that is displayed during a call waiting period.
    /// </summary>
    public partial class WaitingForm : Form
    {
        /// <summary>
        /// The "WaitingForm" constructor initializes a new instance of the "WaitingForm" class.
        /// </summary>
        public WaitingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The "WaitingForm_SizeChanged" method handles the SizeChanged event of the form by ensuring the form remains square.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void WaitingForm_SizeChanged(object sender, EventArgs e)
        {
            int newSize = Math.Max(this.Width, this.Height);
            this.Width = newSize;
            this.Height = newSize;
        }
    }
}
