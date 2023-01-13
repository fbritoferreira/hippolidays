using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class RequestType
    {
        [Key]
        public int request_type_id { get; set; }

        public string? type { get; set; }

        public int reason { get; set; }

    }
}

