using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using api.Domain.Viewer;
using AutoMapper;

namespace api.Profiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<PlaceViewer, PlaceResponse>()
                .ForMember(dto => dto.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dto => dto.Perks, opt => opt.MapFrom(src => src.Perks))
                .ForMember(dto => dto.Photos, opt => opt.MapFrom(src => src.Photos));
            CreateMap<PlaceRequest, Place>();
            CreateMap<PlaceViewer, Place>();
        }
    }
}
