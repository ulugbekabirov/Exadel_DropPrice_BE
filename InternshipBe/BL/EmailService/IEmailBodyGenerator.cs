using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public interface IEmailBodyGenerator
    {
        Dictionary<string, string> InizializeDictionary(User user, Ticket ticket);

        Task<string> GenerateMessageBodyForUserAsync(User user, Ticket ticket);
        
        Task<string> GenerateMessageBodyForVendorAsync(User user, Ticket ticket);

    }
}
