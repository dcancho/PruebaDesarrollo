namespace PruebaDesarrollo.HumanResources.Domain.Models.ValueObjects
{
    public class Distrito
    {
        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public string NombreDistrito { get; set; } = string.Empty;
        public Provincia Provincia { get; set; } = new Provincia();
    }
}
