using System;
using System.ComponentModel.DataAnnotations;

namespace hippolidays.Models
{
	public class RequestStatus
	{
        public int ID { get; set; }

        [Required]
        public Request Request { get; set; }
        public int RequestID { get; set; }

        [Required]
        public User User { get; set; }
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