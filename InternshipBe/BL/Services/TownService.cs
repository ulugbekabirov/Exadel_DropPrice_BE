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
    public class TownService : ITownService
    {
        private readonly ITownRepository _repository;
        private readonly IMapper _mapper;

        public TownService(ITownRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TownDTO>> GetTowns()
        {
            var towns = await _repository.GetAll();

            return towns.Select(_mapper.Map<Town, TownDTO>);
        }
    }
}
