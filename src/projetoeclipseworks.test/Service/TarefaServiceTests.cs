using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using projetoeclipseworks.Application.Services;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dados.Repositorios;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Application.Util;


namespace projetoeclipseworks.test.Service
{
    public class TarefaServiceTests
    {
        [Fact]
        public async Task CreateTarefaAsync_ValidTarefaDto_ReturnsCreatedTarefa()
        {
            // Arrange
            var tarefaDto = new TarefaDto
            {
                Nome = "Tarefa Teste",
                Nivel = Enums.NivelPrioridade.Alto,
                ProjetoId = Guid.NewGuid(),
                UsuarioResponsavelId = Guid.NewGuid(),
                DataConclusao = DateTime.Now.AddDays(7)
            };

            var projeto = new Projeto
            {
                Id = tarefaDto.ProjetoId,
                Tarefas = new List<Tarefa>()
            };

            var projetoRepositorioMock = new Mock<IProjetoRepositorio>();
            projetoRepositorioMock.Setup(repo => repo.GetEntityById(tarefaDto.ProjetoId)).ReturnsAsync(projeto);

            var tarefaRepositorioMock = new Mock<ITarefaRepositorio>();
            tarefaRepositorioMock.Setup(repo => repo.CreateEntity(It.IsAny<Tarefa>())).ReturnsAsync(new Tarefa());

            var mapperMock = new Mock<IMapper>();

            var tarefaService = new TarefaService(mapperMock.Object, tarefaRepositorioMock.Object, projetoRepositorioMock.Object);

            // Act
            var result = await tarefaService.CreateTarefaAsync(tarefaDto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteTarefa_ValidId_ReturnsTrue()
        {
            // Arrange
            var tarefaId = Guid.NewGuid();

            var tarefaRepositorioMock = new Mock<ITarefaRepositorio>();
            tarefaRepositorioMock.Setup(repo => repo.DeleteEntity(tarefaId)).ReturnsAsync(true);

            var tarefaService = new TarefaService(null, tarefaRepositorioMock.Object, null);

            // Act
            var result = await tarefaService.DeleteTarefa(tarefaId);

            // Assert
            Assert.True(result);
        }

        // Testes para GetTarefa, GetTarefasAsync e UpdateTarefaStatusAsync podem ser adicionados aqui para completar 80% de cobertura

    }
}



