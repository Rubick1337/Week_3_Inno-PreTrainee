namespace Week_3_Inno_PreTrainee.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T item);
        void Update(int id, T updatedData);
        void DeleteById(int id);
    }
}
