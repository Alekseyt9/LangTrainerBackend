
using LangTrainerDAL.EntityConfigurations;
using LangTrainerEntity.Entities;
using LangTrainerModel.Entities.Training;
using LangTrainerServices.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LangTrainerDAL.Services
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Expression> Expressions { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserSettings> UserSettings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExpressionConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new TranslateConfig());
            modelBuilder.ApplyConfiguration(new SampleConfig()); 
            modelBuilder.ApplyConfiguration(new SoundConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserSettingsConfig());
            modelBuilder.ApplyConfiguration(new TrainingGroupConfig());
            modelBuilder.ApplyConfiguration(new TranslateInGroupConfig());
            modelBuilder.ApplyConfiguration(new TrainingInfoConfig());

            InitData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void InitData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new List<Language>()
                {
                    new()
                    {
                        Id = Guid.Parse("29425483-C990-4EC9-9F1E-4658EED1CAD2"),
                        Name = "russian"
                    },
                    new()
                    {
                        Id = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "english"
                    },
                    new()
                    {
                        Id = Guid.Parse("4C2916C7-E10E-4579-91C6-39C37965DDB1"),
                        Name = "french"
                    },
                    new()
                    {
                        Id = Guid.Parse("EE8F502D-437C-4378-A1A2-E5D7A3B3B29E"),
                        Name = "german"
                    },
                    new()
                    {
                        Id = Guid.Parse("E52926EE-64F1-4B04-8A7E-187C5D0213C8"),
                        Name = "italian"
                    },
                    new()
                    {
                        Id = Guid.Parse("04DBC458-0835-47F2-8140-432376686536"),
                        Name = "spanish"
                    },
                }
            );

            modelBuilder.Entity<User>().HasData(
                new List<User>() { GetAdminUserForInit() }
            );
        }

        public User GetAdminUserForInit()
        {
            var pass = _configuration["admin_password"];
            byte[] salt;
            var hash = PasswordHashHelper.HashPasword(pass, out salt);
            return new User()
            {
                Login = "admin",
                PasswordHash = hash,
                PassSalt = salt,
                Email = "-",
                Id = Guid.Parse("98D48C5D-A10F-4704-9C08-949FE791CF4D")
            };
        }

    }

}
