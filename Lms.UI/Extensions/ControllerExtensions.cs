using Lms.Core.Wrappers.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UI.Extensions;

public static class ControllerExtensions
{
    public static IActionResult ResponseView<T>(this Controller controller, IResponseDataResult<T> response)
    {
        if (response.ResponseType == Core.Enums.ResponseType.NotFound)
            return controller.NotFound();
        return controller.View(response.Data);
    }

    public static IActionResult ResponseJson<T>(this Controller controller, IResponseDataResult<T> response)
    {
        if (response.ResponseType == Core.Enums.ResponseType.NotFound)
            return controller.NotFound();
        return controller.Json(new {message = response.Message ?? "Success",data = response.Data});
    }
}


