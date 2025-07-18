using DogShow.Modules.DTO.Dog;
using DogShow.Services.DogService;
using DogShow.Services.UsersService;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogDisplayDto>>> GetDog() 
        {
            var dogs = await  _dogServicecs.GetAllAsync();
            return Ok(dogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DogDisplayDto>> GetDog(int id) 
        {
            var dog = await _dogServicecs.GetByIdAsync(id);
            if (dog == null) return NotFound();
            return Ok(dog);
        }

        [HttpPost]
        public async Task<IActionResult> AddDog (DogDTO dto)
        {
            await _dogServicecs.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDog (int id, DogDTO dto)
        {
            var update = await _dogServicecs.UpdateAsync(id, dto);
            if (!update) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id) 
        {
            var deleted = await _dogServicecs.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
