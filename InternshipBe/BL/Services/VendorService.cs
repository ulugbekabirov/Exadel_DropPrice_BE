using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IMapper _mapper;
        public VendorService(IRepository<Vendor> vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorDTO> GetVendorByIdAsync(int id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            return _mapper.Map<VendorDTO>(vendor);

        }

        public async Task<IEnumerable<VendorDTO>> GetVendorsAsync()
        {
            var vendors = await _vendorRepository.GetAllAsync();

            return _mapper.Map<VendorDTO[]>(vendors);
        }
    }
}
