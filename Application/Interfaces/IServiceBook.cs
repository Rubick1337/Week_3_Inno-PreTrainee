using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Interfaces
{
    public interface IServiceBook
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book> CreateBook(Book item);
        Task UpdateBook(int id, Book updatedData);
        Task DeleteBookById(int id);
        Task<IEnumerable<Book>> GetAllBooksWithTitleAsync(string param);
        Task<IEnumerable<Book>> GetAllBooksFilterByYearAsync(int year);
    }
}
