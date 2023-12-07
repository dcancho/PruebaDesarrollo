namespace PruebaDesarrollo.HumanResources.Domain.Models.Commands {
    public record AddTrabajadorCommand {
        public string TipoDocumento { get; init; }
        public string NumeroDocumento { get; init; }
        public string Nombres { get; init; }
        public string Sexo { get; init; }
        public int IdDepartamento { get; init; }
        public int IdProvincia { get; init; }
        public int IdDistrito { get; init; }

        public AddTrabajadorCommand(string tipoDocumento, string numeroDocumento, string nombres, string sexo, int idDepartamento, int idProvincia, int idDistrito) {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Nombres = nombres;
            Sexo = sexo;
            IdDepartamento = idDepartamento;
            IdProvincia = idProvincia;
            IdDistrito = idDistrito;
        }
    }
}