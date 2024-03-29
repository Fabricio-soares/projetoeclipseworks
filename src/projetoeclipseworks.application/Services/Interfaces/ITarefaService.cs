﻿using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dtos;

namespace projetoeclipseworks.Application.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<Tarefa> CreateTarefaAsync(TarefaDto tarefaDto);
        Task<Tarefa> UpdateTarefaStatusAsync(Guid id, AtualizacaoStatusTarefaDto atualizacaoDto);
        Task<Tarefa> GetTarefa(Guid id);
        Task<IEnumerable<Tarefa>> GetTarefasAsync();
        Task<bool> DeleteTarefa(Guid id);
    }
}
