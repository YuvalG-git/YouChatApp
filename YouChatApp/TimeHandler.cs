using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    internal class TimeHandler
    {
        public static string GetFormatTime(DateTime time)
        {
            DateTime CurrentDate = DateTime.Now;
            DateTime yesterdayDate = DateTime.Now.AddDays(-1);
            DateTime lastWeekDate = DateTime.Now.AddDays(-7);

            if (time.Date == CurrentDate.Date)
            {
                return time.ToString("HH:mm");
            }
            else if (time.Date == yesterdayDate.Date)
            {
                return "yesterday";

            }
            else if ((time.Date >= lastWeekDate.Date) && (time.Date < yesterdayDate.Date))
            {
                return time.DayOfWeek.ToString();
            }
            else if (time.Year == CurrentDate.Year)
            {
                return time.ToString("MM/dd");
            }
            else
            {
                return time.ToString("dd/MM/yyyy");
            }
        }
    }
}
