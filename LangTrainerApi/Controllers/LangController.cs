
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangController
    {
        private ILangService _langService;

        public LangController(ILangService service)
        {
            _langService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("GetTokenData")]
        public async Task<ActionResult<Expression>> GetTokenData([FromQuery]TokenInfo token)
        {
            var val = await _langService.LoadExpressionData(token);
            return new ActionResult<Expression>(val);
        }

        [HttpGet("FindInDictionary")]
        public ActionResult<FindResult> FindInDictionary([FromQuery]FindModel model)
        {
            var res = _langService.FindExpressions(model);
            return res;
        }

        [HttpGet("GetLanguages")]
        public ActionResult<List<Language>> GetLanguages()
        {
            return _langService.GetLanguages();
        }

        [HttpGet("GetTranslateLanguages")]
        public ActionResult<List<Language>> GetTranslateLanguages()
        {
            var keys = new HashSet<string>() {"russian", "english"};
            var langs = _langService.GetLanguages();
            return langs.Where(x => keys.Contains(x.Name)).ToList();
        }

    }
}
