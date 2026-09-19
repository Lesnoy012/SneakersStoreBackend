namespace SneakersStore.API.Contracts
{
    public record SneakersRequest(
        string Title,
        decimal Price,
        string Img
    );
}
