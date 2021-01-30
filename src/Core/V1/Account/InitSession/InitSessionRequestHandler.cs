using Core.Data.Repositories;
using Core.Entities;
using Core.Shared.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.InitSession
{
    public class InitSessionRequestHandler : IRequestHandler<InitSessionRequest>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IDateTimeOffsetService dateTimeOffsetService;

        public InitSessionRequestHandler(
            ISessionRepository sessionRepository,
            IDateTimeOffsetService dateTimeOffsetService)
        {
            this.sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
            this.dateTimeOffsetService = dateTimeOffsetService ?? throw new ArgumentNullException(nameof(dateTimeOffsetService));
        }

        public Task<Unit> Handle(InitSessionRequest request, CancellationToken cancellationToken)
        {
            var session = new Session(
                request.RefreshToken,
                request.UserId,
                request.Token,
                expiresOn: dateTimeOffsetService.UtcNow().Add(request.ValidFor),
                createdOn: dateTimeOffsetService.UtcNow());

            sessionRepository.Add(session);

            return Unit.Task;
        }
    }
}
