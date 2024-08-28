using Lms.BusinessLogic.Dtos;
using Lms.CoreLayer.Wrappers.Interfaces;
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.BusinessLogic.Abstract
{
    public interface IAuthorService
    {
        Task<IResponseDataResult<AuthorDto>> GetAuthorAsync();
        Task<IResponseDataResult<IEnumerable<AuthorDto>>> SearchAuthorFullName(string fullName);
    }
}
