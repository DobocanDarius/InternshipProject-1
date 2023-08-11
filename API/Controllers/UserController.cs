using API.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Users.Request;
using RequestResponseModels.Users.Response;
using System.Security.Cryptography.X509Certificates;
using WebApi.Manager;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetUserResponse>>> GetUsers()
    {
        try
        {
            var users = await _userManager.GetUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    [HttpPost ("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest newUser)
    {
        try
        {
            var loggedIn = await _userManager.LogIn(newUser);
            if (loggedIn == null)
            {
                return Unauthorized();
            }

            return Ok(loggedIn);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertUser(InsertUserRequest newUser)
    {
        try
        {
            await _userManager.InsertUser(newUser);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(InsertUserRequest newUser, int id)
    {
        try
        {
            await _userManager.UpdateUser(newUser, id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            await _userManager.DeleteUser(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}
