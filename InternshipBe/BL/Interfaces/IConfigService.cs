using BL.DTO;
using Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IConfigService
    {
        Task<IEnumerable<ConfigVariableDTO>> GetConfigs();

        Task<ConfigVariableDTO> ChangeConfigAsync(ConfigViewModel newConfigs);
    }
}
