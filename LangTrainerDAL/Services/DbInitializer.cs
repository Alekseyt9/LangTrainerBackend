

namespace LangTrainerDAL.Services
{
    public class DbInitializer
    {
        public static void Init(AppDbContext ctx)
        {
            ctx.Database.EnsureCreated();
        }

    }
}
