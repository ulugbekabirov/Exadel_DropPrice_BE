using MimeKit;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(MimeMessage message);
    }
}
