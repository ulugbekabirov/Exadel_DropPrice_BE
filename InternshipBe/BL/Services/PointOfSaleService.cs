using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DAL.Interfaces;

namespace BL.Services
{
    public class PointOfSaleService : IPointOfSaleService
    {
        private readonly IPointOfSaleRepository _pointOfSaleRepository;
        private readonly IMapper _mapper;

        public PointOfSaleService(IPointOfSaleRepository pointOfSaleRepository, IMapper mapper)
        {
            _pointOfSaleRepository = pointOfSaleRepository;
            _mapper = mapper;
        }

        public async Task<List<PointOfSale>> GetPointOfSalesAndCreateIfNotExistAsync(PointOfSale[] pointOfSales)
        {
            var result = new List<PointOfSale>();

            var existingPointOfSales = await _pointOfSaleRepository.GetExistingPointOfSalesAsync(pointOfSales.Select(p => p.Name));

            result.AddRange(existingPointOfSales);

            var notExistingPointOfSales = pointOfSales.Where(p => !existingPointOfSales.Select(a => a.Name).Contains(p.Name));

            for (int i = 0; i < notExistingPointOfSales.Count(); i++)
            {
                var pointOfSale = notExistingPointOfSales.ElementAt(i);
                result.Add(pointOfSale);
                await _pointOfSaleRepository.CreateAsync(pointOfSale);
            }

            await _pointOfSaleRepository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<PointOfSaleDTO>> GetPointOfSalesAsync()
        {
            var pointOfdSales = await _pointOfSaleRepository.GetAllAsync();

            return _mapper.Map<PointOfSaleDTO[]>(pointOfdSales);
        }
    }
}
