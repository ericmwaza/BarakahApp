using AutoMapper;
using BarakahApp.Dtos;
using BarakahApp.Entities;

namespace BarakahApp.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserDto, UserEntity>();
        }
    }
}
