using DAL.Entities;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IMessageBuilder
    {
        Task<Message> GenerateMessageTemplateForUserAsync(User user, Ticket ticket);

        Task<Message> GenerateMessageTemplateForVendorAsync(User user, Ticket ticket);

    }
}
