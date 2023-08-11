using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Users.Response;

public class GetUserResponse
{
    public GetUserResponse(int id, string userName)
    {
        Id = id;
        UserName = userName;
    }
    public int Id { get; set; }
    public string UserName { get; set; }
}
