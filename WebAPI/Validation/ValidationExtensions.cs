using DomainDrivenValidationPattern;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Validation
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> DomainEmail<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .SetValidator(new DomainEmailValidator<T>());
        }

        public static IRuleBuilderOptions<T, string> DomainPhoneNumber<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .SetValidator(new DomainPhoneNumberValidator<T>());
        }
    }
}
