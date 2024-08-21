using Lms.Core.Wrappers.Concretes;

namespace Lms.Core.Wrappers.Interfaces
{
    public interface IResponseDataResult<T> : IResponseResult
    {
        T Data { get; set; }
        ICollection<ResponseValidationResult> ResponseValidationResults { get; set; }
    }
}