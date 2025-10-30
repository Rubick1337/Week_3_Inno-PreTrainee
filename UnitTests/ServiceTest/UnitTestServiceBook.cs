using Moq;
using Xunit;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Application.Services;
using Week_3_Inno_PreTrainee.Domain.Models;

public class UnitTestServiceBook
{
    [Fact]
    public async Task CreateBook_ShouldThrow_WhenAuthorNotFound()
    {
        var repositoryBookMock = new Mock<IRepositoryBook>();
        var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

        repositoryAuthorMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
             .ReturnsAsync((Author)null);
        var serviceBookMock = new ServiceBook(repositoryBookMock.Object, repositoryAuthorMock.Object);

        var newBook = new Book
        {
            Title = "Война и мир",
            AuthorId = 999,
            PublishedYear = DateTime.Now
        };

         await Assert.ThrowsAsync<KeyNotFoundException>(() => serviceBookMock.CreateBook(newBook));
    }
    [Fact]
    public async Task UpdateBook_ShouldThrow_WhenAuthorNotFound()
    {
        var repositoryBookMock = new Mock<IRepositoryBook>();
        var repositoryAuthorMock = new Mock<IRepositoryAuthor>();
        repositoryAuthorMock.Setup(r => r.GetByIdAsync((It.IsAny<int>())))
            .ReturnsAsync((Author)null);

        var serviceBookMock = new ServiceBook(repositoryBookMock.Object, repositoryAuthorMock.Object);

        var newBook = new Book
        {
            Title = "Война и мир",
            AuthorId = 999,
            PublishedYear = DateTime.Now
        };

        await Assert.ThrowsAsync<KeyNotFoundException>(() => serviceBookMock.UpdateBook(1, newBook));
    }
    [Fact]
    public async Task CreateBook_Succesful()
    {
        var repositoryBookMock = new Mock<IRepositoryBook>();
        var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

        repositoryAuthorMock.Setup(r => r.GetByIdAsync((It.IsAny<int>())))
               .ReturnsAsync(new Author
               {
                   Id = 1,
                   Name = "Александр Пушкин",
                   DateOfBirth = new DateTime(1799, 6, 6)
               });
        repositoryBookMock.Setup(b => b.CreateAsync(It.IsAny<Book>()))
            .ReturnsAsync((Book b) =>
            {
                b.Id = 100;
                return b;
            });

        var serviceBook = new ServiceBook(repositoryBookMock.Object,repositoryAuthorMock.Object);

        var newBook = new Book
        {
            Title = "Война и мир",
            AuthorId = 1,
            PublishedYear = DateTime.Now
        };

        var created = await serviceBook.CreateBook(newBook);

        Assert.NotNull(created);
        Assert.Equal(100, created.Id);
    }
    [Fact]
    public async Task DeleteBook_Succesful()
    {
        var repositoryBookMock = new Mock<IRepositoryBook>();
        var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

        repositoryBookMock.Setup(b => b.DeleteByIdAsync((It.IsAny<int>())))
            .Returns(Task.CompletedTask);

        var serviceBook = new ServiceBook(repositoryBookMock.Object, repositoryAuthorMock.Object);

        await serviceBook.DeleteBookById(10);

        repositoryBookMock.Verify(b => b.DeleteByIdAsync(10));
    }
    [Fact] 
    public async Task GetByIdBook_Succesful()
    {
        var repositoryBookMock = new Mock<IRepositoryBook>();
        var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

        repositoryBookMock.Setup(b => b.GetByIdAsync((It.IsAny<int>()))).ReturnsAsync(new Book
        {
            Id = 10,
            Title = "Преступление и наказание",
            PublishedYear = new DateTime(1866, 1, 1),
            AuthorId = 1
        });

        var serviceBook = new ServiceBook(repositoryBookMock.Object, repositoryAuthorMock.Object);

        var bookFind = await serviceBook.GetBookById(10);

        Assert.NotNull(bookFind);
        Assert.Equal(10, bookFind.Id);
    }
    [Fact]
    public async Task GetAllBook_Succesful()
    {
        var repositoryBookMock = new Mock<IRepositoryBook>();
        var repositoryAuthorMock = new Mock<IRepositoryAuthor>();

        repositoryBookMock.Setup(b => b.GetAllAsync()).ReturnsAsync(new List<Book> {
            new Book{Id = 10, Title = "Преступление и наказание",PublishedYear = new DateTime(1866, 1, 1),AuthorId = 1}});

        var serviceBook = new ServiceBook(repositoryBookMock.Object, repositoryAuthorMock.Object);

        var books = await serviceBook.GetAllBooks();

        Assert.NotNull(books);
    }
}
