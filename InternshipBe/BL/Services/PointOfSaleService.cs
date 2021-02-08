using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class PointOfSaleService : IPointOfSaleService
    {
        private readonly IRepository<PointOfSale> _pointOfSaleRepository;
        private readonly IMapper _mapper;
        public PointOfSaleService(IRepository<PointOfSale> pointOfSaleRepository, IMapper mapper)
        {
            _pointOfSaleRepository = pointOfSaleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PointOfSaleDTO>> GetPointOfSales()
        {
            var pointOfdSales = await _pointOfSaleRepository.GetAllAsync();

            return _mapper.Map<PointOfSaleDTO[]>(pointOfdSales);
        }
    }
}
