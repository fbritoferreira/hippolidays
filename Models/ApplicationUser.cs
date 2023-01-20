using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class ApplicationUser : IdentityUser

    {
        [Required]
        public string Team_Name { get; set; } = "Default";

        [Required]
        public string Name { get; set; } = "Anonymous";

        [Required]
        public int Holidays { get; set; }

        [Required]
        public int HolidaysRemaining { get; set; }

        public int Service_Days { get; set; }

        [EnumDataType(typeof(Pattern))]
        public Pattern Shift_Pattern { get; set; }

    }
}

