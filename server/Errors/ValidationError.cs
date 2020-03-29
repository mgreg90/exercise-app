using System.Net;

namespace ExerciseServices.Errors
{
  public class ValidationError : BaseError, IExerciseAppError
  {
    public override string ErrorType { get; set; } = "Validation Error";
    public new HttpStatusCode Status { get; set; } = HttpStatusCode.UnprocessableEntity;

    public ValidationError(string message): base(message)
    {}
  }
}