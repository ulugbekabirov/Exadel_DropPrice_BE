using DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task ArchiveInvalidDiscount()
        {
            using IDbConnection context = new SqlConnection(_connectionString);
            await context.ExecuteAsync("EXEC ArchiveInvalidDiscount");
        }
    }
}
