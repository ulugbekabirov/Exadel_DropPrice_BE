using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TagService : ITagService
    {
        private readonly TagRepository _repository;

        public TagService(TagRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Tag> GetSpecifiedTags(int skip, int take)
        {
            return _repository.GetPopularTags(skip, take);
        }
    }
}
