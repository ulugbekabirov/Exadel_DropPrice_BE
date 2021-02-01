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

        public async Task<IEnumerable<DiscountDTO>> GetClosestAsync(LocationModel model, User user)
        {
            int i = 0;

            var tuple = _repository.GetClosestDiscounts(model.latitude, model.longitude);

            var DTOs = new List<DiscountDTO>();
            
            foreach (var discounts in tuple.Item1)
            {
                ++i;
                foreach (var discount in discounts)
                {
                    var dto = _mapper.Map<Discount, DiscountDTO>(discount);
                    dto.Distance = (int)tuple.Item2[i];
                    DTOs.Add(dto);
                }
            }

            return DTOs.Skip(model.skip).Take(model.take);
        }
    }
}
