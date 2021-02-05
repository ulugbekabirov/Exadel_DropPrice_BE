using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ConfigRepository : Repository<ConfigVariables>, IConfigRepository
    {
        public ConfigRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ConfigVariables GetConfig()
        {
            var config = _context.ConfigVariables.SingleOrDefault();

            return config;
        }

        public async Task<ConfigVariables> ChangeConfig(ConfigModel newconfig)
        {
            _context.ConfigVariables.Update(newconfig);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}