using Homework.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework.Database
{
    public class HomeworkDbContext : DbContext
    {
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Manicipality> Manicipalities { get; set; }

        public HomeworkDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tax>().ToTable("Tax");
            modelBuilder.Entity<Manicipality>().ToTable("Manicipality");
        }
    }
}
