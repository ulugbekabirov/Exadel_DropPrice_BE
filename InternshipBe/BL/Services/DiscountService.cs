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

            var discountDTOs =  _mapper.Map<DiscountDTO[]>(discountModels);

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
    }
}
