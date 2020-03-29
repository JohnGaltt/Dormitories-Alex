﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dormitories.Core.DataAccess
{
    public class Dormitory : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public static void Build(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Dormitory> entityTypeBuilder = modelBuilder.Entity<Dormitory>();
            entityTypeBuilder.ToTable("Dormitory");
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entityTypeBuilder.Property(x => x.Address).IsRequired().HasMaxLength(64);
        }
    }
}
