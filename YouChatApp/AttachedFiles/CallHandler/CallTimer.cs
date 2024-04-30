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
    /// The "CallTimer" class manages the call duration timer.
    /// </summary>
    /// <remarks>
    /// This class handles the start and stop of the call duration timer and updates a label with the current call duration.
    /// </remarks>
    internal class CallTimer
    {
        #region Private Readonly Fields

        /// <summary>
        /// The readonly DateTime "callStartTime" stores the start time of the call.
        /// </summary>
        private readonly DateTime callStartTime;

        /// <summary>
        /// The readonly System.Windows.Forms.Timer "callTimeTimer" is used for tracking the call duration.
        /// </summary>
        private readonly System.Windows.Forms.Timer callTimeTimer;

        #endregion

        #region Constructors

        /// <summary>
        /// The "CallTimer" constructor initializes a new instance of the <see cref="CallTimer"/> class with the specified timer.
        /// </summary>
        /// <param name="callTimeTimer">The timer used for tracking the call duration.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the CallTimer class, which manages the call duration timer.
        /// It sets the call start time to the current time and starts the specified timer.
        /// </remarks>
        public CallTimer(System.Windows.Forms.Timer callTimeTimer)
        {
            this.callStartTime = DateTime.Now;
            this.callTimeTimer = callTimeTimer; 
            this.callTimeTimer.Start();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The "StopTimer" method stops the call time timer.
        /// </summary>
        /// <remarks>
        /// This method stops the call time timer that tracks the duration of the call.
        /// </remarks>
        public void StopTimer()
        {
            this.callTimeTimer.Stop();
        }

        /// <summary>
        /// The "HandleTimerTick" method updates the call time label with the current call duration.
        /// </summary>
        /// <param name="CallTimeLabel">The label control used to display the call duration.</param>
        /// <remarks>
        /// This method calculates the call duration based on the difference between the current time and the call start time.
        /// It then formats the duration as HH:MM:SS or MM:SS, depending on whether the call duration is over an hour.
        /// Finally, it updates the CallTimeLabel with the formatted duration.
        /// </remarks>
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

        #endregion
    }
}
