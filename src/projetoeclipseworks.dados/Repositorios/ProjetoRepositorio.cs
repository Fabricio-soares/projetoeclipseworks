using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace projetoeclipseworks.Dados.Repositorios
{
        public class ProjetoRepositorio : IProjetoRepositorio
    {
            private readonly IRepository<Projeto> _repository;

            public ProjetoRepositorio(IRepository<Projeto> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Projeto>> GetAllEntities()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Projeto> GetEntityById(int id)
            {
                return await _repository.GetByIdAsync(id);
            }

            public async Task<Projeto> CreateEntity(Projeto entity)
            {
                return await _repository.AddAsync(entity);
            }

            public async Task<Projeto> UpdateEntity(Projeto entity)
            {
                return await _repository.UpdateAsync(entity);
            }

            public async Task<bool> DeleteEntity(int id)
            {
                return await _repository.DeleteAsync(id);
            }
        }

}
