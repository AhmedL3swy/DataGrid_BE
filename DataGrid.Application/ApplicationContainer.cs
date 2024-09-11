using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared.Models;
using DataGrid.Application.Shared;
using DataGrid.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            services.AddTransient(typeof(IRequestHandler<SearchQuery<SearchProductViewModel>, ApiResult<SearchProductViewModel>>), typeof(SearchQueryHandler<Product, SearchProductViewModel>));
            return services;

        }
    }
}
