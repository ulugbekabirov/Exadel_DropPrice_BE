using BL.DTO;
using BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IConfigService
    {
        Task<IEnumerable<ConfigVariableDTO>> GetConfigs();

        Task<ConfigVariableDTO> ChangeConfigAsync(ConfigModel newConfigs, int id);
    }
}
