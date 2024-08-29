//CTRL + R + G

using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Dtosl;
using Lms.CoreLayer.Wrappers.Interfaces;
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.BusinessLogic.Abstract;

public interface IBookService
{
    Task<IResponseDataResult<bool>> AddAsync(AddBookDto bookDto);
    Task<IResponseDataResult<IEnumerable<GetBookViewDto>>> GetAllAsync();
    Task<IResponseDataResult<AddBookDto>> GetByIdAsync(int id);
    Task<IResponseDataResult<bool>> UpdateAsync(UpdateBookDto bookDto);
}
