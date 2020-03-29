using System.Net;

namespace ExerciseServices.Errors
{
  public interface IExerciseAppError
  {
    HttpStatusCode Status { get; set; }
    byte[] ToJsonBytes();
  }
}