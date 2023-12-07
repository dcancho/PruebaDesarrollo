using PruebaDesarrollo.HumanResources.Domain.Models.ValueObjects;
using PruebaDesarrollo.HumanResources.Domain.Repositories;
using PruebaDesarrollo.Shared.Infrastructure.Configuration;
using PruebaDesarrollo.Shared.Infrastructure.Repositories;

namespace PruebaDesarrollo.HumanResources.Infrastructure.Repositories;

public class ProvinciaRepository : BaseRepository<Provincia>, IProvinciaRepository
{
    public ProvinciaRepository(AppDbContext context) : base(context)
    {
    }
}