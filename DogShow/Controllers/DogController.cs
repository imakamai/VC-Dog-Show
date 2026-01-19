using DogShow.Modules.DTO.Dog;
using DogShow.Services.DogService;
using DogShow.Services.UsersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DogShow.Modules.Classes;

namespace DogShow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogController : ControllerBase
    {
        private readonly IDogServicecs _dogServicecs;

        public DogController(IDogServicecs dogServicecs)
        {
            _dogServicecs = dogServicecs;
        }

        private Guid GetUserId()
        {
            var userIdString = User.FindFirstValue("Id") ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userIdString, out var userId))
            {
                return userId;
            }
            throw new UnauthorizedAccessException("User ID not found in token");
        }

        private UserRole GetUserRole()
        {
            var roleString = User.FindFirstValue(ClaimTypes.Role);
            if (Enum.TryParse<UserRole>(roleString, out var role))
            {
                return role;
            }
            return UserRole.User; // Default or throw
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogDisplayDto>>> GetDog() 
        {
            var dogs = await _dogServicecs.GetAllAsync(GetUserId(), GetUserRole());
            return Ok(dogs);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DogDisplayDto>> GetDog(int id) 
        {
            var dog = await _dogServicecs.GetByIdAsync(id, GetUserId(), GetUserRole());
            if (dog == null) return NotFound();
            return Ok(dog);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddDog (DogDTO dto)
        {
            await _dogServicecs.AddAsync(dto, GetUserId());
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDog (int id, DogDTO dto)
        {
            var update = await _dogServicecs.UpdateAsync(id, dto, GetUserId(), GetUserRole());
            if (!update) return NotFound();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id) 
        {
            var deleted = await _dogServicecs.DeleteAsync(id, GetUserId(), GetUserRole());
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
