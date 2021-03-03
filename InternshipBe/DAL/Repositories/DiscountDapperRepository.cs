using DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountDapperRepository : IDapperRepository
    {
        private readonly string _connectionString;

        public DiscountDapperRepository(IConfiguration configuration)
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
