using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Enums;

namespace SimpleBlog.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<SignInResultEnum> SignInResultVerify(UserViewModel userViewModel);
    }
}