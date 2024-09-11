using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DataGrid.Application.Features.Search.SearchRequestModels;

namespace DataGrid.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        public static IServiceCollection AddMediatorGenericHandelers(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRequestHandler<SearchQuery<SearchProduct>, ApiResult<SearchProduct>>), typeof(SearchQueryHandler<Product, SearchProduct>));
            return services;

        }
    }
}
