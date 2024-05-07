using AutoMapper;
using UsersAuthAPI.Models;
using UsersAuthAPI.Data.DTOs;

namespace UsersAuthAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
        }
    }
}
