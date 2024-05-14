using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModelResponse?> CreateUser(CreateUserViewModel userViewModelRequest);
        Task<UserViewModelResponse?> GetUserByEmail(string email);
        Task<UserViewModelResponse?> GetUserByEmailPassword(string email, string password);
    }
}
