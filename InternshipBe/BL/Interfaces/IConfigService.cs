using BL.DTO;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IConfigService
    {
        ConfigVariablesDTO GetConfig();

        Task<ConfigVariablesDTO> ChangeConfig(ConfigModel newConfig);
    }
}
