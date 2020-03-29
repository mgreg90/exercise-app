using System;
using System.Net;
using System.Text.Json;
using System.Text;

namespace ExerciseServices.Errors
{
  public class BaseError : ApplicationException
  {
    public virtual string ErrorType { get; set; } = "Internal Server Error";
    public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;
    private byte[] _jsonBytes;

    public BaseError(string message) : base(message)
    {}

    public byte[] ToJsonBytes()
    {
      if (_jsonBytes != null) return _jsonBytes;

      var json = JsonSerializer.Serialize(new {
        Message = ResponseMessage()
      });

      var bytes = Encoding.UTF8.GetBytes(json);
      _jsonBytes = bytes;
      return _jsonBytes;
    }

    public string ResponseMessage() => $"{ErrorType} - {Message}";
  }
}