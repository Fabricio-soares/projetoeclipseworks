//using Microsoft.AspNetCore.Mvc;
//using OrganizacaoTarefas.Models;
//using projeto_eclipseworks.Controllers;
//using projeto_eclipseworks.Dtos;
//using static projeto_eclipseworks.Util.Enums;

//namespace projeto_eclipseworks.Tests
//{
//    public class TarefaControllerTests
//    {
//        private readonly TarefaController _controller;

//        public TarefaControllerTests()
//        {
//            _controller = new TarefaController();
//        }

//        [Fact]
//        public void CreateTarefa_ReturnsCreatedResponse()
//        {
//            // Arrange
//            var tarefaDto = new TarefaDto { Nome = "Nova Tarefa", Nivel = NivelPrioridade.Baixo, ProjetoId = Guid.NewGuid() };

//            // Act
//            var result = _controller.CreateTarefa(tarefaDto);

//            // Assert
//            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
//            var tarefa = Assert.IsType<TarefaModel>(createdResult.Value);
//            Assert.Equal(tarefaDto.Nome, tarefa.Nome);
//            // Adicione mais asserções conforme necessário
//        }

      
//    }
//}
