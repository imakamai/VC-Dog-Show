using DogShow.Modules.Classes;
using DogShow.Modules.DTO.Dog;
using DogShow.Repository.DogRepository;

namespace DogShow.Services.DogService
{
    public class DogService : IDogServicecs
    {
        private readonly IDogRepository _dogRepository;
        private readonly IConfiguration _configuration;

        public DogService(IDogRepository dogRepository, IConfiguration configuration)
        {
            _dogRepository = dogRepository;
            _configuration = configuration;
        }

        public async Task AddAsync(DogDTO dto, Guid userId)
        {
            var dog = new Dog
            {
                Name = dto.Name,
                Breed = dto.Breed,
                BirthDate = dto.Birth,
                Age = dto.Age,
                Gender = dto.Gender,
                Weight = dto.Weight,
                Size = dto.Size,
                Pedigree = dto.Pedigree ?? string.Empty,
                UserId = userId
            };
            await _dogRepository.AddAsync(dog);
        }

        public async Task<bool> DeleteAsync(int id, Guid userId, UserRole role)
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return false;

            if (role != UserRole.Admin && dog.UserId != userId) return false;

            await _dogRepository.DeleteAsync(dog);
            return true;
        }

        public async Task<List<DogDisplayDto>> GetAllAsync(Guid userId, UserRole role)
        {
            var dogs = await _dogRepository.GetAllAsync();
            
            if (role != UserRole.Admin)
            {
                dogs = dogs.Where(d => d.UserId == userId).ToList();
            }

            return dogs.Select(d => new DogDisplayDto
            {
                Id = d.Id,
                Name = d.Name,
                Breed = d.Breed,
                Birth = d.BirthDate,
                Age = d.Age ?? 0, 
                Gender = d.Gender.ToString(),
                Weight = d.Weight ?? 0, 
                Size = d.Size ?? 0,
                Pedigree = d.Pedigree ?? string.Empty
            }).ToList();
        }

        public async Task<DogDisplayDto?> GetByIdAsync(int id, Guid userId, UserRole role)
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return null;

            if (role != UserRole.Admin && dog.UserId != userId) return null;

            return new DogDisplayDto
            {
                Id = dog.Id,
                Name = dog.Name,
                Breed = dog.Breed,
                Birth = dog.BirthDate,
                Age = dog.Age ?? 0, 
                Gender = dog.Gender.ToString(),
                Weight = dog.Weight ?? 0, 
                Size = dog.Size ?? 0,     
                Pedigree = dog.Pedigree ?? string.Empty
            };
        }

        public async Task<bool> UpdateAsync(int id, DogDTO dto, Guid userId, UserRole role)
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return false;

            if (role != UserRole.Admin && dog.UserId != userId) return false;

            dog.Name = dto.Name;
            dog.Breed = dto.Breed;
            dog.BirthDate = dto.Birth;
            dog.Age = dto.Age;
            dog.Gender = dto.Gender;
            dog.Weight = dto.Weight;
            dog.Size = dto.Size;
            dog.Pedigree = dto.Pedigree ?? string.Empty;

            await _dogRepository.UpdateAsync(dog);
            return true;
        }
    }
}
