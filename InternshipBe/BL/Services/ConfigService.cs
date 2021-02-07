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

        public ConfigVariableDTO ChangeConfig(ConfigModel newConfigs, ConfigVariable config)
        {
            var _config = _сonfigRepository.GetConfig();
            _config.Value = newConfigs.Value;
            _сonfigRepository.save
            return _mapper.Map<ConfigVariableDTO>(_config);
        }
    }
}
