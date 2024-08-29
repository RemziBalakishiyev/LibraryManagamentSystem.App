using AutoMapper;
using FluentValidation;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.CoreLayer.Enums;
using Lms.CoreLayer.Extensions;
using Lms.CoreLayer.Wrappers.Concrete;
using Lms.CoreLayer.Wrappers.Interfaces;
using Lms.DataAccessLayer.Abstract;
using Lms.Entity.Books;
using Lms.Entity.Commons;

namespace Lms.BusinessLogic.Concrete;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IValidator<AddBookDto> _addBookDtoValidator;

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper,
        IValidator<AddBookDto> createBookDtoValidator)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _addBookDtoValidator = createBookDtoValidator;
    }
    public async Task<IResponseDataResult.IResponseDataResult<bool>> AddAsync(AddBookDto bookDto)
    {
        var result = await _addBookDtoValidator.ValidateAsync(bookDto);
        if (result.IsValid is false)
        {
            return new ResponseDataResult<bool>(result.ToResponseValidationResults());
        }

        var bookEntity = _mapper.Map<Book>(bookDto);
        var authorEntity = _mapper.Map<Author>(bookDto.Author);
        var uploadedFilesEntity = _mapper.Map<ICollection<UploadedFile>>(bookDto.UploadedFileDtos);

        if (bookDto.AuthorId is null)
        {
            bookEntity.BookAuthors =
                [
                    new BookAuthor { Author = authorEntity}
                ];
        }
        else
        {
            bookEntity.BookAuthors =
            [
                new BookAuthor { AuthorId =  bookDto.AuthorId.Value}
            ];
        }


        bookEntity.UploadedFiles = uploadedFilesEntity;

        await _bookRepository.AddAsync(bookEntity);
        await _bookRepository.SaveChangesAsync();
        return new ResponseDataResult<bool>(ResponseType.SuccessResult);
    }
}
