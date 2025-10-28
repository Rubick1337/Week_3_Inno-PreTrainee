using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Data.Context.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(b => b.Books)
                .WithOne(a => a.Author);

            builder.HasData(
                   new Author
                   {
                       Id = 1,
                       Name = "Александр Пушкин",
                       DateOfBirth = new DateTime(1799, 6, 6)
                   },
                   new Author
                   {
                       Id = 2,
                       Name = "Фёдор Достоевский",
                       DateOfBirth = new DateTime(1821, 11, 11)
                   },
                   new Author
                   {
                       Id = 3,
                       Name = "Лев Толстой",
                       DateOfBirth = new DateTime(1828, 9, 9)
                   },
                   new Author
                   {
                       Id = 4,
                       Name = "Антон Чехов",
                       DateOfBirth = new DateTime(1860, 1, 29)
                   },
                   new Author
                   {
                       Id = 5,
                       Name = "Николай Гоголь",
                       DateOfBirth = new DateTime(1809, 3, 31)
                   }
            );

        }
    }
}
