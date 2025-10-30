namespace Week_3_Inno_PreTrainee.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T item);
        Task UpdateAsync(int id, T updated);
        Task DeleteByIdAsync(int id);
    }
}
