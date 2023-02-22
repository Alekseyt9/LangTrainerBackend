namespace LangTrainerEntity.Entities.Lang
{
    public class Translate
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Language Language { get; set; }

        public Guid LanguageId { get; set; }
    }
}
