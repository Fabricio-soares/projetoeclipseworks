using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using projetoeclipseworks.Controllers;
using projetoeclipseworks.Application.Services.Interfaces;
using projetoeclipseworks.Dtos;
using projetoeclipseworks.Dados.Entidades;

namespace projetoeclipseworks.test.ControllerTeste
{
    public class ProjetoControllerTests
    {
        private readonly ProjetoController _controller;
        private readonly Mock<IProjetoService> _projetoServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public ProjetoControllerTests()
        {
            _projetoServiceMock = new Mock<IProjetoService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ProjetoController(_projetoServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateProjetoAsync_ValidInput_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var projetoDto = new ProjetoDto();
            var projeto = new Projeto();
            _mapperMock.Setup(m => m.Map<Projeto>(projetoDto)).Returns(projeto);
            _projetoServiceMock.Setup(p => p.CreateProjeto(projeto)).ReturnsAsync(projeto);

            // Act
            var result = await _controller.CreateProjetoAsync(projetoDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(projeto, createdAtActionResult.Value);
        }

        [Fact]
        public async Task DeleteProjetoAsync_ValidId_ReturnsNoContent()
        {
            // Arrange
            var id = Guid.NewGuid();
            _projetoServiceMock.Setup(p => p.DeleteProjeto(id)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteProjetoAsync(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetProjeto_ValidId_ReturnsOkObjectResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var projeto = new Projeto();
            _projetoServiceMock.Setup(p => p.GetProjeto(id)).ReturnsAsync(projeto);

            // Act
            var result = await _controller.GetProjeto(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(projeto, okObjectResult.Value);
        }

        [Fact]
        public async Task GetProjetos_ReturnsOkObjectResult()
        {
            // Arrange
            var projetos = new List<Projeto>();
            _projetoServiceMock.Setup(p => p.GetProjetos()).ReturnsAsync(projetos);

            // Act
            var result = await _controller.GetProjetos();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(projetos, okObjectResult.Value);
        }
    }
}



