namespace LangTrainerClientModel.Services.TrainingService
{
    public class StartTrainingItem
    {
        public ICollection<string> Words { get; set; }

        public int Count { get; set; }
    }
}
