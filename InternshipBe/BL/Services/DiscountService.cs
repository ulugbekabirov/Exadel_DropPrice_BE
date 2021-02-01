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
using DAL.Repositories;
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

        public async Task<IEnumerable<DiscountDTO>> GetClosestAsync(LocationModel model, User user)
        {
            var discounts = await _discountRepository.GetAllAsync();

            return _mapper.Map<DiscountDTO[]>((discounts, user.Id, new GeoCoordinate(model.Latitude, model.Longitude)));

            //discounts = _mapper.Map<DiscountDTO>(discounts);
        }
    }
}
