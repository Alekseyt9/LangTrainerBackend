namespace LangTrainerServices.ServicesImpl.TaskService.Tasks.LoadWords
{
    public class LoadWordsTaskParams
    {
        public string Language { get; set; }

        public ICollection<string> Tokens { get; set; }
    }
}
