namespace PruebaDesarrollo.HumanResources.Resources
{
    public class TrabajadorResource
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string NombreDepartamento { get; set; }
        public string NombreProvincia { get; set; }
        public string NombreDistrito { get; set; }
    }

    public class SaveTrabajadorResource
    {
        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
    }

    public class UpdateTrabajadorResource
    {
        public string Nombres { get; set; } = string.Empty;
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
    }
}