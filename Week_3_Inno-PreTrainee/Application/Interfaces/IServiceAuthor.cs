using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Interfaces
{
    public interface IServiceAuthor
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        Author CreateAuthor(Author item);
        void UpdateAuthor(int id, Author updatedData);
        void DeleteAuthorById(int id);
    }
}
