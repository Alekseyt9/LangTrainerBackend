namespace LangTrainerEntity.Entities.Lang
{
    public class Expression
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public ICollection<Translate> Translates { get; set; }

        public ICollection<Sample> Samples { get; set; }

        public ICollection<Sound> Sounds { get; set; }

        public Guid LanguageId { get; set; }

        public Language Language { get; set; }
    }

}
