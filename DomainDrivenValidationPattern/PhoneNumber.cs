using OneOf;
using System;
using System.Text.RegularExpressions;

namespace DomainDrivenValidationPattern
{
    public sealed class PhoneNumber : ValueObject
    {
        private const string _regexString = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static PhoneNumber Parse(string value)
        {
            OneOf<PhoneNumber, EmptyArgument, InvalidPhoneNumber> result = TryParse(value);

            return result.Match(
                email => email,
                _ => throw new ArgumentNullException(nameof(value)),
                _ => throw new ArgumentException("The provided phone number is not valid.", nameof(value))
            );
        }

        public static OneOf<PhoneNumber, EmptyArgument, InvalidPhoneNumber> TryParse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new EmptyArgument();

            if (!Regex.IsMatch(value, _regexString))
                return new InvalidPhoneNumber();

            return new PhoneNumber(value);
        }

        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
    }
}
