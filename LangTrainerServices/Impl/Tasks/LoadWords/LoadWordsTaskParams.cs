

namespace LangTrainerServices.Impl.Tasks.LoadWords
{
    public class LoadWordsTaskParams
    {
        public string Language { get; set; }

        public ICollection<string> Tokens { get; set; }
    }
}
