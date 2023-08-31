using Microsoft.EntityFrameworkCore;

namespace LinqPractices
{
    public class LinqDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } // Entity sınıfının adını düzelttim.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Metod adını düzelttim.
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LinqDatabase"); // optionsBuilder'ın doğru adını düzelttim.
        }
    }
}
