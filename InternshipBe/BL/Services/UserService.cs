using AutoMapper;
using BL.DTO;
using BL.Extensions;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<DiscountDTO>> GetUserSavedDiscountsAsync(LocationModel locationModel, User user)
        {
            var savedDiscounts = await _userRepository.GetSavedDiscountsAsync(user.Id, locationModel.Skip, locationModel.Take);

            var location = _userRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, locationModel.Latitude, locationModel.Longitude);

            var discountModels = savedDiscounts.Select(d => d.CreateDiscountModel(location, user.Id));

            var savedDiscountDTOs = _mapper.Map<DiscountDTO[]>(discountModels);

            return savedDiscountDTOs; 
        }
        
        public async Task<IEnumerable<TicketDTO>> GetUserTicketsAsync(User user, SpecifiedAmountModel specifiedAmountModel)
        {
            var tickets = await _ticketRepository.GetTicketsAsync(user.Id, specifiedAmountModel.Skip, specifiedAmountModel.Take);

            return _mapper.Map<TicketDTO[]>(tickets);
        }
    }
}
