using DogShow.Modules.DTO;
using DogShow.Modules.DTO.User;

namespace DogShow.Services.UsersService
{
    public interface IUserService
    {
        Task<List<UserDisplayDto>> GetAllAsync();
        Task<UserDisplayDto?> GetByIdAsync(int id);
        Task AddAsync(UserDTO dto);
        Task<bool> UpdateAsync(int id, UserDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> RegisterAsync(UserDTO dto);
        Task<string?> LoginAsync(UserLoginDto dto);
    }
}
