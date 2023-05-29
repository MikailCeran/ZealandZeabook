using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace ZealandBook
{
    public class CalendarModel : PageModel
    {
        public List<DateTime> Dates { get; set; }

        public void OnGet()
        {
            // Generate a list of dates for the current month and each hour of the day
            Dates = GetDatesForCurrentMonth();
        }

        private List<DateTime> GetDatesForCurrentMonth()
        {
            var dates = new List<DateTime>();
            var currentDate = DateTime.Today;
            var daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                for (int hour = 0; hour < 24; hour++)
                {
                    dates.Add(new DateTime(currentDate.Year, currentDate.Month, day, hour, 0, 0));
                }
            }

            return dates;
        }
    }
}
