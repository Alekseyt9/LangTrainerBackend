
using LangTrainerClientModel.Services;

namespace LangTrainerServices.ServicesModel
{
    public interface IWordListService
    {
        IEnumerable<WordListItem> GetList(Guid userId, GetWordListModel model);

    }

}
