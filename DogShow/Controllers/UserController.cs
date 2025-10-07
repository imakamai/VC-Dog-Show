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
            };

            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // Update an existing user
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest("ID mismatch.");

            await _userService.UpdateAsync(user);
            return NoContent();
        }

        // Delete a user by ID
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
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
