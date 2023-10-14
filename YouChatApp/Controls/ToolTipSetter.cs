using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    internal class ToolTipSetter
    {
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
        public static void SetToolTip(Control control, ToolTip toolTip)
        {
            toolTip.SetToolTip(control, control.Text);
        }
    }
}
