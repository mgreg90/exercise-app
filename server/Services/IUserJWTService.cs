using Microsoft.IdentityModel.Tokens;

using ExerciseServices.Models;

namespace ExerciseServices.Services
{
  public interface IUserJWTService
  {
    string Call(User user);
  }
}