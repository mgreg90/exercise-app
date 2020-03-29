using System.Net;

namespace ExerciseServices.Errors
{
  public class NotFoundError : BaseError, IExerciseAppError
  {
    public override string ErrorType { get; set; } = "Query Error";
    public new HttpStatusCode Status { get; set; } = HttpStatusCode.NotFound;

    public NotFoundError(string message) : base(message)
    { }
  }
}