using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using AutoMapper;

namespace api.Profiles
{
    public class PlacePerkProfile : Profile
    {
        public PlacePerkProfile()
        {
            CreateMap<PlacePerk, PlacePerkResponse>()
                .ForMember(dto => dto.Perk, opt => opt.MapFrom(src => src.Perk))
                .ForMember(dto => dto.Place, opt => opt.MapFrom(src => src.Place));
            CreateMap<PlacePerkRequest, PlacePerk>();
        }
    }
}
