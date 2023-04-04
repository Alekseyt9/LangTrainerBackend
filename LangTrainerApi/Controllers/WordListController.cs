
using LangTrainerServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WordListController : BaseController
    {
        public WordListController(IAppRepository repository) : base(repository)
        {
        }

        public void GetList()
        {

        }


    }
}
