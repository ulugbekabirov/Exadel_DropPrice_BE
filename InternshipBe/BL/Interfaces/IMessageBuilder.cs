using DAL.Entities;
using MimeKit;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IMessageBuilder
    {
        Task<MimeMessage> GenerateMessageForUserAsync(User user, Ticket ticket);

        Task<MimeMessage> GenerateMessageForVendorAsync(User user, Ticket ticket);
    }
}
