using DomainDrivenValidationPattern;
using FluentValidation;

namespace WebAPI.Validation
{
    public static class ErrorExtensions
    {
        public static void AddErrorMessage<T>(this EmptyArgument _, ValidationContext<T> context) =>
            context.AddFailure("'{PropertyName}' must not be empty.");

        public static void AddErrorMessage<T>(this InvalidEmail _, ValidationContext<T> context) =>
            context.AddFailure("'{PropertyName}' is not a valid email address.");

        public static void AddErrorMessage<T>(this InvalidPhoneNumber _, ValidationContext<T> context) =>
            context.AddFailure("'{PropertyName}' is not a valid phone number.");

        public static void AddErrorMessage<T>(this InvalidLength error, ValidationContext<T> context)
        {
            context.AddFailure("The length of '{PropertyName}' must be between {MaxLength} and {MinLength}.");
            context.MessageFormatter
                .AppendArgument("MaxLength", error.MaxLength)
                .AppendArgument("MinLength", error.MinLength);
        }
    }
}
