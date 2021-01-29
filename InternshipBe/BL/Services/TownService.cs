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
    public class TownService : ITownService
    {
        private readonly TownRepository _repository;

        public TownService(TownRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Town> GetTown()
        {
            return _repository.GetTowns();
        }
    }
}
