﻿using AutoMapper;
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

        public async Task<UserViewModelResponse?> CreateUser(CreateUserViewModel userViewModelRequest)
        {
            var userFound = await _userRepository.GetUserByEmail(userViewModelRequest.Email);

            if (userFound is not null)
            {
                throw new Exception("Este e-mail já está sendo utilizado");
            }
            var user = _mapper.Map<Users>(userViewModelRequest);

            user.Id = Guid.NewGuid();
            user.Active = true;
            user.SaltKey = _cryptoPassHelper.CreateSaltSaltKey();
            user.Password = _cryptoPassHelper.CreatePass(userViewModelRequest.Password, user.SaltKey);

            _userRepository.AddUser(user);

            return _mapper.Map<UserViewModelResponse>(user);
        }

        public async Task<UserViewModelResponse?> GetUserByEmail(string email)
        {
            var userFound = await _userRepository.GetUserByEmail(email);

            if (userFound is not null)
            {
                return _mapper.Map<UserViewModelResponse>(userFound);
            }
            return null;
        }

        public async Task<UserViewModelResponse?> GetUserByEmailPassword(string email, string password)
        {
            var userFound = await _userRepository.GetUserByEmail(email);

            if (userFound is not null)
            {
                var pass = _cryptoPassHelper.CreatePass(password, userFound.SaltKey);

                var userFoundauthorizedLogin = await _userRepository.GetUserAuthorized(email, pass);

                return _mapper.Map<UserViewModelResponse?>(userFoundauthorizedLogin);
            }
            return null;
        }
    }
}
