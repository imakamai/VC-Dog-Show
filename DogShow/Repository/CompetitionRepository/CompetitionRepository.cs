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
            return await _context.Competitions.Include(c => c.Judges).ToListAsync();
        }

        public async Task<Competition?> GetByIdAsync(int id)
        {
            return await _context.Competitions.Include(c => c.Judges).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Competition>> GetActiveAsync()
        {
            // Assuming "Active" means future date or today.
            // Using DateOnly.FromDateTime(DateTime.Now) for comparison.
            var today = DateOnly.FromDateTime(DateTime.Now);
            return await _context.Competitions
                .Include(c => c.Judges)
                .Where(c => c.AcquisitionDate >= today)
                .OrderBy(c => c.AcquisitionDate)
                .ToListAsync();
        }

        public async Task AddAsync(Competition competition)
        {
            _context.Competitions.Add(competition);
            await _context.SaveChangesAsync();
        }
    }
}
