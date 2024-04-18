using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    /// <summary>
    /// The Class provides methods for formatting dates and times.
    /// </summary>
    internal class TimeHandler
    {
        /// <summary>
        /// The method formats a given DateTime object based on its relation to the current date.
        /// </summary>
        /// <param name="time">The date and time to be formatted.</param>
        /// <returns>A string representation of the formatted date and time.</returns>
        public static string GetFormatTime(DateTime? time)
        {
            if (time == null) return "";
            
            DateTime CurrentDate = DateTime.Now;
            DateTime yesterdayDate = DateTime.Now.AddDays(-1);
            DateTime lastWeekDate = DateTime.Now.AddDays(-7);

            DateTime timeValue = time.Value;

            if (timeValue == CurrentDate.Date)
            {
                // Return the time in "HH:mm" format if the date is today.
                return timeValue.ToString("HH:mm");
            }
            else if (timeValue == yesterdayDate.Date)
            {
                // Return "yesterday" if the date is yesterday.
                return "yesterday";
            }
            else if ((timeValue >= lastWeekDate.Date) && (timeValue < yesterdayDate.Date))
            {
                // Return the day of the week if the date is within the last week (excluding today and yesterday).
                return timeValue.DayOfWeek.ToString();
            }
            else if (timeValue.Year == CurrentDate.Year)
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
    }
}
