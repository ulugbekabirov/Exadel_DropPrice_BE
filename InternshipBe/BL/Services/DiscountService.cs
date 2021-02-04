using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;

namespace BL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository,
                                IMapper mapper)
        {
            _discountRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiscountDTO>> GetClosestAsync(SortModel sortModel, User user)
        {
            var location = new GeoCoordinate(sortModel.Latitude, sortModel.Longitude);

            var discounts = await _discountRepository.GetAllAsync();

            var discountModels = GetDiscountModel(discounts, user.Id, location);

            var discountDTOs = _mapper.Map<DiscountDTO[]>(discountModels);

            var sortedModels = SortModel.SortDiscountsBy(discountDTOs, (Sorts)Enum.Parse(typeof(Sorts), sortModel.SortBy));

            return sortedModels.Skip(sortModel.Skip).Take(sortModel.Take);
        }

        public static List<DiscountModel> GetDiscountModel(IEnumerable<Discount> discounts, int userId, GeoCoordinate location)
        {
            var discountModels = new List<DiscountModel>();

            foreach (var discount in discounts)
            {
                var discountModel = new DiscountModel()
                {
                    Discount = discount,
                    UserId = userId,
                    Location = location,
                };

                discountModels.Add(discountModel);
            }

            return discountModels;
        }

        public async Task<IEnumerable<DiscountDTO>> SearchAsync(string searchQuery)
        {
            var discounts = await _discountRepository.SearchDiscounts(searchQuery).ToListAsync();

            return _mapper.Map<DiscountDTO[]>(discounts);
        }

        public async Task<DiscountDTO> GetDiscountByIdAsync(int discountId, User user)
        {
            var discount = await _discountRepository.GetByIdAsync(discountId);

            var discountModel = _mapper.Map(user, _mapper.Map<DiscountModel>(discount));

            return _mapper.Map<DiscountDTO>(discountModel);
        }

        public async Task<SavedDTO> SaveOrUnsaveUserDisocuntAsync(int discountId, User user)
        {
            var savedDiscount = await _discountRepository.GetSavedDiscountAsync(discountId, user.Id);

            if (savedDiscount == null)
            {
                var discount = await _discountRepository.GetByIdAsync(discountId);
                savedDiscount = _discountRepository.CreateSavedDiscount(discount, user);
            }
            else
            {
                savedDiscount.IsSaved = !savedDiscount.IsSaved;
            }
            return _mapper.Map<SavedDTO>(savedDiscount);
        }
    }
}
