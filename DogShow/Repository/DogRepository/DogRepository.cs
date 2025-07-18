using DogShow.Modules.Classes;
using DogShow.Modules.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DogShow.Repository.DogRepository
{
    public class DogRepository : IDogRepository
    {
        private readonly DataContext _context;

        public DogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Dog dog)
        {
            _context.Add(dog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Dog dog)
        {
            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dog>> GetAllAsync()
        {
            return await _context.Dogs.ToListAsync();
        }

        public async Task<Dog?> GetByIdAsync(int id)
        {
            return await _context.Dogs.FirstOrDefaultAsync(d => d.Id == id);

            //return await _context.Dogs.FirstAsync(id);
        }

        public async Task UpdateAsync(Dog dog)
        {
            _context.Dogs.Update(dog);
            await _context.SaveChangesAsync();
        }
    }
}
