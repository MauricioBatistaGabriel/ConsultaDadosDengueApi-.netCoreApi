using ConsultaDadosDengueApi.Model;
using Newtonsoft.Json;

namespace ConsultaDadosDengueApi.Service
{
    public class DadosDengueService : IDadosDengueService
    {
        private readonly HttpClient _httpClient;

        public DadosDengueService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DadosDengueModel>> getDadosDengueSemana(int semana, int ano)
        {
            string api = $"https://info.dengue.mat.br/api/alertcity?geocode=3106200&disease=dengue&format=json&ew_start={semana}&ew_end={semana}&ey_start={ano}&ey_end={ano}";

            var response = await _httpClient.GetAsync(api);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status de requisição: {response.StatusCode}");
            }

            var content = response.Content.ReadAsStringAsync();

            if (content == null)
            {
                throw new Exception("o conteúdo é nulo");
            }

            List<DadosDengueModel>? data = JsonConvert.DeserializeObject<List<DadosDengueModel>>(await content);

            return data ?? throw new Exception("Data is null");
        }
    }
}
