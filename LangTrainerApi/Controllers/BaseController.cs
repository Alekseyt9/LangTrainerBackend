using LangTrainerServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LangTrainerAPI.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAppRepository _repository;

        protected virtual IAppRepository Repository => _repository;

        public BaseController(IAppRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected virtual Guid GetCurrentUserId()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            if (userId == null)
            {
                throw new Exception("null claim");
            }
            return _repository.GetUser(userId).Id;
        }

    }
}
