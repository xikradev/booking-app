using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using AutoMapper;

namespace api.Profiles
{
    public class PerkProfile : Profile
    {
        public PerkProfile()
        {
            CreateMap<Perk, PerkResponse>();
            CreateMap<PerkRequest, Perk>();
        }
    }
}
