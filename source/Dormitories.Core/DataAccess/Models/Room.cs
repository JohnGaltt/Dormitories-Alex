using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dormitories.Core.DataAccess
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public int Floor { get; set; }
        public Dormitory Dormitory { get; set; }
        public int DormitoryId { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Room> entityTypeBuilder = modelBuilder.Entity<Room>();
            entityTypeBuilder.ToTable("Rooms");
            entityTypeBuilder.HasKey(x => new { x.Id });
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entityTypeBuilder.Property(x => x.Floor).IsRequired().HasMaxLength(64);
            entityTypeBuilder.HasOne(x => x.Dormitory).WithMany().HasForeignKey(x => x.DormitoryId);
        }
    }
}
