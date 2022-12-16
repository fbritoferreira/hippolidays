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
        public List<List<Dictionary<string, object>>> calendarList = new List<List<Dictionary<string, object>>>();

        public void OnGet()
        {
            DateTime today = DateTime.Today;
            
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            int dayOfFirstOfMonth = (int)today.Date.AddDays(1 - today.Day).DayOfWeek;
            int dayOfLastOfMonth = (int)today.Date.AddDays(daysInMonth - today.Day).DayOfWeek;            
            int totalDays = daysInMonth + dayOfFirstOfMonth + 7 - dayOfLastOfMonth;

            DateTime previousMonth = today.Date.AddMonths(-1);
            DateTime startDate = previousMonth.Date.AddDays(daysInMonth - today.Day - dayOfFirstOfMonth + 1);

            for (var y = 0; y < totalDays/7; y++)
            {
                List<Dictionary<string, object>> week = new List<Dictionary<string, object>>();

                for (var x = 0; x < 7; x++)
                {
                    int id = x + y * 7;
                    DateTime date = startDate.AddDays(id);
                    bool isToday = date == today;
                    bool isInMonth = date.Month == today.Month;

                    Dictionary<string, object> day = new Dictionary<string, object>
                    {
                        { "id", id },
                        { "date", date },
                        { "is_today", isToday },
                        { "is_in_month", isInMonth },
                    };

                    week.Add(day);
                }

                this.calendarList.Add(week);
            }
        }
    }
}
