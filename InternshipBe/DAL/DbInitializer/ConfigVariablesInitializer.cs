using DAL.DataContext;
using DAL.Entities;
using Shared.Infrastructure;
using System.Linq;

namespace DAL.DbInitializer
{
    public class ConfigVariablesInitializer
    {
        private readonly ApplicationDbContext _context;

        public ConfigVariablesInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeConfigVariables()
        {
            if (!_context.ConfigVariables.Where(p => p.Name == "Radius").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "Radius",
                    Value = "40000",
                    Description = "Radius in meters",
                    DataType = DataTypes.Number,
                });
                _context.SaveChanges();
            }

            if (!_context.ConfigVariables.Where(p => p.Name == "SendingEmailToggler").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "SendingEmailToggler",
                    Value = "false",
                    Description = "Toggler to indicate whether to send emails or not",
                    DataType = DataTypes.Boolean,
                });
                _context.SaveChanges();
            }

            if (!_context.ConfigVariables.Where(p => p.Name == "DiscountEditTimeInMinutes").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "DiscountEditTimeInMinutes",
                    Value = "1",
                    Description = "Value in minutes, which shows how long the discount can be edited",
                    DataType = DataTypes.Number,
                });
                _context.SaveChanges();
            }
        }
    }
}
