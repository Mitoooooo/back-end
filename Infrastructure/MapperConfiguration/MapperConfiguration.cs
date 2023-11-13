using Application.ViewModels.SportTypeViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MapperConfiguration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<CreateSportTypeDTO, SportType>().ReverseMap();
            CreateMap<UpdateSportTypeDTO, SportType>()
                .ForMember(opt => opt.Id, dest => dest.MapFrom(src => src.SportTypeId)).ReverseMap();           
        }
    }
}
