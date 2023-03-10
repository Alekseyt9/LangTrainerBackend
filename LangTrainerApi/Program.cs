
using LangTrainerDAL;
using LangTrainerDAL.Services;
using LangTrainerServies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EngTrainerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration
                .AddJsonFile($"appsettings.json", true, true)
                .AddUserSecrets<Program>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            Init(app);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void Init(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration conf)
        {
            services.ConfigureLangServices();
            services.RegisterPersistence(conf);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(conf["JWT_key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = conf["JWT_key"],
                    ValidAudience = conf["JWT_key"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

            services.AddSingleton<IConfiguration>(conf);

        }

    }
}