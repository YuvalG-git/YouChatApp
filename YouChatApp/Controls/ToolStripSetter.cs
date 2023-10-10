using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    internal class ToolStripSetter
    {
        public static void SetToolStrip(Control control, ToolTip toolTip)
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
    }
}
