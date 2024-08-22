using AutoMapper;
using Lms.BusinessLogic.Dtos;
using Lms.Entity.Accounts;

namespace Lms.BusinessLogic.Mappers;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreatUserDto, User>();
        CreateMap<CreatUserDto, UserDetail>();
    }
}
