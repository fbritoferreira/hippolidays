using System;
using Microsoft.AspNetCore.Identity;

namespace hippolidays
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> CreateRoles(this WebApplication app, IConfiguration configuration)
        {
            using var scope = app.Services.CreateScope();
            var roleManager = (RoleManager<IdentityRole>?)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));
            string[] roles = { "Manager", "Employee" };

            foreach (var role in roles)
            {
                if (roleManager is not null)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            return app;
        }
    }
}
