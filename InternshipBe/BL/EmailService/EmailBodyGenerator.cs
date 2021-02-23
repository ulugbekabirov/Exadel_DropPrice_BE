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

        private static Dictionary<string, string> InizializeDictionary(User user, Ticket ticket)
        {
            var dictionaryForUser = new Dictionary<string, string>
            {
                { "FirstName", user.FirstName },
                { "LastName", user.LastName },
                { "Patronymic", user.Patronymic },
                { "Date", ticket.OrderDate.ToString() },
                { "DiscountName", ticket.Discount.Name },
                { "DiscountValue", ticket.Discount.DiscountAmount.ToString() },
                { "Vendor", ticket.Discount.Vendor.Name },
                { "VendorPhone", ticket.Discount.Vendor.Phone },
                { "VendorEmail", ticket.Discount.Vendor.Email },
                { "Promocode", ticket.Discount.PromoCode }
            };

            return dictionaryForUser;
        }
    }
}

