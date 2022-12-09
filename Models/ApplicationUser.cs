using System;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string? Team_Name { get; set; }

        public string? Name { get; set; }

        public int Available_Holiday{ get; set; }

        public int Available_ServiceDays { get; set; }

        enum Shift_Pattern

        {
            five = 5,
            seven = 7
        }

    }
}

