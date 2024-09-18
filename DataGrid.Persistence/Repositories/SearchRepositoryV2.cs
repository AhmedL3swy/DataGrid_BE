using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using DataGrid.Persistence.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataGrid.Persistence.Repositories
{
    /// <summary>
    /// Represents a repository for searching entities in version 2.
    /// </summary>
    /// <typeparam name="DbSet">The type of the entity set.</typeparam>
    internal class SearchRepositoryV2<DbSet> : ISearchRepositoryV2<DbSet> where DbSet : class
    {
        private readonly ProductDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRepositoryV2{DbSet}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SearchRepositoryV2(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Searches for entities based on the provided query.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>The search result.</returns>
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
