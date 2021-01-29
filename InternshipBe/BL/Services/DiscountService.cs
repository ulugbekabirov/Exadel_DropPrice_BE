using System;
using System.Collections.Generic;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountRepository _repository;

        public DiscountService(DiscountRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<Discount> IDiscountService.GetClosestDiscounts(int skip, int take, double latitude, double longitude, User user)
        {
            var discounts = _repository.GetClosestDiscounts(skip, take, latitude, longitude);

            var saved = _repository.GetSavedDiscounts(user);

            return discounts;
        }
    }
}
