using FluentValidation;

namespace Core.V1.PasswordSites.CreatePasswordSite
{
    public class CreatePasswordSiteRequestValidator : AbstractValidator<CreatePasswordSiteRequest>
    {
        public CreatePasswordSiteRequestValidator()
        {
            RuleFor(x => x.NameSite)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.UrlSite)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.UrlSite)
                .MaximumLength(700);

            RuleFor(x => x.UserNameSite)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.SecretAnswer)
                .MaximumLength(100);
        }
    }
}
