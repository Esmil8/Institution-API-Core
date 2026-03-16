using Institution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Institution.Infrastructure.Context
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Municipality>()
                .HasIndex(m => m.Name)
                .IsUnique();
        }
    }
}