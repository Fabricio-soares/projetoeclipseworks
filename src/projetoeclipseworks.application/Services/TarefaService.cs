using AutoMapper;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Application.Dtos;

namespace projetoeclipseworks.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IMapper _mapper;

        public TarefaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Tarefa> CreateTarefaAsync(TarefaDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            var projeto = DataStore.Projetos.FirstOrDefault(p => p.Id == tarefaDto.ProjetoId);
            if (projeto == null)
            {
                throw new ArgumentNullException("Projeto não encontrado.");
            }

            if (projeto.Tarefas.Count >= 20)
            {
                throw new ArgumentNullException("Número máximo de tarefas atingido para este projeto.");
            }

            if (projeto.Status == (int)Util.Enums.StatusProjeto.Finalizado)
            {
                throw new ArgumentNullException("Não é possível adicionar tarefas a um projeto finalizado.");
            }


            projeto.Tarefas.Add(new Tarefa
            {
                Id = Guid.NewGuid(),
                Nome = tarefaDto.Nome,
                Nivel = (int)tarefaDto.Nivel,
                ProjetoId = tarefaDto.ProjetoId,
                UsuarioResponsavelId = tarefaDto.UsuarioResponsavelId,
                DataConclusao = tarefaDto.DataConclusao
            });
            DataStore.Tarefas.Add(new Tarefa
            {
                Id = Guid.NewGuid(),
                Nome = tarefaDto.Nome,
                Nivel = (int)tarefaDto.Nivel,
                ProjetoId = tarefaDto.ProjetoId,
                UsuarioResponsavelId = tarefaDto.UsuarioResponsavelId,
                DataConclusao = tarefaDto.DataConclusao
            });

            return tarefa;
        }

        public Task DeleteTarefa(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tarefa> GetTarefa(Guid id)
        {
            return DataStore.Tarefas.FirstOrDefault(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasAsync()
        {
            return DataStore.Tarefas.ToList();
        }

        public async Task UpdateTarefaStatusAsync(Guid id, AtualizacaoStatusTarefaDto atualizacaoDto)
        {
            
            var tarefa = DataStore.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                throw new ArgumentNullException("Tarefa não encontrado.");
            }

            tarefa.Finalizada = atualizacaoDto.Finalizada;
            tarefa.UsuarioResponsavelId = atualizacaoDto.UsuarioResponsavelId;
            tarefa.DataConclusao = atualizacaoDto.DataConclusao;
            foreach (var comentario in atualizacaoDto.Comentarios)
            {
                tarefa.Comentarios.Add(new Comentario { Descricao = comentario , Id = Guid.NewGuid(), IdTarefa = tarefa .Id});
            }


            tarefa.HistoricoAlteracoes.Add(new HistoricoAlteracao
            {
                DataAlteracao = DateTime.UtcNow,
                Alteracao = $"Status atualizado para {(atualizacaoDto.Finalizada ? "finalizada" : "pendente")}"
            });

            var projeto = DataStore.Projetos.FirstOrDefault(p => p.Id == tarefa.ProjetoId);
            if (projeto != null && projeto.Tarefas.All(t => t.Finalizada))
            {
                projeto.Status = (int)Util.Enums.StatusProjeto.Finalizado;
            }
        }
    }
}
