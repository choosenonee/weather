using api.Domain.Dto;
using AutoMapper;
using System;

namespace Weather.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<api.Domain.Models.WeatherModel.Main, TemperatureDto>()
                .ForMember(dest => dest.FeelsLike, source => source.MapFrom(source => source.feels_like))
                .ForMember(dest => dest.Temperature, source => source.MapFrom(source => source.temp))
                .ForMember(dest => dest.TempMax, source => source.MapFrom(source => source.temp_max))
                .ForMember(dest => dest.TempMin, source => source.MapFrom(source => source.temp_min));
            CreateMap<decimal, decimal>().ConvertUsing(x => Math.Round(x, 2));
        }
    }
}
