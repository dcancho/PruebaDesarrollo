using PruebaDesarrollo.HumanResources.Domain.Models.Commands;
using PruebaDesarrollo.HumanResources.Resources;

namespace PruebaDesarrollo.HumanResources.Domain.Services
{
    public interface ITrabajadorCommandService
    {
        Task<TrabajadorResource?> Handle(AddTrabajadorCommand command);
        Task<TrabajadorResource?> Handle(UpdateTrabajadorCommand command);
        Task<TrabajadorResource?> Handle(DeleteTrabajadorCommand command);
    }
}