using AutoMapper;
using Azure;
using FluentValidation;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Enums;
using Lms.Core.Enums;
using Lms.Core.Extensions;
using Lms.Core.Helpers;
using Lms.Core.Wrappers.Concretes;
using Lms.Core.Wrappers.Interfaces;
using Lms.DataAccessLayer.Abstract;
using Lms.Entity.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Lms.BusinessLogic.Concrete;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserDto> _validator;
    private readonly IValidator<SigninUserDto> _signinUserValidator;
    public UserService(IUserRepository userRepository,
                       IMapper mapper,
                       IValidator<CreateUserDto> validator,
                       IUserDetailRepository userDetailRepository,
                       IValidator<SigninUserDto> signinUserValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
        _userDetailRepository = userDetailRepository;
        _signinUserValidator = signinUserValidator;
    }

    public async Task<IResponseResult> ChangeUserStatus(RegisterStatusEnum registerStatus, int userId)
    {
        var user = await _userDetailRepository
              .GetWhereAsync(x => x.UserId == userId)
              .SingleOrDefaultAsync();

        if (user is not null)
        {
            user.StatusId = (int)registerStatus;
            await _userDetailRepository.SaveChangesAsync();
            return new ResponseResult(ResponseType.SuccessResult);
        }

        return new ResponseResult(ResponseType.NotFound);
    }

    public async Task<IResponseDataResult<bool>> CheckConfirmCode(int confirmCode)
    {
        var user = await _userDetailRepository
               .GetWhereAsync(x => x.ConfirmCode == confirmCode)
               .FirstOrDefaultAsync();

        return new ResponseDataResult<bool>(ResponseType.SuccessResult, user != null);
    }

    public async Task<IResponseDataResult<RegisterUserDto>> CheckUserAsync(SigninUserDto userDto)
    {

        var validationResult = await _signinUserValidator.ValidateAsync(userDto);

        if (!validationResult.IsValid)
        {
            return new ResponseDataResult<RegisterUserDto>(validationResult.ToResponseValidationResults(), new());
        }

        var user = await _userRepository
            .GetSigninUserWithDetailAsync(userDto.Email);
        if (user is null)
        {
            return new ResponseDataResult<RegisterUserDto>([new() { ErrorMessage = "User is not found by email", PropertyName = "Email" }], new());
        }

        var isCorrectPassword = HashHelper.VerifyPasswordHash(userDto.Password, user.PasswordHash.ToByte(), user.PasswordSalt.ToByte());

        if (isCorrectPassword is false)
        {
            return new ResponseDataResult<RegisterUserDto>([new() { ErrorMessage = "Password is incorrect", PropertyName = "Password" }], new());
        }

        return new ResponseDataResult<RegisterUserDto>(ResponseType.SuccessResult, new RegisterUserDto()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.UserDetail.FirstName,
            LastName = user.UserDetail.LastName,
            ConfirmCode = user.UserDetail.ConfirmCode,
        });
    }

    public async Task<IResponseDataResult<RegisterUserDto>> CreatedUser(CreateUserDto userDto)
    {

        var validationResult = await _validator.ValidateAsync(userDto);

        if (!validationResult.IsValid)
        {
            return new ResponseDataResult<RegisterUserDto>(validationResult.ToResponseValidationResults(), new());
        }


        var user = await _userRepository
            .GetWhereAsync(x => x.Email == userDto.Email)
            .FirstOrDefaultAsync();

        if (user is not null)
        {
            return new ResponseDataResult<RegisterUserDto>(
                [new() { ErrorMessage = "Mail is registered", PropertyName = "Email" }],
                new());
        }

        var userEntity = _mapper.Map<User>(userDto);
        userEntity.UserDetail = _mapper.Map<UserDetail>(userDto);

        byte[] passwordHash;
        byte[] passwordSalt;

        HashHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

        userEntity.PasswordSalt = passwordSalt.ByteToString();
        userEntity.PasswordHash = passwordHash.ByteToString();
        userEntity.UserDetail.ConfirmCode = CodeGenerator.GenerateConfirmCode();
        userEntity.UserDetail.StatusId = (int)RegisterStatusEnum.Register;
        userEntity.UserRoles =
        [
            new() {RoleId = 3}
        ];


        await _userRepository.AddAsync(userEntity);

        try
        {
            await _userRepository.SaveChangesAsync();

        }
        catch (Exception e)
        {
            var mm = e;
            throw;
        }
        return new ResponseDataResult<RegisterUserDto>(ResponseType.SuccessResult, new RegisterUserDto
        {
            Id = userEntity.Id,
            Email = userEntity.Email,
            ConfirmCode = userEntity.UserDetail.ConfirmCode,
            FirstName = userEntity.UserDetail.FirstName,
            LastName = userEntity.UserDetail.LastName,
        });
    }

}
