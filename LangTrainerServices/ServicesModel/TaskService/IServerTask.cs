

namespace LangTrainerServices.Services
{
    public interface IServerTask<T>
    {
        public void Run(TaskContext ctx, T pars);
    }
}
