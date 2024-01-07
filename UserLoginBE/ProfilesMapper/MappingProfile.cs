using AutoMapper;
using GovBE.Controllers;
using GovBE.Models;
using UserLoginBE.Entities.Models;
using UserLoginBE.Models;

namespace UserLoginBE.ProfilesMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserApp, UserRegistrationDto>().ReverseMap();
        }
    }
}
