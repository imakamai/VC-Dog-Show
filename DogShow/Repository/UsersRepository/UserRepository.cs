using DogShow.Modules.Classes;
using DogShow.Modules.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DogShow.Repository.Users
{
    public class UserRepository : IUserRepository 
    {
        // Database context instance
        private readonly DataContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(DataContext context)
        {
            _context = context;
            _users = context.Set<User>();
        }

        // Get user by ID
        public async Task<User?> GetByIdAsync(Guid id)
        {
            var query = from u in _users.AsNoTracking()
                        where u.Id == id
                        select u;
            return await query.FirstOrDefaultAsync();
        }

        // Get user by email
        public async Task<User?> GetByEmailAsync(string email)
        {
            var query = from u in _users.AsNoTracking()
                        where u.Email == email
                        select u;
            return await query.FirstOrDefaultAsync();
        }

        // Get user by username
        public async Task<User?> GetByUsernameAsync(string username)
        {
            var query = from u in _users.AsNoTracking()
                        where u.Username == username
                        select u;
            return await query.FirstOrDefaultAsync();
        }

        // Get all users from the database
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = from u in _users.AsNoTracking()
                        select u;
            return await query.ToListAsync();
        }

        // Add a new user to the database
        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
        }

        // Update an existing user
        public void Update(User user)
        {
            _users.Update(user);
        }

        // Remove a user from the database
        public void Delete(User user)
        {
            _users.Remove(user);
        }

        // Save changes to the database
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Search users by name or surname containing the search term (case-insensitive)
        public async Task<IEnumerable<User>> SearchByNameAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Enumerable.Empty<User>();

            var normalized = searchTerm.Trim().ToLower();
            
            var query = from u in _users.AsNoTracking()
                        where u.Name.ToLower().Contains(normalized) || u.LastName.ToLower().Contains(normalized)
                        select u;

            return await query.ToListAsync();
        }
    }
}
