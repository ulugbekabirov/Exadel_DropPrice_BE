using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class HintsService : IHintsService
    {
        private readonly IHintsRepository _searchRepository;
        private readonly IMapper _mapper;

        public HintsService(IHintsRepository repository, IMapper mapper)
        {
            _searchRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> HintsAsync(string subString, SpecifiedAmountModel specifiedAmountModel)
        {
            var hints =  await _searchRepository.SearchHintsAsync(subString, specifiedAmountModel.Take);

            return (hints);
        }
    }
}
