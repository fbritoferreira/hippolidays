using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string? Team_Name { get; set; }

        public string? Name { get; set; }

        public int Holidays { get; set; }

        public int Service_Days { get; set; }

        [EnumDataType(typeof(Pattern))]
        public Pattern Shift_Pattern { get; set; }

    }
}

