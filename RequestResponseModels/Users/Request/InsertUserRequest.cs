using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Users.Request;

public class InsertUserRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public InsertUserRequest(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
