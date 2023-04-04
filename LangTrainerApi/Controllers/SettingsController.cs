
using LangTrainerClientModel.Services;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesModel;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(
            ISettingsService settingsService,
            IAppRepository repository
        ) : base(repository)
        {
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
        }

        [HttpGet]
        [Route("GetSettings")]
        public ActionResult<SettingsValues> GetSettings()
        {
            var userId = GetCurrentUserId();
            return _settingsService.LoadUserSettings(userId);
        }

        [HttpPost]
        [Route("SetSettings")]
        public IActionResult SetSettings([FromBody] SettingsModel model)
        {
            var userId = GetCurrentUserId();
            _settingsService.SaveUserSettings(userId, model.Data);
            return NoContent();
        }

    }
}
