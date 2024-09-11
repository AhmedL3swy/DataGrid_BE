using AutoMapper;
using DataGrid.Domain;
using DataGrid.Application.Features.Search.SearchRequestModels;

namespace DataGrid.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, SearchProduct>().ReverseMap();
        }

    }
}
