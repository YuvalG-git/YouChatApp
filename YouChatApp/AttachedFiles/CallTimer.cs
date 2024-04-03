using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles
{
    internal class CallTimer
    {
        private readonly DateTime callStartTime;
        private readonly System.Windows.Forms.Timer callTimeTimer;

        public CallTimer(System.Windows.Forms.Timer callTimeTimer)
        {
            this.callStartTime = DateTime.Now;
            this.callTimeTimer = callTimeTimer; 
            this.callTimeTimer.Start();
        }
        public void StopTimer()
        {
            this.callTimeTimer.Stop();
        }
        public void HandleTimerTick(Label CallTimeLabel)
        {
            TimeSpan callDuration = DateTime.Now - callStartTime;

            string formattedDuration;

            if (callDuration.Hours > 0)
            {
                formattedDuration = $"{callDuration.Hours:D2}:{callDuration.Minutes:D2}:{callDuration.Seconds:D2}";
            }
            else
            {
                formattedDuration = $"{callDuration.Minutes:D2}:{callDuration.Seconds:D2}";
            }

            CallTimeLabel.Text = formattedDuration;
        }
    }
}
