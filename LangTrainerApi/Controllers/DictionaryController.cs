
using LangTrainerClientModel.Services;
using LangTrainerClientModel.Services.DataLoader;
using LangTrainerClientModel.Services.LangService;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : BaseController
    {
        private readonly IDictionaryService _dictionaryService;
        private readonly ILanguageService _languageService; 

        public DictionaryController(
            IDictionaryService service, ILanguageService languageService,
            IAppRepository repository) : base(repository)
        {
            _dictionaryService = service ?? throw new ArgumentNullException(nameof(service));
            _languageService = languageService ?? throw new ArgumentNullException(nameof(languageService));
        }

        [HttpGet("GetTokenData")]
        public async Task<ActionResult<Expression>> GetTokenData([FromQuery]WordInfo word)
        {
            var val = await _dictionaryService.LoadExpressionData(word);
            return new ActionResult<Expression>(val);
        }

        [HttpGet("FindInDictionary")]
        public ActionResult<FindResult> FindInDictionary([FromQuery]FindModel model)
        {
            if (!model.LanguageId.HasValue)
            {
                return BadRequest("LanguageId");
            }

            var res = _dictionaryService.FindExpressions(model);
            return res;
        }

        [HttpGet("GetLanguages")]
        public ActionResult<List<Language>> GetLanguages()
        {
            return _languageService.GetLanguages();
        }

        [HttpGet("GetTranslateLanguages")]
        public ActionResult<List<Language>> GetTranslateLanguages()
        {
            return _languageService.GetTranslateLanguages();
        }

        [HttpGet("LoadInBase")]
        public async Task<ActionResult<LoadResult>> LoadInBase([FromQuery] WordInfo word)
        {
            var val = await _dictionaryService.LoadInBase(word);
            return new ActionResult<LoadResult>(val);
        }

    }
}
