using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Shared.EmailService;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IMessageBuilder _messageBuilder;
        private readonly IConfigRepository _configRepository;

        public TicketService(ITicketRepository repository, IMapper mapper, IEmailSender emailSender, IMessageBuilder messageBuilder, IConfigRepository configRepository)
        {
            _ticketRepository = repository;
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
                await SendEmailIfAllowed(user, userTicket);
                await _ticketRepository.SaveChangesAsync();
            }

            return _mapper.Map<Ticket, TicketDTO>(userTicket);
        }

        public async Task SendEmailIfAllowed(User user, Ticket ticket)
        {
            if (await _configRepository.IsSendingEmailsEnabled())
            {
                var message = _messageBuilder.GenerateMessageTemplate(user, ticket);
                await _emailSender.SendEmailAsync(message);
            }
        }
    }
}
