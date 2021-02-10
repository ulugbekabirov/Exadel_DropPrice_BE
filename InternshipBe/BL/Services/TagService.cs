using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

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

        public async Task AddDiscountToTagsAsync(Discount discount, List<Tag> tags)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                tags[i].Discounts.Add(discount);
            }

            await _tagRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(SpecifiedAmountModel specifiedAmountModel)
        {
            var tags = await _tagRepository.GetPopularAsync(specifiedAmountModel.Skip, specifiedAmountModel.Take);

            return _mapper.Map<TagDTO[]>(tags);
        }

        public async Task<List<Tag>> GetTagsAndCreateIfNotExistAsync(string[] tagNames)
        {
            var result = new List<Tag>();

            var allTags = await _tagRepository.GetAllAsync();

            result.AddRange(allTags.Where(t => tagNames.Contains(t.Name)));

            var notExistingTags = tagNames.Except(allTags.Select(t => t.Name));
            
            for (int i = 0; i < notExistingTags.Count(); i++)
            {
                var tag = new Tag()
                {
                    Name = notExistingTags.ElementAt(i),
                };

                result.Add(tag);
                await _tagRepository.CreateAsync(tag);
            }

            await _tagRepository.SaveChangesAsync();

            return result;
        }
    }
}
