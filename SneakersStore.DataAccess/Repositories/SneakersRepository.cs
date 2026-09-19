using Microsoft.EntityFrameworkCore;
using SneakersStore.Core.Abstractions;
using SneakersStore.Core.Filters;
using SneakersStore.Core.Models;
using SneakersStore.DataAccess.Entites;

namespace SneakersStore.DataAccess.Repositories
{
    public class SneakersRepository : ISneakersRepository
    {
        private readonly SneakersStoreDbContext _context;

        public SneakersRepository(SneakersStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Sneakers sneakers)
        {
            var sneakersEntity = new SneakersEntity
            {
                Id = sneakers.Id,
                Title = sneakers.Title,
                Price = sneakers.Price,
                Img = sneakers.Img
            };
            await _context.Sneakers.AddAsync(sneakersEntity);
            await _context.SaveChangesAsync();

            return sneakersEntity.Id;
        }

        public async Task<List<Sneakers>> Get(SneakersFilter filter)
        {
            var query = _context.Sneakers
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                query = query.Where(s =>
                    EF.Functions.ILike(s.Title, $"%{filter.Title}%"));
            }

            var sneakersEntities = await query.ToListAsync();

            var sneakers = sneakersEntities
                .Select(s => Sneakers.Create(s.Id, s.Title, s.Price, s.Img))
                .ToList();

            return sneakers;
        }

        public async Task<Sneakers?> GetById(Guid id)
        {
            var sneakersEntity = await _context.Sneakers
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);

            if (sneakersEntity is null)
            {
                return null;
            }

            var sneakers = Sneakers.Create(sneakersEntity.Id, sneakersEntity.Title, sneakersEntity.Price, sneakersEntity.Img);

            return sneakers;
        }

        public async Task<Guid?> Delete(Guid id)
        {
            var deletedCount = await _context.Sneakers
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

            if (deletedCount == 0)
            {
                return null;
            }

            return id;
        }
    }
}
