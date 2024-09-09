using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Application.Features.Products.Queries.Search
{
    public class SearchProductQuery : IRequest<List<SearchProductViewModel>>
    {
    }

}
