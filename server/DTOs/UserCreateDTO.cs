using ExerciseServices.Models;

namespace ExerciseServices.DTOs
{
  public class UserCreateDTO
  {
    public string userName { get; set; }
    public string password { get; set; }
    public string passwordConfirmation { get; set; }

    public User ToUser() => new User(userName, password, passwordConfirmation);
  }
}