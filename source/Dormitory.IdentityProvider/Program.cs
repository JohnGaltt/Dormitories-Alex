using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

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
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var dormitoryManager = scope.ServiceProvider.GetRequiredService<IDormitoryManager>();
                var roomManager = scope.ServiceProvider.GetRequiredService<IRoomManager>();

                var oldUser = userManager.FindByNameAsync("alexandr").GetAwaiter().GetResult();
                var oldStaffUser = userManager.FindByNameAsync("petro").GetAwaiter().GetResult();
                var studentRole = roleManager.FindByNameAsync("Student").GetAwaiter().GetResult();
                var staffRole = roleManager.FindByNameAsync("Staff").GetAwaiter().GetResult();
                var dormitory = dormitoryManager.GetByName("Гуртожиток №1").GetAwaiter().GetResult();
                RoomViewModel room = new RoomViewModel();
                if(dormitory != null)
                {
                    room = roomManager.GetByDormitoryId(dormitory.Id).GetAwaiter().GetResult().FirstOrDefault();
                }

                if(dormitory is null)
                {
                    dormitory = dormitoryManager.Create(new Dormitories.Api.ViewModels.DormitoryViewModel
                    {
                        Name = "Гуртожиток №1",
                        Address = "Лукаша 1",
                    }).GetAwaiter().GetResult();

                    room = roomManager.Create(new RoomViewModel
                    {
                        Name = "121",
                        Floor = "1 поверх",
                        DormitoryId = dormitory.Id
                    }).GetAwaiter().GetResult();
                }

                if (studentRole is null)
                {
                    var role = new ApplicationRole("Student");

                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
                if(staffRole is null)
                {
                    var role = new ApplicationRole("Staff");

                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }

                if (oldUser == null)
                {
                    var user = new ApplicationUser("alexandr",dormitory.Id, "alexandr@gmail.com", room.Id);

                    userManager.CreateAsync(user, "password").GetAwaiter().GetResult();
                    userManager.AddToRoleAsync(user, "Student").GetAwaiter().GetResult();

                }
                if (oldStaffUser == null)
                {
                    var user = new ApplicationUser("petro", dormitory.Id, "petro@gmail.com", room.Id);

                    userManager.CreateAsync(user, "password").GetAwaiter().GetResult();
                    userManager.AddToRoleAsync(user, "Staff").GetAwaiter().GetResult();
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
