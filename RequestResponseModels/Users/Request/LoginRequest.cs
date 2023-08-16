using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Users.Request;

public class LoginRequest
{
    public LoginRequest(int id, string userName, string password)
    {
        Id = id;
        UserName = userName;
        Password = password;
    }
    public LoginRequest()
    {

    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
