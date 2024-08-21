using AutoMapper;
using Lms.BusinessLogic.Dtos;
using Lms.Entity.Accounts;

namespace Lms.BusinessLogic.AutoMappers
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CreateUserDto,User>();
            CreateMap<CreateUserDto,UserDetail>();


            CreateMap<User, RegisterUserDto>();
            CreateMap<User, RegisterUserDto>();
        }
    }
}
