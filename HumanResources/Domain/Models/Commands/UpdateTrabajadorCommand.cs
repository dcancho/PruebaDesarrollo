namespace PruebaDesarrollo.HumanResources.Domain.Models.Commands
{
    public record UpdateTrabajadorCommand
    {
        public int Id { get; init; }
        public string Nombres { get; init; }
        public int IdDepartamento { get; init; }
        public int IdProvincia { get; init; }
        public int IdDistrito { get; init; }

        public UpdateTrabajadorCommand(int id, string nombres, int idDepartamento, int idProvincia, int idDistrito)
        {
            Id = id;
            Nombres = nombres;
            IdDepartamento = idDepartamento;
            IdProvincia = idProvincia;
            IdDistrito = idDistrito;
        }
    }
}
