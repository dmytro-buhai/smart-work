using FluentValidation;
using System;

namespace SmartWork.Utils.Validators
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .MinimumLength(8)
                          .MaximumLength(16)
                          .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")
                          .WithMessage("Password must contains numbers, capital letters and symbols");

            return options;
        }

        public static IRuleBuilder<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .Length(10)
                          .Matches(@"^0\d{9}$")
                          .WithMessage("Please, specify a valid phone number that starts from 0, for example 0661234567");

            return options;
        }

        public static IRuleBuilder<T, string> Address<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .MaximumLength(256)
                          .Matches(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9',/_-]+)+$")
                          .WithMessage("Please, specify a valid address, for example, Correct address, 54 or Correct address, 54/2");

            return options;
        }

        public static IRuleBuilder<T, string> ObjectName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .MaximumLength(256)
                          .Matches(@"^\D+$")
                          .WithMessage("Please enter a valid name");

            return options;
        }

        public static IRuleBuilder<T, string> PhotoFileName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .WithMessage("Please, specify a photo file name");

            return options;
        }

        public static IRuleBuilder<T, DateTime> BirthDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .Must(BeAValidAge)
                          .WithMessage("Please, specify a valid birth date");

            return options;
        }

        private static bool BeAValidAge(DateTime date)
        {
            var currentYear = DateTime.Now.Year;
            var birthYear = date.Year;

            if (birthYear <= currentYear && birthYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}
