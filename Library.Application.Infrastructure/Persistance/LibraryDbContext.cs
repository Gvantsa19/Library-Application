using Library.Application.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Infrastructure.Persistance
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public LibraryDbContext() {}
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
