﻿//CTRL + R + G

using Lms.BusinessLogic.Dtos;
using Lms.CoreLayer.Wrappers.Interfaces;
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.BusinessLogic.Abstract;

public interface IBookService
{
    Task<IResponseDataResult<bool>> CreateAsync(CreateBookDto bookDto);
}
