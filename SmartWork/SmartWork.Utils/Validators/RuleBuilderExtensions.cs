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
                          .WithMessage("Required length for password is between 8 and 16\n" +
                                       "Password must contains numbers, capital letters and symbols");

            return options;
        }

        public static IRuleBuilder<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .Length(9)
                          .Matches(@"^0[0-9]\d{2}-\d{3}-\d{4}$")
                          .WithMessage("Required length for phone number is 9\n" +
                                       "Please, specify the correct phone number");

            return options;
        }

        public static IRuleBuilder<T, string> Address<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty()
                          .NotNull()
                          .MaximumLength(256)
                          .Matches(@"^[a-zA-Z0-9\_,]+$")
                          .WithMessage("Maximum length for address is 256\n" +
                                       "Please, specify the correct address");

            return options;
        }
    }
}
