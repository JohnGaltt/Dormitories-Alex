using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Dormitories.Core.DataAccess.Models
{
    public class Request : BaseModel
    {
        [JsonProperty("requestType")]
        public RequestTypes RequestType { get; set; }

        [JsonProperty("itemId")]
        public int? ItemId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        public ApplicationUser User { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Request> entityTypeBuilder = modelBuilder.Entity<Request>();
            entityTypeBuilder.ToTable("Requests");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Reason).HasMaxLength(256);
            entityTypeBuilder.Property(x => x.ItemId);
            entityTypeBuilder.Property(x => x.RequestType).IsRequired().HasConversion<int>();
            entityTypeBuilder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public enum RequestTypes : int
    {
        DormitoryComplain = 1,
        RoomComplain,
        ChangeDormitory,
        ChangeRoom
    }
}
