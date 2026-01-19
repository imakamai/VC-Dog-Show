using DogShow.Modules.Classes;
using DogShow.Modules.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DogShow.Repository.CompetitionRepository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly DataContext _context;

        public CompetitionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Competition>> GetAllAsync()
        {
            var query = from c in _context.Competitions.Include(c => c.Judges).AsNoTracking()
                        select c;
            return await query.ToListAsync();
        }

        public async Task<Competition?> GetByIdAsync(int id)
        {
            var query = from c in _context.Competitions.Include(c => c.Judges).AsNoTracking()
                        where c.Id == id
                        select c;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Competition>> GetActiveAsync()
        {
            // Assuming "Active" means future date or today.
            // Using DateOnly.FromDateTime(DateTime.Now) for comparison.
            var today = DateOnly.FromDateTime(DateTime.Now);

            var query = from c in _context.Competitions.Include(c => c.Judges).AsNoTracking()
                        where c.AcquisitionDate >= today
                        orderby c.AcquisitionDate
                        select c;

            return await query.ToListAsync();
        }

        public async Task AddAsync(Competition competition)
        {
            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();
        }
    }
}
