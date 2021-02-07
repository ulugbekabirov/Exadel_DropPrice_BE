using BL.DTO;
using BL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IConfigService
    {
        ConfigVariableDTO GetConfig();

        ConfigVariableDTO ChangeConfig(ConfigModel newConfigs, ConfigVariable config);
    }
}
