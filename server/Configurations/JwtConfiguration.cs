namespace ExerciseServices.Configurations
{
  public class JwtConfiguration : IJwtConfiguration
  {
    public string Secret { get; set; }
  }

  public interface IJwtConfiguration
  {
    string Secret { get; set; }
  }
}