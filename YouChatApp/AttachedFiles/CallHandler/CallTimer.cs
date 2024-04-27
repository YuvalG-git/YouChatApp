using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.AttachedFiles.CallHandler
{
    /// <summary>
    /// The "CallTimer" class manages the duration of a call and updates a label with the call duration.
    /// </summary>
    internal class CallTimer
    {
        private readonly DateTime callStartTime;
        private readonly System.Windows.Forms.Timer callTimeTimer;

        /// <summary>
        /// The "CallTimer" constructor initializes a new instance of the "CallTimer" class with the specified timer for tracking call duration.
        /// </summary>
        /// <param name="callTimeTimer">The timer used to track the call duration.</param>
        public CallTimer(System.Windows.Forms.Timer callTimeTimer)
        {
            this.callStartTime = DateTime.Now;
            this.callTimeTimer = callTimeTimer; 
            this.callTimeTimer.Start();
        }

        /// <summary>
        /// The "StopTimer" method stops the call timer.
        /// </summary>
        public void StopTimer()
        {
            this.callTimeTimer.Stop();
        }

        /// <summary>
        /// The "HandleTimerTick" method handles the timer tick event to update the call duration label.
        /// </summary>
        /// <param name="CallTimeLabel">The label used to display the call duration.</param>
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
