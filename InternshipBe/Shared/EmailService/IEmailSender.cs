using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IEmailSender
    {
        Task ConvertEmailAsync(Message message);
    }
}
