using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace hippolidays.Models
{
    public class Request

    {
        [Key]
        public int Request_Id { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

 
        public virtual RequestType? RequestType { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }

        public bool Repeat { get; set; }

    }
}
