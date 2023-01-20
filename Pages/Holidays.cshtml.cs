using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hippolidays.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace hippolidays.Pages
{
    public class HolidaysModel : PageModel
    {
        public IList<Request> Requests { get; set; } = default!;

        private readonly UserManager<ApplicationUser> _userManager;

        public Dictionary<string, object> viewData = new Dictionary<string, object>();

        private readonly hippolidays.Data.ApplicationDbContext _context;

        public HolidaysModel(hippolidays.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void OnGet(string? filter)
        {
            Requests = new List<Request>();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var requests = await _context.Request.Where(item => item.ApplicationUser == user).OrderByDescending(req => req.Request_Id).ToListAsync();
            foreach (var item in requests)
            {
                if (item.RequestStatus?.Status == filter)
                {
                    Requests.Add(item);
                }
                else if (string.IsNullOrEmpty(filter))
                {
                    Requests.Add(item);
                }
            }

            viewData.Add("filter", filter);

        }
        
        public async Task<IActionResult> OnPostStatusUpdate(int? id, string? status)
        {
            var result = _context.Request.SingleOrDefault(b => b.Request_Id == id);
            if (result != null && result.ApplicationUser != null)
            {
               if (result.ApplicationUser.HolidaysRemaining <= 0)
                {
                    return Page();
                }
               if (result.RequestStatus != null)
                {
                   result.RequestStatus.Status = status;
                   result.ApplicationUser.HolidaysRemaining = result.ApplicationUser.HolidaysRemaining - (result.End_Date - result.Start_Date).Days;
                   await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("./Approve");
        }
    }
}