
using LangTrainerDAL.EntityConfigurations;
using LangTrainerEntity.Entities;
using LangTrainerModel.Entities.Lang;
using LangTrainerModel.Entities.Training;
using LangTrainerServices.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LangTrainerDAL.Services
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Expression> Expressions { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserSettings> UserSettings { get; set; }

        public DbSet<PartOfSpeech> PartOfSpeech { get; set; }

        public DbSet<TrainingGroup> TrainingGroups { get; set; }

        public DbSet<TranslateInGroup> TranslateInGroup { get; set; }

        public DbSet<Translate> Translates { get; set; }

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
            modelBuilder.ApplyConfiguration(new PartOfSpeechConfig());

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
                new List<User>() { GetAdminUserForInit(), GetTestUserForInit() }
            );

            //noun, pronoun, verb, adjective, adverb, preposition, conjunction, interjection
            modelBuilder.Entity<PartOfSpeech>().HasData(
                new List<PartOfSpeech>()
                {
                    new()
                    {
                        Id = Guid.Parse("4B8B1B37-2696-466B-A053-C5A2F4F5C1A3"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "noun"
                    },
                    new()
                    {
                        Id = Guid.Parse("8F281ED9-FB46-49C4-88C7-0C00D304B2CB"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "pronoun"
                    },
                    new()
                    {
                        Id = Guid.Parse("FD0049C4-F203-44BF-AE8C-1679A81DE1D4"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "verb"
                    },
                    new()
                    {
                        Id = Guid.Parse("3EC5B5BB-BAED-4135-853E-23CBF14CEA68"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "adjective"
                    },
                    new()
                    {
                        Id = Guid.Parse("B78304B8-70FA-475C-8898-A7D5C8F48A66"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "adverb"
                    },
                    new()
                    {
                        Id = Guid.Parse("CA7CF798-0015-42B1-BF47-D450DA865B75"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "preposition"
                    },
                    new()
                    {
                        Id = Guid.Parse("EEA3308F-90EB-43DE-815F-15F3B3DC8A22"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "conjunction"
                    },
                    new()
                    {
                        Id = Guid.Parse("571A9FDB-F2DB-4E55-ACAF-3670DB7153EB"),
                        LanguageId = Guid.Parse("2F8444BC-096B-40C4-AE15-3CC1858A0D27"),
                        Name = "interjection"
                    },
                }
            );
        }

        public User GetTestUserForInit()
        {
            var pass = "test";
            byte[] salt;
            var hash = PasswordHashHelper.HashPasword(pass, out salt);
            return new User()
            {
                Login = "test",
                PasswordHash = hash,
                PassSalt = salt,
                Email = "alekseyt9@gmail.com",
                Id = Guid.Parse("E3DB5E30-1C0E-432C-920D-7160D71F8D35")
            };
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
