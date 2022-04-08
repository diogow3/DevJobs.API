using DevJobs.API.Data;
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
        private readonly DevJobsContext _context;
        public JobVacanciesController(DevJobsContext context)
        {
            _context = context;
        }

        // GET: api/<JobVacanciesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobvacancies = _context.JobVacancies;
            return Ok(jobvacancies);
        }

        // GET api/<JobVacanciesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobvacancy = _context.JobVacancies
                .Include(jv => jv.Applications)
                .SingleOrDefault(jv => jv.Id == id);

            if (jobvacancy == null)
                return NotFound();

            return Ok(jobvacancy);
        }

        // POST api/<JobVacanciesController>
        [HttpPost]
        public IActionResult Post(AddJobVacancyDto dto)
        {
            var jobvacancy = new JobVacancy(
                dto.Title,
                dto.Description,
                dto.Company,
                dto.isRemote,
                dto.SalaryRange);

            _context.JobVacancies.Add(jobvacancy);
            _context.SaveChanges();

            return CreatedAtAction(
                "GetById",
                new { id = jobvacancy.Id },
                jobvacancy);
        }

        // PUT api/<JobVacanciesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyDto dto)
        {
            var jobvacancy = _context.JobVacancies
                .SingleOrDefault(jv => jv.Id == id);

            if (jobvacancy == null)
                return NotFound();

            jobvacancy.Update(
                dto.Title,
                dto.Description);

            _context.SaveChanges();

            return NoContent();
        }

    }
}
