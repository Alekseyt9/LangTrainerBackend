
using LangTrainerClientModel.Services;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WordListController : BaseController
    {
        private readonly IWordListService _wordListService;

        public WordListController(IAppRepository repository, IWordListService wordListService) 
            : base(repository)
        {
            _wordListService = wordListService ?? throw new ArgumentNullException(nameof(wordListService));
        }

        [HttpGet]
        [Route("GetList")]
        public ActionResult<IEnumerable<WordListItem>> GetList(GetWordListModel model)
        {
            return new ActionResult<IEnumerable<WordListItem>>(_wordListService.GetList(GetCurrentUserId(), model));
        }

    }
}
