using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using AutoMapper;

namespace api.Profiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Photo, PhotoResponse>();
            CreateMap<PhotoRequest, Photo>();
        }
    }
}
