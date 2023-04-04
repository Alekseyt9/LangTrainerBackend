
using LangTrainerClientModel.Services;
using LangTrainerCommon.Helpers;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services.Tasks;
using LangTrainerServices.ServicesModel.DataLoader;

namespace LangTrainerServices.ServicesImpl.TaskService.Tasks.LoadWords
{
    [ServerTask]
    internal class LoadWordsTask : IServerTask<LoadWordsTaskParams>
    {
        private readonly IDataLoaderService _dataLoaderService;

        public LoadWordsTask(IDataLoaderService dataLoaderService)
        {
            _dataLoaderService = dataLoaderService ??
                                 throw new ArgumentNullException(nameof(dataLoaderService));
        }

        public async void Run(TaskContext ctx, LoadWordsTaskParams pars)
        {
            ctx.SetStatus(ServerTaskStatus.InProcess);

            var cnt = pars.Tokens.Count;
            var i = 0;
            var loaded = 0;
            var notLoaded = 0;

            var errWordList = new List<string>();

            //todo отфильтровать по базе !!!

            /*
            foreach (var word in pars.Tokens)
            {
                try
                {
                    var res = await _dataLoaderService.LoadExpressionData(
                        new WordInfo(word, pars.Language));

                    loaded++;
                    await Task.Delay(RandomHelper.GetInterval(100, 50));
                }
                catch (Exception ex)
                {
                    notLoaded++;
                    errWordList.Add(word);
                    ctx.LogError(ex);
                }

                i++;
                ctx.SetProgress(i/(float)cnt);
            }*/

            ctx.SetStatus(ServerTaskStatus.Success);
            ctx.SetReport(
                $"Loaded words: {loaded}; with errors: {notLoaded}. Words not loaded: {string.Join(", ", errWordList)}");
        }

    }
}
