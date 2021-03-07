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

            if (!_context.ConfigVariables.Where(p => p.Name == "Sending email toggler").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "Sending email toggler",
                    Value = "false",
                    Description = "Toggler to indicate whether to send emails or not",
                    DataType = DataTypes.Boolean,
                });
                _context.SaveChanges();
            }

            if (!_context.ConfigVariables.Where(p => p.Name == "Discount edit time in minutes").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "Discount edit time in minutes",
                    Value = "1",
                    Description = "Value in minutes, which shows how long the discount can be edited",
                    DataType = DataTypes.Number,
                });
                _context.SaveChanges();
            }
        }
    }
}
