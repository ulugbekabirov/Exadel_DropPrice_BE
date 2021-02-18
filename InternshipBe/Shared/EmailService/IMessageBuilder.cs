using DAL.Entities;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IMessageBuilder
    {
        Message GenerateMessageTemplate(User user, Ticket ticket);

        Task<Message> GenerateMessageTemplateAsync(User user, Ticket ticket);
    }
}
