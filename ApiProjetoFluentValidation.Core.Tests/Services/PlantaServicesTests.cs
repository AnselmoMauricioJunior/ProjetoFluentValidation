using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Interfaces.Validations;
using ApiProjetoFluentValidation.Core.Models;
using ApiProjetoFluentValidation.Core.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApiProjetoFluentValidation.Core.Tests.Services
{
    public class PlantaServicesTests
    {
        private MockRepository mockRepository;

        private Mock<IPlantaRepository> mockPlantaRepository;
        private Mock<IPlantaValidation> mockPlantaValidation;

        public PlantaServicesTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockPlantaRepository = this.mockRepository.Create<IPlantaRepository>();
            this.mockPlantaValidation = this.mockRepository.Create<IPlantaValidation>();
        }

        private PlantaServices CreatePlantaServices()
        {
            return new PlantaServices(
                this.mockPlantaRepository.Object,
                this.mockPlantaValidation.Object);
        }

        [Fact(DisplayName = "Deve alterar a água de uma planta")]
        [Trait("AlterarAguaAsync", "altera a água de uma planta")]
        public async Task AlterarAguaAsync_Altera_Agua_De_Uma_Planta_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            Planta planta = new Planta("", 1, 1, 1);
            int id = 1000;
            int agua = 100;

            mockPlantaValidation.Setup(t => t.AlterarAguaValidateAsync(It.IsAny<Planta>()))
                .ReturnsAsync(new ValidationResult());

            mockPlantaRepository.Setup(t => t.AlterarAguaAsync(id, agua))
                .Returns(Task.CompletedTask);

            mockPlantaRepository.Setup(t => t.ObterPorIdAsync(id))
                .ReturnsAsync(planta);

            // Act
            var result = await plantaServices.AlterarAguaAsync(id, agua);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(result.Data, planta);

            mockPlantaValidation.Verify(t => t.AlterarAguaValidateAsync(It.IsAny<Planta>()), Times.Once);
            mockPlantaRepository.Verify(t => t.AlterarAguaAsync(id, agua), Times.Once);
            mockPlantaRepository.Verify(t => t.ObterPorIdAsync(id), Times.Once);
        }

        [Fact(DisplayName = "Deve alterar a luz diária de uma planta")]
        [Trait("AlterarLuzDiariaAsync", "altera a luz diária de uma planta")]
        public async Task AlterarLuzDiariaAsync_Altera_LuzDiaria_De_Uma_Planta_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            Planta planta = new Planta("", 1, 1, 1);
            int id = 1000;
            int luz = 100;

            mockPlantaValidation.Setup(t => t.AlterarLuzDiariaValidateAsync(It.IsAny<Planta>()))
                .ReturnsAsync(new ValidationResult());

            mockPlantaRepository.Setup(t => t.AlterarLuzDiariaAsync(id, luz))
                .Returns(Task.CompletedTask);

            mockPlantaRepository.Setup(t => t.ObterPorIdAsync(id))
                .ReturnsAsync(planta);

            // Act
            var result = await plantaServices.AlterarLuzDiariaAsync(id, luz);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(result.Data, planta);

            mockPlantaValidation.Verify(t => t.AlterarLuzDiariaValidateAsync(It.IsAny<Planta>()), Times.Once);
            mockPlantaRepository.Verify(t => t.AlterarLuzDiariaAsync(id, luz), Times.Once);
            mockPlantaRepository.Verify(t => t.ObterPorIdAsync(id), Times.Once);
        }

        [Fact(DisplayName = "Deve alterar o nome de uma planta")]
        [Trait("AlterarNomeAsync", "altera o nome de uma planta")]
        public async Task AlterarNomeAsync_Altera_Nome_De_Uma_Planta_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            Planta planta = new Planta("", 1, 1, 1);
            int id = 1000;
            string nome = "";

            mockPlantaValidation.Setup(t => t.AlterarNomeValidateAsync(It.IsAny<Planta>()))
                .ReturnsAsync(new ValidationResult());

            mockPlantaRepository.Setup(t => t.AlterarNomeAsync(id, nome))
                .Returns(Task.CompletedTask);

            mockPlantaRepository.Setup(t => t.ObterPorIdAsync(id))
                .ReturnsAsync(planta);

            // Act
            var result = await plantaServices.AlterarNomeAsync(id, nome);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(result.Data, planta);

            mockPlantaValidation.Verify(t => t.AlterarNomeValidateAsync(It.IsAny<Planta>()), Times.Once);
            mockPlantaRepository.Verify(t => t.AlterarNomeAsync(id, nome), Times.Once);
            mockPlantaRepository.Verify(t => t.ObterPorIdAsync(id), Times.Once);
        }

        [Fact(DisplayName = "Deve alterar o peso de uma planta")]
        [Trait("AlterarPesoAsync", "altera o peso de uma planta")]
        public async Task AlterarPesoAsync_Altera_O_Peso_De_Uma_Planta_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            Planta planta = new Planta("", 1, 1, 1);
            int id = 1000;
            int peso = 100;

            mockPlantaValidation.Setup(t => t.AlterarPesoValidateAsync(It.IsAny<Planta>()))
                .ReturnsAsync(new ValidationResult());

            mockPlantaRepository.Setup(t => t.AlterarPesoAsync(id, peso))
                .Returns(Task.CompletedTask);

            mockPlantaRepository.Setup(t => t.ObterPorIdAsync(id))
                .ReturnsAsync(planta);

            // Act
            var result = await plantaServices.AlterarPesoAsync(id,peso);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(result.Data, planta);

            mockPlantaValidation.Verify(t => t.AlterarPesoValidateAsync(It.IsAny<Planta>()), Times.Once);  
            mockPlantaRepository.Verify(t => t.AlterarPesoAsync(id, peso), Times.Once);           
            mockPlantaRepository.Verify(t => t.ObterPorIdAsync(id), Times.Once);
               
        }

        [Fact(DisplayName = "Deve criar uma nova planta")]
        [Trait("CriarAsync", "cria uma nova planta")]
        public async Task CriarAsync_Cria_Planta_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            Planta planta = new Planta("", 1, 1, 1);

            mockPlantaValidation.Setup(t => t.CriarValidateAsync(It.IsAny<Planta>()))
                .ReturnsAsync(new ValidationResult());

            mockPlantaRepository.Setup(t => t.CriarAsync(planta))
                .ReturnsAsync(0);

            mockPlantaRepository.Setup(t => t.ObterPorIdAsync(It.IsAny<int>()))
                .ReturnsAsync(planta);

            // Act
            var result = await plantaServices.CriarAsync(
                planta);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(result.Data, planta);
            mockPlantaValidation.Verify(t => t.CriarValidateAsync(It.IsAny<Planta>()), Times.Once);
            mockPlantaRepository.Verify(t => t.CriarAsync(planta),Times.Once);
            mockPlantaRepository.Verify(t => t.ObterPorIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Deve consultar todas as plantas com sucesso")]
        [Trait("ObterAsync", "Consulta todas as plantas")]
        public async Task ObterAsync_Consulta_Plantas_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            List<Planta> plantas = new  List<Planta>() {new Planta("", 1, 1, 1) };
          

            mockPlantaRepository.Setup(t => t.ObterAsync())
                .ReturnsAsync(plantas);

            // Act
            var result = await plantaServices.ObterAsync();

            // Assert
            Assert.Equal(result, plantas);
            mockPlantaRepository.Verify(t => t.ObterAsync(), Times.Once);
        }

        [Fact(DisplayName = "Deve consultar uma planta pelo id com sucesso")]
        [Trait("ObterPorIdAsync", "Consulta uma planta pelo id")]
        public async Task ObterPorIdAsync_Consulta_Planta_Pelo_Id_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            Planta planta = new Planta("", 1, 1, 1);
           

            mockPlantaRepository.Setup(t => t.ObterPorIdAsync(It.IsAny<int>()))
                .ReturnsAsync(planta);

            // Act
            var result = await plantaServices.ObterPorIdAsync(0);

            // Assert
            Assert.Equal(result, planta);
            mockPlantaRepository.Verify(t => t.ObterPorIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Deve remover uma planta pelo id com sucesso")]
        [Trait("RemoverAsync", "remove uma planta pelo id")]
        public async Task RemoverAsync_Remove_Planta_Pelo_Id_Com_Sucesso()
        {
            // Arrange
            var plantaServices = this.CreatePlantaServices();
            int id = 1000;

            mockPlantaValidation.Setup(t => t.RemoverValidateAsync(It.IsAny<Planta>()))
                .ReturnsAsync(new ValidationResult());

            mockPlantaRepository.Setup(t => t.RemoverAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await plantaServices.RemoverAsync(
                id);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(result.Data, id);
            mockPlantaValidation.Verify(t => t.RemoverValidateAsync(It.IsAny<Planta>()), Times.Once);
            mockPlantaRepository.Verify(t => t.RemoverAsync(id), Times.Once);
        }
    }
}
