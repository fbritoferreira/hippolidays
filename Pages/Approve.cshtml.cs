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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace hippolidays.Pages
{
    [Authorize(Roles = "Manager")]
    public class ApproveModel : PageModel
    {
        public IList<Request> Requests { get; set; } = default!;

        private readonly UserManager<ApplicationUser> _userManager;

        public Dictionary<string, object> viewData = new Dictionary<string, object>();

        private readonly hippolidays.Data.ApplicationDbContext _context;

        public ApproveModel(hippolidays.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void OnGet(string? filter = null)
        {
            Requests = new List<Request>();
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var query = from item in _context.Request
                        where
                            (filter != null ? item.RequestStatus.Status == filter : true) &&
                            item.ApplicationUser.Team_Name == user.Team_Name &&
                            item.ApplicationUser.Id != user.Id
                        orderby item.Request_Id descending
                        select item;

            Requests = await query.ToListAsync();

            viewData.Add("filter", filter);

        }
        
        public async Task<IActionResult> OnPostStatusUpdate(int? id, string? status)
        {
            var result = _context.Request.SingleOrDefault(b => b.Request_Id == id);
            if (result != null)
            {
               if (result.ApplicationUser?.HolidaysRemaining <= 0)
                {
                    return Page();
                }
               if (result.RequestStatus != null && result.ApplicationUser!= null)
                {
                    result.RequestStatus.Status = status;
                    result.RequestStatus.ActionDate = DateTime.Today.Date;
                    if (status == "approved")
                    {
                        result.ApplicationUser.HolidaysRemaining = result.ApplicationUser.HolidaysRemaining - (result.End_Date - result.Start_Date).Days - 1;
                    }
                    await _context.SaveChangesAsync();
                }           
            }
            return RedirectToPage("./Approve");
        }
    }
}