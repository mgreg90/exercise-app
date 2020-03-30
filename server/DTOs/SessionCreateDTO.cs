using ExerciseServices.Models;

namespace ExerciseServices.DTOs
{
  public class SessionCreateDTO
  {
    public string email { get; set; }
    public string password { get; set; }
  }
}