using PruebaDesarrollo.Shared.Domain.Repositories;
using PruebaDesarrollo.Shared.Infrastructure.Configuration;

namespace PruebaDesarrollo.Shared.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
