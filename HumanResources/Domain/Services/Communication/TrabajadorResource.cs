using PruebaDesarrollo.HumanResources.Resources;
using PruebaDesarrollo.Shared.Domain.Services.Communication;

namespace PruebaDesarrollo.HumanResources.Domain.Services.Communication
{
    public class TrabajadorResponse : BaseResponse<TrabajadorResource>
    {
        public TrabajadorResponse(TrabajadorResource resource) : base(resource)
        {
        }

        public TrabajadorResponse(string message) : base(message)
        {
        }
    }
}