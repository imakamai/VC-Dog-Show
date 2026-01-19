using DogShow.Modules.Classes;
using DogShow.Modules.DTO.Dog;

namespace DogShow.Services.DogService
{
    public interface IDogServicecs
    {
        Task<List<DogDisplayDto>> GetAllAsync(Guid userId, UserRole role);
        Task<DogDisplayDto?> GetByIdAsync(int id, Guid userId, UserRole role);
        Task AddAsync(DogDTO dto, Guid userId);
        Task<bool> UpdateAsync(int id, DogDTO dto, Guid userId, UserRole role);
        Task<bool> DeleteAsync(int id, Guid userId, UserRole role);
    }
}
