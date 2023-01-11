using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using hippolidays.Data;
using hippolidays.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace hippolidays.Pages.Requests
{
    public class CreateModel : PageModel
    {
        private readonly hippolidays.Data.ApplicationDbContext _context;

        public CreateModel(hippolidays.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new Request Request { get; set; } = default!;

        public bool Repeat { get; set; }

        [BindProperty]
        public RequestType RequestType { get; set; } = default!;



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Request == null || Request == null)
            {
                return Page();
            }
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.RequestType.Add(RequestType);
            _context.Request.Add(Request);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
