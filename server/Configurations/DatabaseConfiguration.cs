namespace ExerciseServices.Configurations
{
  public class DatabaseConfiguration : IDatabaseConfiguration
  {
    public string UsersCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IDatabaseConfiguration
  {
    string UsersCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}