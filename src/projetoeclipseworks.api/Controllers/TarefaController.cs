using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using projetoeclipseworks.Application.Dtos;
using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dtos;
using System;
using System.Linq;

namespace projetoeclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaService tarefaService, IMapper mapper)
        {
            _tarefaService = tarefaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Tarefa>> CreateTarefaAsync(TarefaDto tarefaDto)
        {
            try
            {
                var  tarefa = await _tarefaService.CreateTarefaAsync(tarefaDto);
                return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Atualiza o status de uma tarefa por ID.
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateTarefaStatusAsync(Guid id, AtualizacaoStatusTarefaDto atualizacaoDto)
        {
            try
            {
                var tarefa = await _tarefaService.UpdateTarefaStatusAsync(id,atualizacaoDto);
                if (tarefa == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        /// <summary>
        /// Obtém uma tarefa por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(Guid id)
        {
            try
            {
                var tarefa = await _tarefaService.GetTarefa(id);
                if (tarefa == null)
                {
                    return NotFound();
                }

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        /// <summary>
        /// Obtém todas as tarefas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefasAsync()
        {
            try
            {
                var tarefa =  await _tarefaService.GetTarefasAsync();
                if (tarefa == null)
                {
                    return NotFound();
                }

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta uma tarefa por ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaAsync(Guid id)
        {
            try
            {
                var tarefaSucesso = await _tarefaService.DeleteTarefa(id);
                if (!tarefaSucesso)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}




