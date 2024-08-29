using AutoMapper;
using FluentValidation;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Dtosl;
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
    private readonly IValidator<UpdateBookDto> _updateBookDtoValidator;

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper,
        IValidator<AddBookDto> createBookDtoValidator,
        IValidator<UpdateBookDto> updateBookDtoValidator)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _addBookDtoValidator = createBookDtoValidator;
        _updateBookDtoValidator = updateBookDtoValidator;
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

    public async Task<IResponseDataResult.IResponseDataResult<IEnumerable<GetBookViewDto>>> GetAllAsync()
    {
        var books = _mapper.Map<IEnumerable<GetBookViewDto>>(await _bookRepository.GetBooksWithDetails());

        return new ResponseDataResult<IEnumerable<GetBookViewDto>>(ResponseType.SuccessResult, books);
    }

    public async Task<IResponseDataResult.IResponseDataResult<AddBookDto>> GetByIdAsync(int id)
    {
        var bookEntity = await _bookRepository.GetBookWithDetailWithIdAsync(id);
        var book = _mapper.Map<AddBookDto>(bookEntity);
        book.AuthorId = bookEntity.BookAuthors.FirstOrDefault().Author.Id;
        return new ResponseDataResult<AddBookDto>(ResponseType.SuccessResult, book);
    }


    public async Task<IResponseDataResult.IResponseDataResult<bool>> UpdateAsync(UpdateBookDto bookDto)
    {
        var result = await _updateBookDtoValidator.ValidateAsync(bookDto);
        if (result.IsValid is false)
        {
            return new ResponseDataResult<bool>(result.ToResponseValidationResults());
        }

     
        var existingBook = await _bookRepository.GetBookWithDetailWithIdAsync(bookDto.Id);
        if (existingBook == null)
        {
            return new ResponseDataResult<bool>(ResponseType.NotFound);
        }
        _mapper.Map(bookDto, existingBook);

        if (bookDto.AuthorId is null)
        {
            var authorEntity = _mapper.Map<Author>(bookDto.Author);
            existingBook.BookAuthors = [new BookAuthor { Author = authorEntity }];
        }
        else
        {
            existingBook.BookAuthors = [new BookAuthor { AuthorId = bookDto.AuthorId.Value }];
        }

        
        existingBook.UploadedFiles = _mapper.Map<ICollection<UploadedFile>>(bookDto.UploadedFileDtos);
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
