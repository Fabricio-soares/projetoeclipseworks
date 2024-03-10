﻿using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dados.Repositorios;
using static projetoeclipseworks.Application.Util.Enums;

namespace projetoeclipseworks.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepositorio _projetoRepositorio;

        public ProjetoService(IProjetoRepositorio projetoRepositorio)
        {
            _projetoRepositorio = projetoRepositorio;
        }

        public async Task<Projeto> CreateProjeto(Projeto projetoDto)
        {
            try
            {
                var projeto = new Projeto
                {
                    Id = Guid.NewGuid(),
                    Nome = projetoDto.Nome,
                    Nivel = (int)projetoDto.Nivel,
                    Status = (int)StatusProjeto.Pendente
                };

             

                await _projetoRepositorio.CreateEntity(projeto);

                return projeto;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task DeleteProjeto(Guid id)
        {
            var projeto = await _projetoRepositorio.GetEntityById(id);
            if (projeto != null)
            {
                if (projeto.Tarefas != null && projeto.Tarefas.Any(t => !t.Finalizada))
                {
                    throw new ArgumentNullException("Não é possível excluir um projeto com tarefas pendentes.");
                }
                await _projetoRepositorio.DeleteEntity(projeto.Id);
            }
        }

        public async Task<Projeto> GetProjeto(Guid id)
        {
            return await _projetoRepositorio.GetEntityById(id);
        }

        public async Task<IEnumerable<Projeto>> GetProjetos()
        {
            return await _projetoRepositorio.GetAllEntities();
        }
    }
}
