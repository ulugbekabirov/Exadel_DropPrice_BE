using DAL.Entities;

namespace Shared.EmailService
{
    public interface IMessageBuilder
    {
        Message GenerateMessageTemplate(User user, Ticket ticket);
    }
}
