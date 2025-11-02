using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Services
{
    public class ServiceAuthor(IRepositoryAuthor authors) : IServiceAuthor
    {
        private readonly IRepositoryAuthor _authors = authors;

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authors.GetAllAsync();
        }
        public async Task<Author?> GetAuthorById(int id)
        {
            return  await _authors.GetByIdAsync(id);
        }
        public async Task<Author> CreateAuthor(Author item)
        {
            return await _authors.CreateAsync(item);
        }
        public async Task UpdateAuthor(int id, Author updatedData)
        {
            await _authors.UpdateAsync(id, updatedData);
        }
        public async Task  DeleteAuthorById(int id)
        {
           await _authors.DeleteByIdAsync(id);
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsWithNameAsync(string param)
        {
            return await _authors.GetAllWithNameAsync(param);
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsWithBooksAsync()
        {

            return await _authors.GetAllWithCountBookAsync();
        }
    }
}
