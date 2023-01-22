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
using Microsoft.AspNetCore.Authorization;

namespace hippolidays.Pages
{
    [Authorize]
    public class HolidaysModel : PageModel
    {
        private static List<Request>? Requests;

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

            var query = from item in _context.Request
                        where
                            (filter != null ? item.RequestStatus.Status == filter : true) &&
                            item.ApplicationUser.Id == user.Id
                        orderby item.Request_Id descending
                        select item;

            Requests = await query.ToListAsync();

            viewData.Add("filter", filter);
            viewData.Add("requests", Requests);

        }
        
        public async Task<IActionResult> OnPostStatusUpdate(int? id, string? status)
        {
            var result = _context.Request.SingleOrDefault(b => b.Request_Id == id);
            if (result != null)
            {
               if (result.ApplicationUser.HolidaysRemaining <= 0)
                {
                    return Page();
                }

               result.RequestStatus.Status = status;
               result.ApplicationUser.HolidaysRemaining = result.ApplicationUser.HolidaysRemaining - (result.End_Date - result.Start_Date).Days;
               await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Approve");
        }
    }
}