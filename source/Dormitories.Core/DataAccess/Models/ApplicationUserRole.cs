using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dormitories.Core.DataAccess.Models
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<ApplicationUserRole> entityTypeBuilder = modelBuilder.Entity<ApplicationUserRole>();

            entityTypeBuilder.HasKey(ur => new { ur.UserId, ur.RoleId });
            entityTypeBuilder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
