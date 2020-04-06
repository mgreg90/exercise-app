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
    public string Email { get; set; }
    [BsonIgnore]
    public string Password { get; set; }
    [BsonIgnore]
    public string PasswordConfirmation { get; set; }
    public string PasswordDigest { get; set; }
    public User(string email, string password, string passwordConfirmation)
    {
      Email = email;
      Password = password;
      PasswordConfirmation = passwordConfirmation;

      if (!IsValid()) throw new ValidationError("Invalid Password");
    }

    public void HashPassword()
    {
      PasswordDigest = BCrypt.Net.BCrypt.HashPassword(Password);
      Password = null;
      PasswordConfirmation = null;
    }

    public bool Authenticate(string password) =>
      BCrypt.Net.BCrypt.Verify(password, PasswordDigest);

    public UserGetDTO ToDTO() => new UserGetDTO()
    {
      id = Id,
      email = Email
    };

    public bool IsValid() =>
      !string.IsNullOrEmpty(Email)
        && !string.IsNullOrEmpty(Password)
        && Password.Length >= MinPasswordLength
        && Password == PasswordConfirmation;
  }
}