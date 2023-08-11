using Newtonsoft.Json;
using RequestResponseModels.Users.Request;
using System.Net.Http;
using System.Text;

namespace UI.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    public const string BasePath = "/api/User";

    public UserService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }
    public async Task<HttpResponseMessage> CreateUser(InsertUserRequest post)
    {
        var json = JsonConvert.SerializeObject(post);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(BasePath, content);
        return response;
    }
}
