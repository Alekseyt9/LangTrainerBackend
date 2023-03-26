
using LangTrainerClientModel.Services;
using LangTrainerClientModel.Services.TrainingService;
using LangTrainerEntity.Entities;
using LangTrainerServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangTrainerAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : BaseController
    {
        public TrainingController(IAppRepository repository) : base(repository)
        {
        }

        [HttpPost]
        [Route("AddTranslateToTraining")]
        public ActionResult AddTranslateToTraining([FromBody] AddTranslateToTrainingModel model)
        {
            var gr = Repository.GetDefaultTrainingGroup(GetCurrentUserId());
            var founded = Repository.GetTranslateInGroup(gr.Id, model.TranslateId);
            if (founded != null)
            {
                return BadRequest("The word has already been added to your list");
            }

            var tr = Repository.GetTranslate(model.TranslateId);

            var trInGroup = new TranslateInGroup()
            {
                AddTime = DateTime.Now.ToUniversalTime(),
                Group = gr,
                TrainingInfo = new TrainingInfo(),
                Translate = tr
            };

            gr.Translates.Add(trInGroup);
            Repository.Save();

            return NoContent();
        }

        [HttpGet]
        [Route("GetTranslatesList")]
        public ActionResult<ICollection<TrainingListItem>> GetTranslatesList()
        {
            var res = new List<TrainingListItem>();

            

            return res;
        }

        [HttpDelete]
        [Route("DeleteTranslate")]
        public ActionResult DeleteTranslate(Guid translateId)
        {
            return NoContent();
        }

        [HttpGet]
        [Route("GetTraining")]
        public ActionResult GetTraining()
        {
            return NoContent();
        }

        [HttpPost]
        [Route("SaveTrainingResult")]
        public ActionResult SaveTrainingResult()
        {
            return NoContent();
        }

    }
}
