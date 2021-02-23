using DAL.Entities;

namespace BL.Interfaces
{
    public interface IEmailBodyGenerator
    {
        string GenerateMessageBodyAsync(User user, Ticket ticket, string emailTemplate);
    }
}
