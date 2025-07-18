using DogShow.Modules.DTO.Dog;

namespace DogShow.Services.DogService
{
    public interface IDogServicecs
    {
        Task<List<DogDisplayDto>> GetAllAsync();
        Task<DogDisplayDto?> GetByIdAsync(int id);
        Task AddAsync(DogDTO dto);
        Task<bool> UpdateAsync(int id, DogDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
