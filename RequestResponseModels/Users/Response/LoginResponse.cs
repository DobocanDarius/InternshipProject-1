using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Users.Response;

public class LoginResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; }

    public LoginResponse()
    {
    }
    public LoginResponse(int id, string userName, string password, string? token)
    {
        Id = id;
        UserName = userName;
        Password = password;
        Token = token;
    }
}
