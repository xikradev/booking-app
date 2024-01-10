using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using AutoMapper;

namespace api.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressResponse>();
            CreateMap<AddressRequest, Address>();
        }
    }
}
