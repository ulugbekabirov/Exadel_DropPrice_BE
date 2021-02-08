using BL.DTO;
using BL.Models;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IConfigService
    {
        ConfigVariableDTO GetConfig();

        Task<ConfigVariableDTO> ChangeConfigAsync(ConfigModel newConfigs);
    }
}
