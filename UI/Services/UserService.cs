using Newtonsoft.Json;
using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;
using System.Net.Http;
using System.Text;

namespace UI.Services;

public class UserService
{
    private readonly HttpClient _client;
    public const string BasePath = "/api/User";

    public UserService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }
    
}
