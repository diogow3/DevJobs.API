namespace DevJobs.API.Dtos
{
    public record AddJobVacancyDto(
        string Title,
        string Description,
        string Company,
        bool isRemote,
        string SalaryRange)
    {
    }
}
