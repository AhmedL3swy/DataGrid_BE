using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
