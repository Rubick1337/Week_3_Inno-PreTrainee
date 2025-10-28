using Microsoft.EntityFrameworkCore;
using Week_3_Inno_PreTrainee.Data.Context.Configurations;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Data.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
               : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
