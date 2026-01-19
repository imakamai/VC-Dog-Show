using DogShow.Modules.DataContext;
using DogShow.Modules.Forms;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<FormForDogs>> GetAllAsync()
        {
            var query = from f in _context.FormForDogs
                            .Include(f => f.Dog)
                            .Include(f => f.User)
                            .Include(f => f.Competition)
                            .AsNoTracking()
                        select f;
            return await query.ToListAsync();
        }
    }
}
