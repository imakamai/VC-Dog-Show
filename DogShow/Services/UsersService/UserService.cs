using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DogShow.Modules.Classes;
using DogShow.Modules.DTO;
using DogShow.Modules.DTO.User;
using DogShow.Repository.Users;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

namespace DogShow.Services.UsersService
{
    public class UserService : IUserService
    {
        // Dependency on the user repository
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Get user by ID
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // Get user by email
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        // Get user by username
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        // Get all users
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Add a new user
        public async Task AddAsync(User user)
        {
            // Check for existing username or email
            var existingByUsername = await _userRepository.GetByUsernameAsync(user.Username);
            if (existingByUsername != null)
                throw new InvalidOperationException("Username already exists.");

            var existingByEmail = await _userRepository.GetByEmailAsync(user.Email);
            if (existingByEmail != null)
                throw new InvalidOperationException("Email already exists.");

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        // Update an existing user
        public async Task UpdateAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        // Delete a user by ID
        public async Task DeleteAsync(Guid id)
        {
            // Retrieve the user to ensure they exist before deletion
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                await _userRepository.SaveChangesAsync();
            }
        }

        // Search users by name
        // NOTE: This method is currently not used anywhere in the project.
        public async Task<IEnumerable<User>> SearchByNameAsync(string searchTerm)
        {
            return await _userRepository.SearchByNameAsync(searchTerm);
        }

        // Authenticate user and generate JWT token
        public async Task<string?> AuthenticateAsync(LoginRequest request, string jwtKey)
        {
            // Retrieve the user by username
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
                return null;

            // Verify the password using BCrypt
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                 }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

