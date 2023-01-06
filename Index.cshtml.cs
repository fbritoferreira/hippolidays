using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hippolidays.Models;

namespace hippolidays
{
    public class IndexModel : PageModel
    {
        private readonly DefaultConnection _context;

        public IndexModel(DefaultConnection context)
        {
            _context = context;
        }

        public IList<Request> Request { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Request != null)
            {
                Request = await _context.Request.ToListAsync();
            }
        }
    }
}
