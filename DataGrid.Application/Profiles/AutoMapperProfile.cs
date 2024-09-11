using AutoMapper;
using DataGrid.Domain;
using DataGrid.Application.Features.Search.SearchRequestModels.Product;

namespace DataGrid.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Product, SearchProductResultDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryArName, opt => opt.MapFrom(src => src.Category.ArName));

        }

    }
}
