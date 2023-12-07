using Microsoft.AspNetCore.Mvc;
using PruebaDesarrollo.HumanResources.Domain.Models.Commands;
using PruebaDesarrollo.HumanResources.Domain.Models.Queries;
using PruebaDesarrollo.HumanResources.Domain.Services;
using PruebaDesarrollo.HumanResources.Domain.Services.Communication;
using PruebaDesarrollo.HumanResources.Mapping;
using PruebaDesarrollo.HumanResources.Resources;
using PruebaDesarrollo.Shared.Infrastructure.Configuration.Extensions;

namespace PruebaDesarrollo.HumanResources.Controllers
{
    [Route(template: "api/v1/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorCommandService _trabajadorCommandService;
        private readonly ITrabajadorQueryService _trabajadorQueryService;

        public TrabajadorController(ITrabajadorCommandService trabajadorCommandService, ITrabajadorQueryService trabajadorQueryService)
        {
            _trabajadorCommandService = trabajadorCommandService;
            _trabajadorQueryService = trabajadorQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            try
            {
                var trabajadores = await _trabajadorQueryService.Handle(new GetAllTrabajadoresQuery());

                if (trabajadores is null)
                {
                    return NotFound();
                }

                return Ok(trabajadores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TrabajadorResponse(ex.Message));
            }
        }

        [HttpPost]
        [Route(template: "register")]
        public async Task<IActionResult> AddAsync([FromBody] SaveTrabajadorResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new TrabajadorResponse(ModelState.GetErrorMessages().ToString() ?? ""));
            }

            try
            {
                var result = await _trabajadorCommandService.Handle(TrabajadorAssembler.SaveResourceToAddCommand(resource));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TrabajadorResponse(ex.Message));
            }

        }

        [HttpPut]
        [Route(template: "update/{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateTrabajadorResource resource, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new TrabajadorResponse(ModelState.GetErrorMessages().ToString() ?? ""));
            }

            var result = await _trabajadorCommandService.Handle(TrabajadorAssembler.UpdateResourceToUpdateCommand(resource, id));

            if (result is null)
            {
                return BadRequest(new TrabajadorResponse("Error al actualizar el trabajador."));
            }

            return Ok(new TrabajadorResponse(result));
        }

        [HttpDelete]
        [Route(template: "remove/{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            var result = await _trabajadorCommandService.Handle(new DeleteTrabajadorCommand(id));
            if (result is null)
            {
                return BadRequest(new TrabajadorResponse("Error al eliminar el trabajador."));
            }

            return Ok(new TrabajadorResponse(result));
        }
    }
}
