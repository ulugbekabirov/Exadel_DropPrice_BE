using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public interface IEmailBodyGenerator
    {
        Dictionary<string, string> InizializeDictionary(User user, Ticket ticket);

        Task<string> GenerateMessageBodyForUserAsync(User user, Ticket ticket);
    }
}
