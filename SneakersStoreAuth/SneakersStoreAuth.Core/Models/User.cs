namespace SneakersStoreAuth.Core.Models
{
    public class User
    {
        const int MAX_USERNAME_LENGTH = 30;
        public const int MIN_USERNAME_LENGTH = 3;
        private User(Guid id, string userName, string hashPassword)
        {
            Id = id;
            UserName = userName;
            HashPassword = hashPassword;
        }

        public Guid Id { get; }
        public string UserName { get; } = string.Empty;
        public string HashPassword { get; } = string.Empty;

        public static User Create(Guid id, string userName, string hashPassword)
        {
            if (string.IsNullOrWhiteSpace(userName) && userName.Length > MAX_USERNAME_LENGTH)
            {
                throw new ArgumentException(
                    $"Название не может быть пустым, больше {MAX_USERNAME_LENGTH} символов или меньше {MIN_TITLE_LENGTH} символов",
                    nameof(userName));
            }

            return new User(id, userName, hashPassword);
        }

    }
}
