using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Service;

namespace UsersApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersControllers : ControllerBase
{
    private readonly UserService _userService;

    public UsersControllers(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserModels>> CreateUser([FromBody] UserModels userModels)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (userModels.User == null)
        {
            return BadRequest("User is null");
        }

        var existingUser = await _userService.GetUserByUserAsync(userModels.User);

        if(existingUser != null)
        {
            return Unauthorized("The username is already in use.");
        }

        await _userService.CreateUserAsync(userModels);

        return CreatedAtAction(nameof(CreateUser), new { id = userModels.Id }, "User successfully created!");
    }
}