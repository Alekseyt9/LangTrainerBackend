namespace LangTrainerEntity.Entities.Lang
{
    /// <summary>
    /// Перевод. Если на тот же язык - то определение 
    /// </summary>
    public class Translate : ICloneable
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Language Language { get; set; }

        public Guid LanguageId { get; set; }

        public object Clone()
        {
            return new Translate() { Text = Text, Language = Language, LanguageId = LanguageId };
        }

        public bool EqualsTranslate(Translate other)
        {
            if (other == null)
                return false;
            return other.Text == Text && other.LanguageId == LanguageId;
        }

    }
}
