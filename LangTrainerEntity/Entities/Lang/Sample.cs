namespace LangTrainerEntity.Entities.Lang
{
    public class Sample : ICloneable
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

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
