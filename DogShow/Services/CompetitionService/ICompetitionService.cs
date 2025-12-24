using DogShow.Modules.Classes;

namespace DogShow.Services.CompetitionService
{
    public interface ICompetitionService
    {
        Task<List<Competition>> GetAllCompetitionsAsync();
        Task<Competition?> GetCompetitionByIdAsync(int id);
        Task<List<Competition>> GetActiveCompetitionsAsync();
        Task<Competition> AddCompetitionAsync(DogShow.Modules.DTO.Competition.CompetitionDTO competitionDto);
    }
}
