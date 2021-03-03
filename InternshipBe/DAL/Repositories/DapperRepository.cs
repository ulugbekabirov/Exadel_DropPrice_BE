using DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void ArchiveInvalidDiscount()
        {
            using IDbConnection context = new SqlConnection(_connectionString);
            context.Execute("EXEC ArchiveInvalidDiscount");
        }
    }
}
