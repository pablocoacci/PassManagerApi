using FluentValidation;

namespace Core.V1.PasswordSites.GetPasswordSiteById
{
    public class GetPasswordSiteByIdRequestValidator : AbstractValidator<GetPasswordSiteByIdRequest>
    {
        public GetPasswordSiteByIdRequestValidator()
        {
            RuleFor(x => x.PasswordSiteId)
                .NotEmpty()
                .NotNull();
        }
    }
}
