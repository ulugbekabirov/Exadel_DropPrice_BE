using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<DiscountDTO>> GetClosestAsync(int skip, int take, double latitude, double longitude, User user)
        {
            int i = 0;

            var typle = await _repository.GetClosestDiscountsAsync(latitude, longitude);

            List<DiscountDTO> DTOs = new List<DiscountDTO>();
            
            foreach (var discounts in typle.Item1)
            {
                ++i;
                foreach (var discount in discounts)
                {
                    var dto = _mapper.Map<Discount, DiscountDTO>(discount);
                    dto.Distance = (int)typle.Item2[i];
                    DTOs.Add(dto);
                }
            }

            return DTOs.Skip(skip).Take(take);
        }
    }
}
