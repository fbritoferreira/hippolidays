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
        public Request Request { get; set; }
        public int RequestID { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        public int UserID { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public string reason { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ActionDate { get; set; }

    }
}
