using CleanArchitectureSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Persistence.Contexts
{
    public class CleanArchitectureDbContext : DbContext
    {
        public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitectureDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
