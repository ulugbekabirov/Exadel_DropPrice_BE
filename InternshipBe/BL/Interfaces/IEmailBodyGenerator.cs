using DAL.Entities;

namespace BL.Interfaces
{
    public interface IEmailBodyGenerator
    {
        string GenerateMessageBody(User user, Ticket ticket, string emailTemplate);
    }
}
