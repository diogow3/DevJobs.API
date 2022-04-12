using DevJobs.API.Data.Repositories;
using DevJobs.API.Dtos;
using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
            var jobvacancies = _repository.GetAll();
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
        /// <summary>
        /// Cadastrar uma vaga de emprego
        /// </summary>
        /// <remarks>
        /// {
        ///  "title": "string",
        ///  "description": "string",
        ///  "company": "string",
        ///  "isRemote": true,
        ///  "salaryRange": "string"
        /// }
        /// </remarks>
        /// <param name="dto">Dados da vaga</param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        public IActionResult Post(AddJobVacancyDto dto)
        {
            Log.Information("POST JobVacancy chamado");
            var jobVacancy = new JobVacancy(
                dto.Title,
                dto.Description,
                dto.Company,
                dto.isRemote,
                dto.SalaryRange);

            if (jobVacancy.Title.Length > 30)
            {
                return BadRequest("Titulo precisa ser menor que 30");
            }

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
