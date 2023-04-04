
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesModel;

namespace LangTrainerServices.ServicesImpl
{
    internal class WordListService : IWordListService
    {
        private readonly IAppRepository _repository;

        public WordListService(IAppRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<WordListItem> GetList(Guid userId, GetWordListModel model)
        {
            var group = _repository.GetDefaultTrainingGroup(userId);
            var list = _repository.GetTranslatesInGroup(group.Id, model.SearchString, 10);
            var res =  list.OrderByDescending(x => x.AddTime).Select(x => new WordListItem()
            {
                Sample = x.Translate.Samples.First().Text,
                Sounds = x.Translate.Expression.Sounds.ToArray(),
                TrainingState = GetTrainingStateStr(x.TrainingInfo),
                Translate = x.Translate.Text,
                TranslateId = x.TranslateId
            });
            return res;
        }

        private string GetTrainingStateStr(TrainingInfo info)
        {
            return null;
        }

    }
}
