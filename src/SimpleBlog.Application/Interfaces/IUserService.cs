using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Application.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserViewModel?> CreateUser(CreateUserViewModel userViewModelRequest);
        Task<UserViewModelResponse?> GetUserByEmail(string email);
    }
}
