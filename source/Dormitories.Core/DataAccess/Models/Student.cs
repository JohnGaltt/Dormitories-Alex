using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dormitories.Core.DataAccess
{
    public class Student : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Dormitory Dormitory { get; set; }
        public int DormitoryId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Student> entityTypeBuilder = modelBuilder.Entity<Student>();
            entityTypeBuilder.ToTable("Students");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entityTypeBuilder.Property(x => x.Email).IsRequired().HasMaxLength(64);

            entityTypeBuilder.HasOne(x => x.Dormitory).WithMany().HasForeignKey(x=>x.DormitoryId);
            entityTypeBuilder.HasOne(x => x.Room).WithMany().HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
