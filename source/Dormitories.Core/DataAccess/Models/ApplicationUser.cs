using Dormitories.Core.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Dormitories.Core.DataAccess
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser(string name, int dormitoryId, string email, int? roomId = null)
        {
            Name = name;
            UserName = name;
            Email = email;
            DormitoryId = dormitoryId;
            RoomId = roomId;
        }

        public string Name { get; set; }
        public Dormitory Dormitory { get; set; }
        public int DormitoryId { get; set; }
        public Room Room { get; set; }
        public int? RoomId { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }


        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<ApplicationUser> entityTypeBuilder = modelBuilder.Entity<ApplicationUser>();
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);

            entityTypeBuilder.HasOne(x => x.Dormitory).WithMany().HasForeignKey(x => x.DormitoryId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.Room).WithMany().HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
