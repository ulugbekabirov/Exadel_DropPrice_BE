using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository repository, IMapper mapper)
        {
            _ticketRepository = repository;
            _mapper = mapper;
        }

        public async Task<TicketDTO> GetOrCreateTicketAsync(int discountId, User user)
        {
            var userTicket = await _ticketRepository.GetTicketAsync(discountId, user.Id);

            if (userTicket is null)
            {
                userTicket = await _ticketRepository.CreateTicketAsync(discountId, user);
                await _ticketRepository.SaveChangesAsync();
            }

            return _mapper.Map<Ticket, TicketDTO>(userTicket);
        }
    }
}
