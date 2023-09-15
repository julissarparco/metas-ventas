using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BCP.META.Application.DTO
{
    public class VentaCreateRequest
    {
        [JsonPropertyName("periodoMes")]
        [Required]
        public string PeriodoMes { get; set; }

        [JsonPropertyName("periodoAnio")]
        [Required]
        public int PeriodoAnio { get; set; }

        [JsonPropertyName("asesorComercialId")]
        [Required]
        public int AsesorId { get; set; }

        [JsonPropertyName("clienteId")]
        [Required]
        public int ClienteId { get; set; }

        [JsonPropertyName("productoComercialId")]
        [Required]
        public int ProductoId { get; set; }

        [JsonPropertyName("fechaVenta")]
        [Required]
        public string FechaVenta { get; set; }

        [JsonPropertyName("montoPrestamo")]
        [Required]
        public decimal MontoPrestamo { get; set; }

        [JsonPropertyName("montoDesembolsado")]
        [Required]
        public decimal MontoDesembolsado { get; set; }

    }
}
