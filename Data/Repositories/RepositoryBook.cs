﻿using Microsoft.EntityFrameworkCore;
using Week_3_Inno_PreTrainee.Data.Context;
using Week_3_Inno_PreTrainee.Data.Interfaces;
using Week_3_Inno_PreTrainee.Domain.Models;

namespace Week_3_Inno_PreTrainee.Data.Repositories
{
    public class RepositoryBook : RepositoryBase<Book> ,IRepositoryBook
    {
        public RepositoryBook(LibraryContext libraryContext) : base(libraryContext)
        {

        }

        public async Task<IEnumerable<Book>> GetAllFilterByYearAsync(int year)
        {
            return await _libraryContext.Set<Book>()
                .AsNoTracking()
                .Where(b => b.PublishedYear.Year >= year)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithNameAsync(string param)
        {
            return await _libraryContext.Set<Book>()
                .AsNoTracking()
                .Where(b => b.Title.Contains(param))
                .ToListAsync();

        }
    }
}
