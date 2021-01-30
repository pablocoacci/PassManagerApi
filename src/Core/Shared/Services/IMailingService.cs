using System.Threading.Tasks;

namespace Core.Shared.Services
{
    public interface IMailingService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
