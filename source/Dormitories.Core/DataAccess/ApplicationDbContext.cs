using Dormitories.Core.DataAccess.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Dormitories.Core.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<Room> Rooms { get; set; }

        private readonly DatabaseSettings _databaseOptions;

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(IOptions<DatabaseSettings> databaseOptions)
        {
            if (databaseOptions.Value == null)
            {
                throw new ArgumentNullException(nameof(databaseOptions));
            }

            if (string.IsNullOrEmpty(databaseOptions.Value.ConnectionString))
            {
                throw new ArgumentException("Database connection string is null or empty.");
            }

            _databaseOptions = databaseOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Student.Build(modelBuilder);
            Room.Build(modelBuilder);
            Dormitory.Build(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_databaseOptions.ConnectionString);
            
        }
    }
}
