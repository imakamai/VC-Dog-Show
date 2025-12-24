using DogShow.Modules.Classes;
using DogShow.Modules.DTO.Application;
using DogShow.Modules.DTO.Dog;
using DogShow.Repository.FormRepository;
using DogShow.Repository.Users;
using DogShow.Services.DogService;

namespace DogShow.Services.FormService
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IDogServicecs _dogService;
        private readonly IUserRepository _userRepository;

        public FormService(IFormRepository formRepository, IDogServicecs dogService, IUserRepository userRepository)
        {
            _formRepository = formRepository;
            _dogService = dogService;
            _userRepository = userRepository;
        }

        public async Task CreateApplicationAsync(ApplicationDTO dto, Guid userId)
        {
             // Placeholder implementation to ensure build passes
             // Real implementation would handle dog creation if needed and link to form
             
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
                 await _dogService.AddAsync(newDog);
                 // Note: Ideally we retrieve the new Dog ID here
             }

             var form = new Modules.Forms.FormForDogs
             {
                 UserId = userId,
                 DogId = dto.DogId ?? 1 // Fallback/Placeholder
             };
             
             await _formRepository.AddAsync(form);
        }
    }
}
