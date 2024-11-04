
using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;
using Microsoft.EntityFrameworkCore;
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

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public List<User> GetUsersByRole(int roleId, int? skip = null, int? take = null)
        {
            return _userRepository.GetFilter(
                filter: user => user.RoleId == roleId, // Filter by role ID
                includes: query => query.Include(user => user.Role),
                skip: skip,
                take: take
            ).Item1.ToList();
        }

        public List<User> SearchUsersByRoleAndNameOrEmail(int roleId, string searchText, int? skip = null, int? take = null)
        {
            return _userRepository.GetFilter(
                filter: user => user.RoleId == roleId &&
                                (user.FirstName.Contains(searchText) ||
                                 user.LastName.Contains(searchText) ||
                                 user.Email.Contains(searchText)),
                includes: query => query.Include(user => user.Role),
                skip: skip,
                take: take
            ).Item1.ToList();
        }

        public bool UpdateUser(User user)
        {
            // Toggle status
            return _userRepository.Update(user);
        }
        public bool UpdateUserStatus(User user)
        {
            user.Status = !user.Status; // Toggle status
            return _userRepository.Update(user);
        }

        // New method for creating a user
        public bool CreateUser(User user)
        {
            return _userRepository.Create(user);
        }

        public void DetachUser(User user)
        {
            _userRepository.Detach(user);
        }

        public User? GetById(Guid id)
        {
            return _userRepository.GetById(id);
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

        public UserDTO GetByIdDTO(Guid id)
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
