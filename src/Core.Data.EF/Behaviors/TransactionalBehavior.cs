using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Data.EF.Behaviors
{
    public class TransactionalBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly DataContext dataContext;

        public TransactionalBehavior(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!typeof(IRequest).IsAssignableFrom(request.GetType()))
                return await next();

            var response = await next();
            await dataContext.SaveChangesAsync();
            return response;
        }
    }
}
