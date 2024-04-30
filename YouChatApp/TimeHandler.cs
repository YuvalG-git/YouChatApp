using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    /// <summary>
    /// The "TimeHandler" class provides methods for formatting DateTime values as strings representing different time formats.
    /// </summary>
    /// <remarks>
    /// This class includes a method for formatting a DateTime value based on its relation to the current date.
    /// </remarks>
    internal class TimeHandler
    {
        #region Public Static Methods

        /// <summary>
        /// The "GetFormatTime" method returns a formatted string representing the given DateTime value.
        /// </summary>
        /// <param name="time">The DateTime value to format.</param>
        /// <returns>A formatted string representing the DateTime value.</returns>
        /// <remarks>
        /// This method checks the date of the provided DateTime value against the current date
        /// to determine how to format and return the time.
        /// - If the date is today, the method returns the time in "HH:mm" format.
        /// - If the date is yesterday, the method returns "yesterday".
        /// - If the date is within the last week (excluding today and yesterday), the method returns the day of the week.
        /// - If the date is within the current year but not within the last week, the method returns the date in "MM/dd" format.
        /// - If the date is outside the current year, the method returns the date in "dd/MM/yyyy" format.
        /// </remarks>
        public static string GetFormatTime(DateTime? time)
        {
            if (time == null) return "";
            
            DateTime CurrentDate = DateTime.Now;
            DateTime yesterdayDate = DateTime.Now.AddDays(-1);
            DateTime lastWeekDate = DateTime.Now.AddDays(-7);

            DateTime timeValue = time.Value;
            DateTime timeValueDate = timeValue.Date;

            if (timeValueDate == CurrentDate.Date)
            {
                // Return the time in "HH:mm" format if the date is today.
                return timeValue.ToString("HH:mm");
            }
            else if (timeValueDate == yesterdayDate.Date)
            {
                // Return "yesterday" if the date is yesterday.
                return "yesterday";
            }
            else if ((timeValueDate >= lastWeekDate.Date) && (timeValue < yesterdayDate.Date))
            {
                // Return the day of the week if the date is within the last week (excluding today and yesterday).
                return timeValue.DayOfWeek.ToString();
            }
            else if (timeValueDate.Year == CurrentDate.Year)
            {
                // Return the date in "MM/dd" format if the date is within the current year.
                return timeValue.ToString("MM/dd");
            }
            else
            {
                // Return the date in "dd/MM/yyyy" format for dates outside the current year.
                return timeValue.ToString("dd/MM/yyyy");
            }
        }

        #endregion
    }
}
