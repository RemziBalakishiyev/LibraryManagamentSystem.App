using Lms.Core.Enums;
using Lms.Core.Wrappers.Interfaces;

namespace Lms.Core.Wrappers.Concretes;

public class ResponseResult : IResponseResult
{
    public ResponseResult(ResponseType responseType) => ResponseType = responseType;

    public ResponseResult(
        ResponseType responseType,
        string message)
    {
        ResponseType = responseType;
        Message = message;
    }
    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }
}
