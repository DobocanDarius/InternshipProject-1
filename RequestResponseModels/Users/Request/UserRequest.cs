using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Users.Request;

public class UserRequest
{
    public UserRequest(int id, string userName)
    {
        Id = id;
        UserName = userName;
    }
    public int Id { get; set; }
    public string UserName { get; set; }
}
