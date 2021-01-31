using FluentValidation;

namespace Core.V1.PasswordSites.UpdatePasswordSite
{
    public class UpdatePasswordSiteRequestValidator : AbstractValidator<UpdatePasswordSiteRequest>
    {
        public UpdatePasswordSiteRequestValidator()
        {
            RuleFor(x => x.PasswordSiteId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.NameSite)
                .MaximumLength(100);

            RuleFor(x => x.UrlSite)
                .MaximumLength(100);

            RuleFor(x => x.UrlSite)
                .MaximumLength(700);

            RuleFor(x => x.UserNameSite)
                .MaximumLength(100);

            RuleFor(x => x.Password)
                .MaximumLength(100);

            RuleFor(x => x.SecretAnswer)
                .MaximumLength(100);
        }
    }
}
