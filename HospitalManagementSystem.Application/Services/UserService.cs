﻿using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;
using System.Net.Mail;

namespace HospitalManagementSystem.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> LoginUserAsync(UserDTO userDTO);
        Task<UserDTO> GetUserByNameAsync(string username);
        Task<bool> CheckUnique(string username, string email);
    }
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;  
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.Select(e => new UserDTO(e));
        }
        public async Task<UserDTO> LoginUserAsync(UserDTO userDTO)
        {
            var user = await GetUserByNameAsync(userDTO.Username);
            if(user != null && user.Password.Equals(userDTO.Password))
            {
                await _userRepository.LoginUser(userDTO.Username);
                return user;
            } else
            {
                throw new Exception("User not found");
            }
            
        }
        public async Task<UserDTO> GetUserByNameAsync(string username)
        {
            User? user;

            try
            {
                MailAddress m = new MailAddress(username);
                user = await _userRepository.GetUserByEmailAsync(username);
            }
            catch (FormatException)
            {
                user = await _userRepository.GetUserByUsernameAsync(username);
            }
            if(user == null)
            {
                throw new Exception("User not found.");
            }
            return new UserDTO(user);
        }

        public async Task<bool> CheckUnique(string username, string email)
        {
            var name = (await _userRepository.GetUserByUsernameAsync(username))==null;
            var mail = (await _userRepository.GetUserByEmailAsync(email)) == null;
            return name && mail;
        }
    }
}
