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
using Microsoft.AspNetCore.Authorization;

namespace hippolidays.Pages.Requests
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly hippolidays.Data.ApplicationDbContext _context;

        public CreateModel(hippolidays.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public RequestStatus RequestStatus { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Request == null || Request == null)
            {
                return Page();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser.HolidaysRemaining == 0)
            {
                return Page();
            }
            var emptyRequestStatus = new RequestStatus();

            Request.ApplicationUser = currentUser;

            _context.RequestType.Add(RequestType);
            Request.RequestType = RequestType;
            Request.RequestStatus = RequestStatus;

            _context.Request.Add(Request);

            emptyRequestStatus.Status = "pending";
            emptyRequestStatus.ActionDate = DateTime.Today.Date;
            emptyRequestStatus.Request = Request;
            emptyRequestStatus.ApplicationUser = currentUser;
            emptyRequestStatus.Reason = "initial request";

            _context.RequestStatus.Add(emptyRequestStatus);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
