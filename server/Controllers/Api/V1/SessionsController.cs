using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExerciseServices.Errors;
using ExerciseServices.DTOs;
using ExerciseServices.Repositories;
using ExerciseServices.Services;

namespace ExerciseServices.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class SessionsController : ControllerBase
  {
    private readonly ILogger<SessionsController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IUserJWTService _userJwtService;

    public SessionsController(
      ILogger<SessionsController> logger,
      IUserJWTService userJwtService,
      IUserRepository userRepository
    )
    {
      _logger = logger;
      _userRepository = userRepository;
      _userJwtService = userJwtService;
    }

    [HttpPost]
    public IActionResult Create(SessionCreateDTO sessionDto)
    {
      var user = _userRepository.GetByUsername(sessionDto.userName);

      if (user == null) throw new NotFoundError("User not found!");
      if (!user.Authenticate(sessionDto.password)) throw new ValidationError("Incorrect Password!");

      var token = _userJwtService.Call(user);

      return new ContentResult() {
        Content = JsonSerializer.Serialize(new { token = token }),
        StatusCode = 201,
        ContentType = "application/json"
      };
    }
  }
}
