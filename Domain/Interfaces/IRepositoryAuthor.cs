using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Domain.Interfaces
{
    public interface IRepositoryAuthor : IRepositoryBase<Author>
    {
        Task<IEnumerable<Author>> GetAllWithNameAsync(string param);
        Task<IEnumerable<Author>> GetAllWithCountBookAsync();
    }
}
