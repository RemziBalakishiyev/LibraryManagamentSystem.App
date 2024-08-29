using AutoMapper;
using Lms.BusinessLogic.Dtos;
using Lms.Entity.Accounts;
using Lms.Entity.Books;
using Lms.Entity.Commons;

namespace Lms.BusinessLogic.Mappers;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreatUserDto, User>();
        CreateMap<CreatUserDto, UserDetail>();
        CreateMap<AddAuthorDto, Author>();
        CreateMap<AddBookDto, Book>();
        CreateMap<UploadedFileDto, UploadedFile>();
    }
}
