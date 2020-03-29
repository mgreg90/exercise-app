using System.Collections.Generic;
using ExerciseServices.Models;

namespace ExerciseServices.Repositories
{
  public interface IUserRepository
  {
    IEnumerable<User> GetUsers();

    User Get(string id);
    User GetByUsername(string username);

    User Create(User user);

    void Update(string id, User userIn);
    void Remove(User userIn);

    void Remove(string id);
  }
}