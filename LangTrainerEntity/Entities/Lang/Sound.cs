
namespace LangTrainerEntity.Entities.Lang
{
    public class Sound : ICloneable
    {
        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public byte[] Hash { get; set; }

        public object Clone()
        {
            return new Sound() { Data = Data, Hash = Hash};
        }

        public bool EqualsSound(Sound val)
        {
            return Hash == val.Hash;
        }

    }
}
