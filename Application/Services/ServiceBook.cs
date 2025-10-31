using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Services
{
    public class ServiceBook : IServiceBook
    {
        private readonly IRepositoryBook _books;
        private readonly IRepositoryAuthor _authors;

        public ServiceBook(IRepositoryBook books, IRepositoryAuthor authors)
        {
            _books = books;
            _authors = authors;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _books.GetAllAsync();
        }
        public async Task<Book?> GetBookById(int id)
        {
            return await _books.GetByIdAsync(id);
        }
        public async Task<Book> CreateBook(Book item)
        {
            var author = await _authors.GetByIdAsync(item.AuthorId);

            if (author is null)
            {
                throw new KeyNotFoundException("Автор с id не найден");
            }

            return await _books.CreateAsync(item);
        }
        public async Task UpdateBook(int id, Book updatedData)
        {
            var author = await _authors.GetByIdAsync(updatedData.AuthorId);

            if (author is null)
            {
                throw new KeyNotFoundException("Автор с id не найден");
            }

            await _books.UpdateAsync(id, updatedData);
        }
        public async Task DeleteBookById(int id)
        {
            await _books.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksWithTitleAsync(string param)
        {
           return await _books.GetAllWithNameAsync(param);
        }

        public async Task<IEnumerable<Book>> GetAllBooksFilterByYearAsync(int year)
        {
            return await _books.GetAllFilterByYearAsync(year);
        }
    }
}
