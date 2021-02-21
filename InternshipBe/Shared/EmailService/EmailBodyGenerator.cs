using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public class EmailBodyGenerator : IEmailBodyGenerator
    {
        private readonly IConfigRepository _сonfigRepository;
        private readonly IReplacerService _replacer;
        public EmailBodyGenerator(IConfigRepository repository, IReplacerService replacer)
        {
            _сonfigRepository = repository;
            _replacer = replacer;
        }

        public Dictionary<string, string> InizializeDictionary(User user, Ticket ticket)
        {
            var DictionaryForUser = new Dictionary<string, string>();

            DictionaryForUser.Add("FirstName", user.FirstName);
            DictionaryForUser.Add("LastName", user.LastName);
            DictionaryForUser.Add("Patronymic", user.Patronymic);
            DictionaryForUser.Add("Date", ticket.OrderDate.ToString());
            DictionaryForUser.Add("DiscountName", ticket.Discount.Name);
            DictionaryForUser.Add("DiscountValue", ticket.Discount.DiscountAmount.ToString());
            DictionaryForUser.Add("Vendor", ticket.Discount.Vendor.Name);
            DictionaryForUser.Add("Vendor", ticket.Discount.Vendor.Phone);
            DictionaryForUser.Add("Vendor", ticket.Discount.Vendor.Email);
            if (ticket.Discount.PromoCode != null)
            {
                DictionaryForUser.Add("Promocode", ticket.Discount.PromoCode);
            }
            else
            {
                DictionaryForUser.Add("Promocode", null);
            }

            return DictionaryForUser;
        }

        public async Task<string> GenerateVendorBody(User user, Ticket ticket)
        {
            Dictionary<string, string> dictionary = InizializeDictionary(user, ticket);

            var emailbody = await _сonfigRepository.EmailLocalization("eng");

            return _replacer.Replacer(emailbody[1], dictionary);
        }

        public async Task<string> GenerateUserBody(User user, Ticket ticket)
        {
            Dictionary<string, string> dictionary = InizializeDictionary(user, ticket);

            var emailbody = await _сonfigRepository.EmailLocalization("eng");

            return _replacer.Replacer(emailbody[0], dictionary);
        }

    }
}
