using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Interfaces.Services;
using Funcionarios.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Funcionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cargos = await _cargoService.GetAll();

                if(!cargos.Any()) return NotFound();

                return Ok(cargos);
            }
            catch (CargoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cargo = await _cargoService.GetById(id);

                if (cargo == null) return NotFound();

                return Ok(cargo);
            }
            catch (CargoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCargo([FromBody] CargoDTO cargo)
        {
            try
            {
                if(cargo == null) return NoContent();

                var response = await _cargoService.Add(cargo);

                if (response.IdRegistro > 0) 
                    return StatusCode(StatusCodes.Status201Created, response.Mensagem);

                return Ok(response);
            }
            catch (CargoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCargo(int id, [FromBody] CargoDTO cargo)
        {
            try
            {
                if (cargo == null) return NoContent();

                var response = await _cargoService.Update(id, cargo);

                return Ok(response);
            }
            catch (CargoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            try
            {
                var response = await _cargoService.Delete(id);

                if(response == null)
                    return NotFound();

                if (response.IdRegistro == id)
                    return NoContent();

                return Ok(response);
            }
            catch (CargoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
