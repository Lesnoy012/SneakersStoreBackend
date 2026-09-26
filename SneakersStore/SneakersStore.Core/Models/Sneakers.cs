
namespace SneakersStore.Core.Models
{
    public class Sneakers
    {
        public const int MAX_TITLE_LENGTH = 150;
        public const int MIN_TITLE_LENGTH = 1;
        public const decimal MIN_PRICE = 0;

        private Sneakers(Guid id, string title, decimal price, string img)
        {
            Id = id;
            Title = title;
            Price = price;
            Img = img;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public decimal Price { get; }
        public string Img { get; } = string.Empty;

        public static Sneakers Create(Guid id, string title, decimal price, string img)
        {
            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH || title.Length < MIN_TITLE_LENGTH)
            {
                throw new ArgumentException(
                    $"Название не может быть пустым, больше {MAX_TITLE_LENGTH} символов или меньше {MIN_TITLE_LENGTH} символов",
                    nameof(title));
            }

            if (price < MIN_PRICE)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(price),
                    $"Стоимость не может быть меньше {MIN_PRICE}");
            }

            return new Sneakers(id, title, price, img);
        }
    }
}
