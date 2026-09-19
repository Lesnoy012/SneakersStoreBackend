using SneakersStore.Core.Filters;
using SneakersStore.Core.Models;

namespace SneakersStore.Core.Abstractions
{
    public interface ISneakersRepository
    {
        Task<Guid> Create(Sneakers sneakers);
        Task<List<Sneakers>> Get(SneakersFilter filter);
        Task<Sneakers?> GetById(Guid id);
        Task<Guid?> Delete(Guid id);
    }
}