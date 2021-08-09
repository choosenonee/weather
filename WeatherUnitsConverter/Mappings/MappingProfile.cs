using api.Domain.Models;
using AutoMapper;

namespace WeatherLogger.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherModel.Main, TemperatureReply>()
                .ForMember(dest => dest.FeelsLike, source => source.MapFrom(source => source.feels_like))
                .ForMember(dest => dest.Temperature, source => source.MapFrom(source => source.temp))
                .ForMember(dest => dest.TempMax, source => source.MapFrom(source => source.temp_max))
                .ForMember(dest => dest.TempMin, source => source.MapFrom(source => source.temp_min));
        }
    }
}
