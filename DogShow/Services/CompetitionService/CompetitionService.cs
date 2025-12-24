using DogShow.Modules.Classes;
using DogShow.Repository.CompetitionRepository;

namespace DogShow.Services.CompetitionService
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _repository;

        public CompetitionService(ICompetitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Competition>> GetAllCompetitionsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Competition?> GetCompetitionByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Competition>> GetActiveCompetitionsAsync()
        {
            return await _repository.GetActiveAsync();
        }

        public async Task<Competition> AddCompetitionAsync(DogShow.Modules.DTO.Competition.CompetitionDTO competitionDto)
        {
            var competition = new Competition
            {
                Title = competitionDto.Title,
                AcquisitionDate = competitionDto.AcquisitionDate,
                AcquisitionTime = competitionDto.AcquisitionTime,
                AcquisitionPlace = competitionDto.AcquisitionPlace,
                Judges = new List<Judge>() 
            };

            await _repository.AddAsync(competition);
            return competition;
        }
    }
}
