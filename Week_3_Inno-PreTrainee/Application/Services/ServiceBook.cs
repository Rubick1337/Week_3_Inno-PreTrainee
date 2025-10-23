using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Services
{
    public class ServiceBook : IServiceBook
    {
        private readonly IRepositoryBase<Book> _books;

        public ServiceBook(IRepositoryBase<Book> books)
        {
            _books = books;
        }
        public IEnumerable<Book> GetAllBooks()
        {

            return _books.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _books.GetById(id);
        }
        public Book CreateBook(Book item)
        {
            return _books.Create(item);
        }
        public void UpdateBook(int id, Book updatedData)
        {
            _books.Update(id, updatedData);
        }
        public void DeleteBookById(int id)
        {
            _books.DeleteById(id);
        }
    }
}
