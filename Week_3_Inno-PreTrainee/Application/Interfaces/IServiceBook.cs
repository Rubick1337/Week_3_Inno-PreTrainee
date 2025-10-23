using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Interfaces
{
    public interface IServiceBook
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book CreateBook(Book item);
        void UpdateBook(int id, Book updatedData);
        void DeleteBookById(int id);
    }
}
