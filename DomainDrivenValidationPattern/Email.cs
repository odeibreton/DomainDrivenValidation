using OneOf;
using System;
using System.Text.RegularExpressions;

namespace DomainDrivenValidationPattern
{
    public sealed class Email : ValueObject
    {
        private const string _regexString = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static OneOf<Email, EmptyArgument, InvalidEmail> TryParse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new EmptyArgument();

            if (!Regex.IsMatch(value, _regexString))
                return new InvalidEmail();

            return new Email(value);
        }

        public static Email Parse(string value)
        {
            var result = TryParse(value);

            return result.Match(
                (Email email) => email,
                (EmptyArgument _) => throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace", nameof(value)),
                (InvalidEmail _) => throw new ArgumentException("The provided email is not valid.", nameof(value))
            );
        }

        public static implicit operator string(Email email) => email.Value;
    }
}
