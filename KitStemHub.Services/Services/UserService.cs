using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Repositories.Repositories;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(User user)
        {
            // Check if the user already exists
            if (_userRepository.UserExists(user.Username, user.Email))
                return false;

            // Additional processing, like hashing the password, can be added here
            user.Password = HashPassword(user.Password);

            // Save user to the database
            _userRepository.AddUser(user);
            return true;
        }

        private string HashPassword(string password)
        {
            // Implement password hashing here
            return password; // Placeholder
        }

        public UserDTO GetById(Guid id)
        {
            var account = _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(account);
        }

        public int? Login(string email, string password)
        {
            var role = _userRepository.Login(email, password);
            return role;
        }
    }
}
