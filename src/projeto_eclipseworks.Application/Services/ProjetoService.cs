﻿using projeto_eclipseworks.Application.Dtos;
using projeto_eclipseworks.Application.Services.Interfaces;
using projeto_eclipseworks.Dados.Entidades;
using projeto_eclipseworks.Dados.Repositorios;
using static projeto_eclipseworks.Util.Enums;

namespace projeto_eclipseworks.Application.Services
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

                //DataStore.Projetos.Add(projeto);

                return projeto;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task DeleteProjeto(Guid id)
        {
            var projeto = DataStore.Projetos.FirstOrDefault(p => p.Id == id);
            if (projeto != null)
            {
                if (projeto.Tarefas.Any(t => !t.Finalizada))
                {
                    throw new ArgumentNullException("Não é possível excluir um projeto com tarefas pendentes.");
                }
                // Verifica se há tarefas pendentes no projeto

                DataStore.Projetos.Remove(projeto);
            }
        }

        public async Task<Projeto> GetProjeto(Guid id)
        {
           return DataStore.Projetos.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IList<Projeto>> GetProjetos()
        {
            return DataStore.Projetos.ToList();
        }
    }
}