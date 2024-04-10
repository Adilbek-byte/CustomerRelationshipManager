using Customer_Relationship_Management.Contracts.User;
using Customer_Relationship_Management.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Customer_Relationship_Management.Controllers;

[ApiController]
[Route("api/user")]
public class UserController: ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService userService)
    {
        _service = userService;
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost("auth/register")]
    public async Task<IActionResult> RegisterUser(UserRegisterDto request)
    {
        var result = await _service.SignUpAsync(request);

        return result == null ? Ok(result) : BadRequest("something wrong with registration");
    }


    [Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _service.GetAllUsersAsync();

        return Ok(result);
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetUserInfo(int id)
    {
        var result = await _service.GetDataUserAsync(id);

        return Ok(result);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPatch("{id}/block")]
    public async Task<IActionResult> BlockUser(long id)
    {
        var result = await _service.BlockUserAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }


    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut("{id}/role")]
    public async Task<IActionResult> ChangeUserRole(long id, RoleEnum newRole)
    {
        var result = await _service.ChangeUserRoleAsync(id, newRole);
        if (result == null)
            return NotFound();
        return Ok(result); 
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var result = await _service.DeleteUserByIdAsync(id);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }


}


