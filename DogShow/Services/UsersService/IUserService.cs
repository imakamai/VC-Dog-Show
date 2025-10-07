using DogShow.Modules.Classes;
using DogShow.Modules.DTO;
using DogShow.Modules.DTO.User;

namespace DogShow.Services.UsersService
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<User>> SearchByNameAsync(string searchTerm);
        Task<string?> AuthenticateAsync(LoginRequest request, string jwtKey);
    }
}
