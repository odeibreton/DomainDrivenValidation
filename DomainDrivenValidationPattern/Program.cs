using System;
using System.Text.RegularExpressions;

namespace DomainDrivenValidationPattern
{
    public sealed class AccountId
    {
        public string Value { get; }

        private AccountId(string value)
        {
            Value = value;
        }

        public static bool TryParse(string value, out AccountId accountId)
        {
            var valid = IsValid(value);

            if (!valid)
            {
                accountId = null;
                return false;
            }

            accountId = new AccountId(value);
            return true;
        }

        public static AccountId Parse(string value)
        {
            var valid = TryParse(value, out var accountId);

            if (!valid)
                throw new FormatException("The account ID does not have the correct format.");

            return accountId;
        }

        private static bool IsValid(string value)
        {
            return Regex.Match(value, "^[a-zA-Z0-9]{16,19}$").Success;
        }
    }
}
