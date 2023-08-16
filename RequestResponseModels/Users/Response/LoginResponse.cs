using RequestResponseModels.Users.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Users.Response;

public class LoginResponse
{
    public string? Token { get; set; }
    public IEnumerable<LoginRequest> Users { get; set; }
    public LoginResponse()
    {
        Users = new List<LoginRequest>();
        Token = string.Empty;
    }
   
}
