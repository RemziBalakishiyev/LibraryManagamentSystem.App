using AutoMapper;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Dtosl;
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
        CreateMap<Book, AddBookDto>()
         .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.BookAuthors.FirstOrDefault().Author.Id))
         .ForMember(dest => dest.UploadedFileDtos, opt => opt.MapFrom(src => src.UploadedFiles));
    

        CreateMap<AddAuthorDto, Author>();
        CreateMap<AddBookDto, Book>()
            .ReverseMap();
        CreateMap<UploadedFileDto, UploadedFile>().ReverseMap();
        CreateMap<Book, GetBookViewDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => string.Join(", ", src.BookAuthors.Select(ba => ba.Author.FullName)))
                )
                .ForMember(
                    dest => dest.Url,
                    opt => opt.MapFrom(src => src.UploadedFiles.FirstOrDefault().FileName)
                )
                .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Value)
                );


        CreateMap<UpdateBookDto, Book>()
           .ForMember(dest => dest.BookAuthors, opt => opt.Ignore()) 
           .ForMember(dest => dest.UploadedFiles, opt => opt.Ignore());

    }
}
