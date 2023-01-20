using System;
using Microsoft.AspNetCore.Identity;

namespace hippolidays
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> CreateRoles(this WebApplication webApp, IConfiguration configuration)
        {
            using var serviceScope = webApp.Services.CreateScope();
            var manager = (RoleManager<IdentityRole>?)serviceScope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));

            string[] authRoles = { "Manager", "Employee" };

            foreach (var item in authRoles)
            {
                if (manager is not null)
                {
                    if (!await manager.RoleExistsAsync(item))
                        await manager.CreateAsync(new IdentityRole(item));
                }
            }

            return webApp;
        }
    }
}
