using AutoMapper;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Enums;
using SimpleBlog.Domain.Interfaces;
using System.Text;
using SimpleBlog.Application.Helpers;

namespace SimpleBlog.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AuthAppService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<Users> SignInResultVerify(CreateUserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }

        //public async Task<Users> SignInResultVerify(UserViewModel userViewModel)
        //{




        //    //var user = await _userRepository.GetUserAsync(userViewModel.Email, userViewModel.Password);

        //    //var password = Helpers.CreatePass(userViewModel.Password);
        //    //var saltKey = CreateSaltSaltKey();

        //    //var user = new Users(Guid.NewGuid(), userViewModel.Name, userViewModel.Email, password, saltKey);

        //    //var userInclud = _mapper.Map<Users>(userViewModel);

        //    //var userResponse = _userRepository.AddUser(userInclud);


        //    //return userResponse;
        //    //return SignInResultEnum.Success;
        //    return new
        //}
    }
}
