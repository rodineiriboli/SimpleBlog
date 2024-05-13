using AutoMapper;
using SimpleBlog.Application.Helpers;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Interfaces;

namespace SimpleBlog.Application.Services
{
    public class UsersService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICryptoPassHelper _cryptoPassHelper;

        public UsersService(IMapper mapper, IUserRepository userRepository, ICryptoPassHelper cryptoPassHelper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _cryptoPassHelper = cryptoPassHelper;
        }

        public CreateUserViewModel CreateUser(CreateUserViewModel userViewModelRequest)
        {
            var userFound = _userRepository.GetUserByEmail(userViewModelRequest.Email);

            if (userFound is null)
            {
                var user = _mapper.Map<Users>(userViewModelRequest);

                user.Id = Guid.NewGuid();
                user.Active = true;
                user.SaltKey = _cryptoPassHelper.CreateSaltSaltKey();
                user.Password = _cryptoPassHelper.CreatePass(userViewModelRequest.Password, user.SaltKey);

                _userRepository.AddUser(user);
            }

            return userViewModelRequest;
        }

        public UserViewModelResponse? GetUserByEmail(string email)
        {
            var userFound = _userRepository.GetUserByEmail(email);

            if (userFound is not null)
            {
                return _mapper.Map<UserViewModelResponse>(userFound);
            }

            return null;
        }
    }
}
