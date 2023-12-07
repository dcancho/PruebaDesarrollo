using PruebaDesarrollo.HumanResources.Domain.Models.Queries;
using PruebaDesarrollo.HumanResources.Resources;

namespace PruebaDesarrollo.HumanResources.Domain.Services
{
    public interface ITrabajadorQueryService
    {
        public Task<IEnumerable<TrabajadorResource>?> Handle(GetAllTrabajadoresQuery query);
    }
}