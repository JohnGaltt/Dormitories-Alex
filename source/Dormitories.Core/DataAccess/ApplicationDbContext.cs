using Dormitories.Core.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dormitories.Core.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,
        int, IdentityUserClaim<int>, ApplicationUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplicationUser.Build(modelBuilder);
            Room.Build(modelBuilder);
            Dormitory.Build(modelBuilder);
            ApplicationUserRole.Build(modelBuilder);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EC5FMB7\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True;");
        }
    }
}
