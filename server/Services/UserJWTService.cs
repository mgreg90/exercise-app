using ExerciseServices.Models;
using ExerciseServices.Configurations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExerciseServices.Services
{
  public class UserJWTService: IUserJWTService
  {
    private const int TokenDaysValid = 7;
    private string Secret;
    public UserJWTService(IJwtConfiguration jwtConfig)
    {
      Secret = jwtConfig.Secret;
    }

    public string Call(User user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = BuildSecurityTokenDescriptor(user);
      var createdToken = tokenHandler.CreateToken(tokenDescriptor);
      var token = tokenHandler.WriteToken(createdToken);

      return token;
    }

    private SecurityTokenDescriptor BuildSecurityTokenDescriptor(User user) {
      var key = Encoding.ASCII.GetBytes(Secret);

      return new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.NameIdentifier, user.Id),
          new Claim(ClaimTypes.Name, user.Email)
        }),
        Expires = DateTime.UtcNow.AddDays(TokenDaysValid),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
    }
  }
}