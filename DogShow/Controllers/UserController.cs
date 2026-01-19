using System.Security.Claims;
using DogShow.Modules.Classes;
using DogShow.Modules.DTO;
using DogShow.Modules.DTO.User;
using DogShow.Services.UsersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogShow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Get user by ID
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // Get user by email
        [HttpGet("by-email")]
        public async Task<ActionResult<User>> GetByEmail([FromQuery] string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // Get user by username
        [HttpGet("by-username")]
        public async Task<ActionResult<User>> GetByUsername([FromQuery] string username)
        {
            var user = await _userService.GetByUsernameAsync(username);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // Get all users (admin or for demo; usually not public)
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // Register a new user
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = UserRole.User
            };

            try
            {
                await _userService.AddAsync(user);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected server error occurred.");
            }
        }

        // Update an existing user
        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateUserRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var currentUserId = Guid.Parse(userIdClaim.Value);
            var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null) return NotFound();

            // Field-level security based on role
            if (currentUserRole == "Admin" || currentUserRole == "Manager")
            {
                // Admin/Manager can ONLY edit identity info
                existingUser.Name = request.Name;
                existingUser.LastName = request.LastName;
                if (!string.IsNullOrEmpty(request.Email)) existingUser.Email = request.Email;
                if (!string.IsNullOrEmpty(request.Username)) existingUser.Username = request.Username;
                // They do NOT update address/phone in this simplified requirement
            }
            else
            {
                // Standard User can edit personal info
                existingUser.Name = request.Name;
                existingUser.LastName = request.LastName;
                existingUser.Phone = request.Phone;
                existingUser.Address = request.Address;
                existingUser.City = request.City;
                existingUser.PostalCode = request.PostalCode;
                existingUser.State = request.State;
                // They do NOT update Email/Username
            }

            await _userService.UpdateAsync(existingUser);
            return NoContent();
        }

        // Delete a user by ID
        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var currentUserId = Guid.Parse(userIdClaim.Value);
            var currentUserRole = User.FindFirst(ClaimTypes.Role)?.Value;

            // Allow if Admin OR if deleting self
            if (currentUserRole != "Admin" && currentUserId != id)
            {
                return Forbid();
            }

            await _userService.DeleteAsync(id);
            return NoContent();
        }

        // Search users by name or surname
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<User>>> SearchByName([FromQuery] string term)
        {
            var users = await _userService.SearchByNameAsync(term);
            return Ok(users);
        }

        // Authenticate user and return JWT token
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request, [FromServices] IConfiguration config)
        {
            var jwtKey = config["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                return StatusCode(500, "Internal Server Error: JWT Key is not configured.");
            }
            var token = await _userService.AuthenticateAsync(request, jwtKey);
            if (token == null)
                return Unauthorized("Invalid credentials");
            return Ok(token);
        }

        // Get the profile of the currently authenticated user
        [Authorize]
        [HttpGet("my")]
        public async Task<ActionResult<User>> GetMyProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
