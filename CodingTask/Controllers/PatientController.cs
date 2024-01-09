using CodingTask.Models;
using CodingTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodingTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly PatientService _patientService;
        private readonly FacilityService _facilityService;

        public PatientController(ILogger<PatientController> logger, PatientService patientService, FacilityService facilityService)
        {
            _logger = logger;
            _patientService = patientService;
            _facilityService = facilityService;
        }

        [HttpGet]
        [Route("GetPatientsWithCustomInfo")]
        public async Task<ActionResult<IEnumerable<PatientResponse>>> GetPatientsWithCustomInfo()
        {
            var facilities = await _patientService.GetPatientsWithCustomInfo();

            return Ok(facilities);
        }

        [HttpGet]
        [Route("GetTest")]
        public ActionResult GetTest()
        {
            _facilityService.GetAllEntities();
            return Ok();
        }
    }
}
