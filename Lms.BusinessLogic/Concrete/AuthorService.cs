using AutoMapper;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.CoreLayer.Wrappers.Concrete;
using Lms.CoreLayer.Wrappers.Interfaces;
using Lms.DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Lms.BusinessLogic.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public Task<IResponseDataResult.IResponseDataResult<AuthorDto>> GetAuthorAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResponseDataResult.IResponseDataResult<IEnumerable<AuthorDto>>> SearchAuthorFullName(string fullName)
        {
            try
            {
                var authorEntity = await _authorRepository
              .GetWhereAsync(x => x.FirstName.Contains(fullName) || x.LastName.Contains(fullName))
              .Select(x => new AuthorDto { Id = x.Id, FullName = x.FullName })
              .ToListAsync();
                return new ResponseDataResult<IEnumerable<AuthorDto>>(CoreLayer.Enums.ResponseType.SuccessResult, authorEntity);
            }
            catch (Exception e)
            {
                var ex = e;
            }
            return new ResponseDataResult<IEnumerable<AuthorDto>>(CoreLayer.Enums.ResponseType.SuccessResult, new List<AuthorDto>());

        }
    }
}
