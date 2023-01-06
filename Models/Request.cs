using System;
using hippolidays.Areas.Identity.Pages.Account;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace hippolidays.Models
{
    public class Request

    {
        public int request_id { get; set; }

        public IdentityUser user_id { get; set; }
        
        public RequestType request_type_id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime start_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime end_date { get; set; }

    }
}

