using BL.Interfaces;
using DAL.Entities;
using System.Collections.Generic;

namespace BL.EmailService
{
    public class EmailBodyGenerator : IEmailBodyGenerator
    {
        private readonly IReplacerService _replacer;

        public EmailBodyGenerator(IReplacerService replacer)
        {
            _replacer = replacer;
        }

        public string GenerateMessageBodyAsync(User user, Ticket ticket, string emailTemplate)
        {
            var dictionary = InizializeDictionary(user, ticket);

            return _replacer.Replacer(emailTemplate, dictionary);
        }

        private Dictionary<string, string> InizializeDictionary(User user, Ticket ticket)
        {
            var dictionaryForUser = new Dictionary<string, string>();

            dictionaryForUser.Add("FirstName", user.FirstName);
            dictionaryForUser.Add("LastName", user.LastName);
            dictionaryForUser.Add("Patronymic", user.Patronymic);
            dictionaryForUser.Add("Date", ticket.OrderDate.ToString());
            dictionaryForUser.Add("DiscountName", ticket.Discount.Name);
            dictionaryForUser.Add("DiscountValue", ticket.Discount.DiscountAmount.ToString());
            dictionaryForUser.Add("Vendor", ticket.Discount.Vendor.Name);
            dictionaryForUser.Add("VendorPhone", ticket.Discount.Vendor.Phone);
            dictionaryForUser.Add("VendorEmail", ticket.Discount.Vendor.Email);
            dictionaryForUser.Add("Promocode", ticket.Discount.PromoCode);

            return dictionaryForUser;
        }
    }
}

