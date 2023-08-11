using RequestResponseModels.Users.Request;

namespace UI.Services
{
    public interface IUserService
    {
        Task<HttpResponseMessage> CreateUser(InsertUserRequest post);
    }
}