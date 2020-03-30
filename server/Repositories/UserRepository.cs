using ExerciseServices.Models;
using ExerciseServices.Configurations;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using ExerciseServices.Errors;

namespace ExerciseServices.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly IMongoCollection<User> _users;

    public UserRepository(IDatabaseConfiguration dbConfig)
    {
      var client = new MongoClient(dbConfig.ConnectionString);
      var database = client.GetDatabase(dbConfig.DatabaseName);

      _users = database.GetCollection<User>(dbConfig.UsersCollectionName);
    }

    public IEnumerable<User> GetUsers() => _users.Find(user => true).ToList();

    public User Get(string id) =>
      _users.Find<User>(user => user.Id == id).FirstOrDefault();

    public User GetByEmail(string email) =>
      _users.Find<User>(user => user.Email == email).FirstOrDefault();

    public User Create(User userIn)
    {
      // Validation
      if (!IsValid(userIn)) throw new ValidationError("User already exists!");

      userIn.HashPassword();
      _users.InsertOne(userIn);
      return userIn;
    }

    public void Update(string id, User userIn) =>
      _users.ReplaceOne(user => user.Id == id, userIn);
    
    public void Remove(User userIn) =>
      _users.DeleteOne(user => user.Id == userIn.Id);

    public void Remove(string id) =>
      _users.DeleteOne(user => user.Id == id);

    private bool IsValid(User userIn)
    {
      return !_users.Find<User>(user => user.Email == userIn.Email).Any();
    }
  }
}