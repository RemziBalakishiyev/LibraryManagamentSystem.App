using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Enums;
using Lms.Core.Wrappers.Interfaces;

namespace Lms.BusinessLogic.Abstract
{
    public interface IUserService
    {
        Task<IResponseDataResult<RegisterUserDto>> CreatedUser(CreateUserDto userDto);
        Task<IResponseDataResult<bool>> CheckConfirmCode(int confirmCode);
        Task<IResponseResult> ChangeUserStatus(RegisterStatusEnum registerStatus,int userId);
        Task<IResponseDataResult<RegisterUserDto>> CheckUserAsync(SigninUserDto userDto);
    }
}
