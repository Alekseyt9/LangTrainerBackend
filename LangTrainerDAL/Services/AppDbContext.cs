
using LangTrainerDAL.EntityConfigurations;
using LangTrainerEntity.Entities.Lang;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<Expression> Expressions { get; set; }

        public DbSet<Language> Languages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExpressionConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new SampleConfig()); 
            modelBuilder.ApplyConfiguration(new SoundConfig());
            modelBuilder.ApplyConfiguration(new TranslateConfig());

            InitData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void InitData(ModelBuilder modelBuilder)
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
        }

    }

}
