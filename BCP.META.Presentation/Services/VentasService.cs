using BCP.META.Presentation.Entities;
using RestSharp;

namespace BCP.META.Presentation.Services
{
    public class VentasService
    {
        private readonly RestClient _restClient;

        public VentasService(IConfiguration configuration)
        {
            string baseUrl = configuration["ServiceBaseUrl"];

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("La URL base del servicio no está configurada.");
            }

            _restClient = new RestClient(baseUrl);
        }

        public async Task<List<Venta>> ObtenerVentas()
        {
            var request = new RestRequest($"/api/Ventas", Method.Get);

            var response = await _restClient.ExecuteAsync<ApiResponse<Venta>>(request);

            if (response.IsSuccessful)
            {
                var ventas = response.Data?.entityList;
                return ventas ?? new List<Venta>();
            }
            else
            {
                return new List<Venta>();
            }
        }
    }
}
