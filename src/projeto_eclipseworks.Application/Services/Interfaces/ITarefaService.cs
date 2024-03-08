using projeto_eclipseworks.Application.Dtos;
using projeto_eclipseworks.Dados.Entidades;
using projeto_eclipseworks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_eclipseworks.Application.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<Tarefa> CreateTarefaAsync(TarefaDto tarefaDto);
        Task UpdateTarefaStatusAsync(Guid id, AtualizacaoStatusTarefaDto atualizacaoDto);
        Task<Tarefa> GetTarefa(Guid id);
        Task<IEnumerable<Tarefa>> GetTarefasAsync();
        Task DeleteTarefa(Guid id);
    }
}
