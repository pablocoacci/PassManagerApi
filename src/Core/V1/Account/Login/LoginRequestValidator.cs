using FluentValidation;

namespace Core.V1.Account.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(m => m.UserName)
                .NotEmpty()
                .NotNull();

            RuleFor(m => m.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
