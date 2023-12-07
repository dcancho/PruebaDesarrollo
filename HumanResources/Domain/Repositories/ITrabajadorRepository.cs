using PruebaDesarrollo.HumanResources.Domain.Models.Entities;
using PruebaDesarrollo.Shared.Domain.Repositories;

namespace PruebaDesarrollo.HumanResources.Domain.Repositories
{
    public interface ITrabajadorRepository : IBaseRepository<Trabajador>
    {
        Task<Trabajador?> FindByIdEagerLoadAsync(int id);
        Task<Trabajador?> FindByDniAsync(string dni);
        Task<IEnumerable<Trabajador>?> ListEagerLoadAsync();
    }
}
