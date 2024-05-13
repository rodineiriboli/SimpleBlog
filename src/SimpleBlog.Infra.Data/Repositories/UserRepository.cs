using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infra.Data.Context;

namespace SimpleBlog.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimpleBlogConext _context;

        public UserRepository(SimpleBlogConext context)
        {
            _context = context;
        }

        public async Task<Users?> GetUserById(Guid guid)
        {
            var user = _context.Find<Users>(guid);

            return user;
        }
        public async Task<Users?> GetUserByEmail(string email)
        {
            var user = await _context.Users
                        .Where(u => u.Email.Equals(email))
                        .FirstOrDefaultAsync();

            return user;
        }

        public Users AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }

    }
}
