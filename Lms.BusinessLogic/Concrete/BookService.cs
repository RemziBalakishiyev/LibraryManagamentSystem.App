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
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.BusinessLogic.Concrete;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly IValidator<CreateBookDto> _createBookDtoValidator;

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper,
        IValidator<CreateBookDto> createBookDtoValidator)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _createBookDtoValidator = createBookDtoValidator;
    }

    public async Task<IResponseDataResult<bool>> CreateAsync(CreateBookDto bookDto)
    {
        var result = await _createBookDtoValidator.ValidateAsync(bookDto);

        if (result.IsValid is false)
        {
            return new ResponseDataResult<bool>(result.ToResponseValidationResults());
        }
        var bookEntity = _mapper.Map<Book>(bookDto);
        if (bookDto.AuthorId is null)
        {
            bookEntity.BookAuthors =
            [
                new BookAuthor { Author =  _mapper.Map<Author>(bookDto.Author)}
            ];
        }
        else
        {
            bookEntity.BookAuthors =
            [
                new BookAuthor { AuthorId =  bookDto.AuthorId.Value}
            ];
        }


        bookEntity.UploadedFiles = _mapper.Map<ICollection<UploadedFile>>(bookDto.UploadFileDtos);
        await _bookRepository.AddAsync(bookEntity);
        try
        {
            await _bookRepository.SaveChangesAsync();
        }
        catch (Exception e)
        {
            var ex = e;
        }

        return new ResponseDataResult<bool>(ResponseType.SuccessResult);

    }
}
