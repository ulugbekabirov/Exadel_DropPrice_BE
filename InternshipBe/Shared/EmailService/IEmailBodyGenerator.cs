using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IEmailBodyGenerator
    {
        Dictionary<string, string> InizializeDictionary(User user, Ticket ticket);

        Task<string> GenerateVendorBody(User user, Ticket ticket);

        Task<string> GenerateUserBody(User user, Ticket ticket);
    }
}
