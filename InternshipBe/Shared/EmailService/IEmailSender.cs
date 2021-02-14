using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
