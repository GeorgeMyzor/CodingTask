using CodingTask.Models;
using Dapper;
using System.Data;

namespace CodingTask.Repositories
{
    public class PatientRepository
    {
        private readonly IDbConnection _dbConnection;

        public PatientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<PatientResponse>> GetPatientsWithCustomInfo()
        {
            string sql = @"
                SELECT 
                    CONCAT(patients.first_name, ', ', patients.last_name) as full_name,
	            CASE WHEN patients.age < 16 
	                THEN 'A' 
		            ELSE 'B' 
	            END as category,
	                STRING_AGG (facilities.city, ', ') as visited_cities,
	                STRING_AGG (payers.city, ', ') AS payer_city
                FROM patients
                JOIN encounters ON patients.id = encounters.patient_id
                JOIN facilities ON facilities.id = encounters.facility_id
                JOIN payers ON payers.id = encounters.payer_id
                GROUP BY patients.id
                HAVING COUNT(DISTINCT payers.city) >= 2
                ORDER BY COUNT(encounters.encounter_id) ASC;";

            return await _dbConnection.QueryAsync<PatientResponse>(sql);
        }
    }
}
