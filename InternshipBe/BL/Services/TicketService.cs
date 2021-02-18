using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Shared.EmailService;
using Shared.Infrastructure;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IMessageBuilder _messageBuilder;
        private readonly IConfigRepository _configRepository;

        public TicketService(ITicketRepository repository, IDiscountRepository discountRepository, IMapper mapper, IEmailSender emailSender, IMessageBuilder messageBuilder, IConfigRepository configRepository)
        {
            _ticketRepository = repository;
            _discountRepository = discountRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _messageBuilder = messageBuilder;
            _configRepository = configRepository;
        }

        public async Task<TicketDTO> GetOrCreateTicketAsync(int discountId, User user)
        {
            var userTicket = await _ticketRepository.GetTicketAsync(discountId, user.Id);

            if (userTicket is null)
            {
                userTicket = await _ticketRepository.CreateTicketAsync(discountId, user);
                await _ticketRepository.SaveChangesAsync();
                await SendEmailIfAllowed(user, userTicket);
            }

            var ticketDTO = _mapper.Map<TicketDTO>(userTicket);
            ticketDTO.IsSavedDiscount = await _discountRepository.IsSavedDiscountAsync(ticketDTO.DiscountId, user.Id);

            return ticketDTO;
        }

        /*        public async Task SendEmailIfAllowed(User user, Ticket ticket)
                {
                    if (await _configRepository.IsSendingEmailsEnabled((int)ConfigIdentifiers.SendingEmailToggler))
                    {
                        var message = _messageBuilder.GenerateMessageTemplate(user, ticket);
                        await _emailSender.SendEmailAsync(message);
                    }
                }*/

        public async Task SendEmailIfAllowed(User user, Ticket ticket)
        {
            if (await _configRepository.IsSendingEmailsEnabled((int)ConfigIdentifiers.SendingEmailToggler))
            {
                //var message = _messageBuilder.GenerateMessageTemplate(user, ticket);

                var message = await _messageBuilder.GenerateMessageTemplateAsync(user, ticket);
                await _emailSender.SendEmailAsync(message);
            }
        }
    }
}
