using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using projeto_eclipseworks.Application.Services.Interfaces;
using projeto_eclipseworks.Dados.Entidades;
using projeto_eclipseworks.Dtos;

namespace projeto_eclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;
        public ProjetoController(IProjetoService projetoService, IMapper mapper)
        {
            _projetoService = projetoService;
            _mapper = mapper;
        }
        /// <summary>
        /// Cria um novo projeto.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Projeto>> CreateProjetoAsync(ProjetoDto projetoDto)
        {
            try
            {
                var projeto = await _projetoService.CreateProjeto(_mapper.Map<Projeto>(projetoDto));
                return CreatedAtAction(nameof(GetProjeto), new { id = projeto.Id }, projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta um projeto por ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjetoAsync(Guid id)
        {
            try
            {
                await _projetoService.DeleteProjeto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtém um projeto por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(Guid id)
        {
            try
            {
                return Ok(await _projetoService.GetProjeto(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        /// <summary>
        /// Obtém todos os projetos.
        /// </summary>
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            try
            {
                return Ok(await _projetoService.GetProjetos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }

        }
    }
}



