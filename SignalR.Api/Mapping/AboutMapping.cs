using AutoMapper;
using SignalR.Dto.AboutDto;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
