using Microsoft.EntityFrameworkCore;
using System;
using Week_3_Inno_PreTrainee.Data.Context;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Interfaces;

namespace Week_3_Inno_PreTrainee.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IIWithId
    {
        protected readonly LibraryContext _libraryContext;

        public RepositoryBase(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<T> CreateAsync(T item)
        {
            await _libraryContext.Set<T>().AddAsync(item);
            await _libraryContext.SaveChangesAsync();
            return item;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var existing = await _libraryContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            _libraryContext.Set<T>().Remove(existing);

            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _libraryContext.Set<T>()
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _libraryContext.Set<T>()
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task UpdateAsync(int id, T updated)
        {
            var existing = await _libraryContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            updated.Id = id;
            _libraryContext.Entry(existing).CurrentValues.SetValues(updated);

            await _libraryContext.SaveChangesAsync();
        }

    }
}
