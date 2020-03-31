using ExerciseServices.Errors;
using ExerciseServices.Configurations;
using ExerciseServices.Repositories;
using ExerciseServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;

namespace ExerciseServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // Error Filter
            services.AddControllers(options => {
                options.Filters.Add(typeof(ErrorFilter));
            });

            // JWT Tokens
            services.Configure<JwtConfiguration>(
                Configuration.GetSection(nameof(JwtConfiguration)));
            services.AddSingleton<IJwtConfiguration>(x =>
                x.GetRequiredService<IOptions<JwtConfiguration>>().Value);

            // MongoDB
            services.Configure<DatabaseConfiguration>(
                Configuration.GetSection(nameof(DatabaseConfiguration)));
            services.AddSingleton<IDatabaseConfiguration>(x =>
                x.GetRequiredService<IOptions<DatabaseConfiguration>>().Value);

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserJWTService, UserJWTService>();

            // JWT Auth
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtConfiguration:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Redirect non /api calls to render the UI
            app.Use(async (context, next) =>
            {
                await next();
                var path = context.Request.Path.Value;

                if (!path.StartsWith("/api") && !Path.HasExtension(path))
                {
                    context.Response.Redirect($"/index.html#{path}");
                    return;
                }
            });
            app.UseStaticFiles();
        }
    }
}
