
using LangTrainerClientModel.Model.User;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LangTrainerClientModel.Model;
using LangTrainerClientModel.Model.Settings;

namespace LangTrainerAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IJWTManager _jWTManager;
        private readonly ISettingsService _settingsService;

        public UserController(
            IJWTManager jWTManager,
            ISettingsService settingsService,
            IAppRepository repository
        ) : base(repository)
        {
            _jWTManager = jWTManager ?? throw new ArgumentNullException(nameof(jWTManager));
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserAuth userAuthModel)
        {
            var token = _jWTManager.Authenticate(userAuthModel);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        public IAsyncResult Register()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult PasswordRecovery()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult PasswordChange()
        {
            throw new NotImplementedException();
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
