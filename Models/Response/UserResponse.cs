using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response;

public class UserResponse
{
    public UserResponse(int id, string userName)
    {
        Id = id;
        UserName = userName;
    
    }

    public int Id { get; set; }
    public string UserName { get; set; }
}
