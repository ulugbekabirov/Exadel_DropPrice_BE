using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public class EmailBodyGenerator : IEmailBodyGenerator
    {
        private readonly IConfigRepository _сonfigRepository;
        private readonly IReplacerService _replacer;
        private readonly IMapper _mapper;

        public EmailBodyGenerator(IConfigRepository repository, IReplacerService replacer, IMapper mapper)
        {
            _сonfigRepository = repository;
            _replacer = replacer;
            _mapper = mapper;
        }

        public Dictionary<string, string> InizializeDictionary(User user, Ticket ticket)
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

        public async Task<string> GenerateMessageBodyForUserAsync(User user, Ticket ticket)
        {
            var dictionary = InizializeDictionary(user, ticket);

            var emailTemplate = await _сonfigRepository.EmailLocalization();
            var emailTemplateModel = _mapper.Map<ConfigModel>(emailTemplate).UserTemplate;

            return _replacer.Replacer(emailTemplateModel, dictionary);
        }

        public async Task<string> GenerateMessageBodyForVendorAsync(User user, Ticket ticket)
        {
            var dictionary = InizializeDictionary(user, ticket);

            var emailTemplate = await _сonfigRepository.EmailLocalization();
            var emailTemplateModel = _mapper.Map<ConfigModel>(emailTemplate).VendorTemplate;

            return _replacer.Replacer(emailTemplateModel, dictionary);
        }
    }
}

