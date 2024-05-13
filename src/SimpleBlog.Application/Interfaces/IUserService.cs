using SimpleBlog.Application.ViewModels;

namespace SimpleBlog.Application.Interfaces
{
    public interface IUserService
    {
        CreateUserViewModel CreateUser(CreateUserViewModel userViewModelRequest);
        UserViewModelResponse? GetUserByEmail(string email);
    }
}
