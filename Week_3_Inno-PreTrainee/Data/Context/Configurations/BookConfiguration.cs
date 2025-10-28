using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Data.Context.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Author)
                .WithMany(b => b.Books);

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Евгений Онегин",
                    PublishedYear = new DateTime(1833, 1, 1),
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Преступление и наказание",
                    PublishedYear = new DateTime(1866, 1, 1),
                    AuthorId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Война и мир",
                    PublishedYear = new DateTime(1869, 1, 1),
                    AuthorId = 3
                },
                new Book
                {
                    Id = 4,
                    Title = "Вишнёвый сад",
                    PublishedYear = new DateTime(1904, 1, 1),
                    AuthorId = 4
                },
                new Book
                {
                    Id = 5,
                    Title = "Мёртвые души",
                    PublishedYear = new DateTime(1842, 1, 1),
                    AuthorId = 5
                }
            );

        }
    }
}
