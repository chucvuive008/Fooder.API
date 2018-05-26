using AutoMapper;
using Fooder.API.DTOs;
using Fooder.API.Models;

namespace Fooder.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForDetailDto, User>();
        }
    }
}