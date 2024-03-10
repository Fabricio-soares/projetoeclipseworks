using Moq;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetoeclipseworks.Application.Services;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dados.Repositorios;
using static projetoeclipseworks.Application.Util.Enums;

namespace projetoeclipseworks.test.Service
{
    public class ProjetoServiceTests
    {
        [Fact]
        public async Task CreateProjeto_ValidProjeto_ReturnsCreatedProjeto()
        {
            // Arrange
            var projetoDto = new Projeto
            {
                Nome = "Projeto Teste",
                Nivel = 1
            };

            var projetoRepositorioMock = new Mock<IProjetoRepositorio>();
            projetoRepositorioMock.Setup(repo => repo.CreateEntity(It.IsAny<Projeto>())).ReturnsAsync(new Projeto());

            var projetoService = new ProjetoService(projetoRepositorioMock.Object);

            // Act
            var result = await projetoService.CreateProjeto(projetoDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projetoDto.Nome, result.Nome);
            Assert.Equal(projetoDto.Nivel, result.Nivel);
            Assert.Equal(StatusProjeto.Pendente, (StatusProjeto)result.Status);
        }

        [Fact]
        public async Task DeleteProjeto_ValidIdWithNoTarefas_ReturnsSuccessful()
        {
            // Arrange
            var projetoId = Guid.NewGuid();
            var projeto = new Projeto { Id = projetoId, Tarefas = new List<Tarefa>() };

            var projetoRepositorioMock = new Mock<IProjetoRepositorio>();
            projetoRepositorioMock.Setup(repo => repo.GetEntityById(projetoId)).ReturnsAsync(projeto);
            projetoRepositorioMock.Setup(repo => repo.DeleteEntity(projetoId)).ReturnsAsync(true);

            var projetoService = new ProjetoService(projetoRepositorioMock.Object);

            // Act
            await projetoService.DeleteProjeto(projetoId);

            // Assert
            projetoRepositorioMock.Verify(repo => repo.DeleteEntity(projetoId), Times.Once);
        }

        [Fact]
        public async Task DeleteProjeto_ValidIdWithTarefasPending_ThrowsException()
        {
            // Arrange
            var projetoId = Guid.NewGuid();
            var tarefa = new Tarefa { Finalizada = false };
            var projeto = new Projeto { Id = projetoId, Tarefas = new List<Tarefa> { tarefa } };

            var projetoRepositorioMock = new Mock<IProjetoRepositorio>();
            projetoRepositorioMock.Setup(repo => repo.GetEntityById(projetoId)).ReturnsAsync(projeto);

            var projetoService = new ProjetoService(projetoRepositorioMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await projetoService.DeleteProjeto(projetoId));
        }

        [Fact]
        public async Task GetProjeto_ValidId_ReturnsProjeto()
        {
            // Arrange
            var projetoId = Guid.NewGuid();
            var projeto = new Projeto { Id = projetoId };

            var projetoRepositorioMock = new Mock<IProjetoRepositorio>();
            projetoRepositorioMock.Setup(repo => repo.GetEntityById(projetoId)).ReturnsAsync(projeto);

            var projetoService = new ProjetoService(projetoRepositorioMock.Object);

            // Act
            var result = await projetoService.GetProjeto(projetoId);

            // Assert
            Assert.Equal(projeto, result);
        }

        [Fact]
        public async Task GetProjetos_ReturnsListOfProjetos()
        {
            // Arrange
            var projetos = new List<Projeto> { new Projeto(), new Projeto() };

            var projetoRepositorioMock = new Mock<IProjetoRepositorio>();
            projetoRepositorioMock.Setup(repo => repo.GetAllEntities()).ReturnsAsync(projetos);

            var projetoService = new ProjetoService(projetoRepositorioMock.Object);

            // Act
            var result = await projetoService.GetProjetos();

            // Assert
            Assert.Equal(projetos, result);
        }
    }
}



