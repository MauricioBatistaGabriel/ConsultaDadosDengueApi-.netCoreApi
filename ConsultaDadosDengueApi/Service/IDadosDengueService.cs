using ConsultaDadosDengueApi.Model;

namespace ConsultaDadosDengueApi.Service
{
    public interface IDadosDengueService
    {
        Task<List<DadosDengueModel>> getDadosDengueSemana(int semana, int ano);
    }
}
