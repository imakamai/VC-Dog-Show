using DogShow.Modules.DTO.Application;

namespace DogShow.Services.FormService
{
    public interface IFormService
    {
        Task CreateApplicationAsync(ApplicationDTO dto, Guid userId);
    }
}
