using AutoMapper;
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
