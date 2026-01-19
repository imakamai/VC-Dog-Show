using DogShow.Modules.Forms;

namespace DogShow.Repository.FormRepository
{
    public interface IFormRepository
    {
        Task AddAsync(FormForDogs form);
        Task<List<FormForDogs>> GetAllAsync();
    }
}
