using Microsoft.EntityFrameworkCore;
using PruebaDesarrollo.HumanResources.Domain.Models.Entities;
using PruebaDesarrollo.HumanResources.Domain.Repositories;
using PruebaDesarrollo.Shared.Infrastructure.Configuration;
using PruebaDesarrollo.Shared.Infrastructure.Repositories;

namespace PruebaDesarrollo.HumanResources.Infrastructure.Repositories
{
    public class TrabajadorRepository : BaseRepository<Trabajador>, ITrabajadorRepository
    {
        public TrabajadorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Trabajador?> FindByIdEagerLoadAsync(int id)
        {
            return await _context.Trabajadores
                .Include(t => t.Departamento)
                .Include(t => t.Provincia)
                .Include(t=> t.Distrito)
                .FirstOrDefaultAsync(
                    t => t.Id == id);
        }

        public async Task<Trabajador?> FindByDniAsync(string dni)
        {
            return await _context.Trabajadores
                .Include(t => t.Departamento)
                .Include(t => t.Provincia)
                .Include(t=> t.Distrito)
                .FirstOrDefaultAsync(
                t => t.NumeroDocumento == dni);
            
        }

        public async Task<IEnumerable<Trabajador>?> ListEagerLoadAsync()
        {
            return await _context.Trabajadores
                .Include(t => t.Departamento)
                .Include(t => t.Provincia)
                .Include(t => t.Distrito)
                .ToListAsync();
        }
    }
}
