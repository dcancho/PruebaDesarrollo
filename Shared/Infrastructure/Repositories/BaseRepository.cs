using Microsoft.EntityFrameworkCore;
using PruebaDesarrollo.Shared.Domain.Repositories;
using PruebaDesarrollo.Shared.Infrastructure.Configuration;

namespace PruebaDesarrollo.Shared.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
