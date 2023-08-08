using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApi.Manager;

namespace WebApi.Controllers;

public class PostController
{
    PostManager postManager = new PostManager();
    [HttpGet]
    public async Task<IResult> GetPosts()
    {
        try
        {
            return Results.Ok(postManager.Get());
        }
        catch(Exception ex)
        {
            return Results.BadRequest(ex);
        }
        
    }
}
