using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class RequestStatus
    {
        public int ID { get; set; }

        [Required]
        public virtual Request? Request { get; set; }

        [Required]
        public virtual ApplicationUser? ApplicationUser { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Reason { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ActionDate { get; set; }

    }
}
