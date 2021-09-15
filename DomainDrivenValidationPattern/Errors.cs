namespace DomainDrivenValidationPattern
{
    public abstract record Error;
    public record EmptyArgument : Error;
    public record InvalidEmail : Error;
    public record InvalidPhoneNumber : Error;
    public record InvalidLength(int MinLength, int MaxLength) : Error;
}
