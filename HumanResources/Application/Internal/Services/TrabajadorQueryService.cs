using PruebaDesarrollo.HumanResources.Domain.Models.Queries;
using PruebaDesarrollo.HumanResources.Domain.Repositories;
using PruebaDesarrollo.HumanResources.Domain.Services;
using PruebaDesarrollo.HumanResources.Mapping;
using PruebaDesarrollo.HumanResources.Resources;
using PruebaDesarrollo.Shared.Domain.Repositories;

namespace PruebaDesarrollo.HumanResources.Application.Internal.Services
{
    public class TrabajadorQueryService : ITrabajadorQueryService
    {
        private readonly ITrabajadorRepository trabajadorRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrabajadorQueryService(ITrabajadorRepository trabajadorRepository, IUnitOfWork unitOfWork)
        {
            this.trabajadorRepository = trabajadorRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TrabajadorResource>?> Handle(GetAllTrabajadoresQuery query)
        {
            var trabajadores = await trabajadorRepository.ListEagerLoadAsync();

            if (trabajadores is null)
            {
                return null;
            }

            return trabajadores.Select(TrabajadorAssembler.FromEntityToResource).ToList();
        }
    }
}
