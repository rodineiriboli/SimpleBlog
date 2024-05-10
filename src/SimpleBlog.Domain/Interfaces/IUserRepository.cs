using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email, string password);
    }
}
