using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Interfaces;
using Shared.ViewModels;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ConfigVariableDTO>> GetConfigsAsync()
        {
            var configs = await _сonfigRepository.GetConfigsAsync();

            return _mapper.Map<ConfigVariableDTO[]>(configs);
        }

        public async Task<ConfigVariableDTO> ChangeConfigAsync(ConfigViewModel newConfig)
        {
            var config = await _сonfigRepository.GetByIdAsync(newConfig.Id);
            config.Value = newConfig.Value;

            await _сonfigRepository.SaveChangesAsync();

            return _mapper.Map<ConfigVariableDTO>(config);
        }
    }
}
