using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructionLayer.Haqbahoo.Persistence.Seed
{
    public class Seeder : IHostedService
    {
        private readonly IServiceProvider _service;

        public Seeder(IServiceProvider service)
        {
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            string adminEmail = "Admin@gmail.com";
            string adminPassword = "Pa$$w0rd";
            string[] rolesToAdd = { Role.Admin};

            using (var scope = _service.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                await SeedRolesAndUser(adminEmail, adminPassword, rolesToAdd, roleManager, userManager);
                //await SeedCountries(dbContext);
            }
        }

        private static async Task SeedRolesAndUser(string adminEmail, string adminPassword, string[] rolesToAdd, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            foreach (string roleName in rolesToAdd)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = roleName, NormalizedName = roleName.ToUpper() });
                }
            }

            // Check if SuperAdmin user exists
            var superAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (superAdmin == null)
            {
                // SuperAdmin user doesn't exist, create it
                superAdmin = new ApplicationUser { FirstName = "Admin", LastName = "Admin", UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var createResult = await userManager.CreateAsync(superAdmin, adminPassword);

                if (createResult.Succeeded)
                {
                    // Assign SuperAdmin role to the SuperAdmin user
                    await userManager.AddToRoleAsync(superAdmin, "Admin");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
