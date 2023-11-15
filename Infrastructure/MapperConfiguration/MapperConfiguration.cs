using Application.ViewModels.BookingViewModels;
using Application.ViewModels.FieldClusterViewModels;
using Application.ViewModels.SportFieldViewModels;
using Application.ViewModels.SportTypeViewModels;
using Application.ViewModels.TimeSlotViewModels;
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

            CreateMap<CreateTimeSlotDTO, TimeSlot>().ReverseMap();
            CreateMap<UpdateTimeSlotDTO, TimeSlot>()
                .ForMember(opt => opt.Id, dest => dest.MapFrom(src => src.TimeSlotId)).ReverseMap();

            CreateMap<CreateFieldClusterDTO, FieldCluster>().ReverseMap();
            CreateMap<UpdateFieldClusterDTO, FieldCluster>()
                .ForMember(opt => opt.Id, dest => dest.MapFrom(src => src.FieldClusterId)).ReverseMap();

            CreateMap<CreateSportFieldDTO, SportField>().ReverseMap();
            CreateMap<UpdateSportFieldDTO, SportField>()
                .ForMember(opt => opt.Id, dest => dest.MapFrom(src => src.SportFieldId)).ReverseMap();

            CreateMap<CreateBookingDTO, Booking>().ReverseMap();
            CreateMap<UpdateBookingDTO, Booking>()
                .ForMember(opt => opt.Id, dest => dest.MapFrom(src => src.BookingId)).ReverseMap();
        }
    }
}
