

namespace LangTrainerEntity.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public byte[] PassSalt { get; set; }

        public string PasswordHash { get; set; }

    }
}
