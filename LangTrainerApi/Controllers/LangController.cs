
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities.Lang;
using LangTrainerServices.Services.LangService;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangController
    {
        private ILangService _service;

        public LangController(ILangService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("gettokendata")]
        public async Task<ActionResult<Expression>> GetTokenData([FromQuery]TokenInfo token)
        {
            var val = await _service.LoadExpressionData(token);
            return new ActionResult<Expression>(val);
        }

    }
}
