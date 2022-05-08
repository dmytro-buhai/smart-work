using FluentValidation;

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
                          .WithMessage("Please, specify the correct phone number that starts from 0, for example 0661234567");

            return options;
        }

        public static IRuleBuilder<T, string> Address<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .MaximumLength(256)
                          .Matches(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9',/_-]+)+$")
                          .WithMessage("Please, specify the correct address, for example, Correct address, 54 or Correct address, 54/2");

            return options;
        }
    }
}
