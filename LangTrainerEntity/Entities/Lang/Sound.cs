
namespace LangTrainerEntity.Entities
{
    public class Sound : ICloneable
    {
        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public byte[] Hash { get; set; }

        public string Url { get; set; }

        public object Clone()
        {
            return new Sound()
            {
                Data = Data, 
                Url = Url, 
                Hash = Hash
            };
        }

        public bool EqualsSound(Sound val)
        {
            if (val ==  null)
                throw new ArgumentNullException("Val");

            if (Url == null || val.Url == null)
                throw new ArgumentNullException("Url");

            if (Hash == null || val.Hash == null)
                throw new ArgumentNullException("Hash");

            return Url == val.Url || Hash == val.Hash;
        }

    }
}
