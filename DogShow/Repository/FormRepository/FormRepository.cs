using DogShow.Modules.DataContext;
using DogShow.Modules.Forms;

namespace DogShow.Repository.FormRepository
{
    public class FormRepository : IFormRepository
    {
        private readonly DataContext _context;

        public FormRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FormForDogs form)
        {
            _context.FormForDogs.Add(form);
            await _context.SaveChangesAsync();
        }
    }
}
