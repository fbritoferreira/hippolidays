using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hippolidays.Data;
using hippolidays.Models;

namespace hippolidays.Pages.Requests
{
    public class DetailsModel : PageModel
    {
        private readonly hippolidays.Data.ApplicationDbContext _context;

        public DetailsModel(hippolidays.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Request Request { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FirstOrDefaultAsync(m => m.request_id == id);
            if (request == null)
            {
                return NotFound();
            }
            else 
            {
                Request = request;
            }
            return Page();
        }
    }
}
