using Lms.Core.Enums;

namespace Lms.Core.Wrappers.Interfaces;

public interface IResponseResult
{
     string Message { get; set; }
     ResponseType ResponseType { get; set; }
}
