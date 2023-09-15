using System.Text.Json.Serialization;

namespace BCP.META.Application.DTO
{
    public class AgenciaResponse
    {
        [JsonPropertyName("id")]
        public int AgenciaId { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }
}
