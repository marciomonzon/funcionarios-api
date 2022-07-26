using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Interfaces.Services;
using Funcionarios.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Funcionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioCLTController : ControllerBase
    {
        private readonly IFuncionarioCLTService _funcionarioService;

        public FuncionarioCLTController(IFuncionarioCLTService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cargos = await _funcionarioService.GetAll();

                if (!cargos.Any()) return NotFound();

                return Ok(cargos);
            }
            catch (FuncionarioCLTControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cargo = await _funcionarioService.GetById(id);

                if (cargo == null) return NotFound();

                return Ok(cargo);
            }
            catch (FuncionarioCLTControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCargo([FromBody] FuncionarioCltDTO funcionario)
        {
            try
            {
                if (funcionario == null) return NoContent();

                var response = await _funcionarioService.Add(funcionario);

                if (response.IdRegistro > 0)
                    return StatusCode(StatusCodes.Status201Created, response.Mensagem);

                return Ok(response);
            }
            catch (FuncionarioCLTControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCargo(int id, [FromBody] FuncionarioCltDTO funcionario)
        {
            try
            {
                if (funcionario == null) return NoContent();

                var response = await _funcionarioService.Update(id, funcionario);

                return Ok(response);
            }
            catch (FuncionarioCLTControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            try
            {
                var response = await _funcionarioService.Delete(id);

                if (response == null)
                    return NotFound();

                if (response.IdRegistro == id)
                    return NoContent();

                return Ok(response);
            }
            catch (FuncionarioCLTControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
