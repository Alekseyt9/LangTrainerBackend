namespace LangTrainerEntity.Entities.Lang
{
    public class Expression
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public ICollection<Translate> Translates { get; set; } = new HashSet<Translate>();

        public ICollection<Sound> Sounds { get; set; } = new List<Sound>();


        public Guid LanguageId { get; set; }

        public Language Language { get; set; }
        
    }

}
