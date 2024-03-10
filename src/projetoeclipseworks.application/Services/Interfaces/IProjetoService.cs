using projetoeclipseworks.Dados.Entidades;

namespace projetoeclipseworks.Application.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<Projeto> CreateProjeto(Projeto projetoDto);
        Task DeleteProjeto(Guid id);
        Task<Projeto> GetProjeto(Guid id);
        Task<IEnumerable<Projeto>> GetProjetos();
    }
}
