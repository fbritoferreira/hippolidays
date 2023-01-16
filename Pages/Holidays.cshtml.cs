using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hippolidays.Models;

namespace hippolidays.Pages
{
	public class HolidaysModel : PageModel
    {
        public Dictionary<string, object> viewData = new Dictionary<string, object>();

        private readonly hippolidays.Data.ApplicationDbContext _context;

        public HolidaysModel(hippolidays.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public new IList<Request> Request { get; set; } = default!;

        public async void OnGet(string? filter)
        {

            if (_context.Request != null)
            {
                Request = await _context.Request.ToListAsync();
            }
            
            //if (!string.IsNullOrEmpty(filter))
            //{
            //    Request = Request.FindAll(request => (string)request["request_status"] == filter);
            //}

            viewData.Add("requests", Request);
            viewData.Add("filter", filter);
        }
    }
}
