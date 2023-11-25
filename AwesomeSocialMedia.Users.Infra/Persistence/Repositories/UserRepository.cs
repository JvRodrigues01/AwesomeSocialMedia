using AwesomeSocialMedia.Users.Core.Entities;
using AwesomeSocialMedia.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AwesomeSocialMedia.Users.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;
        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
