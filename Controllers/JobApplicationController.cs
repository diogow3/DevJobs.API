using DevJobs.API.Data.Repositories;
using DevJobs.API.Dtos;
using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;
        public JobApplicationController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        // POST api/job-vacancies/4/applications
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationDto dto)
        {
            var jobvacancy = _repository.GetById(id);

            if (jobvacancy == null)
                return NotFound();

            var application = new JobApplication(
                dto.ApplicantName,
                dto.ApplicantEmail,
                id);

            _repository.AddApplication(application);

            return NoContent();
        }
    }
}
