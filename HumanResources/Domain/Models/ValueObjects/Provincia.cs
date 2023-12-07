namespace PruebaDesarrollo.HumanResources.Domain.Models.ValueObjects
{
    public class Provincia
    {
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string NombreProvincia { get; set; } = string.Empty;
        public Departamento Departamento { get; set; } = new Departamento();
    }
}
