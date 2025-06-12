using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;

namespace Mission.Services.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<string> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }


        public async Task<UserResponseModel> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<UserResponseModel> UpdateUser(int id, UserResponseModel model)
        {
            return await _userRepository.UpdateUser(id, model);
        }

    }
}
