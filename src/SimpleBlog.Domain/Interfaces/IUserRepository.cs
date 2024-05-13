using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IUserRepository
    {
        Users? GetUserById(Guid guid);
        Users? GetUserByEmail(string email);
        Users AddUser(Users user);
    }
}
