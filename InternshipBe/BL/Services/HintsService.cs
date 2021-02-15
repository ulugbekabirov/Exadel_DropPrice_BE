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

        public HintsService(IHintsRepository repository)
        {
            _searchRepository = repository;
        }

        public async Task<IEnumerable<string>> HintsAsync(string subString, SpecifiedAmountModel specifiedAmountModel)
        {
            var hints =  await _searchRepository.SearchHintsAsync(subString, specifiedAmountModel.Take);

            return (hints);
        }
    }
}
