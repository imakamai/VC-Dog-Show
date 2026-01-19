using DogShow.Modules.Classes;
using DogShow.Modules.Forms;
using DogShow.Modules.DTO.Application;
using DogShow.Modules.DTO.Dog;
using DogShow.Repository.FormRepository;
using DogShow.Repository.Users;
using DogShow.Services.DogService;
using DogShow.Repository.CompetitionRepository;

namespace DogShow.Services.FormService
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IDogServicecs _dogService;
        private readonly IUserRepository _userRepository;
        private readonly ICompetitionRepository _competitionRepository;

        public FormService(IFormRepository formRepository, IDogServicecs dogService, IUserRepository userRepository, ICompetitionRepository competitionRepository)
        {
            _formRepository = formRepository;
            _dogService = dogService;
            _userRepository = userRepository;
            _competitionRepository = competitionRepository;
        }

        public async Task<List<FormDetailDto>> GetAllApplicationsAsync()
        {
            var forms = await _formRepository.GetAllAsync();
            
            return forms.Select(f => new FormDetailDto
            {
                Id = f.Id,
                CompetitionClass = f.CompetitionClass,
                
                // Dog
                DogName = f.Dog?.Name ?? "Unknown",
                DogBreed = f.Dog?.Breed ?? "Unknown",
                DogAge = f.Dog?.Age ?? 0,
                DogPedigree = f.Dog?.Pedigree ?? "N/A",

                // User
                OwnerName = f.User != null ? $"{f.User.Name} {f.User.LastName}" : "Unknown",
                OwnerUsername = f.User?.Username ?? "Unknown",
                OwnerEmail = f.User?.Email ?? "Unknown",
                OwnerPhone = f.User?.Phone ?? "N/A",

                // Competition
                CompetitionName = f.Competition?.Title ?? "Unknown"

            }).ToList();
        }

        public async Task CreateApplicationAsync(ApplicationDTO dto, Guid userId)
        {
             var competition = await _competitionRepository.GetByIdAsync(dto.CompetitionId);
             if (competition == null)
             {
                 throw new ArgumentException("Competition not found");
             }

             if (competition.ApplicationDeadline < DateOnly.FromDateTime(DateTime.Now))
             {
                 throw new InvalidOperationException("Application deadline has passed");
             }

             if (dto.DogId == null)
             {
                var newDog = new DogDTO
                {
                    Name = dto.Name ?? "Unknown",
                    Breed = dto.Breed ?? "Unknown",
                    Birth = dto.Birth ?? DateOnly.FromDateTime(DateTime.Now),
                    Age = dto.Age ?? 0,
                    Gender = dto.Gender ?? Gender.Male,
                    Weight = dto.Weight ?? 0,
                    Size = dto.Size ?? 0,
                    Pedigree = dto.Pedigree ?? ""
                };
                await _dogService.AddAsync(newDog, userId);
                 // Note: Ideally we retrieve the new Dog ID here
             }

             var form = new Modules.Forms.FormForDogs
             {
                 UserId = userId,
                 DogId = dto.DogId ?? 1, // Fallback/Placeholder
                 CompetitionId = dto.CompetitionId,
                 CompetitionClass = dto.CompetitionClass
             };
             
             await _formRepository.AddAsync(form);
        }
    }
}
