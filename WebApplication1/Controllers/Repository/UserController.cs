using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Request;
using Models.Response;

namespace WebApplication1.Controllers.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LocalDbContext localDbContext;

        public UserController(LocalDbContext localDbContext)
        {
            this.localDbContext = localDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            try
            {
                var users = await localDbContext.Users.ToListAsync();
                List<UserResponse> userResponse = new List<UserResponse>();
                foreach (var user in users)
                {
                    userResponse.Add(new UserResponse(user.Id, user.UserName, user.Password));
                }
                return userResponse;
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUsers(int id)
        {
            try
            {
                var user = await localDbContext.Users.FindAsync(id);
                if (user == null)
                {
                    return BadRequest("User does not exist");
                }
                return new UserResponse(user.Id, user.UserName, user.Password);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
        [HttpPost]
        public async Task<ActionResult<UserResponse>> InsertUser(UserRequest newUser)
        {
            try
            {
                var user = new User
                {

                    UserName = newUser.UserName,
                    Password = newUser.Password
                };

                localDbContext.Users.Add(user);
                await localDbContext.SaveChangesAsync();

                var userResponse = new UserResponse(user.Id, user.UserName, user.Password);

                return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, userResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUsers(UserRequest updateUser, int id)
        {
            try
            {
                var dbUser = await localDbContext.Users.FindAsync(id);
                if (dbUser == null)
                {
                    return BadRequest("User does not exist");
                }

                dbUser.UserName = updateUser.UserName;
                dbUser.Password = updateUser.Password;

                await localDbContext.SaveChangesAsync();

                return Ok(dbUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            try
            {
                var dbUser = await localDbContext.Users.FindAsync(id);
                if (dbUser == null)
                {
                    return BadRequest("User does not exist");
                }

                localDbContext.Users.Remove(dbUser);
                await localDbContext.SaveChangesAsync();

                return StatusCode(200, $"User deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

}
