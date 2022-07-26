using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Interfaces.Services;
using Funcionarios.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Funcionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly IFuncaoService _funcaoService;

        public FuncaoController(IFuncaoService funcaoService)
        {
            _funcaoService = funcaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cargos = await _funcaoService.GetAll();

                if (!cargos.Any()) return NotFound();

                return Ok(cargos);
            }
            catch (FuncaoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cargo = await _funcaoService.GetById(id);

                if (cargo == null) return NotFound();

                return Ok(cargo);
            }
            catch (FuncaoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCargo([FromBody] FuncaoDTO funcao)
        {
            try
            {
                if (funcao == null) return NoContent();

                var response = await _funcaoService.Add(funcao);

                if (response.IdRegistro > 0)
                    return StatusCode(StatusCodes.Status201Created, response.Mensagem);

                return Ok(response);
            }
            catch (FuncaoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCargo(int id, [FromBody] FuncaoDTO funcao)
        {
            try
            {
                if (funcao == null) return NoContent();

                var response = await _funcaoService.Update(id, funcao);

                return Ok(response);
            }
            catch (FuncaoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            try
            {
                var response = await _funcaoService.Delete(id);

                if (response == null)
                    return NotFound();

                if (response.IdRegistro == id)
                    return NoContent();

                return Ok(response);
            }
            catch (FuncaoControllerException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
