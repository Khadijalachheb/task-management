using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;
[Route("api/users/{userId}/tasks")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{userId}")]
    public ActionResult<User> GetUserById(int userId)
    {
        var user = _userService.GetUserById(userId);
        if (user is null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> AddUser(User user)
    {
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, User updatedUser)
    {
        var existingUser = _userService.GetUserById(userId);
        if (existingUser is null)
        {
            return NotFound();
        }
        updatedUser.UserId = userId;
        _userService.UpdateUser(updatedUser);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        var existingUser = _userService.GetUserById(userId);
        if (existingUser is null)
        {
            return NotFound();
        }
        _userService.DeleteUser(userId);
        return NoContent();
    }

    [HttpGet("{userId}/tasks")]
    public ActionResult<IEnumerable<TaskP>> GetTasksByUserId(int userId)
    {
        var tasks = _userService.GetTasksByUserId(userId);
        if (tasks is null)
        {
            return NotFound();
        }
        return Ok(tasks);
    }
}
