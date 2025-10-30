using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_3_Inno_PreTrainee.Application.Services;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace UnitTests.ServiceTest
{
    public class UnitTestServiceAuthor
    {
        [Fact]
        public async Task GetAllAuthors_Succesful()
        {
            var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

            repositoryAuthorMock.Setup(a => a.GetAllAsync()).ReturnsAsync(new List<Author> { 
                new Author {Id = 1,Name = "Александр Пушкин",DateOfBirth = new DateTime(1799, 6, 6)} });

            var serviceAuthor = new ServiceAuthor(repositoryAuthorMock.Object);

            var authors = await serviceAuthor.GetAllAuthors();

            Assert.NotNull(authors);
        }
        [Fact]
        public async Task CreateAuthor_Succesful()
        {
            var repositoryAuthorMock = new Mock<IRepositoryAuthor>();


            repositoryAuthorMock.Setup(a => a.CreateAsync(It.IsAny<Author>()))
                .ReturnsAsync((Author a) =>
                {
                    a.Id = 10;
                    return a;
                });
            var serviceAuthor = new ServiceAuthor(repositoryAuthorMock.Object);

            var newAuthor = new Author
            {
                Id = 1,
                Name = "Александр Пушкин",
                DateOfBirth = new DateTime(1799, 6, 6)
            };

            var created = await serviceAuthor.CreateAuthor(newAuthor);

            Assert.NotNull(created);
            Assert.Equal(10, created.Id);
        }
        [Fact]
        public async Task DeleteAuthor_Succesful()
        {
            var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

            repositoryAuthorMock.Setup(a => a.DeleteByIdAsync((It.IsAny<int>())))
                .Returns(Task.CompletedTask);

            var serviceAuthor = new ServiceAuthor(repositoryAuthorMock.Object);

            await serviceAuthor.DeleteAuthorById(10);

            repositoryAuthorMock.Verify(a => a.DeleteByIdAsync(10));
        }
        [Fact]
        public async Task GetByIdAuthor_Succesful()
        {
            var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

            repositoryAuthorMock.Setup(a => a.GetByIdAsync((It.IsAny<int>()))).ReturnsAsync(new Author
            {
                Id = 1,
                Name = "Александр Пушкин",
                DateOfBirth = new DateTime(1799, 6, 6)
            });

            var serviceAuthor = new ServiceAuthor(repositoryAuthorMock.Object);

            var authorFind = await serviceAuthor.GetAuthorById(1);

            Assert.NotNull(authorFind);
            Assert.Equal(1, authorFind.Id);
        }
        [Fact]
        public async Task GetAllAuthorsWithName_Succesful()
        {
            var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

            repositoryAuthorMock.Setup(a => a.GetAllWithNameAsync((It.IsAny<string>()))).ReturnsAsync(new List<Author> {
                new Author {Id = 1,Name = "Александр Пушкин",DateOfBirth = new DateTime(1799, 6, 6)} });

            var serviceAuthor = new ServiceAuthor(repositoryAuthorMock.Object);

            var authorsFiltred = await serviceAuthor.GetAllAuthorsWithNameAsync("Александр");

            Assert.Contains(authorsFiltred, a => a.Name.Contains("Александр"));
        }
        [Fact]
        public async Task GetAllAuthorsWithBooksAsync_ReturnsAuthorsWithBooks()
        {
            var repositoryAuthorMock = new Mock<IRepositoryAuthor>();
            repositoryAuthorMock.Setup(a => a.GetAllWithCountBookAsync()).ReturnsAsync(new List<Author> {
                new Author
            {
                Id = 1,
                Name = "Александр Пушкин",
                DateOfBirth = new DateTime(1799, 6, 6),
                Books = new List<Book>
                {
                    new Book { Id = 1, Title = "Евгений Онегин", PublishedYear = new DateTime(1833,1,1), AuthorId = 1 }
                }
            }});

            var serviceAuthor = new ServiceAuthor(repositoryAuthorMock.Object);

            var authorsWithCount = await serviceAuthor.GetAllAuthorsWithBooksAsync();
            var firstAuthor = authorsWithCount.First();
            Assert.NotNull(authorsWithCount);
            Assert.Equal(1, firstAuthor.Books.Count);
        }
    }
}
