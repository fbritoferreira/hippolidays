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

namespace hippolidays.Pages
{
    public class ApproveModel : PageModel
    {
        private static List<Request> Requests;
        private static List<RequestStatus> RequestStatuses = new List<RequestStatus>();
        private static List<Request> allRequests = new List<Request>();

        private readonly UserManager<ApplicationUser> _userManager;

        public Dictionary<string, object> viewData = new Dictionary<string, object>();

        private readonly hippolidays.Data.ApplicationDbContext _context;

        public ApproveModel(hippolidays.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void OnGet(string? filter)
        {
            viewData.Add("requests", null);
            Requests = new List<Request>();

            if (_context.Request != null)
            {
               allRequests = await _context.Request.ToListAsync();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            foreach (var item in allRequests)
                {
                   var result = await _context.RequestStatus.Where(item => item.ApplicationUser.Team_Name == user.Team_Name).ToListAsync();
                   
                        foreach (var status in result)
                        {
                            if (item.Request_Id == status.Request?.Request_Id)
                            {
                        if (status.Status == filter)
                        {
                            Requests.Add(item);
                        } else if (string.IsNullOrEmpty(filter))
                        {
                            Requests.Add(item);
                        }

                    }
                }
            }
            viewData.Add("filter", filter);
            viewData["requests"] = Requests;

        }
    }
}