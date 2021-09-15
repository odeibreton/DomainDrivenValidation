using DomainDrivenValidationPattern;
using FluentValidation;
using FluentValidation.Validators;

namespace WebAPI.Validation
{
    public class DomainEmailValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "DomainEmailValidator";
        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return "'{PropertyName}' is not a valid email address.";
        }

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = Email.TryParse(value);

            return result.Match(
                (Email _) => true,
                (EmptyArgument _) => true,
                (InvalidEmail _) => false
            );
        }
    }
}
