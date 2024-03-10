using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Controllers;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dtos;

namespace projetoeclipseworks.test.ControllerTeste
{
    public class TarefaControllerTests
    {
        private readonly TarefaController _controller;
        private readonly Mock<ITarefaService> _tarefaServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public TarefaControllerTests()
        {
            _tarefaServiceMock = new Mock<ITarefaService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new TarefaController(_tarefaServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateTarefaAsync_ValidInput_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var tarefaDto = new TarefaDto();
            var tarefa = new Tarefa();
            _tarefaServiceMock.Setup(s => s.CreateTarefaAsync(tarefaDto)).ReturnsAsync(tarefa);

            // Act
            var result = await _controller.CreateTarefaAsync(tarefaDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(tarefa, createdAtActionResult.Value);
        }

        [Fact]
        public async Task UpdateTarefaStatusAsync_ValidId_ReturnsNoContent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var atualizacaoDto = new AtualizacaoStatusTarefaDto();
            _tarefaServiceMock.Setup(s => s.UpdateTarefaStatusAsync(id, atualizacaoDto)).ReturnsAsync(new Tarefa());

            // Act
            var result = await _controller.UpdateTarefaStatusAsync(id, atualizacaoDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetTarefa_ExistingId_ReturnsOkObjectResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var tarefa = new Tarefa();
            _tarefaServiceMock.Setup(s => s.GetTarefa(id)).ReturnsAsync(tarefa);

            // Act
            var result = await _controller.GetTarefa(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(tarefa, okObjectResult.Value);
        }

        [Fact]
        public async Task GetTarefa_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _tarefaServiceMock.Setup(s => s.GetTarefa(id)).ReturnsAsync((Tarefa)null);

            // Act
            var result = await _controller.GetTarefa(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetTarefasAsync_ReturnsOkObjectResult()
        {
            // Arrange
            var tarefas = new List<Tarefa>();
            _tarefaServiceMock.Setup(s => s.GetTarefasAsync()).ReturnsAsync(tarefas);

            // Act
            var result = await _controller.GetTarefasAsync();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(tarefas, okObjectResult.Value);
        }

        [Fact]
        public async Task DeleteTarefaAsync_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var id = Guid.NewGuid();
            _tarefaServiceMock.Setup(s => s.DeleteTarefa(id)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTarefaAsync(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTarefaAsync_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _tarefaServiceMock.Setup(s => s.DeleteTarefa(id)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteTarefaAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }



}