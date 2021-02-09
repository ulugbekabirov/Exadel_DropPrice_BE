using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper, ITicketRepository ticketRepository)
        {
            _userRepository = repository;
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<UserDTO> GetUserInfoAsync(User user)
        {
            var userDTO = _mapper.Map<UserDTO>(user);

            return _mapper.Map(await _userRepository.GetUserRolesAsync(user.Id), userDTO);
        }

        public async Task<IEnumerable<TicketDTO>> GetUserTicketsAsync(User user)
        {
            var tickets = await _ticketRepository.GetTicketAsync(user.Id);

            return _mapper.Map<TicketDTO[]>(tickets);        
        }
    }
}
