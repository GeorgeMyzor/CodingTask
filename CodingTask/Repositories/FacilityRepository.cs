using CodingTask.Models;
using Dapper;
using System.Data;

namespace CodingTask.Repositories
{
    public class FacilityRepository
    {
        private readonly IDbConnection _dbConnection;

        public FacilityRepository (IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Facility> GetAll()
        {
            return _dbConnection.Query<Facility>("SELECT * FROM facilities");
        }
    }
}
