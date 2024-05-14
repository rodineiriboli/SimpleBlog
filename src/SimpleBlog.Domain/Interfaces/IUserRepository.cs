using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Users?> GetUserById(Guid guid);
        Task<Users?> GetUserByEmail(string email);
        Users AddUser(Users user);
        Task<Users?> GetUserAuthorized(string email, string pass);
    }
}
