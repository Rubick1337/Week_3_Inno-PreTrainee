using Microsoft.EntityFrameworkCore;
using Week_3_Inno_PreTrainee.Application.Dto.AuthorDto;
using Week_3_Inno_PreTrainee.Data.Context;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Data.Repositories
{
    public class RepositoryAuthor : RepositoryBase<Author>, IRepositoryAuthor
    {
        public RepositoryAuthor(LibraryContext libraryContext) : base(libraryContext) 
        {
           
        }

        public async Task<IEnumerable<Author>> GetAllWithCountBookAsync()
        {
            return await _libraryContext.Set<Author>()
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAllWithNameAsync(string param)
        {
            return await _libraryContext.Set<Author>()
                .AsNoTracking()
                .Where(a => a.Name.Contains(param))
                .ToListAsync();
        }
    }
}
