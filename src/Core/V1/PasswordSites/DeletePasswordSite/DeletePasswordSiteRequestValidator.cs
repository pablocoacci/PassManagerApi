using FluentValidation;

namespace Core.V1.PasswordSites.DeletePasswordSite
{
    public class DeletePasswordSiteRequestValidator : AbstractValidator<DeletePasswordSiteRequest>
    {
        public DeletePasswordSiteRequestValidator()
        {
            RuleFor(x => x.PasswordSiteId)
                .NotNull()
                .NotEmpty();
        }
    }
}
