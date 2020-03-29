using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ExerciseServices.Errors;
using ExerciseServices.DTOs;

namespace ExerciseServices.Models
{
  public class User
  {
    private const int MinPasswordLength = 6;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserName { get; set; }
    [BsonIgnore]
    public string Password { get; set; }
    [BsonIgnore]
    public string PasswordConfirmation { get; set; }
    public string PasswordDigest { get; set; }
    public User(string userName, string password, string passwordConfirmation)
    {
      UserName = userName;
      Password = password;
      PasswordConfirmation = passwordConfirmation;

      if (!_IsValid()) throw new ValidationError("Invalid Password");
    }

    public void HashPassword()
    {
      PasswordDigest = BCrypt.Net.BCrypt.HashPassword(Password);
      Password = null;
      PasswordConfirmation = null;
    }

    public UserGetDTO ToDTO() => new UserGetDTO()
    {
      id = Id,
      userName = UserName
    };

    private bool _IsValid()
    {
      return Password.Length >= MinPasswordLength
        && Password == PasswordConfirmation;
    }
  }
}