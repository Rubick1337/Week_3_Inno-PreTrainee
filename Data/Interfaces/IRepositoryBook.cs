using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Data.Interfaces
{
    public interface IRepositoryBook : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetAllWithNameAsync(string param);
        Task<IEnumerable<Book>> GetAllFilterByYearAsync(int year);
    }
}
