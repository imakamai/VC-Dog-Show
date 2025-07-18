using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DogShow.Modules.Classes;
using DogShow.Modules.DTO;
using DogShow.Modules.DTO.User;
using DogShow.Repository.Users;
using Microsoft.IdentityModel.Tokens;

namespace DogShow.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<List<UserDisplayDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDisplayDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Name = u.Name,
                LastName = u.LastName,
                Email = u.Email,
                Phone = u.Phone,
                Address = u.Address,
                City = u.City,
                PostalCode = u.PostalCode,
                State = u.State
            }).ToList();
        }

        public async Task<UserDisplayDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDisplayDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                City = user.City,
                PostalCode = user.PostalCode,
                State = user.State
            };
        }

        public async Task AddAsync(UserDTO dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                PostalCode = dto.PostalCode,
                State = dto.State
            };
            await _repository.AddAsync(user);
        }

        public async Task<bool> UpdateAsync(int id, UserDTO dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return false;

            user.UserName = dto.UserName;
            user.Password = dto.Password;
            user.Name = dto.Name;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Address = dto.Address;
            user.City = dto.City;
            user.PostalCode = dto.PostalCode;
            user.State = dto.State;

            await _repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return false;
            await _repository.DeleteAsync(user);
            return true;
        }

        public async Task<bool> RegisterAsync(UserDTO dto)
        {
            var existing = (await _repository.GetAllAsync())
                .Any(u => u.UserName == dto.UserName || u.Email == dto.Email);
            if (existing) return false;

            var user = new User
            {
                UserName = dto.UserName,
                Password = dto.Password, 
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                PostalCode = dto.PostalCode,
                State = dto.State
            };
            await _repository.AddAsync(user);
            return true;
        }

        public async Task<string?> LoginAsync(UserLoginDto dto)
        {
            var user = (await _repository.GetAllAsync())
                .FirstOrDefault(u => u.UserName == dto.UserName && u.Password == dto.Password);
            if (user == null) return null;

            // Generate JWT
            var jwtKey = _configuration["Jwt:Key"] ?? "super_secret_key_123!";
            var jwtIssuer = _configuration["Jwt:Issuer"] ?? "DogShowIssuer";
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }                                                                                                                                        
    }
}

