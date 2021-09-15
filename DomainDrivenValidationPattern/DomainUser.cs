using OneOf;

namespace DomainDrivenValidationPattern
{
    public sealed class DomainUser
    {
        public string Name { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }

        private DomainUser(string name, Email email, PhoneNumber phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static OneOf<DomainUser, EmptyArgument, InvalidLength> Create(string name, Email email, PhoneNumber phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new EmptyArgument();

            if (name.Length < 3 || name.Length > 100)
                return new InvalidLength(3, 100);

            return new DomainUser(name, email, phoneNumber);
        }
    }
}
