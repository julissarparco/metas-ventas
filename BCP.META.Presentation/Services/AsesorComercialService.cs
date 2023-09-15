using BCP.META.Presentation.Entities;
using RestSharp;

namespace BCP.META.Presentation.Services
{
    public class AsesorComercialService 
    {

        private readonly RestClient _restClient;

        public AsesorComercialService()
        {
            _restClient = new RestClient("http://localhost:5266");
        }

        public async Task<List<AsesorComercial>> ObtenerAsesoresComercialesAsync(int agenciaId)
        {
            var request = new RestRequest($"/AsesorComercial?agenciaId={agenciaId}", Method.Get);

            var response = await _restClient.ExecuteAsync<List<AsesorComercial>>(request);
          
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return new List<AsesorComercial>();
            }
        }
    }
}
