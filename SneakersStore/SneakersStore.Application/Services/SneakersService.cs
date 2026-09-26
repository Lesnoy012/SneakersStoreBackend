using SneakersStore.Application.Exceptions;
using SneakersStore.Core.Abstractions;
using SneakersStore.Core.Filters;
using SneakersStore.Core.Models;
using SneakersStore.Core.Sort;

namespace SneakersStore.Application.Services
{
    public class SneakersService : ISneakersService
    {
        private readonly ISneakersRepository _sneakersRepository;

        public SneakersService(ISneakersRepository sneakersRepository)
        {
            _sneakersRepository = sneakersRepository;
        }

        public async Task<Guid> CreateSneakers(Sneakers sneakers)
        {
            return await _sneakersRepository.Create(sneakers);
        }

        public async Task<List<Sneakers>> GetAllSneakers(SneakersFilter filter, SneakersSort sort)
        {
            return await _sneakersRepository.Get(filter, sort);
        }

        public async Task<Sneakers> GetSneakersById(Guid id)
        {
            var sneakers = await _sneakersRepository.GetById(id);

            if (sneakers is null)
            {
                throw new NotFoundException("Sneakers not found");
            }

            return sneakers;
        }

        public async Task<Guid> DeleteSneakersById(Guid id)
        {
            var result = await _sneakersRepository.Delete(id);

            if (result is null)
            {
                throw new NotFoundException("Sneakers not found");
            }

            return result.Value;
        }
    }
}
