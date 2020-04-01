using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dormitories.Core.DataAccess
{
    public class Dormitory : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Dormitory> entityTypeBuilder = modelBuilder.Entity<Dormitory>();
            entityTypeBuilder.ToTable("Dormitories");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entityTypeBuilder.Property(x => x.Address).IsRequired().HasMaxLength(64);
        }
    }
}
