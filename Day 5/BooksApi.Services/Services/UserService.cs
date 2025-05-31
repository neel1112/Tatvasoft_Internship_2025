using BooksApi.Entities.Entities;
using BooksApi.Entities.Migrations;
using BooksApi.Entities.Repositories.Interface;
using BooksApi.Models;
using BooksApi.Services.Services.Interface;

namespace BooksApi.Services
{
    // For CRUD on books
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // To Add User
        public async Task AddUser(User user)
        {
            await this._userRepository.AddUser(user);
        }

        public User? Login(string username, string password)
        {
            return this._userRepository.Login(username, password);
        }
    }
}
