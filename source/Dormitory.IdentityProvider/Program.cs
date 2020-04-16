using Dormitories.Core.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dormitory.IdentityProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var oldUser = userManager.FindByNameAsync("alexandr").GetAwaiter().GetResult();
                var oldStaffUser = userManager.FindByNameAsync("petro").GetAwaiter().GetResult();
                if (oldUser == null)
                {
                    var user = new ApplicationUser("alexandr", 1,2);

                    userManager.CreateAsync(user, "password").GetAwaiter().GetResult();
                }
                if (oldStaffUser == null)
                {
                    var user = new ApplicationUser("petro", 1, 2);

                    userManager.CreateAsync(user, "password").GetAwaiter().GetResult();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
