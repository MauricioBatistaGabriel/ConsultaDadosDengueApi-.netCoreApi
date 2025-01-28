using ConsultaDadosDengueApi.Model;
using ConsultaDadosDengueApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaDadosDengueApi.Controllers
{

    [ApiController]
    [Route("/api/consulta_dados_dengue/semana")]
    public class DadosDengueController
    {
        private readonly IDadosDengueService _dadosDengueService;
        public DadosDengueController(IDadosDengueService dadosDengueService)
        {
            _dadosDengueService = dadosDengueService;
        }

        [HttpGet]
        public async Task<List<DadosDengueModel>> GetDadosDengueSemana([FromQuery] int semana, [FromQuery] int ano)
        {
            return await _dadosDengueService.getDadosDengueSemana(semana, ano);
        }
    }
}
