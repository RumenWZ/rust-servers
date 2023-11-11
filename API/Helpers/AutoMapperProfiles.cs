using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddServerDTO, RustServer>().ReverseMap();
            CreateMap<ServerDTO, RustServer>().ReverseMap()
                .ForMember(d => d.WipeDates, op => op.MapFrom(src => src.CalculateWipeDays()));
        }
    }
}
