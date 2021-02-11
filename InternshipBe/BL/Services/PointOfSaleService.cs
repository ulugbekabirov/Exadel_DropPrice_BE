using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<List<PointOfSale>> GetPointOfSalesAndCreateIfNotExistAsync(PointOfSale[] pointOfSales)
        {
            var result = new List<PointOfSale>();

            var allPointOfSales = await _pointOfSaleRepository.GetAllAsync();

            result.AddRange(allPointOfSales.Where(p => pointOfSales.Select(p => p.Name).Contains(p.Name)));

            var notExistingPointOfSales = pointOfSales.Where(p => !allPointOfSales.Select(a => a.Name).Contains(p.Name));

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
