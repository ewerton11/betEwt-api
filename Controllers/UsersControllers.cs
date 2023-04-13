using Microsoft.AspNetCore.Mvc;
using MyDbContextApi.Data;
using UserApi.Models;
using UserApi.Service;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> PostUsersModels([FromBody] UserModels userModels, string password)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (userModels.User == null)
        {
            return BadRequest("User is null");
        }

        // Fazer a verificação se a senha é nula ou se nao esta entre 3 a 30 caracteres
        // E tratar essas pocibilidades

        var existingUser = await _userService.GetUserByUserAsync(userModels.User);

        if(existingUser != null)
        {
            return BadRequest("The username is already in use.");
        }

        await _userService.CreateUserAsync(userModels, password);

        return CreatedAtAction("GetUsersModels", new { id = userModels.Id }, userModels);

    }
}