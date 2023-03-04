

namespace LangTrainerServices.Services.Tasks
{
    public interface IServerTask<T>
    {
        public void Run(TaskContext ctx, T pars);
    }
}
