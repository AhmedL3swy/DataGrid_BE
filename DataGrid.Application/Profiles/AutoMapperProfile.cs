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
                .ForMember(dest => dest.EnCategoryName, opt => opt.MapFrom(src => src.Category.EnName))
                .ForMember(dest => dest.ArCategoryName, opt => opt.MapFrom(src => src.Category.ArName));

        }

    }
}
