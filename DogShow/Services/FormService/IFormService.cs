using DogShow.Modules.DTO.Application;
using DogShow.Modules.Forms;

namespace DogShow.Services.FormService
{
    public interface IFormService
    {
        Task CreateApplicationAsync(ApplicationDTO dto, Guid userId);
        Task<List<FormDetailDto>> GetAllApplicationsAsync();
    }
}
