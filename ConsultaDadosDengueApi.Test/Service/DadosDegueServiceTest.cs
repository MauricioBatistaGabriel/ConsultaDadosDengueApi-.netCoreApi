using System.Net;
using ConsultaDadosDengueApi.Model;
using ConsultaDadosDengueApi.Service;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace ConsultaDadosDengueApi.Tests
{
    public class DadosDengueServiceTests
    {
        [Fact]
        public async Task GetDadosDengueSemana_ReturnsExpectedData()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var expectedData = new List<DadosDengueModel>
            {
                new DadosDengueModel { casos = 71, casos_est = 1208.5, nivel = 3, se = 202503 }
            };

            // Simular a resposta da API
            var responseContent = new StringContent(JsonConvert.SerializeObject(expectedData));
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = responseContent
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var service = new DadosDengueService(httpClient);

            // Act
            var result = await service.getDadosDengueSemana(3, 2025);

            // Assert
            Assert.Single(result);
            var resultItem = result.First();
            var expectedItem = expectedData.First();
            Assert.Equal(expectedItem.casos, resultItem.casos);
            Assert.Equal(expectedItem.casos_est, resultItem.casos_est);
            Assert.Equal(expectedItem.nivel, resultItem.nivel);
            Assert.Equal(expectedItem.se, resultItem.se);
        }


        [Fact]
        public async Task GetDadosDengueSemana_ThrowsExceptionOnHttpRequestError()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("Bad Request")
            };

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var service = new DadosDengueService(httpClient);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(() => service.getDadosDengueSemana(5, 2023));
            Assert.Contains("Status de requisição", exception.Message);
        }
    }
}
