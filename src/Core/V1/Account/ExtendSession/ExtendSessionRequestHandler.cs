using Core.Data.Repositories;
using Core.Shared.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.ExtendSession
{
    public class ExtendSessionRequestHandler : IRequestHandler<ExtendSessionRequest>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IDateTimeOffsetService dateTimeOffsetService;

        public ExtendSessionRequestHandler(ISessionRepository sessionRepository, IDateTimeOffsetService dateTimeOffsetService)
        {
            this.sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
            this.dateTimeOffsetService = dateTimeOffsetService ?? throw new ArgumentNullException(nameof(dateTimeOffsetService));
        }

        public async Task<Unit> Handle(ExtendSessionRequest request, CancellationToken cancellationToken)
        {
            var session = await sessionRepository.FindByIdAsync(request.OldRefreshToken);

            session.Token = request.AccessToken;
            session.ExpiresOn = dateTimeOffsetService.UtcNow().Add(request.ValidFor);

            sessionRepository.Update(session);

            return Unit.Value;
        }
    }
}
