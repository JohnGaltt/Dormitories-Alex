using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Dormitories.Core.DataAccess
{
    public class Room : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("floor")]
        public string Floor { get; set; }

        public Dormitory Dormitory { get; set; }

        [JsonProperty("dormitoryId")]
        public int DormitoryId { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Room> entityTypeBuilder = modelBuilder.Entity<Room>();
            entityTypeBuilder.ToTable("Rooms");
            entityTypeBuilder.HasKey(x => new { x.Id });
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entityTypeBuilder.Property(x => x.Floor).IsRequired().HasMaxLength(64);
            entityTypeBuilder.HasOne(x => x.Dormitory).WithMany().HasForeignKey(x => x.DormitoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
