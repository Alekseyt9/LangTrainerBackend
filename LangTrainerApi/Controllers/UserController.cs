
using LangTrainerClientModel.Model.User;
using LangTrainerServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTManager _jWTManager;

        public UserController(IJWTManager jWTManager)
        {
            _jWTManager = jWTManager ?? throw new ArgumentNullException(nameof(jWTManager));
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

    }
}
