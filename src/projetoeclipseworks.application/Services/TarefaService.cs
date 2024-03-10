﻿using AutoMapper;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Application.Dtos;
using projetoeclipseworks.Dados.Repositorios;

namespace projetoeclipseworks.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IMapper _mapper;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly IProjetoRepositorio _projetoRepositorio;

        public TarefaService(IMapper mapper, ITarefaRepositorio tarefaService, IProjetoRepositorio projetoService)
        {
            _mapper = mapper;
            _tarefaRepositorio = tarefaService;
            _projetoRepositorio = projetoService;
        }

        public async Task<Tarefa> CreateTarefaAsync(TarefaDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            var projeto = await _projetoRepositorio.GetEntityById(tarefaDto.ProjetoId);
            if (projeto == null)
            {
                throw new ArgumentNullException("Projeto não encontrado.");
            }

            if (projeto.Tarefas != null && projeto.Tarefas.Count >= 20)
            {
                throw new ArgumentNullException("Número máximo de tarefas atingido para este projeto.");
            }

            if (projeto.Status == (int)Util.Enums.StatusProjeto.Finalizado)
            {
                throw new ArgumentNullException("Não é possível adicionar tarefas a um projeto finalizado.");
            }

            var tarefaEntity = new Tarefa
            {
                Id = Guid.NewGuid(),
                Nome = tarefaDto.Nome,
                Nivel = (int)tarefaDto.Nivel,
                ProjetoId = tarefaDto.ProjetoId,
                UsuarioResponsavelId = tarefaDto.UsuarioResponsavelId,
                DataConclusao = tarefaDto.DataConclusao
            };

            await _tarefaRepositorio.CreateEntity(tarefaEntity);
            return tarefa;
        }

        public async Task DeleteTarefa(Guid id)
        {
            await _tarefaRepositorio.DeleteEntity(id);
        }

        public async Task<Tarefa> GetTarefa(Guid id)
        {
            return await _tarefaRepositorio.GetEntityById(id);
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasAsync()
        {
            return await _tarefaRepositorio.GetAllEntities();
        }

        public async Task UpdateTarefaStatusAsync(Guid id, AtualizacaoStatusTarefaDto atualizacaoDto)
        {

            var tarefa = await _tarefaRepositorio.GetEntityById(id);
            if (tarefa == null)
            {
                throw new ArgumentNullException("Tarefa não encontrado.");
            }

            tarefa.Finalizada = atualizacaoDto.Finalizada;
            tarefa.UsuarioResponsavelId = atualizacaoDto.UsuarioResponsavelId;
            tarefa.DataConclusao = atualizacaoDto.DataConclusao;
            foreach (var comentario in atualizacaoDto.Comentarios)
            {
                tarefa.Comentarios.Add(new Comentario { Descricao = comentario, Id = Guid.NewGuid(), IdTarefa = tarefa.Id });
            }


            tarefa.HistoricoAlteracoes.Add(new HistoricoAlteracao
            {
                DataAlteracao = DateTime.UtcNow,
                Alteracao = $"Status atualizado para {(atualizacaoDto.Finalizada ? "finalizada" : "pendente")}"
            });

            var projeto = await _projetoRepositorio.GetEntityById(tarefa.ProjetoId);
            if (projeto != null && projeto.Tarefas.All(t => t.Finalizada))
            {
                projeto.Status = (int)Util.Enums.StatusProjeto.Finalizado;
                await _projetoRepositorio.UpdateEntity(projeto);
            }
        }
    }
}