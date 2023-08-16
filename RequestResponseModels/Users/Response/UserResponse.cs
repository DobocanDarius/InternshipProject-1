using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestResponseModels.Users.Request;

namespace RequestResponseModels.Users.Response;

public class UserResponse
{
    public IEnumerable<UserRequest> Users { get; set; }
    public UserResponse()
    {
        Users = new List<UserRequest>();
    }
}
