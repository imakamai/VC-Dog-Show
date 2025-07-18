using DogShow.Modules.Classes;

namespace DogShow.Repository.DogRepository
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllAsync();
        Task<Dog?> GetByIdAsync(int id);
        Task AddAsync(Dog dog);
        Task UpdateAsync(Dog dog);
        Task DeleteAsync(Dog dog);
    }
}
