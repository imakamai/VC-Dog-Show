using DogShow.Modules.Classes;
using DogShow.Services.CompetitionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _service;

        public CompetitionController(ICompetitionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Competition>>> GetAll()
        {
            var competitions = await _service.GetAllCompetitionsAsync();
            return Ok(competitions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetById(int id)
        {
            var competition = await _service.GetCompetitionByIdAsync(id);
            if (competition == null)
            {
                return NotFound();
            }
            return Ok(competition);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<Competition>>> GetActive()
        {
            var activeCompetitions = await _service.GetActiveCompetitionsAsync();
            return Ok(activeCompetitions);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public async Task<ActionResult<Competition>> Create([FromBody] DogShow.Modules.DTO.Competition.CompetitionDTO competitionDto)
        {
            var createdCompetition = await _service.AddCompetitionAsync(competitionDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCompetition.Id }, createdCompetition);
        }
    }
}
