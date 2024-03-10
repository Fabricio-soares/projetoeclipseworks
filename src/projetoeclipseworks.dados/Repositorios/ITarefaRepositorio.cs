using projetoeclipseworks.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoeclipseworks.Dados.Repositorios
{
    public interface ITarefaRepositorio
    {
        Task<IEnumerable<Tarefa>> GetAllEntities();

        Task<Tarefa> GetEntityById(Guid id);

        Task<Tarefa> CreateEntity(Tarefa entity);

        Task<Tarefa> UpdateEntity(Tarefa entity);

        Task<bool> DeleteEntity(Guid id);
    }
}
