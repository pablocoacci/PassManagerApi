using Core.Data.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.V1.Account.Logout
{
    public class LogoutRequestHandler : IRequestHandler<LogoutRequest>
    {
        private readonly ISessionRepository sessionRepository;

        public LogoutRequestHandler(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }

        public async Task<Unit> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            var session = await sessionRepository.FindByUserIdAndToken(request.UserId, request.AccessToken);

            sessionRepository.Delete(session);

            return Unit.Value;
        }
    }
}
