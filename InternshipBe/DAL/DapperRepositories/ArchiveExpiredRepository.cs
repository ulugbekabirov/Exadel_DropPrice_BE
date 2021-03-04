using DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class ArchiveExpiredRepository : IArchiveExpiredRepository
    {
        private readonly string _connectionString;

        public ArchiveExpiredRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task ArchiveExpiredDiscountAsync()
        {
            using IDbConnection context = new SqlConnection(_connectionString);
            await context.ExecuteAsync($"EXEC ArchiveExpiredDiscount @dateNow = '{DateTime.UtcNow}'");
        }
    }
}
