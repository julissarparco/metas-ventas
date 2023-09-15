using System.Text.Json.Serialization;

namespace BCP.META.Application.DTO
{
    public class ProductoComercialResponse
    {
        [JsonPropertyName("productoId")]
        public int ProductoID { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("puntosPorVenta")]
        public string PuntosPorVenta { get; set; }
        [JsonPropertyName("tipoPuntos")]
        public string TipoPuntos { get; set; }
    }
}
