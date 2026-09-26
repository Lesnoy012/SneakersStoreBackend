using SneakersStore.Core.Filters;
using SneakersStore.Core.Models;
using SneakersStore.Core.Sort;

namespace SneakersStore.Core.Abstractions
{
    public interface ISneakersService
    {
        Task<Guid> CreateSneakers(Sneakers sneakers);
        Task<List<Sneakers>> GetAllSneakers(SneakersFilter filter, SneakersSort sort);
        Task<Sneakers> GetSneakersById(Guid id);
        Task<Guid> DeleteSneakersById(Guid id);
    }
}
