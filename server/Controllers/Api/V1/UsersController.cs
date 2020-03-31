using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExerciseServices.Repositories;
using ExerciseServices.DTOs;
using ExerciseServices.Models;

namespace ExerciseServices.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> _logger;
    private readonly IUserRepository _userRepository;

    public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
    {
      _logger = logger;
      _userRepository = userRepository;
    }

    [HttpPost]
    public IActionResult Create(UserCreateDTO userDto)
    {
      var user = userDto.ToUser();
      user = _userRepository.Create(user);
      return Ok(user.ToDTO());
    }

    [HttpGet]
    public IActionResult Show()
    {
      return Ok(new { Hey = "dog"});
    }
  }
}
