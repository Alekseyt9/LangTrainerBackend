namespace LangTrainerEntity.Entities
{
    public class Sample : ICloneable
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Translate Translate { get; set; }

        public Guid TranslateId { get; set; }

        public object Clone()
        {
            return new Sample() { Text = Text};
        }

        public bool EqualsSample(Sample other)
        {
            if (other == null)
                return false;
            return other.Text == Text;
        }

    }
}
