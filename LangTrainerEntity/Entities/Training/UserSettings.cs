
using LangTrainerEntity.Entities;

namespace LangTrainerModel.Entities.Training
{
    public class UserSettings
    {
        public User User { get; set; }

        public Guid UserId { get; set; }

        public string Data { get; set; }
    }

}
