using ConsultaDadosDengueApi.Controllers;
using ConsultaDadosDengueApi.Model;
using ConsultaDadosDengueApi.Service;
using Moq;

namespace ConsultaDadosDengueApi.Test.Controller
{
    public class DadosDengueControllerTests
    {
        [Fact]
        public async void GetDadosDengueSemana_ReturnsExpectedData()
        {
            // Arrange
            var mockService = new Mock<IDadosDengueService>();
            var expectedData = new List<DadosDengueModel>
            {
                new DadosDengueModel { casos = 100, casos_est = 150, nivel = 3, se = 202502 },
                new DadosDengueModel { casos = 200, casos_est = 250, nivel = 4, se = 202503 }
            };
            mockService.Setup(service => service.getDadosDengueSemana(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(expectedData);

            var controller = new DadosDengueController(mockService.Object);

            // Act
            var result = await controller.GetDadosDengueSemana(5, 2023);

            // Assert
            Assert.Equal(expectedData, result);
        }
    }
}
