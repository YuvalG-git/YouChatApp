using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "ToolTipSetter" class provides methods for setting tooltips on controls.
    /// </summary>
    /// <remarks>
    /// This class contains static methods for setting tooltips based on the text length of controls.
    /// </remarks>
    internal class ToolTipSetter
    {
        #region Public Static Fields

        /// <summary>
        /// The "SetToolTipBySpaceOver" method sets a tooltip for a given control based on whether the text of the control exceeds its width.
        /// </summary>
        /// <param name="control">The control for which to set the tooltip.</param>
        /// <param name="toolTip">The tooltip control.</param>
        /// <remarks>
        /// If the text of the control is longer than its width, sets the tooltip to display the full text;
        /// otherwise, sets the tooltip to null, indicating no tooltip should be displayed.
        /// </remarks>
        public static void SetToolTipBySpaceOver(Control control, ToolTip toolTip)
        {
            if (TextRenderer.MeasureText(control.Text, control.Font).Width > control.Width)
            {
                toolTip.SetToolTip(control, control.Text);
            }
            else
            {
                toolTip.SetToolTip(control, null);
            }
        }
        /// <summary>
        /// The "SetToolTip" method sets a tooltip for a given control.
        /// </summary>
        /// <param name="control">The control for which to set the tooltip.</param>
        /// <param name="toolTip">The tooltip control.</param>
        public static void SetToolTip(Control control, ToolTip toolTip)
        {
            toolTip.SetToolTip(control, control.Text);
        }

        #endregion
    }
}
