using PruebaDesarrollo.HumanResources.Domain.Models.ValueObjects;

namespace PruebaDesarrollo.HumanResources.Domain.Models.Entities
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = string.Empty; // Considerar migrar a un ValueObject "TipoDocumento"
        public string NumeroDocumento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public int IdDepartamento { get; set; }
        public Departamento? Departamento { get; set; }
        public int IdProvincia { get; set; }
        public Provincia? Provincia { get; set; }
        public int IdDistrito { get; set; }
        public Distrito? Distrito { get; set; }

        public Trabajador(string tipoDocumento, string numeroDocumento, string nombres, string sexo, int idDepartamento, int idProvincia, int idDistrito)
        {
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
