using DevJobs.API.Models;

namespace DevJobs.API.Data.Repositories
{
    public interface IJobVacancyRepository
    {
        List<JobVacancy> GetAll();
        JobVacancy GetById(int id);
        void Add(JobVacancy jobVacancy);
        void Update(JobVacancy jobVacancy);
        void AddApplication(JobApplication jobApplication);
    }
}
