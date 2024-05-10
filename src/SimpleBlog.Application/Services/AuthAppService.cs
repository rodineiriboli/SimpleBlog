using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Enums;
using SimpleBlog.Domain.Interfaces;

namespace SimpleBlog.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IUserRepository _userRepository;

        public AuthAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<SignInResultEnum> SignInResultVerify(UserViewModel userViewModel)
        {
            User user = await _userRepository.GetUser(userViewModel.Email, userViewModel.Password);

            return SignInResultEnum.Success;
        }
    }
}
