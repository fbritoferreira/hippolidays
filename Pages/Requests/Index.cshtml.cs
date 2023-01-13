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
    public class IndexModel : PageModel
    {
        private readonly hippolidays.Data.ApplicationDbContext _context;

        public IndexModel(hippolidays.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public new IList<Request> Request { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Request != null)
            {
                Request = await _context.Request.ToListAsync();
            }
        }
    }
}
