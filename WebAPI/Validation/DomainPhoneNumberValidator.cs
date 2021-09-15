using DomainDrivenValidationPattern;
using FluentValidation;
using FluentValidation.Validators;

namespace WebAPI.Validation
{
    public class DomainPhoneNumberValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "DomainPhoneNumberValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return "'{PropertyName}' is not a valid phone number";
        }

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            var result = PhoneNumber.TryParse(value);

            return result.Match(
                (PhoneNumber _) => true,
                (EmptyArgument _) => true,
                (InvalidPhoneNumber _) => false
            );
        }
    }
}
