using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository repository,
                           IMapper mapper)
        {
            _tagRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(SpecifiedAmountModel specifiedAmountModel)
        {
            var tags = await _tagRepository.GetPopularAsync(specifiedAmountModel.Skip, specifiedAmountModel.Take);

            return _mapper.Map<TagDTO[]>(tags);
        }
    }
}
