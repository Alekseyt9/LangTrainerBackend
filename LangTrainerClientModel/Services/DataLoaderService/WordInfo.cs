namespace LangTrainerClientModel.Services.DataLoader
{
    public class WordInfo
    {
        public WordInfo()
        {
        }

        public WordInfo(string expression, Guid languageId)
        {
            Expression = expression;
            LanguageId = languageId;
        }

        public string Expression { get; set; }

        public Guid LanguageId { get; set; }
    }
}
