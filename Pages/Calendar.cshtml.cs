using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hippolidays.Pages
{
	public class CalendarModel : PageModel
    {
        public Dictionary<string, object> calendar = new Dictionary<string, object>();

        public void OnGet(DateTime? calendar)
        {
            DateTime CurrentMonth = DateTime.Today.Date;

            if (calendar.HasValue)
            {
                CurrentMonth = (DateTime)calendar;
            }

            int daysInMonth = DateTime.DaysInMonth(CurrentMonth.Year, CurrentMonth.Month);
            int dayOfFirstOfMonth = (int)CurrentMonth.Date.AddDays(1 - CurrentMonth.Day).DayOfWeek;
            dayOfFirstOfMonth = dayOfFirstOfMonth == 0 ? 7 : dayOfFirstOfMonth;
            int dayOfLastOfMonth = (int)CurrentMonth.Date.AddDays(daysInMonth - CurrentMonth.Day).DayOfWeek;
            dayOfLastOfMonth = dayOfLastOfMonth == 0 ? 7 : dayOfLastOfMonth;
            int totalDays = daysInMonth + dayOfFirstOfMonth + 6 - dayOfLastOfMonth;

            DateTime previousMonth = CurrentMonth.Date.AddMonths(-1);
            DateTime startDate = CurrentMonth.Date.AddDays(1 - CurrentMonth.Day - dayOfFirstOfMonth + 1);

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
                        { "requests", new List<Dictionary<string, object>>() }
                    };

                    week.Add(day);
                }

                data.Add(week);
            }

            // <-- mock data -->
            List<Dictionary<string, object>> requestsData = new List<Dictionary<string, object>>();
            Dictionary<string, object> requestA = new Dictionary<string, object>
            {
                { "request_status", "approved"},
                { "user_name", "Hal"},
                { "request_type_id", "333"},
                { "start_date", new DateTime(2023, 1, 2)},
                { "end_date", new DateTime(2023, 1, 10)}
            };
            Dictionary<string, object> requestB = new Dictionary<string, object>
            {
                { "request_status", "pending"},
                { "user_name", "Me again"},
                { "request_type_id", "334"},
                { "start_date", new DateTime(2023, 1, 3)},
                { "end_date", new DateTime(2023, 1, 14)}
            };
            Dictionary<string, object> requestC = new Dictionary<string, object>
            {
                { "request_status", "pending"},
                { "user_name", "That sounds bad stuff blah blah"},
                { "request_type_id", "334"},
                { "start_date", new DateTime(2023, 1, 10)},
                { "end_date", new DateTime(2023, 1, 17)}
            };
            Dictionary<string, object> requestD = new Dictionary<string, object>
            {
                { "request_status", "pending"},
                { "user_name", "That sounds bad stuff blah blah"},
                { "request_type_id", "334"},
                { "start_date", new DateTime(2023, 1, 8)},
                { "end_date", new DateTime(2023, 1, 12)}
            };
            requestsData.Add(requestA);
            requestsData.Add(requestB);
            requestsData.Add(requestC);
            requestsData.Add(requestD);
            // <-- mock data -->

            foreach (var request in requestsData)
            {
                foreach (List<Dictionary<string,object>> week in data)
                {
                    foreach (Dictionary<string, object> day in week)
                    {
                        DateTime dayDate = (DateTime)day["date"];
                        DateTime requestStartDate = (DateTime)request["start_date"];
                        DateTime requestEndDate = (DateTime)request["end_date"];

                        if (dayDate.Date >= requestStartDate.Date && dayDate.Date <= requestEndDate.Date)
                        {
                            List<Dictionary<string, object>> requests = (List<Dictionary<string, object>>)day["requests"];
                            requests.Add(request);
                        }
                    }
                }
            }

            this.calendar.Add("data", data);
            this.calendar.Add("current_month", CurrentMonth);
            this.calendar.Add("previous_month", CurrentMonth.Date.AddMonths(-1));
            this.calendar.Add("next_month", CurrentMonth.Date.AddMonths(1));
        }
    }
}
