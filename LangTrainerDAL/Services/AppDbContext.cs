
using LangTrainerDAL.EntityConfigurations;
using LangTrainerEntity.Entities.Lang;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<Expression> Expressions { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }

    }

}
