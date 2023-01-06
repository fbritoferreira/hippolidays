using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hippolidays.Pages
{
	public class HolidaysModel : PageModel
    {
        public Dictionary<string, object> viewData = new Dictionary<string, object>();

        public void OnGet(string? filter)
        {
            // <-- mock data -->
            List<Dictionary<string, object>> requestsData = new List<Dictionary<string, object>>();
            Dictionary<string, object> requestA = new Dictionary<string, object>
            {
                { "request_status", "approved"},
                { "user_name", "Hal"},
                { "request_type_id", "333"},
                { "start_date", new DateTime(2023, 1, 2)},
                { "end_date", new DateTime(2023, 1, 10)}
            };
            Dictionary<string, object> requestB = new Dictionary<string, object>
            {
                { "request_status", "pending"},
                { "user_name", "Hal"},
                { "request_type_id", "334"},
                { "start_date", new DateTime(2023, 1, 3)},
                { "end_date", new DateTime(2023, 1, 14)}
            };
            Dictionary<string, object> requestC = new Dictionary<string, object>
            {
                { "request_status", "denied"},
                { "user_name", "Hal"},
                { "request_type_id", "334"},
                { "start_date", new DateTime(2023, 1, 10)},
                { "end_date", new DateTime(2023, 1, 17)}
            };
            Dictionary<string, object> requestD = new Dictionary<string, object>
            {
                { "request_status", "pending"},
                { "user_name", "Hal"},
                { "request_type_id", "334"},
                { "start_date", new DateTime(2023, 1, 8)},
                { "end_date", new DateTime(2023, 1, 12)}
            };
            requestsData.Add(requestA);
            requestsData.Add(requestB);
            requestsData.Add(requestC);
            requestsData.Add(requestD);
            // <-- mock data -->

            if (!string.IsNullOrEmpty(filter))
            {
                requestsData = requestsData.FindAll(request => (string)request["request_status"] == filter);
            }

            viewData.Add("requests", requestsData);
        }
    }
}
