using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using projetoeclipseworks.Application.Dtos;
using projetoeclipseworks.Application.Services.Interfaces;
using System;
using System.Linq;

namespace projetoeclipseworks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITarefaService _tarefaService;
        public RelatorioController(IMapper mapper, ITarefaService tarefaService)
        {
            _mapper = mapper;
            _tarefaService = tarefaService;
        }

        /// <summary>
        /// Gera o relatório do número médio de tarefas concluídas por usuário nos últimos 30 dias.
        /// </summary>
        [HttpGet("media-tarefas-concluidas-por-usuario")]
        public async Task<IActionResult> MediaTarefasConcluidasPorUsuarioNosUltimos30Dias()
        {
            var dataLimite = DateTime.UtcNow.AddDays(-30);
            var tarefasConcluidasPorUsuario = new Dictionary<Guid, int>(); // Dicionário para armazenar o número de tarefas concluídas por usuário

            // Itera sobre as tarefas e conta quantas tarefas foram concluídas por cada usuário nos últimos 30 dias
            foreach (var tarefa in await _tarefaService.GetTarefasAsync())
            {
                if (tarefa.Finalizada && tarefa.DataConclusao >= dataLimite)
                {
                    if (tarefasConcluidasPorUsuario.ContainsKey(tarefa.UsuarioResponsavelId))
                    {
                        tarefasConcluidasPorUsuario[tarefa.UsuarioResponsavelId]++;
                    }
                    else
                    {
                        tarefasConcluidasPorUsuario[tarefa.UsuarioResponsavelId] = 1;
                    }
                }
            }

            var mediaTarefasConcluidas = new List<object>(); // Lista para armazenar os resultados finais

            // Calcula a média diária de tarefas concluídas para cada usuário
            foreach (var usuarioId in tarefasConcluidasPorUsuario.Keys)
            {
                var mediaTarefas = (double)tarefasConcluidasPorUsuario[usuarioId] / 30;
                mediaTarefasConcluidas.Add(new { UsuarioId = usuarioId, MediaTarefasConcluidas = mediaTarefas });
            }

            return Ok(mediaTarefasConcluidas);
        }
    }
}


