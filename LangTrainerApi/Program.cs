
using LangTrainerDAL;
using LangTrainerDAL.Services;
using LangTrainerServies;

namespace EngTrainerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile($"appsettings.json", true, true);

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
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        public static void Init(WebApplication app)
        {
            var dbContext = app.Services.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration conf)
        {
            services.ConfigureLangServices();
            services.RegisterPersistence(conf);
        }

    }
}