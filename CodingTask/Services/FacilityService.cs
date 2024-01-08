using CodingTask.Models;
using CodingTask.Repositories;

namespace CodingTask.Services
{
    public class FacilityService
    {
        private readonly FacilityRepository _facilityRepository;

        public FacilityService(FacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<Facility> GetAllEntities()
        {
            // Additional business logic if needed
            return _facilityRepository.GetAll();
        }
    }
}
