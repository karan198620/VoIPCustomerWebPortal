using System.Threading.Tasks;
using VoipProjectEntities.Application.Models.Mail;

namespace VoipProjectEntities.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
