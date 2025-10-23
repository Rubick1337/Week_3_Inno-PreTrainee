using Week_3_Inno_PreTrainee.Application.Interfaces;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Application.Services
{
    public class ServiceAuthor : IServiceAuthor
    {
        private readonly IRepositoryBase<Author> _authors;

        public ServiceAuthor(IRepositoryBase<Author> authors)
        {
            _authors = authors;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authors.GetAll();
        }
        public Author GetAuthorById(int id)
        {
            return _authors.GetById(id);
        }
        public Author CreateAuthor(Author item)
        {
            return _authors.Create(item);
        }
        public void UpdateAuthor(int id, Author updatedData)
        {
            _authors.Update(id, updatedData);
        }
        public void DeleteAuthorById(int id)
        {
            _authors.DeleteById(id);
        }
    }
}
