using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hippolidays.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace hippolidays.Pages
{
    [Authorize]
	public class CalendarModel : PageModel
    {
        public Dictionary<string, object?> calendar = new Dictionary<string, object>();

        public int approved;
        public int pending;
        public int available;

        private readonly hippolidays.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CalendarModel(hippolidays.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public new IList<Request> Request { get; set; } = default!;


        public async void OnGet(string? calendar)
        {
            ApplicationUser? CurrentUser = await _userManager.GetUserAsync(User);
            DateTime CurrentMonth = (calendar != null) ? DateTime.Parse(calendar): DateTime.Today.Date;

            if (_context.Request != null)
            {
                Request = await _context.Request.ToListAsync();
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
                        { "requests", new List<Request>() }
                    };

                    week.Add(day);
                }

                data.Add(week);
            }

            foreach (var item in Request)
            {
                if (item.RequestStatus.Status == "rejected")
                {
                    continue;
                }
                foreach (List<Dictionary<string,object>> week in data)
                {
                    foreach (Dictionary<string, object> day in week)
                    {
                        DateTime dayDate = (DateTime)day["date"];
                        DateTime requestStartDate = (DateTime)item.Start_Date;
                        DateTime requestEndDate = (DateTime)item.End_Date;

                        if (dayDate.Date >= requestStartDate.Date && dayDate.Date <= requestEndDate.Date)
                        {
                            List<Request> requests = (List<Request>)day["requests"];
                            requests.Add(item);
                        }
                    }
                }
            }
            
            this.calendar.Add("data", data);
            this.calendar.Add("current_month", CurrentMonth);
            this.calendar.Add("previous_month", CurrentMonth.Date.AddMonths(-1));
            this.calendar.Add("next_month", CurrentMonth.Date.AddMonths(1));
            this.calendar.Add("currentUser", CurrentUser);

            if (CurrentUser != null)
            {
                foreach (var req in Request)

                {
                    if (req?.ApplicationUser?.Id == CurrentUser.Id)
                    {
                        if (req.RequestStatus.Status == "approved")
                        {
                            var difference = req.End_Date - req.Start_Date;
                            approved = approved + difference.Days;

                        }
                        else if (req.RequestStatus.Status == "pending")
                        {
                            var difference = req.End_Date - req.Start_Date;
                            pending = pending + difference.Days;
                        }
                    }
                }
                available = CurrentUser.HolidaysRemaining - pending;
            }
        }
    }
}
