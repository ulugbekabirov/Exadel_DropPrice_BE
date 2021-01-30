using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        public DiscountService(IDiscountRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        IEnumerable<DiscountDTO>  IDiscountService.GetClosest(int skip, int take, double latitude, double longitude, User user)
        {
            var discounts = _repository.GetClosestDiscounts(skip, take, latitude, longitude).Select(_mapper.Map<Discount,DiscountDTO>);

            var saved = _repository.GetSavedDiscounts(user);

            return discounts;
        }
    }
}
