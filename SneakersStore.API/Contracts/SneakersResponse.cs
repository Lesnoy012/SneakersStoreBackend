namespace SneakersStore.API.Contracts
{
    public record SneakersResponse(
        Guid Id,
        string Title,
        decimal Price,
        string Img
    );
}
