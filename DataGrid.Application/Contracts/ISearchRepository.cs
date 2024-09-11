﻿using DataGrid.Application.Shared.Models;

namespace DataGrid.Application.Contracts
{
    public interface ISearchRepository<DbSet, SearchObject> where DbSet : class where SearchObject : class
    {
        Task<List<DbSet>> SearchAsync(SearchQuery<DbSet, SearchObject> query);
    }
}
