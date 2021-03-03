using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IDiscountRepository discountRepository, IMapper mapper, ITicketRepository ticketRepository, IDiscountService discountService)
        {
            _userRepository = repository;
            _discountRepository = discountRepository;
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _discountService = discountService;
        }

        public async Task<UserDTO> GetUserInfoAsync(User user)
        {
            var userDTO = _mapper.Map<UserDTO>(user);

            return _mapper.Map(await _userRepository.GetUserRolesAsync(user.Id), userDTO);
        }

        public async Task<IEnumerable<DiscountDTO>> GetUserSavedDiscountsAsync(LocationModel locationModel, User user)
        {          
            var location = _userRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, locationModel.Latitude, locationModel.Longitude);

            var savedDiscounts = await _userRepository.GetSavedDiscountsAsync(user.Id, locationModel.Skip, locationModel.Take);

            var savedDiscountDTOs = _mapper.Map<DiscountDTO[]>(savedDiscounts);

            for (int i = 0; i < savedDiscountDTOs.Length; i++)
            {
                await _discountService.AddCompositePropertiesToDiscountDTOAsync(user.Id, savedDiscountDTOs[i], location);
            }

            return savedDiscountDTOs; 
        }
        
        public async Task<IEnumerable<TicketDTO>> GetUserTicketsAsync(User user, SpecifiedAmountModel specifiedAmountModel)
        {
            var tickets = await _ticketRepository.GetTicketsAsync(user.Id, specifiedAmountModel.Skip, specifiedAmountModel.Take);

            var ticketDTOs = _mapper.Map<TicketDTO[]>(tickets);

            for (int i = 0; i < ticketDTOs.Length; i++)
            {
                ticketDTOs[i].IsSavedDiscount = await _discountRepository.IsSavedDiscountAsync(ticketDTOs[i].DiscountId, user.Id);
            }

            return ticketDTOs;
        }
    }
}
