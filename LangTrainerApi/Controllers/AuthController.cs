using LangTrainerClientModel.Services.AuthService;
using LangTrainerEntity.Entities;
using LangTrainerServices.Helpers;
using LangTrainerServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IJWTManager _jWTManager;

        public AuthController(IJWTManager jWTManager, IAppRepository repository
        ) : base(repository)
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

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(UserAuth data)
        {
            var oldUser = Repository.GetUser(data.Email);
            if (oldUser == null)
            {
                var hash = PasswordHashHelper.HashPasword(data.Password, out var salt);

                Repository.AddUser(new User()
                {
                    Email = data.Email,
                    PasswordHash = hash,
                    PassSalt = salt
                });
                return Ok();
            }
            return BadRequest("User already exist");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Recovery")]
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
