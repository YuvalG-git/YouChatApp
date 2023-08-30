using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    public partial class LockableRichTextBox : RichTextBox
    {
        private const int WM_NCHITTEST = 0x0084;
        private const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                int hitTestResult = (int)m.Result.ToInt64();
                if (hitTestResult == HTBOTTOMRIGHT)
                {
                    // Prevent resizing behavior by changing the hit test result to HTCLIENT
                    m.Result = new IntPtr(1); // HTCLIENT
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
