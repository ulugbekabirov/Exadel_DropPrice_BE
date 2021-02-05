using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _сonfigRepository;
        private readonly IMapper _mapper;

        public ConfigService(IConfigRepository repository, IMapper mapper)
        {
            _сonfigRepository = repository;
            _mapper = mapper;
        }

        ConfigVariablesDTO IConfigService.GetConfig()
        {
            var config = _сonfigRepository.GetConfig();
            
            return _mapper.Map<ConfigVariablesDTO>(config);
        }

        public async Task<ConfigVariablesDTO> ChangeConfig(ConfigModel newconfig)
        {
            _context.ConfigVariablesDTO.Update(newconfig);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
