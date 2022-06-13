using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace SmartWork.Utils.Validators
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,16}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            var options = ruleBuilder
                            .Must(password => !string.IsNullOrWhiteSpace(password))
                            .WithMessage("Password should not be empty")
                            .Must(password => hasNumber.IsMatch(password))
                            .WithMessage("Password should contain at least one numeric value.")
                            .Must(password => hasUpperChar.IsMatch(password))
                            .WithMessage("Password should contain at least one upper case letter.")
                            .Must(password => hasMiniMaxChars.IsMatch(password))
                            .WithMessage("Password should not be lesser than 8 or greater than 16 characters.")
                            .Must(password => hasLowerChar.IsMatch(password))
                            .WithMessage("Password should contain at least one lower case letter.")
                            .Must(password => hasSymbols.IsMatch(password))
                            .WithMessage("Password should contain at least one special case character.");
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
