using Mission.Entities;
using Mission.Entities.Models;
using Mission.Repositories;
namespace Mission.Services.IServices
{
    public interface ILoginService
    {
        ResponseResult LoginUser(LoginUserRequestModel model);

        LoginUserResponseModel UserLogin(LoginUserRequestModel model);

        Task<string> RegisterUser(RegisterUserRequestModel registerUserRequest);
        UserResponseModel LoginUserDetailById(int id);
        Task<string> UpdateUser(UserRequestModel model, string imageUploadPath);        
    }
}
