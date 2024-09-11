using AutoMapper;
using DataGrid.Domain;
using DataGrid.Application.Features.Search.Queries;

namespace DataGrid.Application.Profiles
{
    public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Product, SearchProductViewModel>().ReverseMap();
		}

	}
}
