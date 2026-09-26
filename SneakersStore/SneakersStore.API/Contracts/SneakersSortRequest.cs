using SneakersStore.Core.Sort;

namespace SneakersStore.API.Contracts
{
    public record SneakersSortRequest(
        string? SortBy,
        SortDirection? SortDirection
    );
}
