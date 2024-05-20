using Microsoft.EntityFrameworkCore;
using MyEBook.Models.Configurations;
using MyEBook.Models.Entities;

namespace MyEBook.Models
{
    public class EBookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public EBookDbContext(DbContextOptions<EBookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
