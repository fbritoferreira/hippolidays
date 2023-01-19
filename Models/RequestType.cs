using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class RequestType
    {
        [Key]
        public int RequestType_Id { get; set; }

        [Display(Name = "Leave Type")]
        public string? Type { get; set; }

        [Display(Name = "Leave Reason")]
        [MaxLength(50)]
        public string? Reason { get; set; }

    }
}
