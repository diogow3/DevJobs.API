using DevJobs.API.Data.Repositories;
using DevJobs.API.Dtos;
using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<JobVacanciesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobvacancies = _repository.GetAll;
            return Ok(jobvacancies);
        }

        // GET api/<JobVacanciesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobvacancy = _repository.GetById(id);

            if (jobvacancy == null)
                return NotFound();

            return Ok(jobvacancy);
        }

        // POST api/<JobVacanciesController>
        [HttpPost]
        public IActionResult Post(AddJobVacancyDto dto)
        {
            var jobVacancy = new JobVacancy(
                dto.Title,
                dto.Description,
                dto.Company,
                dto.isRemote,
                dto.SalaryRange);

            _repository.Add(jobVacancy);

            return CreatedAtAction(
                "GetById",
                new { id = jobVacancy.Id },
                jobVacancy);
        }

        // PUT api/<JobVacanciesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyDto dto)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(
                dto.Title,
                dto.Description);

            _repository.Update(jobVacancy);

            return NoContent();
        }

    }
}
