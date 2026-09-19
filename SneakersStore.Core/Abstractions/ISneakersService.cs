using SneakersStore.Core.Filters;
using SneakersStore.Core.Models;

namespace SneakersStore.Core.Abstractions
{
    public interface ISneakersService
    {
        Task<Guid> CreateSneakers(Sneakers sneakers);
        Task<List<Sneakers>> GetAllSneakers(SneakersFilter filter);
        Task<Sneakers> GetSneakersById(Guid id);
        Task<Guid> DeleteSneakersById(Guid id);
    }
}