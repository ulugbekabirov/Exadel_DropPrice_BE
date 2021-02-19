using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TownService : ITownService
    {
        private readonly IRepository<Town> _townRepository;
        private readonly IMapper _mapper;

        public TownService(IRepository<Town> repository, IMapper mapper)
        {
            _townRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TownDTO>> GetTownsAsync()
        {
            //CultureInfo newCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            //Thread.CurrentThread.CurrentUICulture = newCulture;
            //Thread.CurrentThread.CurrentCulture = newCulture;

            return _mapper.Map<TownDTO[]>(await _townRepository.GetAllAsync());
        }
    }
}
