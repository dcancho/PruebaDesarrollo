using PruebaDesarrollo.HumanResources.Domain.Models.ValueObjects;
using PruebaDesarrollo.HumanResources.Domain.Repositories;
using PruebaDesarrollo.Shared.Infrastructure.Configuration;
using PruebaDesarrollo.Shared.Infrastructure.Repositories;

namespace PruebaDesarrollo.HumanResources.Infrastructure.Repositories;

public class DistritoRepository : BaseRepository<Distrito>, IDistritoRepository 
{
    public DistritoRepository(AppDbContext context) : base(context)
    {
    }
}