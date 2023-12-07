using PruebaDesarrollo.HumanResources.Domain.Models.Commands;
using PruebaDesarrollo.HumanResources.Domain.Repositories;
using PruebaDesarrollo.HumanResources.Domain.Services;
using PruebaDesarrollo.HumanResources.Mapping;
using PruebaDesarrollo.HumanResources.Resources;
using PruebaDesarrollo.Shared.Domain.Repositories;

namespace PruebaDesarrollo.HumanResources.Application.Internal.Services
{
    public class TrabajadorCommandService : ITrabajadorCommandService
    {
        private readonly ITrabajadorRepository _trabajadorRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IProvinciaRepository _provinciaRepository;
        private readonly IDistritoRepository _distritoRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public TrabajadorCommandService(ITrabajadorRepository trabajadorRepository, IDepartamentoRepository departamentoRepository, IProvinciaRepository provinciaRepository, IDistritoRepository distritoRepository, IUnitOfWork unitOfWork)
        {
            _trabajadorRepository = trabajadorRepository;
            _departamentoRepository = departamentoRepository;
            _provinciaRepository = provinciaRepository;
            _distritoRepository = distritoRepository;
            _unitOfWork = unitOfWork;
        }

        private void ValidateAdministrativeAreas(int departamento, int provincia, int distrito)
        {
            var existingDepartamento = _departamentoRepository.FindByIdAsync(departamento).Result;
            if (existingDepartamento is null)
            {
                throw new Exception($"Departamento con ID {departamento} no encontrado.");
            }

            var existingProvincia = _provinciaRepository.FindByIdAsync(provincia).Result;
            if (existingProvincia is null)
            {
                throw new Exception($"Provincia con ID {provincia} no encontrada.");
            }

            var existingDistrito = _distritoRepository.FindByIdAsync(distrito).Result;
            if (existingDistrito is null)
            {
                throw new Exception($"Distrito con ID {distrito} no encontrado.");
            }
        }

        public async Task<TrabajadorResource?> Handle(AddTrabajadorCommand command)
        {
            var existingTrabajador = await _trabajadorRepository.FindByDniAsync(command.NumeroDocumento);
            if (existingTrabajador is not null)
            {
                return null;
            }
            
            
            ValidateAdministrativeAreas(command.IdDepartamento, command.IdProvincia, command.IdDistrito);

            var trabajador = TrabajadorAssembler.FromAddCommandToEntity(command);
            trabajador.Departamento = await _departamentoRepository.FindByIdAsync(command.IdDepartamento);
            trabajador.Provincia = await _provinciaRepository.FindByIdAsync(command.IdProvincia);
            trabajador.Distrito = await _distritoRepository.FindByIdAsync(command.IdDistrito);

            try
            {
                await _trabajadorRepository.AddAsync(trabajador);
                await _unitOfWork.CompleteAsync();
                
                trabajador = await _trabajadorRepository.FindByIdEagerLoadAsync(trabajador.Id);

                return TrabajadorAssembler.FromEntityToResource(trabajador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrabajadorResource?> Handle(UpdateTrabajadorCommand command)
        {
            var existingTrabajador = await _trabajadorRepository.FindByIdEagerLoadAsync(command.Id);
            if (existingTrabajador is null)
            {
                return null;
            }

            var trabajador = TrabajadorAssembler.FromUpdateCommandToEntity(command, existingTrabajador);

            try
            {
                _trabajadorRepository.Update(TrabajadorAssembler.FromUpdateCommandToEntity(command, existingTrabajador));
                await _unitOfWork.CompleteAsync();
                
                return TrabajadorAssembler.FromEntityToResource(trabajador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrabajadorResource?> Handle(DeleteTrabajadorCommand command)
        {
            var existingTrabajador = await _trabajadorRepository.FindByIdEagerLoadAsync(command.Id);
            if (existingTrabajador == null)
            {
                throw new Exception($"Trabajador con ID {command.Id} no encontrado.");
            }

            var resource = TrabajadorAssembler.FromEntityToResource(existingTrabajador);

            try
            {
                _trabajadorRepository.Remove(existingTrabajador);
                await _unitOfWork.CompleteAsync();

                return resource;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
