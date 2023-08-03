using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response;

public class UserResponse
{
    public UserResponse(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public UserResponse(int id, string? userName, string? password)
    {
        Id = id;
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public int Id { get; }
}
