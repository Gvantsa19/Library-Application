using Library.Application.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Infrastructure.Persistance
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        public LibraryDbContext() {}
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }


        //protected override void OnModelCreating(ModelBuilder builder)
        //    => builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
