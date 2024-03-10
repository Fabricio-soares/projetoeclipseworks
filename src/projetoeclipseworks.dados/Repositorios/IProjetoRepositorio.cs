using projetoeclipseworks.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoeclipseworks.Dados.Repositorios
{
    public interface IProjetoRepositorio
    {
        Task<IEnumerable<Projeto>> GetAllEntities();

        Task<Projeto> GetEntityById(Guid id);

        Task<Projeto> CreateEntity(Projeto entity);

        Task<Projeto> UpdateEntity(Projeto entity);

        Task<bool> DeleteEntity(Guid id);
    }
}
