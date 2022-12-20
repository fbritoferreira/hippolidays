using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hippolidays.Pages
{
	public class CalendarModel : PageModel
    {
        public Dictionary<string, object> calendar = new Dictionary<string, object>();

        public void OnGet(DateTime? calendar)
        {
            DateTime CurrentMonth = DateTime.Today;

            if (calendar.HasValue)
            {
                CurrentMonth = (DateTime)calendar;
            }

            int daysInMonth = DateTime.DaysInMonth(CurrentMonth.Year, CurrentMonth.Month);
            int dayOfFirstOfMonth = (int)CurrentMonth.Date.AddDays(1 - CurrentMonth.Day).DayOfWeek;
            int dayOfLastOfMonth = (int)CurrentMonth.Date.AddDays(daysInMonth - CurrentMonth.Day).DayOfWeek;            
            int totalDays = daysInMonth + dayOfFirstOfMonth + 7 - dayOfLastOfMonth;

            DateTime previousMonth = CurrentMonth.Date.AddMonths(-1);
            DateTime startDate = previousMonth.Date.AddDays(daysInMonth - CurrentMonth.Day - dayOfFirstOfMonth + 1);

            List<List<Dictionary<string, object>>> data = new List<List<Dictionary<string, object>>>();

            for (var y = 0; y < totalDays/7; y++)
            {
                List<Dictionary<string, object>> week = new List<Dictionary<string, object>>();

                for (var x = 0; x < 7; x++)
                {
                    int id = x + y * 7;
                    DateTime date = startDate.AddDays(id);
                    bool isToday = date == DateTime.Today;
                    bool isInMonth = date.Month == CurrentMonth.Month;

                    Dictionary<string, object> day = new Dictionary<string, object>
                    {
                        { "id", id },
                        { "date", date },
                        { "is_today", isToday },
                        { "is_in_month", isInMonth },
                    };

                    week.Add(day);
                }

                data.Add(week);
            }

            this.calendar.Add("data", data);
            this.calendar.Add("current_month", CurrentMonth);
            this.calendar.Add("previous_month", CurrentMonth.Date.AddMonths(-1));
            this.calendar.Add("next_month", CurrentMonth.Date.AddMonths(1));
        }
    }
}
