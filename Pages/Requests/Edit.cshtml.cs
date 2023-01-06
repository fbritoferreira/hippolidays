using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hippolidays.Data;
using hippolidays.Models;

namespace hippolidays.Pages.Requests
{
    public class EditModel : PageModel
    {
        private readonly hippolidays.Data.ApplicationDbContext _context;

        public EditModel(hippolidays.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Request Request { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request =  await _context.Request.FirstOrDefaultAsync(m => m.request_id == id);
            if (request == null)
            {
                return NotFound();
            }
            Request = request;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(Request.request_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RequestExists(int id)
        {
          return (_context.Request?.Any(e => e.request_id == id)).GetValueOrDefault();
        }
    }
}
