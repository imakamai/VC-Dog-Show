using DogShow.Modules.DTO.Application;
using DogShow.Services.FormService;
using Microsoft.AspNetCore.Authorization;
using DogShow.Modules.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DogShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IFormService _formService;

        public ApplicationController(IFormService formService)
        {
            _formService = formService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationDTO dto)
        {
            // Extract User ID from Claims
            var userIdString = User.FindFirstValue("Id"); // Assuming claim name is "Id" as per common JWT setup, or check Program.cs/Token setup
            // If "Id" claim is used for Guid:
            if (!Guid.TryParse(userIdString, out var userId))
            {
                 // Fallback or error if ID logic differs
                 // Often "sub" or "nameid" is used. Let's try nameid if Id fails or simple parsing.
                 var nameId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 if (!Guid.TryParse(nameId, out userId))
                 {
                     return Unauthorized("User ID not found in token");
                 }
            }

            await _formService.CreateApplicationAsync(dto, userId);
            return Ok();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpGet]
        public async Task<ActionResult<List<DogShow.Modules.Forms.FormDetailDto>>> GetAll()
        {
            var applications = await _formService.GetAllApplicationsAsync();
            return Ok(applications);
        }
    }
}
