using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Interfaces
{
    public interface IServiceAuthor
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author?> GetAuthorById(int id);
        Task<Author> CreateAuthor(Author item);
        Task UpdateAuthor(int id, Author updatedData);
        Task DeleteAuthorById(int id);
        Task<IEnumerable<Author>> GetAllAuthorsWithNameAsync(string param);
        Task<IEnumerable<Author>> GetAllAuthorsWithBooksAsync();
    }
}
