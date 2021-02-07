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

        ConfigVariableDTO IConfigService.GetConfig()
        {
            var config = _сonfigRepository.GetConfig();
            
            return _mapper.Map<ConfigVariableDTO>(config);
        }

        public async Task<ConfigVariableDTO> ChangeConfigAsync(ConfigModel newConfigs)
        {
            var config = _сonfigRepository.GetConfig();
            config.Value = newConfigs.Value;
            await _сonfigRepository.SaveChangesAsync();
            return _mapper.Map<ConfigVariableDTO>(config);
        }
    }
}
