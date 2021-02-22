using MimeKit;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public interface IEmailSender
    {
        Task SendAsync(MimeMessage message);
    }
}
