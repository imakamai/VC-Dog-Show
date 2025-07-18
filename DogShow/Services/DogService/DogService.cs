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

        public async Task AddAsync(DogDTO dto)
        {
            var dog = new Dog
            {
                Name = dto.Name,
                Breed = dto.Breed,
                Age = dto.Age,
                Gender = dto.Gender,
                Weight = dto.Weight,
                Size = dto.Size,
                Pedigree = dto.Pedigree //?? string.Empty; // Ensure Pedigree is not null

            };
            await _dogRepository.AddAsync(dog);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return false;
            await _dogRepository.DeleteAsync(dog);
            return true;
        }

        public async Task<List<DogDisplayDto>> GetAllAsync()
        {
            var dog = await _dogRepository.GetAllAsync();
            return dog.Select(d => new DogDisplayDto
            { 
                Id = d.Id,
                Name = d.Name,
                Breed = d.Breed,
                Age = d.Age,
                Gender = d.Gender.ToString(),
                Weight = d.Weight,
                Size = d.Size,
                
            }).ToList();
        }

        public async Task<DogDisplayDto?> GetByIdAsync(int id)
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return null;

            return new DogDisplayDto
            {
                Name = dog.Name,
                Breed = dog.Breed,
                Age = dog.Age,
                Gender = dog.Breed,
                Weight = dog.Age,
                Size = dog.Size,
                Pedigree = dog.Pedigree 
            };
        }

        public async Task<bool> UpdateAsync(int id, DogDTO dto)
        {
            var dog = await _dogRepository.GetByIdAsync(id);
            if (dog == null) return false;

            dog.Name = dto.Name;
            dog.Breed = dto.Breed;
            dog.Age = dto.Age;
            dog.Gender = dto.Gender;
            dog.Weight = dto.Weight;
            dog.Size = dto.Size;
            dog.Pedigree = dto.Pedigree;

            await _dogRepository.UpdateAsync(dog);
            return true;
        }
    }
}
