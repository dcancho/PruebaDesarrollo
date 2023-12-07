using PruebaDesarrollo.HumanResources.Domain.Models.Commands;
using PruebaDesarrollo.HumanResources.Domain.Models.Entities;
using PruebaDesarrollo.HumanResources.Resources;

namespace PruebaDesarrollo.HumanResources.Mapping
{
    public static class TrabajadorAssembler
    {
        public static AddTrabajadorCommand SaveResourceToAddCommand(SaveTrabajadorResource resource)
        {
            return new AddTrabajadorCommand(
                resource.TipoDocumento,
                resource.NumeroDocumento,
                resource.Nombres,
                resource.Sexo,
                resource.IdDepartamento,
                resource.IdProvincia,
                resource.IdDistrito
            );
        }

        public static UpdateTrabajadorCommand UpdateResourceToUpdateCommand(UpdateTrabajadorResource resource, int id)
        {
            return new UpdateTrabajadorCommand(
                id,
                resource.Nombres,
                resource.IdDepartamento,
                resource.IdProvincia,
                resource.IdDistrito
                );

        }

        public static Trabajador FromAddCommandToEntity(AddTrabajadorCommand command)
        {
            return new Trabajador(
                command.TipoDocumento,
                command.NumeroDocumento,
                command.Nombres,
                command.Sexo,
                command.IdDepartamento,
                command.IdProvincia,
                command.IdDistrito
                );
        }

        public static TrabajadorResource FromEntityToResource(Trabajador trabajador)
        {
            return new TrabajadorResource
            {
                Id = trabajador.Id,
                TipoDocumento = trabajador.TipoDocumento,
                NumeroDocumento = trabajador.NumeroDocumento,
                Nombres = trabajador.Nombres,
                Sexo = trabajador.Sexo,
                NombreDepartamento = trabajador.Departamento.NombreDepartamento,
                NombreProvincia = trabajador.Provincia.NombreProvincia,
                NombreDistrito = trabajador.Distrito.NombreDistrito
            };
        }

        public static Trabajador FromUpdateCommandToEntity(UpdateTrabajadorCommand command, Trabajador existingTrabajador)
        {
            existingTrabajador.Nombres = command.Nombres;
            existingTrabajador.IdDepartamento = command.IdDepartamento;
            existingTrabajador.IdProvincia = command.IdProvincia;
            existingTrabajador.IdDistrito = command.IdDistrito;

            return existingTrabajador;
        }
    }
}