using CodingTask.Models;
using Dapper;
using Npgsql;
using System.Data;

namespace CodingTask.Repositories
{
    public class FacilityRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<FacilityRepository> _logger;

        public FacilityRepository (IDbConnection dbConnection, ILogger<FacilityRepository> logger)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }

        public IEnumerable<Facility> GetAll()
        {
            try
            {
                return _dbConnection.Query<Facility>("SELECT * FROM faketable");
            }
            catch (PostgresException ex)
            {
                _logger.LogError($"FacilityRepository.GetAll. Message:{ex.Message}");
                throw;
            }
        }
    }
}
