using CodingTask.Models;
using CodingTask.Repositories;

namespace CodingTask.Services
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientResponse>> GetPatientsWithCustomInfo()
        {
            return await _patientRepository.GetPatientsWithCustomInfo();
        }
    }
}
