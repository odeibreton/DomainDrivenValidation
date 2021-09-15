using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Validation
{
    public class UserPostRequestValidator : AbstractValidator<UserPostRequest>
    {
        public UserPostRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .DomainEmail();

            RuleFor(m => m.PhoneNumber)
                .DomainPhoneNumber();
        }
    }
}
