//using Microsoft.AspNetCore.Mvc;
//using projeto_eclipseworks.Controllers;
//using projeto_eclipseworks.Dtos;
//using projeto_eclipseworks.Model;
//using static projeto_eclipseworks.Util.Enums;

//namespace projeto_eclipseworks.Testes
//{
//    public class ProjetoControllerTests
//    {
//        [Fact]
//        public void CreateProjeto_ReturnsCreatedAtAction()
//        {
//            var MockMapper = new ProjetoModel();
//            // Arrange
//            var controller = new ProjetoController();
//            var projetoDto = new ProjetoDto { Nome = "Novo Projeto", Nivel = NivelPrioridade.Alto };

//            // Act
//            var result = controller.CreateProjeto(projetoDto);

//            // Assert
//            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
//            var projeto = Assert.IsType<ProjetoModel>(createdAtActionResult.Value);
//            Assert.Equal("Novo Projeto", projeto.Nome);
//            // Add more assertions as needed
//        }

//        [Fact]
//        public void DeleteProjeto_WithValidId_ReturnsNoContent()
//        {
//            // Arrange
//            var controller = new ProjetoController();
//            var projeto = new ProjetoModel { Id = Guid.NewGuid(), Nome = "Projeto Teste", Status = StatusProjeto.Pendente };
//            DataStore.Projetos.Add(projeto);

//            // Act
//            var result = controller.DeleteProjeto(projeto.Id);

//            // Assert
//            Assert.IsType<NoContentResult>(result);
//            Assert.DoesNotContain(projeto, DataStore.Projetos);
//        }

//        // Add more test methods for GetProjeto and GetProjetos
//    }

//    public class TarefaControllerTests
//    {
//        // Similar to ProjetoControllerTests, write tests for TarefaController methods
//    }
//}
