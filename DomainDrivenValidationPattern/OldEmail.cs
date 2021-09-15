using System;
using System.Text.RegularExpressions;

namespace DomainDrivenValidationPattern
{
    public sealed class OldEmail : ValueObject
    {
        private const string _regexString = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

        public string Value { get; }

        public OldEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace", nameof(value));

            if (!Regex.IsMatch(value, _regexString))
                throw new ArgumentException($"'{nameof(value)}' is not a valid email.", nameof(value));

            Value = value;
        }

        public static implicit operator string(OldEmail email) => email.Value;
    }
}
