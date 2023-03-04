

namespace LangTrainerCommon.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static TimeSpan GetInterval(int mean, int delta)
        {
            return TimeSpan.FromMilliseconds(mean +
                _random.Next((int)(-delta*0.5), (int)(delta*0.5)));
        }

    }
}
