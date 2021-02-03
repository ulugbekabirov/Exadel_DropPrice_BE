using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<TicketDTO> GetOrCreateTicket(int discountId, User user)
        {
            var userTicket = await _ticketRepository.GetOrCreateTicketForUser(discountId, user);

            return _mapper.Map<TicketDTO>(userTicket);
        }
    }
}
