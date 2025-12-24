using DogShow.Modules.Classes;

namespace DogShow.Repository.CompetitionRepository
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetAllAsync();
        Task<Competition?> GetByIdAsync(int id);
        Task<List<Competition>> GetActiveAsync();
        Task AddAsync(Competition competition);
    }
}
