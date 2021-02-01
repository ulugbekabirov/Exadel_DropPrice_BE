using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository repository,
                           IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(SpecifiedAmountModel model)
        {
            var tags = await _repository.GetPopularAsync(model.Skip, model.Take);

            return _mapper.Map<Tag[], TagDTO[]>(tags.ToArray());
        }
    }
}
