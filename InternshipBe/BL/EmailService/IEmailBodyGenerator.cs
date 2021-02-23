using DAL.Entities;

namespace BL.EmailService
{
    public interface IEmailBodyGenerator
    {
        string GenerateMessageBodyAsync(User user, Ticket ticket, string emailTemplate);
    }
}
