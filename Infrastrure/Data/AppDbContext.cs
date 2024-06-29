
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppPeople> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bảng People
            modelBuilder.Entity<AppPeople>()
                .Property(p => p.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<AppPeople>()
                .Property(p => p.FirstName)
                .HasMaxLength(200);
            modelBuilder.Entity<AppPeople>()
                .Property(p => p.LastName)
                .HasMaxLength(200);
            modelBuilder.Entity<AppPeople>()
                .Property(p => p.Place)
                .HasMaxLength(1000); 
            modelBuilder.Entity<AppPeople>()
                .Property(p => p.Description)
                .HasColumnType("nvarchar(max)");
        }
    }
}
