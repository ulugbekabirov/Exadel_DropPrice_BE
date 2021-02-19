using DAL.Entities;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IMessageBuilder
    {
        Task<Message> GenerateMessageTemplateAsync(User user, Ticket ticket);
    }
}
