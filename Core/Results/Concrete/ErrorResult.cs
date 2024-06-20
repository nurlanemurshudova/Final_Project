using Core.Validation;

namespace Core.Results.Concrete
{
    public class ErrorResult : Result
    {
        public List<ValidationErrorModel> Errors { get; }
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(message, false)
        {
        }
        public ErrorResult(List<ValidationErrorModel> errors) : base(false)
        {
            Errors = errors;
        }

    }
}
