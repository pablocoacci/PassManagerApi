using FluentValidation;

namespace Core.V1.Account.Reset
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
