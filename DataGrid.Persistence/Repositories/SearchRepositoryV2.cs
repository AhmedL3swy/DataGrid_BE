using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using DataGrid.Persistence.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataGrid.Persistence.Repositories
{
    internal class SearchRepositoryV2<DbSet> : ISearchRepositoryV2<DbSet> where DbSet : class
    {
        private readonly ProductDbContext _context;

        public SearchRepositoryV2(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<SearchResult<DbSet>> SearchAsync(SearchQueryV2 query)
        {
            IQueryable<DbSet> entities = _context.Set<DbSet>().AsNoTracking();

            // Apply Keyword Search
            entities = entities.ApplyKeywordSearch(query.SearchByKeyword);

            // Apply Range Search
            entities = entities.ApplyRangeSearch(query.RangeSearch);


            // Apply Sorting
            entities = entities.ApplySorting(query.SortBy, query.SortDirection);

            // Apply Includes for related fields
            entities = entities.ApplyIncludes(query.Include);

            // Pagination
            var total = await entities.CountAsync();
            entities = entities.ApplyPaging(query.PageNumber, query.PageSize);

            var result = await entities.ToListAsync();

            return new SearchResult<DbSet>
            {
                Data = result,
                Total = total
            };
        }



    }
}
