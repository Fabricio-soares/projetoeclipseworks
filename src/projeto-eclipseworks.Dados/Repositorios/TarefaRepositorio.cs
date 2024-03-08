using projeto_eclipseworks.Dados.Entidades;
using projeto_eclipseworks.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace projeto_eclipseworks.Dados.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
            private readonly IRepository<Tarefa> _repository;

        public TarefaRepositorio(IRepository<Tarefa> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tarefa>> GetAllEntities()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tarefa> GetEntityById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Tarefa> CreateEntity(Tarefa entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<Tarefa> UpdateEntity(Tarefa entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteEntity(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}
