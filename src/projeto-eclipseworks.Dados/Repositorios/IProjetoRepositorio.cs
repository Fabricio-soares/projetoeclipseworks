using projeto_eclipseworks.Dados.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_eclipseworks.Dados.Repositorios
{
    public interface IProjetoRepositorio
    {
        Task<Projeto> CreateEntity(Projeto entity);
    }
}
