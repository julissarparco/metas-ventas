using System.Text.Json.Serialization;

namespace BCP.META.Application.DTO
{
    public class ClienteReponse
    {
        [JsonPropertyName("id")]
        public int ClienteId { get; set; }
        [JsonPropertyName("tipoDocumento")]
        public string TipoDocumento { get; set; }
        [JsonPropertyName("numeroDocumento")]
        public string NumeroDocumento { get; set; }
        [JsonPropertyName("apellidos")]
        public string Apellidos { get; set; }
        [JsonPropertyName("nombres")]
        public string Nombres { get; set; }
        [JsonPropertyName("numeroCelular")]
        public string NumeroCelular { get; set; }
    }
}
