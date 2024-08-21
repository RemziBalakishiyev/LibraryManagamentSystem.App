using FluentValidation.Results;
using Lms.Core.Wrappers.Concretes;

namespace Lms.Core.Extensions;

public static class ValidationExtensions
{
    public static  List<ResponseValidationResult> ToResponseValidationResults(this ValidationResult validationResult)
    {
        List<ResponseValidationResult> responseValidationResults = [];
        foreach (var item in validationResult.Errors)
        {
            responseValidationResults.Add(new()
            {
                ErrorMessage = item.ErrorMessage,
                PropertyName = item.PropertyName,
            });
        }

        return responseValidationResults;
    }
}
