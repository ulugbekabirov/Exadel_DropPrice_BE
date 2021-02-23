using BL.DTO;
using Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IConfigService
    {
        Task<IEnumerable<ConfigVariableDTO>> GetConfigsAsync();

        Task<ConfigVariableDTO> ChangeConfigAsync(ConfigViewModel newConfigs);
    }
}
