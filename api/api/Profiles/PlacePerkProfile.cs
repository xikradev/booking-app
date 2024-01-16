using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using api.Domain.Viewer;
using AutoMapper;

namespace api.Profiles
{
    public class PlacePerkProfile : Profile
    {
        public PlacePerkProfile()
        {
            CreateMap<PlacePerkViewer, PlacePerkResponse>()
                .ForMember(dto => dto.Perk, opt => opt.MapFrom(src => src.Perk));
            CreateMap<PlacePerkRequest, PlacePerk>();
            CreateMap<PlacePerkViewer, PlacePerk>();
        }
    }
}
