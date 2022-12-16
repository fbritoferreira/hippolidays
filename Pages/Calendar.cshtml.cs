using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hippolidays.Pages
{
	public class CalendarModel : PageModel
    {
        public int BlockOfFirstOfMonth;
        public int BlockOfLastOfMonth;
        public int BlockOfToday;
        public int BlocksToShow;

        public void OnGet()
        {
            DateTime today = DateTime.Today;
            
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            int dayOfFirstOfMonth = (int)today.Date.AddDays(1 - today.Day).DayOfWeek;
            int dayOfLastOfMonth = (int)today.Date.AddDays(daysInMonth - today.Day).DayOfWeek;

            this.BlocksToShow = daysInMonth + dayOfFirstOfMonth - 1 + 7 - dayOfLastOfMonth;

            this.BlockOfFirstOfMonth = dayOfFirstOfMonth;
            this.BlockOfLastOfMonth = dayOfFirstOfMonth + daysInMonth - 1;
            this.BlockOfToday = today.Day + dayOfFirstOfMonth - 1;
        }
    }
}
