using System;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Interfaces;

namespace Week_3_Inno_PreTrainee.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IIWithId
    {
        protected readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public T Create(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return item;
        }

        public void Update(int id, T updatedData)
        {
            var idUpdate = _items.FindIndex(x => x.Id == id);
            _items[idUpdate] = updatedData;
        }

        public void DeleteById(int id)
        {
            _items.RemoveAll(x => x.Id == id);
        }
    }
}
