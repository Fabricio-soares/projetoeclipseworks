using projeto_eclipseworks.Application.Dtos;
using projeto_eclipseworks.Dados.Entidades;

namespace projeto_eclipseworks.Application.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<Projeto> CreateProjeto(Projeto projetoDto);
        Task DeleteProjeto(Guid id);
        Task<Projeto> GetProjeto(Guid id);
        Task<IList<Projeto>> GetProjetos();
    }
}
